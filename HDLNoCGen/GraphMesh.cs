using HDLNoCGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDL_NoC_CodeGen
{
    class GraphMesh : Graph, IRectangleLike, IWestFirst
    {
        public override GraphType id()
        {
            return GraphType.Mesh;
        }

        private List<List<int>> ways_routing_XY; //пути по XY алгоритму
        private List<List<int>> ways_routing_westFirst; // пути по west-first алгоритму маршрутизации

        private double efficiencyXY;
        private double efficiencyWestFirst;

        private void calculateEfficiencyXY ()
        {
            double deikstra_count = 0;
            double XY_count = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_count += this.min_ways_routing_deikstra[i].Count - 1;
                XY_count += this.ways_routing_XY[i].Count - 1;
            }

            this.efficiencyXY = Math.Round(deikstra_count / XY_count, 3);
        }

        private void calculateEfficiencyWestFirst()
        {
            double deikstra_count = 0;
            double westFirst_count = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_count += this.min_ways_routing_deikstra[i].Count - 1;
                westFirst_count += this.ways_routing_XY[i].Count - 1;
            }

            this.efficiencyWestFirst = Math.Round(deikstra_count / westFirst_count, 3);
        }

        public List<List<int>> Get_ways_routing_XY()
        {
            return this.ways_routing_XY;
        }

        public List<List<int>> Get_ways_routing_westFirst()
        {
            return this.ways_routing_westFirst;
        }

        public double getXY_Efficiency()
        {
            calculateEfficiencyXY();
            return this.efficiencyXY;
        }

        public double getWestFirstEfficiency()
        {
            calculateEfficiencyWestFirst();
            return this.efficiencyWestFirst;
        }

        public GraphMesh() : base()
        {
            this.ways_routing_XY = null;
            this.ways_routing_westFirst = null;
        }

        public GraphMesh(string paraneters)
        {
            this.node_count = 1;

            string[] buffer = paraneters.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] buffer_topology = buffer[0].Trim().Split(new string[] { "М", "м", "M", "m", ";", ":", ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);

            generators = new List<int>(buffer_topology.Length);
            int node_count = 1;
            foreach (var item in buffer_topology)
            {
                int value = Convert.ToInt32(item);
                generators.Add(value);
                node_count *= value;
            }
            generators.Sort();

            diameter = generators[0];

            string[] buffer_parameters;
            if (buffer.Length > 1)
            {
                buffer_parameters = buffer[1].Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                buffer_parameters[0].Trim();
                string[] sub_buffer_parameters = buffer_parameters[0].Trim().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                //this.p = Convert.ToInt32(sub_buffer_parameters[1]);
                this.node_count = Convert.ToInt32(buffer_parameters[1]) * Convert.ToInt32(buffer_parameters[2]);
            }

            //string[] buffer = paraneters.Split(new string[] { "С(", "C(", ";", ":",  ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            //this.node_count = Convert.ToInt32(buffer[0]);
            //this.p = Convert.ToInt32(param_2);

            this.is_created = true;
        }

        public List<List<int>> Generate_XY_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;

            this.ways_routing_XY = new List<List<int>>();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                for (int i = 0; i < this.node_count; i++)
                {
                    for (int j = 0; j < this.node_count; j++)
                    {
                        iterations_count = 0;
                        start_node = i;
                        end_node = j;
                        List<int> route = new List<int>() { start_node + Settings.Get_node_naming_start_index() };
                        while (start_node != end_node)
                        {
                            iterations_count++;

                            start_node = XY_routing(start_node, end_node, generators, node_count);
                            route.Add(start_node + Settings.Get_node_naming_start_index());

                            if (iterations_count > Settings.Get_error_iterations_count())
                            {
                                throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма Simple");
                            }
                        }
                        this.ways_routing_XY.Add(route);
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.ways_routing_XY;
        } // проверка на ошибки добавлена

        private int XY_routing(int start_node, int end_node, List<int> generators, int node_count)
        {
            if ((end_node - start_node) == 0)
            {
                return start_node;
            }

            int sg1 = start_node % generators[1];
            int sg0 = start_node % generators[0];
            int eg1 = end_node % generators[1];
            int eg0 = end_node % generators[0];
            if (sg1 < eg1)
            {
                start_node++;
            }
            else if (sg1 > eg1)
            {
                start_node--;
            }
            else if ((start_node % node_count) < (end_node % node_count))
            {
                start_node += generators[1];
            }
            else if (sg0 > eg0 || ((start_node % node_count) > (end_node % node_count)))
            {
                start_node -= generators[1];
            }
            //if (start_node == 0) 
            //start_node = this.node_count;
            return start_node;
        }

        public List<List<int>> Generate_westFirst_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;

            this.ways_routing_westFirst = new List<List<int>>();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                for (int i = 0; i < this.node_count; i++)
                {
                    for (int j = 0; j < this.node_count; j++)
                    {
                        iterations_count = 0;
                        start_node = i;
                        end_node = j;
                        List<int> route = new List<int>() { start_node + Settings.Get_node_naming_start_index() };
                        while (start_node != end_node)
                        {
                            iterations_count++;

                            start_node = westFirst_routing(start_node, end_node, generators);
                            route.Add(start_node + Settings.Get_node_naming_start_index());

                            if (iterations_count > Settings.Get_error_iterations_count())
                            {
                                throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма Simple");
                            }
                        }
                        this.ways_routing_westFirst.Add(route);
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.ways_routing_westFirst;
        } // проверка на ошибки добавлена

        private int westFirst_routing(int start_node, int end_node, List<int> generators)
        {
            int S = Math.Abs(end_node - start_node);
            if (S == 0)
            {
                return start_node;
            }
            else if (start_node % generators[1] == end_node % generators[1])
            {
                if (start_node < end_node)
                {
                    start_node += generators[1];
                }
                else
                {
                    start_node -= generators[1];
                }
            }
            else if (start_node / generators[1] == end_node / generators[1])
            {
                if (start_node < end_node)
                {
                    start_node++;
                }
                else
                {
                    start_node--;
                }
            }
            else if (start_node % generators[1] > end_node % generators[1])
            {
                start_node--;
            }
            else if (start_node / generators[1] > end_node / generators[1])
            {
                start_node -= generators[1];
            }
            else if (start_node / generators[1] < end_node / generators[1])
            {
                start_node += generators[1];
            }
            return (start_node);
        }

        protected override void Create_matr_smej()
        {
            this.matr_smej = new int[this.node_count, this.node_count];
            int n = generators[0];
            int m = generators[1];

            for (int i = 0; i < this.node_count; i++)
            {
                if (i % m != 0)
                {
                    matr_smej[i, i - 1] = 1;
                    matr_smej[i - 1, i] = 1;
                }
                if (i / m != 0)
                {
                    matr_smej[i, i - m] = 1;
                    matr_smej[i - m, i] = 1;
                }
            }
        }

        public override void createTopEntity(string project_name, string routing_algorithm, string project_path)
        {
            string top_entity_name = $"top_level_{project_name}";
            string router_name = $"router_{project_name}";

            int coordinates_size = 0;
            int counter = 1;
            while (counter < generators.Max())
            {
                coordinates_size++;
                counter *= 2;
            }
            int data_packet_size = 1 + (coordinates_size) * 2 + 8;

            FileStream fs;
            StreamWriter sw;

            Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");
            fs = new FileStream($"{project_path}\\{top_entity_name}.v", FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            #region Verilog code
            sw.WriteLine($"`define N {data_packet_size}");

            sw.WriteLine($"module {top_entity_name}");
            sw.WriteLine($"(");
            sw.WriteLine($"");
            sw.WriteLine($"    clk,");

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    sw.WriteLine($"");
                    sw.WriteLine($"    core_{i}{j}_out,");
                    sw.WriteLine($"    core_{i}{j}_in,");
                }
            }
            sw.WriteLine($");");
            sw.WriteLine($"");

            sw.WriteLine($"    input clk;");
            sw.WriteLine($"");

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    sw.WriteLine($"");
                    sw.WriteLine($"    input [`N - 1:0] core_{i}{j}_out;");
                    sw.WriteLine($"    output wire [`N - 1:0] core_{i}{j}_in;");
                }
            }
            sw.WriteLine($"");

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    sw.WriteLine($"");
                    sw.WriteLine($"    wire [`N - 1:0] core_{i}{j}_north;");
                    sw.WriteLine($"    wire [`N - 1:0] core_{i}{j}_east;");
                    sw.WriteLine($"    wire [`N - 1:0] core_{i}{j}_south;");
                    sw.WriteLine($"    wire [`N - 1:0] core_{i}{j}_west;");
                }
            }
            sw.WriteLine($"");


            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    string router_description = $"{router_name} r{i}{j} (.clk(clk), .router_Y({i}), .router_X({j}), ";
                    router_description += $".input_core(core_{i}{j}_out), ";

                    if (i > 0)
                    {
                        router_description += $".input_north(core_{i - 1}{j}_south), ";
                    }
                    if (j < generators[1] - 1)
                    {
                        router_description += $".input_east(core_{i}{j + 1}_west), ";
                    }
                    if (i < generators[0] - 1)
                    {
                        router_description += $".input_south(core_{i + 1}{j}_north), ";
                    }
                    if (j > 0)
                    {
                        router_description += $".input_west(core_{i}{j - 1}_east), ";
                    }

                    router_description += $".output_core(core_{i}{j}_in), ";
                    router_description += $".output_north(core_{i}{j}_north), ";
                    router_description += $".output_east(core_{i}{j}_east), ";
                    router_description += $".output_south(core_{i}{j}_south), ";
                    router_description += $".output_west(core_{i}{j}_west));";

                    sw.WriteLine($"");
                    sw.WriteLine($"    {router_description}");
                }
            }
            sw.WriteLine($"");

            sw.WriteLine($"");
            sw.WriteLine($"endmodule");

            #endregion

            sw.Close();
            fs.Close();
        }

        public void createRouterXY(string project_name, string project_path)
        {
            string router_name = $"router_{project_name}";

            int coordinates_size = 0;
            int counter = 1;
            while (counter < generators.Max())
            {
                coordinates_size++;
                counter *= 2;
            }
            int data_packet_size = 1 + (coordinates_size) * 2 + 8;

            FileStream fs;
            StreamWriter sw;

            fs = new FileStream($"{project_path}\\{router_name}.v", FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            #region Verilog code

            sw.WriteLine($"`define N {data_packet_size}");
            sw.WriteLine($"`define M {coordinates_size}");

            sw.WriteLine($"module {router_name}");
            sw.WriteLine($"(");
            sw.WriteLine($"");
            sw.WriteLine($"    clk,");
            sw.WriteLine($"");
            sw.WriteLine($"    router_X,");
            sw.WriteLine($"    router_Y,");
            sw.WriteLine($"");
            sw.WriteLine($"    input_core,");
            sw.WriteLine($"");
            sw.WriteLine($"    input_north,");
            sw.WriteLine($"    input_east,");
            sw.WriteLine($"    input_south,");
            sw.WriteLine($"    input_west,");
            sw.WriteLine($"");
            sw.WriteLine($"    output_core,");
            sw.WriteLine($"");
            sw.WriteLine($"    output_north,");
            sw.WriteLine($"    output_east,");
            sw.WriteLine($"    output_south,");
            sw.WriteLine($"    output_west");
            sw.WriteLine($");");
            sw.WriteLine($"");

            sw.WriteLine($"    input clk;");
            sw.WriteLine($"");
            sw.WriteLine($"    input unsigned [`M - 1:0] router_X;");
            sw.WriteLine($"    input unsigned [`M - 1:0] router_Y;");
            sw.WriteLine($"");
            sw.WriteLine($"    input [`N - 1:0] input_core;");
            sw.WriteLine($"");
            sw.WriteLine($"    input [`N - 1:0] input_north;");
            sw.WriteLine($"    input [`N - 1:0] input_east;");
            sw.WriteLine($"    input [`N - 1:0] input_south;");
            sw.WriteLine($"    input [`N - 1:0] input_west;");
            sw.WriteLine($"");
            sw.WriteLine($"    output reg [`N - 1:0] output_core = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"");
            sw.WriteLine($"    output reg [`N - 1:0] output_north = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"    output reg [`N - 1:0] output_east = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"    output reg [`N - 1:0] output_south = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"    output reg [`N - 1:0] output_west = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"");
            sw.WriteLine($"    reg in_flag = 1'b0;");
            sw.WriteLine($"    reg [`N - 1:0] data = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"    reg [`M - 1:0] destination_X;");
            sw.WriteLine($"    reg [`M - 1:0] destination_Y;");
            sw.WriteLine($"");

            sw.WriteLine($"");
            sw.WriteLine($"    always @(posedge clk)");
            sw.WriteLine($"    begin");
            sw.WriteLine($"");
            sw.WriteLine($"        if (input_core[`N - 1] == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = input_core;");
            sw.WriteLine($"            in_flag = 1'b1;");
            sw.WriteLine($"        end");
            sw.WriteLine($"        else if (input_north[`N - 1] == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = input_north;");
            sw.WriteLine($"            in_flag = 1'b1;");
            sw.WriteLine($"        end");
            sw.WriteLine($"        else if (input_east[`N - 1] == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = input_east;");
            sw.WriteLine($"            in_flag = 1'b1;");
            sw.WriteLine($"        end");
            sw.WriteLine($"        else if (input_south[`N - 1] == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = input_south;");
            sw.WriteLine($"            in_flag = 1'b1;");
            sw.WriteLine($"        end");
            sw.WriteLine($"        else if (input_west[`N - 1] == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = input_west;");
            sw.WriteLine($"            in_flag = 1'b1;");
            sw.WriteLine($"        end");
            sw.WriteLine($"        else");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            data = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};");
            sw.WriteLine($"            in_flag = 1'b0;");
            sw.WriteLine($"        end");
            sw.WriteLine($"");
            sw.WriteLine($"");
            sw.WriteLine($"        if (in_flag == 1'b1)");
            sw.WriteLine($"        begin");
            sw.WriteLine($"            destination_Y = data[`N - 2:`N - `M - 1];");
            sw.WriteLine($"            destination_X = data[`N - `M - 2:`N - 2 * `M - 1];");
            sw.WriteLine($"");
            sw.WriteLine($"            if (router_X < destination_X)");
            sw.WriteLine($"            begin");
            sw.WriteLine($"                output_east = data;");
            sw.WriteLine($"            end");
            sw.WriteLine($"            else if (router_X > destination_X)");
            sw.WriteLine($"            begin");
            sw.WriteLine($"                output_west = data;");
            sw.WriteLine($"            end");
            sw.WriteLine($"            else if (router_Y > destination_Y)");
            sw.WriteLine($"            begin");
            sw.WriteLine($"                output_north = data;");
            sw.WriteLine($"            end");
            sw.WriteLine($"            else if (router_Y < destination_Y)");
            sw.WriteLine($"            begin");
            sw.WriteLine($"                output_south = data;");
            sw.WriteLine($"            end");
            sw.WriteLine($"            else");
            sw.WriteLine($"            begin");
            sw.WriteLine($"                output_core = data;");
            sw.WriteLine($"            end");
            sw.WriteLine($"        end");
            sw.WriteLine($"    end");
            sw.WriteLine($"");
            sw.WriteLine($"endmodule");

            #endregion

            sw.Close();
            fs.Close();
        }
    }
}

