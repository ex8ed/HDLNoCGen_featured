using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;

namespace HDL_NoC_CodeGen
{
    public static class Settings
    {
        public static string settings_file_name = "settings.json";
        public static string algorithms_file_name = "algorithms.json";

        public static int back_color_graph { get; set; }              // фон, на котором отрисовывается граф
        public static bool black_graph_color { get; set; }            // черно-белая отрисовка графа
        public static bool alternative_draw_graph { get; set; }       // отрисовка образующих эллипсом
        public static int pen_node_color { get; set; }                // цвет, которым рисуются узлы и основная образующая
        public static int pen_node_width { get; set; }                // ширина линий, которыми рисуются узлы и образующие
        public static int vertex_size { get; set; }                   // размер отрисовки вершин (диаметр окружности)
        public static string node_naming_font_name { get; set; }      // название шрифта, которым подписываются узлы
        public static int node_naming_font_size { get; set; }         // размер шрифта, которым подписываются узлы
        public static int node_naming_brush_color { get; set; }       // цвет шрифта, которым подписываются узлы
        public static bool node_naming { get; set; }                  // нумерация узлов графа
        public static int node_naming_start_index { get; set; }       // начало нумерации с 0 или с 1 - соответствует записанному числу
        public static int node_naming_interval { get; set; }          // интервал нумерации узлов
        public static int node_naming_string_offset { get; set; }     // смещение подписи узлв от центра узла
        public static int route_color { get; set; }                  // цвет отрисовки маршрута
        public static int route_width { get; set; }                  // щирина линии, которой отрисовывается маршрут

        public static int error_iterations_count { get; set; }        // количество шагов маршрута, после которого считать, что алгоритм не может построить
                                                                      // в форме настрое этого параметра пока нет 
        public static string quartus_folder_path { get; set; }
        public static string project_folder_path { get; set; }
        public static string data_base_path { get; set; }

        public static bool[] circulant_algorithms_checked { get; set; }
        public static bool[] mesh_algorithms_checked { get; set; }
        public static bool[] torus_algorithms_checked { get; set; }

        // добавить нужные поля и функции для их установки и получения

        public static void Load()
        {
            try
            {
                string json = File.ReadAllText(settings_file_name);
                SettingsSerializer serializer = JsonSerializer.Deserialize<SettingsSerializer>(json);

                var source_fields = serializer.GetType().GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
                var destination_fields = typeof(Settings).GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (var source_field in source_fields)
                {
                    var destination_field = destination_fields.Single(p => p.Name == source_field.Name);

                    destination_field.SetValue(serializer, source_field.GetValue(serializer));
                }
            }
            catch
            {
                back_color_graph = -1;
                black_graph_color = false;
                alternative_draw_graph = false;
                pen_node_color = -16777216;
                pen_node_width = 5;
                vertex_size = 30;
                node_naming_font_name = "Arial";
                node_naming_font_size = 7;
                node_naming_brush_color = -16777216;
                node_naming = true;
                node_naming_start_index = 0;
                node_naming_interval = 1;
                node_naming_string_offset = 50;
                route_color = -10496;
                route_width = 5;
                error_iterations_count = 30;
                quartus_folder_path = " ";
                project_folder_path = " ";
                data_base_path = " ";

                circulant_algorithms_checked = new bool[] { false, false, false, false };
                mesh_algorithms_checked = new bool[] { false, false };
                torus_algorithms_checked = new bool[] { false };
            }
        }

        public static void Save()
        {
            SettingsSerializer serializer = new SettingsSerializer();

            var destination_fields = serializer.GetType().GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            var source_fields = typeof(Settings).GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var destination_field in destination_fields)
            {
                var source_field = source_fields.Single(p => p.Name == destination_field.Name);

                destination_field.SetValue(serializer, source_field.GetValue(null));
            }

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(serializer, options);
            File.WriteAllText(settings_file_name, json);
        }

        public static int Get_back_color_graph()
        {
            return back_color_graph;
        }

        public static bool Get_black_graph_color()
        {
            return black_graph_color;
        }

        public static bool Get_alternative_draw_graph()
        {
            return alternative_draw_graph;
        }

        public static bool Get_draw_graph()
        {
            return alternative_draw_graph;
        }

        public static int Get_pen_node_color()
        {
            return pen_node_color;
        }

        public static int Get_pen_node_width()
        {
            return pen_node_width;
        }

        public static int Get_vertex_size()
        {
            return vertex_size;
        }

        public static string Get_node_naming_font_name()
        {
            return node_naming_font_name;
        }

        public static int Get_node_naming_font_size()
        {
            return node_naming_font_size;
        }

        public static int Get_node_naming_brush_color()
        {
            return node_naming_brush_color;
        }

        public static bool Get_node_naming()
        {
            return node_naming;
        }

        public static int Get_node_naming_start_index()
        {
            return node_naming_start_index;
        }

        public static int Get_node_naming_string_offset()
        {
            return node_naming_string_offset;
        }

        public static int Get_node_naming_interval()
        {
            return node_naming_interval;
        }

        public static int Get_route_color()
        {
            return route_color;
        }

        public static int Get_route_width()
        {
            return route_width;
        }

        public static int Get_error_iterations_count()
        {
            return error_iterations_count;
        }
        public static string Get_path_to_quartus()
        {
            return quartus_folder_path;
        }
        public static string Get_project_path()
        {
            return project_folder_path;
        }
        public static string Get_path_to_data_base()
        {
            return data_base_path;
        }
        public static bool Get_checked_routing_algorithms_circulant(int index)
        {
            return circulant_algorithms_checked[index];
        }

