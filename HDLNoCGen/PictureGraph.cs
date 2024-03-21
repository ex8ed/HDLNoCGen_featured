using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using static HDL_NoC_CodeGen.Graph;

namespace HDL_NoC_CodeGen
{
    abstract class PictureGraph
    {
        public abstract Graph.GraphType id();

        public Size bmp_size;
        protected Bitmap bmp;                 // поле для отрисовки
        protected bool is_draw;               // была ли отрисовка рисунка
        protected Graphics graph;             // переменная самого графа

        protected Color back_color_graph;     // фон поля для отрисовки
        protected bool black_graph_color;     // черно-белая отрисовка графа
        protected bool alternative_draw_graph;// отрисовка образующих эллипсом
        protected List<Color> colors;         // список цветов для отрисовки образующих
        protected int pen_node_width;         // ширина линий для рисования узлов и образующих
        protected Pen pen_node;               // перо для рисования узлов графа
        protected Pen pen_graph;              // перо для рисования образующих графа
        protected int vertex_size;            // размер узла

        protected int route_width;            // щирина линии, которой отрисовывается маршрут

        protected Pen pen_route;              // перо для рисования маршрута

        protected SolidBrush brush;           // кисть для отсования подписей узлов
        protected Font font;                  // шрифт для рисования подписей узлов
        protected int string_offset;          // смещение подписи узлв от центра узла
        protected bool node_naming;           // указывает нужно ли подписывать узлы
        protected int node_naming_start_index;// начало нумерации узлов
        protected int node_naming_interval;

        public PictureGraph()
        {

            this.is_draw = false;

            this.black_graph_color = Settings.Get_black_graph_color();
            this.alternative_draw_graph = Settings.Get_alternative_draw_graph();

            this.back_color_graph = Color.FromArgb(Settings.Get_back_color_graph());
            this.black_graph_color = Settings.Get_black_graph_color();
            this.alternative_draw_graph = Settings.Get_alternative_draw_graph();
            this.colors = new List<Color> // перевести в настройки
            {
                Color.Black,
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Pink,
                Color.Yellow
            };
            this.pen_node_width = Settings.Get_pen_node_width();
            this.pen_node = new Pen(Color.FromArgb(Settings.Get_pen_node_color()));
            this.pen_node.Width = this.pen_node_width;
            this.pen_graph = new Pen(Color.FromArgb(Settings.Get_pen_node_color()));
            this.pen_graph.Width = this.pen_node_width;
            this.vertex_size = Settings.Get_vertex_size();

            this.pen_route = new Pen(Color.FromArgb(Settings.Get_route_color()));
            this.route_width = Settings.Get_route_width();
            this.pen_route.Width = this.route_width;

            this.brush = new SolidBrush(Color.FromArgb(Settings.Get_node_naming_brush_color()));
            this.font = new Font(Settings.Get_node_naming_font_name(), Settings.Get_node_naming_font_size());
            this.string_offset = Settings.Get_node_naming_string_offset();
            this.node_naming_interval = Settings.Get_node_naming_interval();
            this.node_naming = Settings.Get_node_naming();
            this.node_naming_start_index = Settings.Get_node_naming_start_index();
        }

        public void Set_bmp_size(Size bmp_size)
        {
            this.bmp_size = bmp_size;
        }

        public void Update_Draw_Settings()
        {

            this.black_graph_color = Settings.Get_black_graph_color();
            this.alternative_draw_graph = Settings.Get_alternative_draw_graph();

            this.back_color_graph = Color.FromArgb(Settings.Get_back_color_graph());
            this.black_graph_color = Settings.Get_black_graph_color();
            this.alternative_draw_graph = Settings.Get_alternative_draw_graph();
            this.colors = new List<Color> // перевести в настройки
            {
                Color.Black,
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Pink,
                Color.Yellow
            };
            this.pen_node_width = Settings.Get_pen_node_width();
            this.pen_node = new Pen(Color.FromArgb(Settings.Get_pen_node_color()));
            this.pen_node.Width = this.pen_node_width;
            this.pen_graph = new Pen(Color.FromArgb(Settings.Get_pen_node_color()));
            this.pen_graph.Width = this.pen_node_width;
            this.vertex_size = Settings.Get_vertex_size();

            this.pen_route = new Pen(Color.FromArgb(Settings.Get_route_color()));
            this.route_width = Settings.Get_route_width();
            this.pen_route.Width = this.route_width;

            this.brush = new SolidBrush(Color.FromArgb(Settings.Get_node_naming_brush_color()));
            this.font = new Font(Settings.Get_node_naming_font_name(), Settings.Get_node_naming_font_size());
            this.string_offset = Settings.Get_node_naming_string_offset();
            this.node_naming_interval = Settings.Get_node_naming_interval();
            this.node_naming = Settings.Get_node_naming();
            this.node_naming_start_index = Settings.Get_node_naming_start_index();
        }

        public bool Is_Draw()
        {
            return this.is_draw;
        }


        protected List<Point> Calculate_Node_Points(int node_count, int draw_diametr, Point draw_center)
        {
            double curr_angel;
            double x;
            double y;
            List<Point> node_points = new List<Point>();

            for (int i = 0; i < node_count; i++)
            {
                curr_angel = 180 - 360 / (double)node_count * i;
                x = draw_center.X + draw_diametr / 2 * Math.Sin(Math.PI * curr_angel / 180);
                y = draw_center.Y + draw_diametr / 2 * Math.Cos(Math.PI * curr_angel / 180);
                node_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            }

            return node_points;
        }


        protected Point Calculate_Center_Graph()
        {
            return new Point(this.bmp_size.Width / 2, this.bmp_size.Height / 2);
        }

        public virtual Bitmap Draw_Graph(int node_count, List<int> generators) 
        {
            this.bmp = new Bitmap(bmp_size.Width, bmp_size.Height);
            this.bmp.SetResolution(500, 500);
            graph = Graphics.FromImage(this.bmp);
            graph.Clear(this.back_color_graph);
            return bmp;
        }

        public abstract Bitmap Draw_Route(string route, int node_count, List<int> generators);

        public abstract Bitmap Draw_Selected_Node(Size bmp_size, Point mouse_location, int node_count, List<int> generators);

        protected abstract int Calculate_Diametr();

        public PictureGraph CreatePictureGraphInstance(GraphType graphType, string buffer)
        {
            switch (graphType)
            {
                case GraphType.Circulant:
                    return new PictureGraphCirculant();
                case GraphType.Mesh:
                    return new PictureGraphMesh();
                case GraphType.Torus:
                    return new PictureGraphTorus();
                default:
                    throw new Exception("Unsupported graph type");
            }
        }

        public PictureGraph CreatePictureGraphFromBuffer(string buffer)
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
                    graphType = GraphType.Mesh;
                    break;
                case "t":
                case "T":
                    graphType = GraphType.Torus;
                    break;
                default:
                    throw new Exception("Incorrect topology");
            }

            return CreatePictureGraphInstance(graphType, buffer);
        }
    }
}
