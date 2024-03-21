using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HDL_NoC_CodeGen
{
    class PictureGraphTorus : PictureGraph
    {

        public override Graph.GraphType id()
        {
            return Graph.GraphType.Torus;
        }

        public PictureGraphTorus() : base() { }

        /*
        public Bitmap Get_bmp()
        {
            return this.bmp;
        }
        */
        protected override int Calculate_Diametr()
        {
            return Math.Min(this.bmp_size.Height, this.bmp_size.Width) - 300;
        }

        private List<Point> Calculate_Node_Points(List<int> generators, Point draw_center)
        {
            double x;
            double y;
            int w;
            int h;
            int draw_diametr;
            w = this.bmp_size.Width; h = this.bmp_size.Height;
            draw_diametr = Math.Min(w, h) / (Math.Max(generators[1], generators[0]) + 1);
            List<Point> node_points = new List<Point>();

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    x = draw_center.X - draw_diametr * (generators[1] - 1) / 2 + draw_diametr * j;
                    y = draw_center.Y - draw_diametr * (generators[0] - 1) / 2 + draw_diametr * i;
                    node_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                }
            }

            return node_points;
        }

        private List<Point> Calculate_Node_Name_Points(List<int> generators, Point draw_center)
        {
            double x;
            double y;
            int w;
            int h;
            int draw_diametr;
            w = this.bmp_size.Width; h = this.bmp_size.Height;
            draw_diametr = Math.Min(w, h) / (Math.Max(generators[1], generators[0]) + 1);
            List<Point> string_points = new List<Point>();

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = 0; j < generators[1]; j++)
                {
                    x = draw_center.X - (draw_diametr * (generators[1] - 1) / 2 + this.string_offset / 2) + draw_diametr * j;
                    y = draw_center.Y - (draw_diametr * (generators[0] - 1) / 2 + this.string_offset / 2) + draw_diametr * i;
                    string_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
                }
            }

            return string_points;
        }


        public override Bitmap Draw_Graph(int node_count, List<int> generators)
        {
            this.bmp = new Bitmap(bmp_size.Width, bmp_size.Height);
            this.bmp.SetResolution(500, 500);

            base.Draw_Graph(node_count, generators);

            Point draw_center = Calculate_Center_Graph();

            List<Point> node_points = new List<Point>();
            List<Point> string_points = new List<Point>();
            node_points = Calculate_Node_Points(generators, draw_center);
            string_points = Calculate_Node_Name_Points(generators, draw_center);

            float x_diametr = node_points[generators[1]-1].X - node_points[0].X + 4 * Settings.Get_vertex_size();
            float y_diametr = node_points[generators[0]*generators[1]-1].Y - node_points[0].Y + 4 * Settings.Get_vertex_size();

            //Вычисления для горизонтальных овальчиков
            float mesh_width = node_points[generators[1] - 1].X - node_points[0].X;
            float xy_diametr = y_diametr / generators[0] / 2;
            //На сколько по координате y поднят горизонатльный овал
            float xy = (float)((Math.Sqrt(1 - Math.Pow((mesh_width), 2) / Math.Pow(x_diametr, 2))) * xy_diametr / 2);
            float derivationAngleX = (float)(Math.Atan((mesh_width / 2) / (xy)) / Math.PI * 180);

            //Вычисления для вертикальных овальчиков
            float mesh_height = node_points[generators[0] * generators[1] - 1].Y - node_points[0].Y;
            float yx_diametr = x_diametr / generators[1] / 2;
            //На сколько по коорденате x поднят вуртикальный овал
            float yx = (float)((Math.Sqrt(1 - Math.Pow((mesh_height), 2) / Math.Pow(y_diametr, 2))) *
                yx_diametr / 2);
            float derivationAngleY = (float)(Math.Atan((mesh_height / 2) / (yx)) / Math.PI * 180);

            for (int i = 0; i < generators[0]; i++)
            {
                for (int j = i * generators[1]; j < i * generators[1] + generators[1]; j++)
                {
                    if ((j + 1) % generators[1] != 0)
                    {
                        pen_graph.Color = Color.Black;
                        graph.DrawLine(this.pen_graph, node_points[j], node_points[(j + 1) % node_count]);
                    }
                    if (i < generators[0] - 1)
                    {
                        pen_graph.Color = Color.Black;
                        graph.DrawLine(this.pen_graph, node_points[j], node_points[(j + generators[1]) % node_count]);
                    }
                    if (i == 0)
                    {
                        pen_graph.Color = Color.Red;
                        graph.DrawArc(this.pen_graph,
                            node_points[j].X - (yx_diametr / 2) - yx,
                            node_points[j].Y - Settings.Get_vertex_size() * 2,
                            yx_diametr, y_diametr,
                            0 + derivationAngleY, 360 - derivationAngleY * 2);
                    }
                    if (j % generators[1] == 0)
                    {
                        pen_graph.Color = Color.Red;
                        graph.DrawArc(this.pen_graph, node_points[j].X - Settings.Get_vertex_size()*2,
                            node_points[j].Y - (xy_diametr/2) - xy,
                            x_diametr, xy_diametr,
                            90 + derivationAngleX, 360 - derivationAngleX*2);
                    }

                }
            }
            if (this.node_naming)
            {
                Calculate_Node_Name_Points(generators, draw_center);
            }

            // для проверки центрирования отрисовки
            //this.graph.DrawEllipse(this.pen_node, new Rectangle(this.draw_center.X - 15, this.draw_center.Y - 15, 30, 30));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < node_count; i++)
            {
                // первые два числа - координаты угла описанного квадрата, вторые два числа - его размеры
                graph.DrawEllipse(this.pen_node, new Rectangle(node_points[i].X - this.vertex_size / 2, node_points[i].Y - this.vertex_size / 2, this.vertex_size, this.vertex_size));
                // для проверки расположения подписей ущлов
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


            this.is_draw = true;
            graph.Dispose();
            return bmp;
        }

        public override Bitmap Draw_Route(string route, int node_count, List<int> generators)
        {
            Graphics graph = Graphics.FromImage(this.bmp);
            Point draw_center = Calculate_Center_Graph();
            int w;
            int h;
            int draw_diametr;
            w = this.bmp_size.Width; h = this.bmp_size.Height;
            draw_diametr = Math.Min(w, h) / (Math.Max(generators[1], generators[0]) + 1);
            List<Point> node_points = Calculate_Node_Points(generators, draw_center);
            string[] buffer = route.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                int node_index_1 = Convert.ToInt32(buffer[i]) - Settings.Get_node_naming_start_index();
                int node_index_2 = Convert.ToInt32(buffer[i + 1]) - Settings.Get_node_naming_start_index();
                graph.DrawLine(this.pen_route, node_points[node_index_1], node_points[node_index_2]);
            }
            graph.Dispose();
            return this.bmp;
        }

        public override Bitmap Draw_Selected_Node(Size bmp_size, Point mouse_location, int node_count, List<int> generators)
        {
            Graphics graph = Graphics.FromImage(this.bmp);
            Point draw_center = Calculate_Center_Graph();
            int draw_diametr = Calculate_Diametr();
            List<Point> node_points = Calculate_Node_Points(generators, draw_center);
            int node_near_mouse_click = -1;
            for (int i = 0; i < node_points.Count; i++)
            {
                if (mouse_location.X >= node_points[i].X - 10 && mouse_location.X <= node_points[i].X + 10)
                {
                    if (mouse_location.Y >= node_points[i].Y - 10 && mouse_location.Y <= node_points[i].Y + 10)
                    {
                        node_near_mouse_click = i;
                    }
                }
            }

            if (node_near_mouse_click != -1)
            {
                for (int j = 0; j < generators.Count; j++)
                {
                    Pen pen = new Pen(Color.Gold);
                    graph.DrawEllipse(pen, new Rectangle(node_points[node_near_mouse_click].X - 5, node_points[node_near_mouse_click].Y - 5, 10, 10));

                    pen.Color = Color.White;
                    graph.DrawLine(pen, node_points[node_near_mouse_click % node_count], node_points[(node_near_mouse_click + generators[j]) % node_count]);
                    pen.Color = Color.LightGray;
                    graph.DrawLine(pen, node_points[node_near_mouse_click % node_count], node_points[(node_near_mouse_click - generators[j] + node_count) % node_count]);
                }
            }

            graph.Dispose();
            return this.bmp;
        }
    }
}
