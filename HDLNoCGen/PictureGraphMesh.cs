using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HDL_NoC_CodeGen
{
    /*internal*/
    class PictureGraphMesh : PictureGraph
    {
        public override Graph.GraphType id()
        {
            return Graph.GraphType.Mesh;
        }

        public PictureGraphMesh() : base() { }

        private int Calculate_Height() // вычисляет высоту сетки
        {
            return (bmp_size.Height) - 150;
        }

        private int Calculate_Width() // вычисляет ширину сетки
        {
            return (bmp_size.Width) - 150;
        }

        private List<Point> Calculate_Node_Points(Point draw_center, List<int> generators)
        {
            double x;
            double y;
            long w1b;
            long h1b;
            long dim;
            w1b = Calculate_Width() / (generators[1] - 1);
            h1b = Calculate_Height() / (generators[0] - 1);

            dim = Math.Min(w1b, h1b);

            List<Point> node_points = new List<Point>();

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    x = draw_center.X - dim * (generators[1] - 1) / 2 + dim * j;
                    y = draw_center.Y - dim * (generators[0] - 1) / 2 + dim * i;
                    node_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                }
            }
            return node_points;
        }

        private List<Point> Calculate_Node_Name_Points(Point draw_center, List<int> generators)
        {
            double x;
            double y;
            long w1b;
            long h1b;
            long dim;
            w1b = Calculate_Width() / (generators[1] - 1);
            h1b = Calculate_Height() / (generators[0] - 1);

            dim = Math.Min(w1b, h1b);

            List<Point> string_points = new List<Point>();

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    x = draw_center.X - (dim * (generators[1] - 1) / 2 + this.string_offset) + dim * j;
                    y = draw_center.Y - (dim * (generators[0] - 1) / 2 + this.string_offset) + dim * i;
                    string_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                }
            }

            return string_points;
        }
        
        public override Bitmap Draw_Graph(int node_count, List<int> generators)
        {
            base.Draw_Graph(node_count, generators);

            Point draw_center = Calculate_Center_Graph();
            List<Point> node_points = Calculate_Node_Points(draw_center, generators);
            List<Point> string_points = Calculate_Node_Name_Points(draw_center, generators);
            if (this.node_naming)
            {
                Calculate_Node_Name_Points(draw_center, generators);
            }

            // для проверки центрирования отрисовки
            //graph.DrawEllipse(this.pen_node, new Rectangle(draw_center.X - 15, draw_center.Y - 15, 30, 30));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < node_count; i++)
            {
                // первые два числа - координаты угла описанного квадрата, вторые два числа - его размеры
                graph.DrawEllipse(this.pen_node, new Rectangle(node_points[i].X - this.vertex_size / 2, node_points[i].Y - this.vertex_size / 2, this.vertex_size, this.vertex_size));
                // для проверки расположения подписей узлов
                //this.graph.DrawRectangle(this.pen_node, new Rectangle(this.string_points[i].X - 60, this.string_points[i].Y - 60, 120, 120));
                // смещение в координате Y на 4 нужно для точного позиционирования относительно узла
                if (this.node_naming)
                {
                    if (i % node_naming_interval == 0 || i == (node_count - 1))
                    {
                        graph.DrawString((i + this.node_naming_start_index).ToString(), this.font, this.brush, new Rectangle(string_points[i].X - 60, string_points[i].Y - 60 + 4, 120, 120), sf);
                    }
                }
            }

            // рисование ребер между ячейками

            for (int i = 0; i < generators[0]; i++)// строки
            {
                for (int j = i * generators[1]; j < i * generators[1] + generators[1]; j++) // столбцы
                {
                    if ((j + 1) % generators[1] != 0)
                    {
                        graph.DrawLine(this.pen_graph, node_points[j], node_points[(j + 1) % node_count]);
                    }
                    if (i < generators[0] - 1)
                    {
                        graph.DrawLine(this.pen_graph, node_points[j], node_points[(j + generators[1]) % node_count]);
                    }
                }
            }

            this.is_draw = true;
            graph.Dispose();
            return bmp;
        }

        public override Bitmap Draw_Route(string route, int node_count, List<int> generators)
        {
            Graphics graphMesh = Graphics.FromImage(this.bmp);
            Point draw_center = Calculate_Center_Graph();
            List<Point> node_points = Calculate_Node_Points(draw_center, generators);
            string[] buffer = route.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                int node_index_1 = Convert.ToInt32(buffer[i]) - Settings.Get_node_naming_start_index();
                int node_index_2 = Convert.ToInt32(buffer[i + 1]) - Settings.Get_node_naming_start_index();
                graphMesh.DrawLine(this.pen_route, node_points[node_index_1], node_points[node_index_2]);
            }
            graphMesh.Dispose();
            return this.bmp;
        }

        //Filler just for now. REWRITE ASAP
        public override Bitmap Draw_Selected_Node(Size bmp_size,
            Point mouse_location, int node_count, List<int> generators)
        {
            return Draw_Graph(node_count, generators);
        }

        protected override int Calculate_Diametr()
        {
            return Math.Min(this.bmp_size.Height, this.bmp_size.Width) - 300;
        }
    }
}