        public static bool Get_checked_routing_algorithms_mesh(int index)
        {
            return mesh_algorithms_checked[index];
        }

        public static bool Get_checked_routing_algorithms_torus(int index)
        {
            return torus_algorithms_checked[index];
        }

        public static void Set_back_color_graph(int color)
        {
            back_color_graph = color;
        }

        public static void Set_black_graph_color(bool graph_color)
        {
            black_graph_color = graph_color;
        }

        public static void Set_alternative_draw_graph(bool alternative_draw)
        {
            alternative_draw_graph = alternative_draw;
        }

        public static void Set_pen_node_color(int color)
        {
            pen_node_color = color;
        }

        public static void Set_pen_node_width(int width)
        {
            pen_node_width = width;
        }

        public static void Set_vertex_size(int size)
        {
            vertex_size = size;
        }

        public static void Set_node_naming_font_name(string name)
        {
            node_naming_font_name = name;
        }

        public static void Set_node_naming_font_size(int size)
        {
            node_naming_font_size = size;
        }

        public static void Set_node_naming_brush_color(int color)
        {
            node_naming_brush_color = color;
        }

        public static void Set_node_naming(bool naming)
        {
            node_naming = naming;
        }

        public static void Set_node_naming_start_index(int index)
        {
            node_naming_start_index = index;
        }

        public static void Set_node_naming_string_offset(int string_offset)
        {
            node_naming_string_offset = string_offset;
        }

        public static void Set_node_naming_interval(int naming_interval)
        {
            node_naming_interval = naming_interval;
        }

        public static void Set_route_color(int color)
        {
            route_color = color;
        }

        public static void Set_route_width(int width)
        {
            route_width = width;
        }

        public static void Set_error_iterations_count(int iterations_count)
        {
            error_iterations_count = iterations_count;
        }
        public static void Set_path_to_quartus(string way_to_quartus)
        {
            quartus_folder_path = way_to_quartus;
        }
        public static void Set_project_path(string project_path)
        {
            project_folder_path = project_path;
        }
        public static void Set_path_to_data_base(string way_to_data_base)
        {
            data_base_path = way_to_data_base;
        }
        public static void Set_checked_routing_algorithms_circulant(int index, bool state)
        {
            circulant_algorithms_checked[index] = state;
        }
        public static void Set_checked_routing_algorithms_mesh(int index, bool state)
        {
            mesh_algorithms_checked[index] = state;
        }

        public static void Set_checked_routing_algorithms_torus(int index, bool state)
        {
            torus_algorithms_checked[index] = state;
        }

    }

    public class SettingsSerializer
    {
        public int back_color_graph { get; set; }              // фон, на котором отрисовывается граф
        public bool black_graph_color { get; set; }            // черно-белая отрисовка графа
        public bool alternative_draw_graph { get; set; }       // отрисовка образующих эллипсом
        public int pen_node_color { get; set; }                // цвет, которым рисуются узлы и основная образующая
        public int pen_node_width { get; set; }                // ширина линий, которыми рисуются узлы и образующие
        public int vertex_size { get; set; }                   // размер отрисовки вершин (диаметр окружности)
        public string node_naming_font_name { get; set; }      // название шрифта, которым подписываются узлы
        public int node_naming_font_size { get; set; }         // размер шрифта, которым подписываются узлы
        public int node_naming_brush_color { get; set; }       // цвет шрифта, которым подписываются узлы
        public bool node_naming { get; set; }                  // нумерация узлов графа
        public int node_naming_start_index { get; set; }       // начало нумерации с 0 или с 1 - соответствует записанному числу
        public int node_naming_interval { get; set; }          // интервал нумерации узлов
        public int node_naming_string_offset { get; set; }     // смещение подписи узлв от центра узла
        public int route_color { get; set; }                   // цвет отрисовки маршрута
        public int route_width { get; set; }                  // щирина линии, которой отрисовывается маршрут

        public int error_iterations_count { get; set; }        // количество шагов маршрута, после которого считать, что алгоритм не может построить
                                                               // в форме настрое этого параметра пока нет 
        public string quartus_folder_path { get; set; }
        public string project_folder_path { get; set; }
        public string data_base_path { get; set; }

        public bool[] circulant_algorithms_checked { get; set; }
        public bool[] mesh_algorithms_checked { get; set; }
        public bool[] torus_algorithms_checked { get; set; }

        public SettingsSerializer()
        {
            back_color_graph = -1;
            black_graph_color = false;
            alternative_draw_graph = false;
            pen_node_color = -16777216;
            pen_node_width = 5;
            vertex_size = 30;
            node_naming_font_name = "Arial";
            node_naming_font_size = 7;
            node_naming_brush_color = -16777216;
            node_naming = true;
            node_naming_start_index = 0;
            node_naming_interval = 1;
            node_naming_string_offset = 50;
            route_color = -10496;
            route_width = 5;
            error_iterations_count = 30;
            quartus_folder_path = " ";
            project_folder_path = " ";
            data_base_path = " ";

            circulant_algorithms_checked = new bool[] { false, false, false, false };
            mesh_algorithms_checked = new bool[] { false, false };
            torus_algorithms_checked = new bool[] { false };

        }
    }
}
