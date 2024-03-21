using HDLNoCGen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HDL_NoC_CodeGen
{
    public partial class Form_Main : Form
    {

        PictureGraph pictureGraph;

        Graph graph;

        int size = 3000;

        string selected_route = "";

        List<string> routingAlgorithmsCirculant;
        List<string> routingAlgorithmsMesh;
        List<string> routingAlgorithmsTorus;

        public Form_Main()
        {
            Settings.Load();

            InitializeComponent();

            pictureGraph = new PictureGraphCirculant();
            graph = new GraphCirculant();

            saveFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";



            //tabControl1.TabPages.Remove(tabPage1); // алгоритм дейкстры
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            tabControl1.TabPages.Remove(tabPage6);
            tabControl1.TabPages.Remove(tabPage7);

            routingAlgorithmsCirculant = new List<string>
            {
                "Simple маршрутизация",
                "ROU маршрутизация",
                "APM маршрутизация",
                "APO маршрутизация"
            };
            routingAlgorithmsMesh = new List<string>
            {
                "XY маршрутизация",
                "WestFirst маршрутизация"
            }; 
            routingAlgorithmsTorus = new List<string>
            {
                "XY маршрутизация"
            };

            ButtonCompile.Enabled = false;
        }

        private void Draw_graph()
        {
            pictureGraph.Set_bmp_size(pictureBox1.Size);
            pictureBox1.Image = pictureGraph.Draw_Graph(graph.Get_node_count(), graph.Get_generators());
            GC.Collect();
        }

        private void Draw_route(string route)
        {
            if (pictureGraph!= null)
            {

                pictureBox1.Image = pictureGraph.Draw_Route(route, graph.Get_node_count(), graph.Get_generators());

                GC.Collect();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            try
            {
                if (pictureGraph != null && pictureGraph.Is_Draw())
            {
                Draw_graph();
            }

            if (selected_route != "")
            {
                Draw_route(selected_route);
            }
            }
            catch
            {

            }
            /*
            try
            {
                Draw_graph();
            }
            catch
            {

            }
            try
            {
                Draw_route(selected_route);
            }
            catch
            {

            }
            */

            GC.Collect();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            /* if (pictureGraph.Is_Draw())
             {
                 Point mouse_location = new Point(e.X, e.Y);
                 pictureBox1.Image = pictureGraph.Draw_Selected_Node(pictureBox1.Size, mouse_location, graph.Get_node_count(), graph.Get_generators());
             }*/
        }

        private void View_route(List<List<int>> route_list, ListView listView)
        {
            int route_length = 0; // длина маршрута
            string route_name = "";
            string route;
            List<int> buff_list;
            ListViewItem item;

            listView.Items.Clear();

            try
            {
                if (route_list != null)
                {
                    for (int i = 0; i < route_list.Count; i++)
                    {
                        if (route_list[i] != null)
                        {
                            route = "";
                            buff_list = new List<int>(route_list[i]);

                            route_name = route_list[i][0].ToString() + "-";
                            for (int j = 0; j < route_list[i].Count; j++)
                            {
                                route += route_list[i][j].ToString() + "-";
                            }
                            route_name += route_list[i][route_list[i].Count - 1].ToString();
                            route = route.Remove(route.Length - 1);

                            item = new ListViewItem(route_name, i - 1);
                            item.SubItems.Add(route);

                            route_length = 0;
                            for (int k = 0; k < route.Length - 1; k++) // вычисление длины маршрута
                            {
                                if (route[k].Equals('-'))
                                {
                                    route_length++;
                                }
                            }
                            item.SubItems.Add(route_length.ToString());
                            listView.Items.Add(item);
                        }
                        else
                        {
                            MessageBox.Show("Элемент внутри route_list равен null.", "Ошибка", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("route_list равен null.", "Ошибка", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Общая ошибка", MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void listView_deikstra_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_Deikstra.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();

        }  // вывод выбранного маршрута дейкстра алгоритма

        private void listView_circle_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_Simple.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        } // вывод выбранного маршрута простого алгоритма

        private void listView_routes_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_ROU.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        } // вывод выбранного маршрута адаптивного алгоритма

        private void listView_APM_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_APM.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        }  // вывод выбранного маршрута алгоритма парной маршрутизации АПМ

        private void listView_APO_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_APO.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        }

        private void Show_efficient()
        {
            int selected_tab = tabControl1.SelectedIndex;
            GraphCirculant graphCirculant = graph as GraphCirculant;
            GraphMesh graphMesh = graph as GraphMesh;
            GraphTorus graphTorus = graph as GraphTorus;
            switch (selected_tab)
            {
                case 0:
                    label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_deikstra();
                    break;
                case 1:
                    label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_simple();
                    break;
                case 2:
                    label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_ROU();
                    break;
                case 3:
                    label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_APM();
                    break;
                case 4:
                    label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_APO();
                    break;
                case 5:
                    label_efficiency_algorithm.Text = "E = " + graphMesh.getXY_Efficiency();
                    break;
                case 6:
                    label_efficiency_algorithm.Text = "E = " + graphMesh.getWestFirstEfficiency();
                    break;

            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Save_grapg_image_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = null;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    Bitmap save_bmp = null;
                    Bitmap save_bmp2 = null;

                    try
                    {
                        pictureGraph.Set_bmp_size(new Size(size, size));
                        save_bmp = pictureGraph.Draw_Graph(graph.Get_node_count(), graph.Get_generators());
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        save_bmp = pictureGraph.Draw_Route(selected_route, graph.Get_node_count(), graph.Get_generators());
                    }
                    catch (Exception)
                    {

                    }
                    if (save_bmp != null)
                    {
                        save_bmp2 = save_bmp.Clone(new Rectangle(0, 0, size, size), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        save_bmp.Dispose();
                        GC.Collect();
                        save_bmp2.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);

                        save_bmp2.Dispose();
                        GC.Collect();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Описание топологии не было задано или не было произведено создание топологии.", "Ошибка сохранения изображения", System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                string selected_tab = tabControl1.SelectedTab.Name;
                GraphCirculant graphCirculant = graph as GraphCirculant;
                GraphMesh graphMesh = graph as GraphMesh;
                GraphTorus graphTorus = graph as GraphTorus;
                switch (selected_tab)
                {
                    case "tabPage1":
                        label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_deikstra();
                        break;
                    case "tabPage2":
                        label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_simple();
                        break;
                    case "tabPage3":
                        label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_ROU();
                        break;
                    case "tabPage4":
                        label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_APM();
                        break;
                    case "tabPage5":
                        label_efficiency_algorithm.Text = "E = " + graphCirculant.Calculate_efficiency_APO();
                        break;
                    case "tabPage6":
                        if (graphTorus != null)
                        {
                            label_efficiency_algorithm.Text = "E = " + graphTorus.getXY_Efficiency();
                        }
                        else if (graphMesh != null)
                        {
                            label_efficiency_algorithm.Text = "E = " + graphMesh.getXY_Efficiency();
                        }
                        break;
                    case "tabPage7":
                        label_efficiency_algorithm.Text = "E = " + graphMesh.getWestFirstEfficiency();
                        break;
                }
            }
            catch
            {

            }

            GC.Collect();
        }

        private void ToolStripMenuItemm_Generate_pair_net_connection_file_Click(object sender, EventArgs e)
        {
            try
            {
                VerilogGenerator.Generate_pair_net_connection_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItemm_Generate_pair_select_data_file_Click(object sender, EventArgs e)
        {
            try
            {
                VerilogGenerator.Generate_pair_select_data_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            if (form_Settings.ShowDialog() == DialogResult.OK)
            {
                pictureGraph.Update_Draw_Settings();
                if (pictureGraph.Is_Draw())
                {
                    this.Draw_graph();
                }
            }

            GC.Collect();
        }

        private void ToolStripMenuItem1_routing_Settings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void загрузитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void списокМоделированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void нарисоватьМаршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Draw_graph();
                Draw_route(textBox_topology_signature.Text);
                selected_route = textBox_topology_signature.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Не было произведено создание топологии. \nОтрисовка маршрута невозможна", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }

        private void BuildTopology_Click(object sender, EventArgs e)
        {
            try
            {
                listView_Deikstra.Items.Clear();
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage7);
                ButtonCompile.Enabled = false;
                string buffer = textBox_topology_signature.Text.Trim();
                graph = graph.CreateGraphFromBuffer(buffer) as Graph;
                pictureGraph = pictureGraph.CreatePictureGraphFromBuffer(buffer);
                Draw_graph();
            }
            catch(System.Exception)
            {
                MessageBox.Show("Описание топологии не было задано или задано некорректно.", "Ошибка создания топологии", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();

        }

        private void textBox_topology_signature_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == (Keys)13)
            {
                // Enter key pressed
                BuildTopology_Click(sender, e);
            }
        }

        private void CreateMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listView_Deikstra.Items.Clear();
                string buffer = textBox_topology_signature.Text.Trim();
                graph = graph.CreateGraphFromBuffer(buffer) as Graph;
            }
            catch
            {
                MessageBox.Show("Описание топологии не было задано или задано некорректно.", "Ошибка создания топологии", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ButtonCompile_Click(object sender, EventArgs e)
        {
            if (graph.id() == Graph.GraphType.Circulant)
            {
                FormQuartusCompilaton compilaton_form = new FormQuartusCompilaton(graph, routingAlgorithmsCirculant);
                compilaton_form.Show();
            }
            else if (graph.id() == Graph.GraphType.Mesh)
            {
                FormQuartusCompilaton compilaton_form = new FormQuartusCompilaton(graph, routingAlgorithmsMesh);
                compilaton_form.Show();
            }
            else if (graph.id() == Graph.GraphType.Torus)
            {
                FormQuartusCompilaton compilaton_form = new FormQuartusCompilaton(graph, routingAlgorithmsTorus);
                compilaton_form.Show();
            }

            GC.Collect();
        }

        private void ButtonRouting_Click(object sender, EventArgs e)
        {
            if (graph.id() == Graph.GraphType.Circulant)
            {
                try
                {
                    GraphCirculant circulant = graph as GraphCirculant;

                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    tabControl1.TabPages.Remove(tabPage7);

                    View_route(circulant.Generate_deikstra_routing(), listView_Deikstra);
                    label_diam_graph.Text = "D=" + circulant.Calculate_diameter().ToString();

                    if (Settings.Get_checked_routing_algorithms_circulant(0))
                    {
                        tabControl1.TabPages.Add(tabPage2);
                        View_route(circulant.Generate_Simple_routing(), listView_Simple);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_Simple.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_Simple.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_Simple.Items[j].SubItems[2].Text) > circulant.Get_diameter())
                            {
                                listView_Simple.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage2);
                    }
                    if (Settings.Get_checked_routing_algorithms_circulant(1))
                    {
                        tabControl1.TabPages.Add(tabPage3);
                        View_route(circulant.Generate_ROU_routing(), listView_ROU);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_ROU.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_ROU.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_ROU.Items[j].SubItems[2].Text) > circulant.Get_diameter())
                            {
                                listView_ROU.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage3);
                    }
                    if (Settings.Get_checked_routing_algorithms_circulant(2))
                    {
                        tabControl1.TabPages.Add(tabPage4);
                        View_route(circulant.Generate_APM_routing(), listView_APM);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_APM.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_APM.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_APM.Items[j].SubItems[2].Text) > circulant.Get_diameter())
                            {
                                listView_APM.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage4);
                    }
                    if (Settings.Get_checked_routing_algorithms_circulant(3))
                    {
                        tabControl1.TabPages.Add(tabPage5);
                        View_route(circulant.Generate_APO_routing(), listView_APO);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_APO.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_APO.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_APO.Items[j].SubItems[2].Text) > circulant.Get_diameter())
                            {
                                listView_APO.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage5);
                    }

                    ButtonCompile.Enabled = true;

                }
                catch
                {
                    MessageBox.Show(graph.Get_error_message(), "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
            else if (graph.id() == Graph.GraphType.Mesh)
            {
                try
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    tabControl1.TabPages.Remove(tabPage7);

                    GraphMesh graphMesh = graph as GraphMesh;
                    View_route(graphMesh.Generate_deikstra_routing(), listView_Deikstra);

                    if (Settings.Get_checked_routing_algorithms_mesh(0))
                    {
                        tabControl1.TabPages.Add(tabPage6);
                        View_route(graphMesh.Generate_XY_routing(), listView_XY);
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage6);
                    }
                    if (Settings.Get_checked_routing_algorithms_mesh(1))
                    {
                        tabControl1.TabPages.Add(tabPage7);
                        View_route(graphMesh.Generate_westFirst_routing(), listView_WestFirst);
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage7);
                    }
                    //label_diam_graph.Text = "D=" + graph.Calculate_diameter().ToString();

                    //if (ToolStripMenuItem_routing_simple.Checked)
                    {
                        //     View_route(graphMesh.Generate_westFirst_routing(), listView_Simple);

                    }

                    ButtonCompile.Enabled = true;

                }
                catch
                {
                    MessageBox.Show(graph.Get_error_message(), "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
            else if (graph.id() == Graph.GraphType.Torus)
            {
                try
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage3);
                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    tabControl1.TabPages.Remove(tabPage6);
                    tabControl1.TabPages.Remove(tabPage7);

                    GraphTorus torisInterface = graph as GraphTorus;
                    View_route(torisInterface.Generate_deikstra_routing(), listView_Deikstra);

                    if (Settings.Get_checked_routing_algorithms_torus(0))
                    {
                        tabControl1.TabPages.Add(tabPage6);
                        View_route(torisInterface.Generate_XY_routing(), listView_XY);
                    }
                    else
                    {
                        tabControl1.TabPages.Remove(tabPage6);
                    }
                    //label_diam_graph.Text = "D=" + graph.Calculate_diameter().ToString();

                    //if (ToolStripMenuItem_routing_simple.Checked)
                    {
                        //     View_route(graphMesh.Generate_westFirst_routing(), listView_Simple);

                    }

                    ButtonCompile.Enabled = true;

                }
                catch
                {
                    MessageBox.Show(graph.Get_error_message(), "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
            }


            GC.Collect();
        }

        private void симуляцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            form_Settings.treeView1_Preselect(1);
            if (form_Settings.ShowDialog() == DialogResult.OK)
            {
                pictureGraph.Update_Draw_Settings();
                if (pictureGraph.Is_Draw())
                {
                    this.Draw_graph();
                }
            }

            GC.Collect();
        }

        private void ToolStripMenuItemDataBase_Click(object sender, EventArgs e)
        {
            Form_data_base form_Data_Base = new Form_data_base();
            form_Data_Base.ShowDialog();
        }
    }
}