using HDLNoCGen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HDL_NoC_CodeGen
{
    class GraphCirculant : Graph, IRoundLike
    {
        public override GraphType id()
        {
            return GraphType.Circulant;
        }

        private int p; // для алгоритма парной маршрутизации
        private List<List<int>> min_ways_routing_simple; // минимальные пути по простому алгоритму маршрутизации
        private List<List<int>> min_ways_routing_ROU; // минимальные пути по адаптивному алгоритму маршрутизации
        private List<List<int>> min_ways_routing_APM; // минимальные пути по алгоритму парной маршрутизации
        private List<List<int>> min_ways_routing_APO;
        private List<List<int>> min_ways_routing_AAO;
        private List<List<int>> min_ways_routing_AAO_orig; // маинимальные пути по алгоритму относительной маршрутизации
        private List<List<int>> min_ways_routing_gl;// минимальные пути по алгоритму парного обмена

        private double efficiency_simple;
        private double efficiency_ROU;
        private double efficiency_APM;
        private double efficiency_APO;
        //private double efficiency_AAO;
        //private double efficiency_AAO_orig;

        public double Get_average_distance()
        {
            return this.average_distance;
        }

        public int Get_p()
        {
            return this.p;
        }

        public List<List<int>> Get_min_ways_routing_deikstra()
        {
            return this.min_ways_routing_deikstra;
        }

        public List<List<int>> Get_min_ways_routing_simple()
        {
            return this.min_ways_routing_simple;
        }

        public List<List<int>> Get_min_ways_routing_ROU()
        {
            return this.min_ways_routing_ROU;
        }

        public List<List<int>> Get_min_ways_routing_APM()
        {
            return this.min_ways_routing_APM;
        }

        public List<List<int>> Get_min_ways_routing_APO()
        {
            return this.min_ways_routing_APO;
        }

        public double Get_efficiency_simple()
        {
            return this.efficiency_simple;
        }

        public double Get_efficiency_ROU()
        {
            return this.efficiency_ROU;
        }

        public double Get_efficiency_APM()
        {
            return this.efficiency_APM;
        }

        public double Get_efficiency_APO()
        {
            return this.efficiency_APO;
        }

        public GraphCirculant() : base()
        {
            this.diameter = 0;
            this.p = 0;
            this.matr_smej = null;
            this.min_ways_routing_deikstra = null;
            this.min_ways_routing_simple = null;
            this.min_ways_routing_ROU = null;
            this.min_ways_routing_APM = null;
            this.min_ways_routing_APO = null;

            this.min_ways_routing_AAO = null;
        }

        public GraphCirculant(string parameters)
        {

            string[] buffer = parameters.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] buffer_topology = buffer[0].Trim().Split(new string[] { "С", "c", "C" , "с" , ";", ":", ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            this.node_count = Convert.ToInt32(buffer_topology[0]);
            generators = new List<int>();
            for (int i = 1; i < buffer_topology.Length; i++)
            {
                generators.Add(Convert.ToInt32(buffer_topology[i]));
            }
            generators.Sort();

            string[] buffer_parameters;
            if (buffer.Length > 1)
            {
                buffer_parameters = buffer[1].Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                buffer_parameters[0].Trim();
                string[] sub_buffer_parameters = buffer_parameters[0].Trim().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                this.p = Convert.ToInt32(sub_buffer_parameters[1]);
            }

            //string[] buffer = parameters.Split(new string[] { "С(", "C(", ";", ":",  ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            //this.node_count = Convert.ToInt32(buffer[0]);
            //this.p = Convert.ToInt32(param_2);



            this.is_created = true;
        }

        protected override void Create_matr_smej()
        {
            this.matr_smej = new int[this.node_count, this.node_count];

            Parallel.For(0, this.generators.Count, i =>
            {
                for (int j = 1; j < (this.node_count + 1); j++)
                {
                    int k = this.generators[i] + j;
                    if (k > this.node_count)
                    {
                        k = k - this.node_count;
                    }
                    lock (this.matr_smej)
                    {
                        this.matr_smej[j - 1, k - 1] = 1;
                        this.matr_smej[k - 1, j - 1] = 1;
                    }
                }
            });

        }

        public int Calculate_diameter()
        {
            this.diameter = 0;
            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                if (this.min_ways_routing_deikstra[i].Count > this.diameter)
                {
                    this.diameter = this.min_ways_routing_deikstra[i].Count;
                }
            }
            --this.diameter;

            return this.diameter;
        }

        public double Calculate_Average_distance()
        {
            this.average_distance = 0.0;
            int hops = 0;
            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                hops = hops + this.min_ways_routing_deikstra[i].Count - 1;
            }
            this.average_distance = Math.Round((double)hops / (double)this.min_ways_routing_deikstra.Count, 6);


            return this.average_distance;
        }

        public List<List<int>> Generate_Simple_routing()
        {
            this.min_ways_routing_simple = new List<List<int>>();

            for (int m = 0; m < node_count; m++)
            {
                int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

                int start_node;
                int end_node;

                try
                {
                    if (!this.is_created)
                    {
                        throw new Exception("Описание топологии не было задано или задано не полностью");
                    }

                    Parallel.For(0, node_count, i =>
                    {
                        iterations_count = 0;

                        start_node = m + 1;
                        end_node = i + 1;
                        List<int> route = new List<int>();
                        route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                        while (end_node != start_node)
                        {
                            iterations_count++;

                            start_node = Simple_routing(start_node, end_node);
                            route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                            if (iterations_count > Settings.Get_error_iterations_count())
                            {
                                throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма Simple");
                            }
                        }
                        
                        lock (this)
                        {
                            this.min_ways_routing_simple.Add(route);
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.error_message = ex.Message;
                    return null;
                }
            }

            return this.min_ways_routing_simple;
        } // проверка на ошибки добавлена

        private int Simple_routing(int start_node, int end_node)
        {
            int S = end_node - start_node;
            if (S == 0)
            {
                return (start_node);
            }
            if (S < 0)
            {
                S = S + this.node_count;
            }
            if (S <= (this.node_count / 2))
            {
                int i;
                for(i = this.generators.Count()-1; i > 0; i--)
                {
                    if (S >= this.generators[i])
                    {
                        start_node = (this.generators[i] + start_node) % this.node_count;
                        i = -1;
                    }
                }
                if(i == 0)
                    start_node = (this.generators[0] + start_node) % this.node_count;
            }
            else
            {
                S = this.node_count - S;

                int i;
                for (i = this.generators.Count()-1; i > 0; i--)
                {
                    if (S >= this.generators[i])
                    {
                        start_node = (this.generators[i] + start_node) % this.node_count;
                        i = -1;
                    }
                }
                if (i == 0)
                    start_node = (this.generators[0] + start_node) % this.node_count;
            }
            if (start_node == 0) start_node = this.node_count;
            return (start_node);
        }

        public List<List<int>> Generate_GL_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;
            List<int> route;

            this.min_ways_routing_gl = new List<List<int>>();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                Parallel.For(0, this.node_count, i =>
                {
                    iterations_count = 0;

                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                    while (end_node != start_node)
                    {
                        iterations_count++;
                        start_node = GL_routing(this.node_count, this.generators, start_node, end_node);
                        route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                        if (iterations_count > Settings.Get_error_iterations_count())
                        {
                            throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма GL");
                        }
                    }
                    lock (this) 
                    {
                        this.min_ways_routing_gl.Add(route);
                    }
                });
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_gl;
        }

        private int GL_routing(int nodesCount, List<int> generatrixes, int startNode, int endNode)
        {
            if (nodesCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nodesCount), nodesCount, "Должно быть больше 0.");
            }

            // Ищем точное расстояние и направление (по часовой или против часовой стрелки)
            int halfLength = nodesCount / 2;
            int length = endNode - startNode;

            if (length == 0)
            {
                return endNode;
            }

            // Идем по часовой, если разница индексов конечного узла и предыдущего не меньше 0, иначе в противоположную.
            bool isClockwise = length > 0;

            // флаг игнорирования условий. Обозначает, что была найдена образующая, дальнейший поиск не требуется
            bool isQuit = false;
            int value = -1;

            // Если текущее расстояние по выбранному расстоянию будет больше половины пути, идем в противоположную сторону от выбранной
            if (Math.Abs(length) > halfLength)
            {
                isClockwise = !isClockwise;

                if (endNode > startNode)
                {
                    length = nodesCount - endNode + startNode;
                }
                else
                {
                    length = nodesCount - startNode + endNode;
                }
            }
            else
            {
                // В противном случае, оставляем модуль "расстояния"
                // это можно вынести перед if, избегая вызова для Math.Abs(length) дважды.
                length = Math.Abs(length);
            }

            // Расстояние и направление найдено

            var g1 = generatrixes[0];
            var g2 = generatrixes[1];

            if (length >= g2)
            {
                var intG2 = length / g2;
                var modG2 = length % g2;

                // Если нет остатка от большей образующей, идем только по ней.
                if (modG2 == 0)
                {
                    value = isClockwise ? startNode + g2 : startNode - g2;
                    isQuit = true;
                }

                if (!isQuit)
                {
                    // Когда есть остаток, но есть возможность не делать доп. шаги, засчет выбора по меньшей образующей. В конечном результате, останется длина, кратная большей образующей,
                    // либо меньшей образующей
                    if (modG2 + intG2 >= g1)
                    {
                        isQuit = true;
                        value = isClockwise ? startNode + g1 : startNode - g1;
                    }

                    // Находим расстояние, если бы поиск ввелся по одной из образующих, с учетом доп. шага для сокращения единичных шагов и единичные шаги
                    if (!isQuit)
                    {
                        // рассчет по меньшей образующей
                        var lengthG1 = length / g1;
                        // оставшееся расстояние после движения
                        var cl1 = length - lengthG1 * g1;

                        // требование для дополнительного шага
                        // cl1 > Math.Abs(cl1 - g1) -> 2 * cl1 > g1

                        if (cl1 > Math.Abs(cl1 - g1))
                        {
                            // если потребовалось
                            lengthG1++;
                            // оставшийся путь с учетом доп.шага * 2 (кол-во единичных шагов)
                            // Math.Abs(cl1 - g1) -> g1 - cl1
                            lengthG1 += Math.Abs(cl1 - g1) * 2;
                        }
                        else
                        {
                            // не потребовалось, то оставшееся расстояние * 2 (оставшееся расстояние - это кол-во "единичных" шагов
                            lengthG1 += cl1 * 2;
                        }

                        // рассчет по большей образующей. Поймете.
                        var lengthG2 = length / g2;
                        cl1 = length - lengthG2 * g2;

                        // Мы всегда делаем по меньшей образующей доп. шаг, т.к. в любом случае у нас "отдалится" от конечного шага.
                        // P.S. возможно, есть ситуация, когда нужно делать по g2. Но это еще более усложнит алгоритм, и требуется только для альтернативных путей.
                        if (cl1 > Math.Abs(cl1 - g1))
                        {
                            lengthG2++;
                            lengthG2 += Math.Abs(cl1 - g1) * 2;
                        }
                        else
                        {
                            lengthG2 += cl1 * 2;
                        }

                        // выбор следующей образующей
                        var nextGeneratrix = lengthG1 < lengthG2 ? g1 : g2;
                        value = isClockwise ? startNode + nextGeneratrix : startNode - nextGeneratrix;
                        isQuit = true;
                    }
                }
            }

            // Выбрана меньшая образующая
            if (length == g1)
            {
                value = endNode;
                isQuit = true;
            }

            if (!isQuit)
            {
                // Если требуется сделать доп. шаг по меньшей образующей для сокращения кол-ва единичных шагов.
                // Можно это условие заменить на 2 * length > g1 - без всяких + 1
                if (length > Math.Abs(length - g1))
                {
                    value = isClockwise ? startNode + g1 : startNode - g1;
                }
                else
                {
                    // Идем в противоположную сторону, т.к. это будет первый этап "единичного" шага.
                    value = isClockwise ? startNode - g1 : startNode + g1;
                }
            }

            // Индекс найден, "нормализируем" его.
            if (value > 0)
            {
                // Не требует нормализации.
                if (value <= nodesCount)
                {
                    return value;
                }

                // Остаток будет следующим индексом узла, где условный пакет будет находиться
                return value % nodesCount;
            }

            // Индекс "находится" в обратной стороне, для крупных отрицательных индексов такая схема работает.
            // Можно заменить на nodes - value (это так просто) при оптимальных графах
            return nodesCount - Math.Abs(value) % nodesCount;
        }

        public List<List<int>> Generate_ROU_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;
            List<int> route;

            this.min_ways_routing_ROU = new List<List<int>>();

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

                        start_node = i + 1;
                        end_node = j + 1;
                        route = new List<int>();
                        route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                        while (end_node != start_node)
                        {
                            iterations_count++;
                            start_node = ROU_routing(start_node, end_node, this.node_count, this.generators[0], this.generators[1]);
                            route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                            if (iterations_count > Settings.Get_error_iterations_count())
                            {
                                throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма ROU");
                            }
                        }
                        this.min_ways_routing_ROU.Add(route);
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_ROU;
        } // проверка на ошибки добавлена

        private int ROU_routing(int start_node, int end_node, int node_count, int s1 = 1, int s2 = 2)
        {
            //чтобы начальный всегда был меньше конечного  
            //117 1 43  - надо устранение 2 циклов по большой образующей
            //500 1 276 - надо устранение 2+ циклов по большой образующей
            if (start_node > end_node)
            {
                start_node = start_node - Step_cicles(end_node, start_node, node_count, s1, s2);
                //start_node = start_node - Step(end_node, start_node, N, s1, s2);
            }
            else
            {
                start_node = start_node + Step_cicles(start_node, end_node, node_count, s1, s2);
                //start_node = start_node + Step(start_node, end_node, N, s1, s2);
            }

            // ! работает тоже 
            //  чтобы начальный всегда был меньше конечного
            //if(start_node > end_node)
            //{
            //    end_node = end_node + N;
            //}
            //start_node = start_node + Step(start_node, end_node, N, s1, s2);

            // нормализация 
            if (start_node > node_count)
            {
                start_node = start_node - node_count;
            }
            else if (start_node <= 0)
            {
                start_node = start_node + node_count;
            }
            return start_node;
        }

        /*
         * Поиск шага, когда 2 образующие, s1=1. Устраняются циклы.
         */
        private int Step_cicles(int start_node, int end_node, int node_count, int s1, int s2)
        {
            int best_way_R = 0, step_R = 0, best_way_L = 0, step_L = 0;
            int s = end_node - start_node;

            // лучший путь вправо и шаг
            int R1 = s / s2 + s % s2;
            int R2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_R = R1;
                step_R = s2;
            }
            else
            {
                if (R1 < R2)
                {
                    best_way_R = R1;
                    step_R = s1;
                }
                else
                {
                    best_way_R = R2;
                    step_R = s2;
                }
            }

            //1 цикл
            int R5 = (s + node_count) / s2 + (s + node_count) % s2;
            int R6 = (s + node_count) / s2 - (s + node_count) % s2 + s2 + 1;
            if (R5 < best_way_R)
            {
                best_way_R = R5;
                step_R = s2;
            }
            if (R6 < best_way_R)
            {
                best_way_R = R6;
                step_R = s2;
            }

            //2 цикл
            int R9 = (s + node_count + node_count) / s2 + (s + node_count + node_count) % s2;
            int R10 = (s + node_count + node_count) / s2 - (s + node_count + node_count) % s2 + s2 + 1;
            if (R9 < best_way_R)
            {
                best_way_R = R9;
                step_R = s2;
            }
            if (R10 < best_way_R)
            {
                best_way_R = R10;
                step_R = s2;
            }
            //3 цикл
            //..

            // лучший путь влево и шаг
            s = start_node - end_node + node_count;
            int L1 = s / s2 + s % s2;
            int L2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_L = L1;
                step_L = -s2;
            }
            else
            {
                if (L1 < L2)
                {
                    best_way_L = L1;
                    step_L = -s1;
                }
                else
                {
                    best_way_L = L2;
                    step_L = -s2;
                }
            }

            //1 цикл
            int R7 = (s + node_count) / s2 + (s + node_count) % s2;
            int R8 = (s + node_count) / s2 - (s + node_count) % s2 + s2 + 1;
            if (R7 < best_way_L)
            {
                best_way_L = R7;
                step_L = -s2;
            }
            if (R8 < best_way_L)
            {
                best_way_L = R8;
                step_L = -s2;
            }

            //2 цикл
            int R11 = (s + node_count + node_count) / s2 + (s + node_count + node_count) % s2;
            int R12 = (s + node_count + node_count) / s2 - (s + node_count + node_count) % s2 + s2 + 1;
            if (R11 < best_way_L)
            {
                best_way_L = R11;
                step_L = -s2;
            }
            if (R12 < best_way_L)
            {
                best_way_L = R12;
                step_L = -s2;
            }

            // решаем куда шагнуть, и шагаем
            if (best_way_R < best_way_L)
            {
                return step_R;
            }
            else
            {
                return step_L;
            }
        }

        /*
         * Поиск шага, когда 2 образующие, s1=1. Циклы не проверяются.
         */
        private int Step(int start_node, int end_node, int node_count, int s1 = 1, int s2 = 2)
        {
            int best_way_R = 0, step_R = 0, best_way_L = 0, step_L = 0;
            int s = end_node - start_node;

            // лучший путь вправо и шаг
            int R1 = s / s2 + s % s2;
            int R2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_R = R1;
                step_R = s2;
            }
            else
            {
                if (R1 < R2)
                {
                    best_way_R = R1;
                    step_R = s1;
                }
                else
                {
                    best_way_R = R2;
                    step_R = s2;
                }
            }

            // лучший путь влево и шаг
            s = start_node - end_node + node_count;
            int L1 = s / s2 + s % s2;
            int L2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_L = L1;
                step_L = -s2;
            }
            else
            {
                if (L1 < L2)
                {
                    best_way_L = L1;
                    step_L = -s1;
                }
                else
                {
                    best_way_L = L2;
                    step_L = -s2;
                }
            }

            // решаем куда шагнуть, и шагаем
            if (best_way_R < best_way_L)
            {
                return step_R;
            }
            else
            {
                return step_L;
            }
        }

        public List<List<int>> Generate_APM_routing()
        {
            this.min_ways_routing_APM = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route; // то что будет записываться в итоговый лист
            List<int> buff_route;

            try
            {
                if (!this.is_created || this.p == 0)
                {
                    throw new Exception("Описание топологии не было задано или не было произведено создание топологии");
                }
                for (int i = 0; i < this.node_count; i++)
                {
                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    buff_route = new List<int>();
                    buff_route = APM_routing(start_node, end_node, diameter, this.p);

                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < Math.Abs(buff_route[j]); k++)
                        {
                            if (buff_route[j] > 0)
                            {
                                start_node = start_node + generators[j];
                                start_node = start_node % node_count;
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                            }
                            else
                            {
                                start_node = start_node - generators[j];
                                if (start_node < 0)
                                {
                                    start_node = node_count + start_node;
                                }
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                            }
                        }
                    }

                    this.min_ways_routing_APM.Add(route);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_APM;
        }

        private List<int> APM_routing(int start_node, int end_node, int d, int p)
        {
            bool flag_dir = false; // вычисояем как обычно
            List<int> result = new List<int>();
            int V = end_node - start_node;
            if (V >= node_count / 2)
            {
                V = node_count - V;
                flag_dir = true; // инвертируем знаки в итоговом векторе
            }
            int gamma = 2 * (d + 1 - p);
            int i = V / generators[2];
            int j, k, k1;
            bool step;

            if (V < (i + 1) * generators[1])
            {
                j = (V - i * generators[2]) / (generators[2] - generators[1]);
                k = V - i * generators[2] - j * (generators[2] - generators[1]) - gamma;
                k1 = i + 2 * j + gamma - d - 1;
                step = false;
            }
            else
            {
                j = (V - (i + 1) * generators[1]) / (generators[2] - generators[1]);
                k = V - (i + 1) * generators[1] - j * (generators[2] - generators[1]) - gamma + 1;
                k1 = i + gamma - d - 1;
                step = true;
            }

            if (!step) // шаг 2
            {
                if (((i + 2 * j) >= 0 && (i + 2 * j) <= (d - gamma) && (k >= -gamma) && (k <= 0)) ||
                    (((i + 2 * j) > (d - gamma)) && (i + 2 * j) <= d && k >= -gamma && k < -k1))
                {
                    result.Add(k + gamma);
                    result.Add(-j);
                    result.Add(i + j);
                }
                else if (((i + 2 * j) >= 0 && (i + 2 * j) <= (d - gamma) && k >= 0 && k <= (gamma - 3)) ||
                        ((i + 2 * j) > (d - gamma) && (i + 2 * j) <= d && k > k1 && k <= (gamma - 3)))
                {
                    result.Add(-(gamma - k - 2));
                    result.Add(-(j + 1));
                    result.Add(i + j + 1);
                }
                else
                {
                    result.Add(k);
                    result.Add(d + 1 - gamma / 2 - j);
                    result.Add(-(d - gamma / 2 - i - j));
                }
            }
            else // шаг 3
            {
                if ((i >= 0 && i <= (d - gamma) && k > -gamma && k <= 0) ||
                    (i > (d - gamma) && i <= (d - gamma / 2) && k > -gamma && k < -k1))
                {
                    result.Add(gamma - 1 - Math.Abs(k));
                    result.Add(i + 1 - j);
                    result.Add(j);
                }
                else if ((i > (d - gamma) && i <= (d - gamma / 2) && Math.Abs(k) <= k1))
                {
                    result.Add(k);
                    result.Add(-(d - gamma / 2 - i + j));
                    result.Add(-(d + 1 - gamma / 2 - j));
                }
                else
                {
                    result.Add(-(gamma - 1 - k));
                    result.Add(i - j);
                    result.Add(j + 1);
                }
            }

            if (flag_dir)
            {
                result[0] = -result[0];
                result[1] = -result[1];
                result[2] = -result[2];
            }

            return result;
        }

        public List<List<int>> Generate_APO_routing()
        {
            this.min_ways_routing_APO = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route; // то что будет записываться в итоговый лист
            List<int> buff_route;

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
                        start_node = i + 1;
                        end_node = j + 1;
                        route = new List<int>();
                        buff_route = new List<int>(); // получаем сколько нужно пройти по первой и по второй образующим
                        buff_route = APO_routing(start_node, end_node, generators[0]);

                        route.Add(start_node - 1 + Settings.Get_node_naming_start_index());// сначала записываем узел из которого идем
                        for (int k = 0; k < 2; k++)
                        {
                            for (int m = 0; m < Math.Abs(buff_route[k]); m++)
                            {
                                if (buff_route[k] > 0)
                                {
                                    start_node = start_node + generators[k];
                                    start_node = start_node % node_count;
                                    if (start_node == 0)
                                    {
                                        start_node = node_count;
                                    }
                                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                                }
                                else
                                {
                                    start_node = start_node - generators[k];
                                    if (start_node < 0)
                                    {
                                        start_node = node_count + start_node;
                                    }
                                    if (start_node == 0)
                                    {
                                        start_node = node_count;
                                    }
                                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                                }
                            }
                        }

                        this.min_ways_routing_APO.Add(route);
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_APO;
        }

        private List<int> APO_routing(int start_node, int end_node, int s1)
        {
            List<int> result = new List<int>();  //хранит 2 числа сколько нужно шагов по по первой образующей и сколько по второй
            int sgn = 0;
            int alpha = 0;
            int betta = 0;
            int k = 0;

            k = Math.Abs(start_node - end_node);
            if (end_node <= start_node)
            {
                sgn = -1;
            }
            else
            {
                sgn = 1;
            }

            if (k > (node_count / 2))
            {
                sgn = -sgn;
                k = node_count - k;
            }

            betta = k % s1;
            alpha = k / s1 - betta;

            if ((alpha >= (betta - s1)) && (alpha <= s1))
            {
                result.Add(alpha * sgn);
                result.Add(betta * sgn);
            }
            else if (alpha < (betta - s1))
            {
                result.Add((alpha + s1 + 1) * sgn);
                result.Add((betta - s1) * sgn);
            }
            else
            {
                result.Add((alpha - (s1 + 1)) * sgn);
                result.Add((betta + s1) * sgn);
            }

            return result;
        }

        public List<List<int>> Generate_AAO_routing()
        {
            this.min_ways_routing_AAO = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route;
            List<int> buff_route;
            Random rnd = new Random();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                int[] node_name_x = new int[this.node_count]; // координата X узла (колво шагов по малой обр)
                int[] node_name_y = new int[this.node_count]; // координата Y узла (колво шагов по большой обр)

                for (int i = 1; i < this.node_count; i++) // генерация координат узлов
                {
                    List<int> buff_list = new List<int>(this.min_ways_routing_deikstra[i]);
                    for (int j = 1; j < buff_list.Count; j++)
                    {
                        int checker = (buff_list[j] - buff_list[j - 1]);
                        if (checker == this.generators[0])
                        {
                            node_name_x[i] += 1;
                        }
                        else if (checker == this.generators[1])
                        {
                            node_name_y[i] += 1;
                        }
                        else if (checker == -this.generators[0])
                        {
                            node_name_x[i] -= 1;
                        }
                        else if (checker == -this.generators[1])
                        {
                            node_name_y[i] -= 1;
                        }
                        else
                        {
                            if (checker > 0)
                            {
                                checker = (buff_list[j] - buff_list[j - 1]) - this.node_count;
                                if (checker == -this.generators[0])
                                {
                                    node_name_x[i] -= 1;
                                }
                                else if (checker == -this.generators[1])
                                {
                                    node_name_y[i] -= 1;
                                }
                            }
                            else
                            {
                                checker = (buff_list[j] - buff_list[j - 1]) + this.node_count;
                                if (checker == this.generators[0])
                                {
                                    node_name_x[i] += 1;
                                }
                                else if (checker == this.generators[1])
                                {
                                    node_name_y[i] += 1;
                                }
                            }
                        }
                    }
                } // генерация координат узлов

                for (int i = 0; i < node_count; i++)
                {
                    //start_node = 1;
                    //end_node = i + 1;

                    start_node = rnd.Next(1, node_count);
                    end_node = rnd.Next(1, node_count);

                    route = new List<int>();
                    buff_route = new List<int>(); // получаем сколько нужно пройти по первой и по второй образующим
                    buff_route = AAO_routing(node_name_x[start_node - 1], node_name_y[start_node - 1], node_name_x[end_node - 1], node_name_y[end_node - 1]);
                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < Math.Abs(buff_route[j]); k++)
                        {
                            if (buff_route[j] > 0)
                            {
                                start_node = start_node + generators[j];
                                start_node = start_node % node_count;
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                            }
                            else
                            {
                                start_node = start_node - generators[j];
                                if (start_node < 0)
                                {
                                    start_node = node_count + start_node;
                                }
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                            }
                        }
                    }

                    this.min_ways_routing_AAO.Add(route);
                }

            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_AAO;
        }

        private List<int> AAO_routing(int x_start_node, int y_start_node, int x_dest_node, int y_dest_node)
        {
            List<int> result = new List<int>();  //хранит 2 числа сколько нужно шагов по по первой образующей и сколько по второй
            int dx = x_dest_node - x_start_node;
            int dy = y_dest_node - y_start_node;

            int abs_summ = Math.Abs(dx) + Math.Abs(dy);
            if (abs_summ > this.diameter)
            {
                int[] dxi = new int[8];
                int[] dyi = new int[8];

                dxi[0] = dx + this.diameter + 1; dyi[0] = dy - this.diameter;
                dxi[1] = dx - 1; dyi[1] = dy + 2 * this.diameter;
                dxi[2] = dx + 2 * this.diameter + 1; dyi[2] = dy;
                dxi[3] = dx + this.diameter; dyi[3] = dy + this.diameter;
                dxi[4] = dx - this.diameter - 1; dyi[4] = dy + this.diameter;
                dxi[5] = dx + 1; dyi[5] = dy - 2 * this.diameter;
                dxi[6] = dx - 2 * this.diameter - 1; dyi[6] = dy;
                dxi[7] = dx - this.diameter; dyi[7] = dy - this.diameter;

                dx = dxi[0]; dy = dyi[0];

                for (int i = 1; i < 8; i++)
                {
                    abs_summ = Math.Abs(dx) + Math.Abs(dy);
                    int abs_summ2 = Math.Abs(dxi[i]) + Math.Abs(dyi[i]);

                    if (abs_summ2 < abs_summ)
                    {
                        dx = dxi[i]; dy = dyi[i];
                    }
                }
            }

            result.Add(dx);
            result.Add(dy);

            return result;
        }

        public List<List<int>> Generate_AAO_routing_orig()
        {
            this.min_ways_routing_AAO_orig = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route;
            List<int> buff_route;
            Random rnd = new Random();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                int[] node_name_x = new int[this.node_count]; // координата X узла (колво шагов по малой обр)
                int[] node_name_y = new int[this.node_count]; // координата Y узла (колво шагов по большой обр)

                for (int i = 1; i < this.node_count; i++) // генерация координат узлов
                {
                    List<int> buff_list = new List<int>(this.min_ways_routing_deikstra[i]);
                    for (int j = 1; j < buff_list.Count; j++)
                    {
                        int checker = (buff_list[j] - buff_list[j - 1]);
                        if (checker == this.generators[0])
                        {
                            node_name_x[i] += 1;
                        }
                        else if (checker == this.generators[1])
                        {
                            node_name_y[i] += 1;
                        }
                        else if (checker == -this.generators[0])
                        {
                            node_name_x[i] -= 1;
                        }
                        else if (checker == -this.generators[1])
                        {
                            node_name_y[i] -= 1;
                        }
                        else
                        {
                            if (checker > 0)
                            {
                                checker = (buff_list[j] - buff_list[j - 1]) - this.node_count;
                                if (checker == -this.generators[0])
                                {
                                    node_name_x[i] -= 1;
                                }
                                else if (checker == -this.generators[1])
                                {
                                    node_name_y[i] -= 1;
                                }
                            }
                            else
                            {
                                checker = (buff_list[j] - buff_list[j - 1]) + this.node_count;
                                if (checker == this.generators[0])
                                {
                                    node_name_x[i] += 1;
                                }
                                else if (checker == this.generators[1])
                                {
                                    node_name_y[i] += 1;
                                }
                            }
                        }
                    }
                } // генерация координат узлов

                int count = 0;
                int[] ai = new int[4];
                int[] bi = new int[4];

                string FileName;
                string Base_FolderName;
                string file_name;
                string FilePath;

                FileStream fs;
                StreamReader sr;

                file_name = node_count.ToString() + "_nodes";
                Base_FolderName = "zeroes";

                FileName = file_name + ".txt";
                FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

                fs = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite);
                sr = new StreamReader(fs);

                for (int i = 0; i < 4; i++)
                {
                    string buffer = sr.ReadLine();
                    string[] buffer2 = buffer.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (buffer2.Length == 2)
                    {
                        ai[count] = Int32.Parse(buffer2[0]);
                        bi[count] = Int32.Parse(buffer2[1]);
                        count++;
                    }
                }

                sr.Close();
                fs.Close();

                for (int i = 0; i < node_count; i++)
                {
                    //start_node = 1;
                    //end_node = i + 1;

                    start_node = 9;//rnd.Next(1, node_count);
                    end_node = 5;//rnd.Next(1, node_count);

                    route = new List<int>();
                    buff_route = new List<int>(); // получаем сколько нужно пройти по первой и по второй образующим
                    buff_route = AAO_routing_orig(node_name_x[start_node - 1], node_name_y[start_node - 1], node_name_x[end_node - 1], node_name_y[end_node - 1], ai, bi, count);
                    route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < Math.Abs(buff_route[j]); k++)
                        {
                            if (buff_route[j] > 0)
                            {
                                start_node = start_node + generators[j];
                                start_node = start_node % node_count;
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());

                            }
                            else
                            {
                                start_node = start_node - generators[j];
                                if (start_node < 0)
                                {
                                    start_node = node_count + start_node;
                                }
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + Settings.Get_node_naming_start_index());
                            }
                        }
                    }

                    this.min_ways_routing_AAO_orig.Add(route);
                }

            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_AAO_orig;
        }

        private List<int> AAO_routing_orig(int x_start_node, int y_start_node, int x_dest_node, int y_dest_node, int[] ai, int[] bi, int count)
        {
            List<int> result = new List<int>();  //хранит 2 числа сколько нужно шагов по по первой образующей и сколько по второй
            int dx = x_dest_node - x_start_node;
            int dy = y_dest_node - y_start_node;

            int abs_summ = Math.Abs(dx) + Math.Abs(dy);
            if (abs_summ >= this.diameter)
            {
                int[] dxi = new int[9];
                int[] dyi = new int[9];

                for (int i = 0; i < count; i++)
                {
                    dxi[i] = dx + ai[i]; dyi[i] = dy + bi[i];
                    dxi[i + count] = dx - ai[i]; dyi[i + count] = dy - bi[i];
                }
                dxi[count * 2] = dx; dyi[count * 2] = dy;

                dx = dxi[0]; dy = dyi[0];

                for (int i = 1; i < (count * 2 + 1); i++)
                {
                    abs_summ = Math.Abs(dx) + Math.Abs(dy);
                    int abs_summ2 = Math.Abs(dxi[i]) + Math.Abs(dyi[i]);

                    if (abs_summ2 < abs_summ)
                    {
                        dx = dxi[i]; dy = dyi[i];
                    }
                }
            }

            result.Add(dx);
            result.Add(dy);

            return result;
        }


        public double Calculate_efficiency_simple()
        {
            double deikstra_algorithm_L = 0;
            double simple_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                simple_algorithm_L += this.min_ways_routing_simple[i].Count - 1;
            }

            efficiency_simple = Math.Round((deikstra_algorithm_L / simple_algorithm_L), 3);
            return this.efficiency_simple;
        }

        public double Calculate_efficiency_ROU()
        {
            double deikstra_algorithm_L = 0;
            double ROU_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                ROU_algorithm_L += this.min_ways_routing_ROU[i].Count - 1;
            }

            efficiency_ROU = Math.Round((deikstra_algorithm_L / ROU_algorithm_L), 3);
            return this.efficiency_ROU;
        }

        public double Calculate_efficiency_APM()
        {
            double deikstra_algorithm_L = 0;
            double APM_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                APM_algorithm_L += this.min_ways_routing_APM[i].Count - 1;
            }

            efficiency_APM = Math.Round((deikstra_algorithm_L / APM_algorithm_L), 3);
            return this.efficiency_APM;
        }

        public double Calculate_efficiency_APO()
        {
            double deikstra_algorithm_L = 0;
            double APO_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                APO_algorithm_L += this.min_ways_routing_APO[i].Count - 1;
            }

            efficiency_APO = Math.Round((deikstra_algorithm_L / APO_algorithm_L), 3);
            return this.efficiency_APO;
        }

        public override void createTopEntity(string project_name, string routing_algorithm, string project_path)
        {
            throw (new Exception("Not impemented yet"));
        }
    }
}
