using HDL_NoC_CodeGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

namespace HDLNoCGen
{
    public partial class FormQuartusCompilaton : Form
    {

        private Process process;
        private Graph graph;
        private List<string> routingAlgorithms;
        private List<int> generators;
        private string fitmentSummary;
        private string commandLineText;

        public FormQuartusCompilaton()
        {
            InitializeComponent();
        }
        public FormQuartusCompilaton(Graph graph, List<string> routingAlgorithms)
        {
            InitializeComponent();

            this.graph = graph;
            this.generators = graph.Get_generators();
            this.routingAlgorithms = routingAlgorithms;

            string graph_signature = $"{graph.id()}";

            if (graph.id() == Graph.GraphType.Circulant)
            {
                graph_signature = $"{graph_signature} {graph.Get_node_count()}";
            }

            for (int i = 0; i < generators.Count; i++)
            {
                graph_signature = $"{graph_signature} {generators[i]}";
            }
            labelGraphSignature.Text = graph_signature;

            if (graph.id() == Graph.GraphType.Circulant)
            {
                for (int i = 0; i < routingAlgorithms.Count; i++)
                {
                    if (Settings.Get_checked_routing_algorithms_circulant(i))
                    {
                        comboBoxRoutingAlgorithm.Items.Add(routingAlgorithms[i]);
                    }
                }
            }
            else if (graph.id() == Graph.GraphType.Mesh)
            {
                for (int i = 0; i < routingAlgorithms.Count; i++)
                {
                    if (Settings.Get_checked_routing_algorithms_mesh(i))
                    {
                        comboBoxRoutingAlgorithm.Items.Add(routingAlgorithms[i]);
                    }
                }
            }
            else if (graph.id() == Graph.GraphType.Torus)
            {
                for (int i = 0; i < routingAlgorithms.Count; i++)
                {
                    if (Settings.Get_checked_routing_algorithms_torus(i))
                    {
                        comboBoxRoutingAlgorithm.Items.Add(routingAlgorithms[i]);
                    }
                }
            }
        }

        private static void killProcessAndChildren(int pid)
        {
            if (pid == 0)
            {
                return;
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                killProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }

            GC.Collect();

        }

        private void FormQuartusCompilaton_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                string dialog_text = "Проект находится в процессе компиляии. Все равно закрыть?";
                if (MessageBox.Show(dialog_text, "Компиляция Quartus-проекта", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    killProcessAndChildren(process.Id);
                }
            }

            GC.Collect();

        }

        private void createNet(string project_name, string selected_routing)
        {
            graph.createTopEntity(project_name, selected_routing, $"{Settings.Get_project_path()}\\{project_name}");

            GC.Collect();

        }

        private void createRouter(string project_name, string selected_routing)
        {
            if (selected_routing == "Simple маршрутизация")
            {
                throw new Exception("Реализация данного алгоритма маршрутизации не добавлена");
            }
            else if (selected_routing == "ROU маршрутизация")
            {
                throw new Exception("Реализация данного алгоритма маршрутизации не добавлена");
            }
            else if (selected_routing == "APM маршрутизация")
            {
                throw new Exception("Реализация данного алгоритма маршрутизации не добавлена");
            }
            else if (selected_routing == "APO маршрутизация")
            {
                throw new Exception("Реализация данного алгоритма маршрутизации не добавлена");
            }
            else if (selected_routing == "XY маршрутизация")
            {
                if (graph.id() == Graph.GraphType.Mesh)
                {
                    (graph as GraphMesh).createRouterXY(project_name, $"{Settings.Get_project_path()}\\{project_name}");
                }
                else if (graph.id() == Graph.GraphType.Torus)
                {
                    (graph as GraphTorus).createRouterXY(project_name, $"{Settings.Get_project_path()}\\{project_name}");
                }
            }
            else if (selected_routing == "WestFirst маршрутизация")
            {
                throw new Exception("Реализация данного алгоритма маршрутизации не добавлена");
            }
            else
            {
                throw new Exception("Опечатка в коде");
            }

            GC.Collect();

        }

        private void compileProject(string project_name, string graph_signature, string selected_routing)
        {
            buttonCompile.Enabled = false;

            commandLineText = "";
            fitmentSummary = "";
            textBoxCLI.Text = "";
            textBoxCompilationReport.Text = "";

            ProjectGenerator.initializeTCL(project_name, selected_routing, graph_signature, graph.Get_generators());
            ProjectGenerator.createBat(project_name);

            string bat_path = $"{Settings.Get_project_path()}\\{project_name}\\Compile.bat";

            DataReceivedEventHandler commandLineTextReader = (s, ev) =>
            {
                try
                {
                    if (!String.IsNullOrEmpty(ev.Data))
                    {
                        if (InvokeRequired)
                        {
                            commandLineText += $"{ev.Data}\n";
                            Invoke((Action<string>)textBoxCLI.AppendText, ev.Data + Environment.NewLine);
                        }
                        else
                        {
                            commandLineText += $"{ev.Data}\n";
                            textBoxCLI.AppendText(ev.Data + Environment.NewLine);
                        }
                    }

                }
                catch (Exception)
                {
                    // Form has been closed
                }

                GC.Collect();

            };

            EventHandler processFinishingHandler = (s, ev) =>
            {
                try
                {
                    if (InvokeRequired)
                    {
                        Invoke((Action)(() => labelProcessStatus.Text = "Окончена"));

                        string fitment_summary = "";

                        FileStream fs = new FileStream($"{Settings.Get_project_path()}\\{project_name}\\{project_name}.fit.summary", FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            fitment_summary += $"{line}\n";
                            Invoke((Action)(() => textBoxCompilationReport.AppendText(line)));
                            Invoke((Action)(() => textBoxCompilationReport.AppendText(Environment.NewLine)));
                        }
                        this.fitmentSummary = fitment_summary;

                        sr.Close();
                        fs.Close();

                        Invoke((Action)(() => buttonCompile.Enabled = true));
                    }
                    else
                    {
                        labelProcessStatus.Text = "Finished";

                        string fitment_summary = "";

                        FileStream fs = new FileStream($"{Settings.Get_project_path()}\\{project_name}\\{project_name}.fit.summary", FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);

                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            fitment_summary += $"{line}\n";
                            textBoxCompilationReport.AppendText(line);
                            textBoxCompilationReport.AppendText(Environment.NewLine);
                        }
                        this.fitmentSummary = fitment_summary;

                        sr.Close();
                        fs.Close();

                        buttonCompile.Enabled = true;
                    }
                }
                catch (Exception)
                {
                    // Form has been closed
                }
            };

