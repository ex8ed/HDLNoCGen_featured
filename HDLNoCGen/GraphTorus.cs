using HDLNoCGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace HDL_NoC_CodeGen
{
    class GraphTorus : Graph, IRectangleLike
    {

        public override GraphType id()
        {
            return GraphType.Torus;
        }

        private List<List<int>> ways_routing_XY;

        private double XY_Efficiency;

        private void calculateEfficiencyXY()
        {
            double deikstra_count = 0;
            double XY_count = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_count += this.min_ways_routing_deikstra[i].Count - 1;
                XY_count += this.ways_routing_XY[i].Count - 1;
            }

            this.XY_Efficiency = Math.Round(deikstra_count / XY_count, 3);
        }

        public List<List<int>> Get_ways_routing_XY()
        {
            return this.ways_routing_XY;
        }

        public double getXY_Efficiency()
        {
            calculateEfficiencyXY();
            return this.XY_Efficiency;
        }

        public GraphTorus() : base()
        {
            this.diameter = 0;
            this.matr_smej = null;
        }

        public GraphTorus(string parameters)
        {

            string[] buffer = parameters.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] buffer_topology = buffer[0].Trim().Split(new string[] { "T", "t", ";", ":", ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            generators = new List<int>();
            for (int i = 0; i < buffer_topology.Length; i++)
            {
                generators.Add(Convert.ToInt32(buffer_topology[i]));
            }
            generators.Sort();
            this.node_count = generators[0] * generators[1];

            //string[] buffer = parameters.Split(new string[] { "С(", "C(", ";", ":",  ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            //this.node_count = Convert.ToInt32(buffer[0]);
            //this.p = Convert.ToInt32(param_2);

            this.is_created = true;
        }

        protected override void Create_matr_smej()
        {
            this.matr_smej = new int[this.node_count, this.node_count];
            int n = generators[0];
            int m = generators[1];

            for (int i = 0; i < this.node_count; i++)
            {
                if (i % m != m - 1)
                {
                    this.matr_smej[i, i + 1] = 1;
                    this.matr_smej[i + 1, i] = 1;
                }
                if (i % m == 0)
                {
                    this.matr_smej[i, i + m - 1] = 1;
                    this.matr_smej[i + m - 1, i] = 1;
                }
                if (i < (this.node_count - m))
                {
                    this.matr_smej[i, i + m] = 1;
                    this.matr_smej[i + m, i] = 1;
                }
                if (i < m)
                {
                    this.matr_smej[i, i + m * (n - 1)] = 1;
                    this.matr_smej[i + m * (n - 1), i] = 1;
                }
            }
        }


        public List<List<int>> Generate_XY_routing()
        {
            int iterations_count;

            int start_node;
            int end_node;
            List<int> route;

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
                        route = new List<int>();
                        route.Add(start_node + Settings.Get_node_naming_start_index());
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
        }

        private int XY_routing(int start_node, int end_node, List<int> generators, int node_count)
        {
            int start_x = start_node % generators[1];
            int end_x = end_node % generators[1];
            int start_y = start_node / generators[1];
            int end_y = end_node / generators[1];
            int step = 0;

            if (start_x < end_x)
            {
                if (end_x - start_x < generators[1] - end_x + start_x)
                {
                    step = 1;
                }
                else
                {
                    if (start_x == 0)
                    {
                        step = generators[1] - 1;
                    }
                    else
                    {
                        step = -1;
                    }
                }
            }
            else if (start_x > end_x)
            {
                if (start_x - end_x < generators[1] - start_x + end_x)
                {
                    step = -1;
                }
                else
                {
                    if (start_x == generators[1] - 1)
                    {
                        step = -generators[1] + 1;
                    }
                    else
                    {
                        step = 1;
                    }
                }
            }
            else
            {
                if (start_y < end_y)
                {
                    if (end_y - start_y < generators[0] - end_y + start_y)
                    {
                        step = generators[1];
                    }
                    else
                    {
                        if (start_y == 0)
                        {
                            step = generators[1] * (generators[0] - 1);
                        }
                        else
                        {
                            step = -generators[1];
                        }
                    }
                }
                else if (start_y > end_y)
                {
                    if (start_y - end_y < generators[0] - start_y + end_y)
                    {
                        step = -generators[1];
                    }
                    else
                    {
                        if (start_y == generators[0] - 1)
                        {
                            step = -generators[1] * (generators[0] - 1);
                        }
                        else
                        {
                            step = generators[1];
                        }
                    }
                }
            }

            return start_node + step;

            /*
            if (S == 0)
                return start_node;
            else if ((start_node % generators[1]) < (end_node % generators[1]))
                start_node++;
            else if ((start_node % generators[1]) > (end_node % generators[1]))
                start_node--;
            else if ((((start_node % generators[0]) < (end_node % generators[0])) && (start_node % node_count) < (end_node % node_count)) || ((start_node & node_count) < (end_node % node_count)))
                start_node += generators[1];
            else if ((start_node % generators[0]) > (end_node % generators[0]) || (start_node % node_count) > (end_node % node_count))
                start_node -= generators[1];
            return start_node;
            */
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

            fs = new FileStream($"{project_path}\\{project_name}\\{top_entity_name}.v", FileMode.Create, FileAccess.ReadWrite);
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

            sw.WriteLine($"    reg unsigned [7:0] max_X = {generators[0]};");
            sw.WriteLine($"    reg unsigned [7:0] max_Y = {generators[1]};");
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
                    else
                    {
                        router_description += $".input_north(core_{generators[0] - 1}{j}_south), ";
                    }
                    if (j < generators[1] - 1)
                    {
                        router_description += $".input_east(core_{i}{j + 1}_west), ";
                    }
                    else
                    {
                        router_description += $".input_east(core_{i}{0}_west), ";
                    }
                    if (i < generators[0] - 1)
                    {
                        router_description += $".input_south(core_{i + 1}{j}_north), ";
                    }
                    else 
                    {
                        router_description += $".input_south(core_{0}{j}_north), ";
                    }
                    if (j > 0)
                    {
                        router_description += $".input_west(core_{i}{j - 1}_east), ";
                    }
                    else
                    {
                        router_description += $".input_west(core_{i}{generators[1] - 1}_east), ";
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

            fs = new FileStream($"{project_path}\\{router_name}.v", FileMode.Create, FileAccess.ReadWrite);

            #region Verilog code
            byte[] input = Encoding.Default.GetBytes(
                $"`define N {data_packet_size}\r\n" +
                $"`define M {coordinates_size}\r\n" +
                $"module {router_name}\r\n" +
                "(\r\n" +
                "\r\n" +
                "    clk,\r\n\r\n\r" +
                "    max_X,\r\n" +
                "    max_Y,\r\n\r\n" +
                "    router_X,\r\n" +
                "    router_Y,\r\n\r\n" +
                "    input_core,\r\n\r\n" +
                "    input_north,\r\n" +
                "    input_east,\r\n" +
                "    input_south,\r\n" +
                "    input_west,\r\n\r\n" +
                "    output_core,\r\n\r\n" +
                "    output_north,\r\n" +
                "    output_east,\r\n" +
                "    output_south,\r\n" +
                "    output_west\r\n);\r\n\r\n" +
                "    input clk;\r\n\r\n" +
                "    input unsigned [`M - 1:0] max_X;\r\n" +
                "    input unsigned [`M - 1:0] max_Y;\r\n\r\n" +
                "    input unsigned [`M - 1:0] router_X;\r\n" +
                "    input unsigned [`M - 1:0] router_Y;\r\n\r\n" +
                "    input [`N - 1:0] input_core;\r\n\r\n" +
                "    input [`N - 1:0] input_north;\r\n" +
                "    input [`N - 1:0] input_east;\r\n" +
                "    input [`N - 1:0] input_south;\r\n" +
                "    input [`N - 1:0] input_west;\r\n\r\n" +
                $"    output reg [`N - 1:0] output_core = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};\r\n\r\n" +
                $"    output reg [`N - 1:0] output_north = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};\r\n" +
                $"    output reg [`N - 1:0] output_east = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};\r\n" +
                $"    output reg [`N - 1:0] output_south = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};\r\n" +
                $"    output reg [`N - 1:0] output_west = `N'b{String.Concat(Enumerable.Repeat("0", data_packet_size))};\r\n\r\n" +
                "    reg in_flag = 1'b0;\r\n" +
                "    reg [`N - 1:0] data = `N'b" + String.Concat(Enumerable.Repeat("0", data_packet_size)) + ";\r\n" +
                "    reg [`M - 1:0] destination_X;\r\n" +
                "    reg [`M - 1:0] destination_Y;\r\n\r\n\r\n" +
                "    always @(posedge clk)\r\n\tbegin\r\n\t\t\r\n\t\t" +
                "if (input_core[7] == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdata = input_core;\r\n" +
                "\t\t\tin_flag = 1'b1;\r\n" +
                "\t\tend\r\n" +
                "\t\telse if (input_north[7] == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdata = input_north;\r\n" +
                "\t\t\tin_flag = 1'b1;\r\n" +
                "\t\tend\r\n" +
                "\t\telse if (input_east[7] == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdata = input_east;\r\n" +
                "\t\t\tin_flag = 1'b1;\r\n" +
                "\t\tend\r\n" +
                "\t\telse if (input_south[7] == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdata = input_south;\r\n" +
                "\t\t\tin_flag = 1'b1;\r\n" +
                "\t\tend\r\n" +
                "\t\telse if (input_west[7] == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdata = input_west;\r\n" +
                "\t\t\tin_flag = 1'b1;\r\n" +
                "\t\tend\r\n" +
                "\t\t\r\n\t\t\r\n\t" +
                "\tif (in_flag == 1'b1)\r\n" +
                "\t\tbegin\r\n" +
                "\t\t\tdestination_Y = data[6:5];\r\n" +
                "\t\t\tdestination_X = data[4:3];\r\n" +
                "\t\t\t\r\n\t\t\tif (destination_X > router_X)\r\n" +
                "\t\t\tbegin\r\n" +
                "\t\t\t\tif (max_X - destination_X + router_X > destination_X - router_X)\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_east = data;\r\n" +
                "\t\t\t\tend\r\n" +
                "\t\t\t\t\r\n" +
                "\t\t\t\telse\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_west = data;\r\n" +
                "\t\t\t\tend\r\n\t\t\tend\r\n" +
                "\t\t\t\r\n\t\t\telse if (router_X > destination_X)\r\n" +
                "\t\t\tbegin\r\n" +
                "\t\t\t\tif (max_X - router_X + destination_X > router_X - destination_X)\r\n" +
                "\t\t\t\tbegin\r\n\t\t\t\t\toutput_west = data;\r\n" +
                "\t\t\t\tend\r\n" +
                "\t\t\t\t\r\n\t\t\t\telse\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_east = data;\r\n" +
                "\t\t\t\tend\r\n" +
                "\t\t\tend\r\n" +
                "\t\t\t\r\n\t\t\telse if (destination_Y > router_Y)\r\n" +
                "\t\t\tbegin\r\n" +
                "\t\t\t\tif (max_Y - destination_Y + router_Y > destination_Y - router_Y)\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_south = data;\r\n" +
                "\t\t\t\tend\r\n" +
                "\t\t\t\t\r\n" +
                "\t\t\t\telse\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_north = data;\r\n" +
                "\t\t\t\tend\r\n\t\t\tend\r\n" +
                "\t\t\t\r\n\t\t\telse if (router_Y > destination_Y)\r\n" +
                "\t\t\tbegin\r\n" +
                "\t\t\t\tif (max_Y - router_Y + destination_Y > router_Y - destination_Y)\r\n" +
                "\t\t\t\tbegin\r\n\t\t\t\t\toutput_north = data;\r\n" +
                "\t\t\t\tend\r\n\t\t\t\t\r\n" +
                "\t\t\t\telse\r\n" +
                "\t\t\t\tbegin\r\n" +
                "\t\t\t\t\toutput_south = data;\r\n" +
                "\t\t\t\tend\r\n" +
                "\t\t\tend\r\n" +
                "\t\t\t\r\n" +
                "\t\t\telse\r\n" +
                "\t\t\tbegin\r\n" +
                "\t\t\t\toutput_core = data;\r\n" +
                "\t\t\tend\r\n" +
                "\t\tend\r\n" +
                "\t\t\r\n\tend\r\n\t\r\n" +
                "endmodule\r\n"
                );
            #endregion

            fs.Write(input, 0, input.Length);
            fs.Close();
        }

    }
}
