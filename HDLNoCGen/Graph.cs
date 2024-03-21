using HDLNoCGen.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HDL_NoC_CodeGen.Graph;

namespace HDL_NoC_CodeGen
{

    public abstract class Graph
    {
        public enum GraphType
        {
            Circulant, Mesh, Torus
        };

        protected string error_message;
        protected int diameter;
        protected int[,] matr_smej;

        protected double average_distance;

        protected List<List<int>> min_ways_routing_deikstra; //минимальные пути по алгоритму Дейкстры
        protected double efficiency_deikstra = 1;

        public abstract GraphType id();

        public Graph()
        {
            this.error_message = "";

            this.is_created = false;
            this.generators = null;
            this.node_count = 0;
        }

        public int[,] Get_matr_smej()
        {
            return this.matr_smej;
        }

        public int Get_diameter()
        {
            return this.diameter;
        }
        
        public double Get_efficiency_deikstra()
        {
            return this.efficiency_deikstra;
        }

        public double Calculate_efficiency_deikstra()
        {
            this.efficiency_deikstra = 1.0;

            return this.efficiency_deikstra;
        }

        protected abstract void Create_matr_smej();

        public List<List<int>> Generate_deikstra_routing()
        {

            Create_matr_smej();

            int[] dInit = new int[node_count]; // минимальное расстояние
            int[] vInit = new int[node_count]; // посещенные вершины
            Parallel.For(0, node_count, i =>
            {
                dInit[i] = 10000;
                vInit[i] = 1;
            });

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 10;
            min_ways_routing_deikstra = new List<List<int>>();
            Parallel.For(0, node_count, options, m =>
            {
                int minindex;
                int min;
                int temp;

                int[] d = (int[])dInit.Clone();
                int[] v = (int[])vInit.Clone();
                d[m] = 0;

                // Шаг алгоритма
                do
                {
                    minindex = 10000;
                    min = 10000;
                    for (int i = 0; i < node_count; i++)
                    { // Если вершину ещё не обошли и вес меньше min
                        if (v[i] == 1 && d[i] < min)
                        { // Переприсваиваем значения
                            min = d[i];
                            minindex = i;
                        }
                    }

                    // Добавляем найденный минимальный вес к текущему весу вершины
                    // и сравниваем с текущим минимальным весом вершины
                    if (minindex != 10000)
                    {
                        for (int i = 0; i < node_count; i++)
                        {
                            if (matr_smej[minindex, i] > 0)
                            {
                                temp = min + matr_smej[minindex, i];
                                if (temp < d[i])
                                {
                                    d[i] = temp;
                                }
                            }
                        }
                        v[minindex] = 0;
                    }
                } while (minindex < 10000);
                //конец алгоритма Дейкстра


                //восстанавливаем пути
                List<int[]> ways = new List<int[]>();
                for (int i = 0; i < node_count; i++)
                {
                    int[] ver = new int[node_count];
                    for (int j = 0; j < node_count; j++)
                    {
                        ver[j] = -1;
                    }
                    int end = i;
                    ver[0] = i;
                    int k = 1;
                    int weight = d[end];

                    while (end != m)//Пока не окажимся в начальной вершине
                    {
                        for (int j = 0; j < node_count; j++)
                        {
                            if (matr_smej[end, j] > 0)//Если вершины смежны
                            {
                                temp = weight - matr_smej[end, j];//Предсказываем вес вершины
                                if (temp == d[j])//Если вес вершины совпал с предсказанным
                                {
                                    weight = temp;
                                    end = j;//переходим в вершину
                                    ver[k] = j;//записваем переход
                                    k++;
                                    break;
                                }
                            }
                        }
                    }
                    ways.Add(ver);//Записываем путь
                }

                Parallel.For(0, node_count, i =>
                {
                    List<int> buff = new List<int>();
                    for (int j = node_count - 1; j > -1; j--)
                    {
                        if (ways[i][j] != -1)//Если переход не пустой
                        {
                            buff.Add(ways[i][j]);
                        }
                    }
                    lock (min_ways_routing_deikstra)
                    {
                        min_ways_routing_deikstra.Add(buff);
                    }
                });
            });

            return this.min_ways_routing_deikstra;
        }

        protected bool is_created;
        protected int node_count;
        protected List<int> generators;

        public bool Is_created()
        {
            return this.is_created;
        }

        public string Get_error_message()
        {
            return this.error_message;
        }

        public int Get_node_count()
        {
            return this.node_count;
        }

        public List<int> Get_generators()
        {
            return this.generators;
        }
        public Graph CreateGraphInstance(GraphType graphType, string buffer)
        {
            switch (graphType)
            {
                case GraphType.Circulant:
                    return new GraphCirculant(buffer);
                case GraphType.Mesh:
                    return new GraphMesh(buffer);
                case GraphType.Torus:
                    return new GraphTorus(buffer);
                default:
                    throw new Exception("Unsupported graph type");
            }
        }

        public Graph CreateGraphFromBuffer(string buffer)
        {
            GraphType graphType;

            // Определение типа графа на основе ввода
            switch (buffer.Split(' ')[0])
            {
                case "c":
                case "C":
                case "с":
                case "С":
                    graphType = GraphType.Circulant;
                    break;
                case "m":
                case "M":
                case "м":
                case "М":
                    graphType = GraphType.Mesh;
                    break;
                case "t":
                case "T":
                    graphType = GraphType.Torus;
                    break;
                default:
                    throw new Exception("Incorrect topology");
            }

            return CreateGraphInstance(graphType, buffer);
        }

        public abstract void createTopEntity(string project_name, string routing_algorithm, string project_path);
    }

}