            process = new Process();
            process.StartInfo.FileName = bat_path;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = true;
            process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding(866);
            process.OutputDataReceived += commandLineTextReader;
            process.Exited += processFinishingHandler;
            
            process.Start();
            process.BeginOutputReadLine();
            labelProcessStatus.Text = "В процессе";

            GC.Collect();

        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            try
            {
                string graph_signature = $"{graph.id()}";
                string selected_routing = $"{comboBoxRoutingAlgorithm.SelectedItem}";

                string project_name = $"{selected_routing.Split(' ')[0]}_{graph_signature}";
                for (int i = 0; i < graph.Get_generators().Count; i++)
                {
                    project_name += $"_{graph.Get_generators()[i]}";
                }

                Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");

                createNet(project_name, selected_routing);
                createRouter(project_name, selected_routing);
                compileProject(project_name, graph_signature, selected_routing);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "debug", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();

        }

        private void ToolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            Form_Settings form_Settings = new Form_Settings();
            if (form_Settings.ShowDialog() == DialogResult.OK)
            {
                Settings.Save();
            }

            GC.Collect();

        }

        private void ToolStripMenuItemTextCLI_Click(object sender, EventArgs e)
        {
            string graph_signature = $"{graph.id()}";
            string selected_routing = $"{comboBoxRoutingAlgorithm.SelectedItem}";

            string project_name = $"{selected_routing.Split(' ')[0]}_{graph_signature}";
            for (int i = 0; i < graph.Get_generators().Count; i++)
            {
                project_name += $"_{graph.Get_generators()[i]}";
            }

            Stream stream;
            SaveFileDialog save_file_dialog = new SaveFileDialog();

            save_file_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save_file_dialog.FilterIndex = 1;
            save_file_dialog.RestoreDirectory = true;
            save_file_dialog.FileName = $"{project_name}_CLI_dump";

            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = save_file_dialog.OpenFile()) != null)
                {
                    byte[] input = Encoding.Default.GetBytes(commandLineText);

                    stream.Write(input, 0, input.Length);
                    stream.Close();
                }
            }
        }

        private void ToolStripMenuItemCompilationReport_Click(object sender, EventArgs e)
        {
            string graph_signature = $"{graph.id()}";
            string selected_routing = $"{comboBoxRoutingAlgorithm.SelectedItem}";

            string project_name = $"{selected_routing.Split(' ')[0]}_{graph_signature}";
            for (int i = 0; i < graph.Get_generators().Count; i++)
            {
                project_name += $"_{graph.Get_generators()[i]}";
            }

            Stream stream;
            SaveFileDialog save_file_dialog = new SaveFileDialog();

            save_file_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save_file_dialog.FilterIndex = 1;
            save_file_dialog.RestoreDirectory = true;
            save_file_dialog.FileName = $"{project_name}_report_dump";

            if (save_file_dialog.ShowDialog() == DialogResult.OK)
            {
                if ((stream = save_file_dialog.OpenFile()) != null)
                {
                    byte[] input = Encoding.Default.GetBytes(fitmentSummary);

                    stream.Write(input, 0, input.Length);
                    stream.Close();
                }
            }

        }

        private void buttonNet_Click(object sender, EventArgs e)
        {
            try
            {
                string graph_signature = $"{graph.id()}";
                string selected_routing = $"{comboBoxRoutingAlgorithm.SelectedItem}";

                string project_name = $"{selected_routing.Split(' ')[0]}_{graph_signature}";
                for (int i = 0; i < graph.Get_generators().Count; i++)
                {
                    project_name += $"_{graph.Get_generators()[i]}";
                }

                Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");

                createNet(project_name, selected_routing);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "debug", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void buttonRouter_Click(object sender, EventArgs e)
        {
            try
            {
                string graph_signature = $"{graph.id()}";
                string selected_routing = $"{comboBoxRoutingAlgorithm.SelectedItem}";

                string project_name = $"{selected_routing.Split(' ')[0]}_{graph_signature}";
                for (int i = 0; i < graph.Get_generators().Count; i++)
                {
                    project_name += $"_{graph.Get_generators()[i]}";
                }

                Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");

                createRouter(project_name, selected_routing);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "debug", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }
    }
}
