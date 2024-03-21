using HDLNoCGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace HDL_NoC_CodeGen
{
    static class ProjectGenerator
    {
        //private static string fitmentSummary;

        /*
        public static void initializeDirectory()
        {
            Directory.CreateDirectory($"{Settings.Get_project_path()}");
        }
        public static string getFitmentSummary()
        {
            return fitmentSummary;
        }
        public static void setFitmentSummary(string fitment_summary)
        {
            fitmentSummary = fitment_summary;
        }
        */

        public static void initializeTCL(string project_name, string routing_algorithm, string graph_signature, List<int> generators)
        {
            string top_entity_name = $"top_level_{project_name}";
            string router_name = $"router_{project_name}";

            FileStream fs;
            StreamWriter sw;

            Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");
            fs = new FileStream($"{Settings.Get_project_path()}\\{project_name}\\Setup.tcl", FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            sw.WriteLine($"project_new {project_name} -overwrite");
            sw.WriteLine();
            sw.WriteLine("set_global_assignment -name FAMILY \"Cyclone V\"");
            sw.WriteLine("set_global_assignment -name DEVICE 5CGXFC9E7F35C8");
            sw.WriteLine($"set_global_assignment -name VERILOG_FILE {top_entity_name}.v");
            sw.WriteLine($"set_global_assignment -name VERILOG_FILE {router_name}.v");
            sw.WriteLine($"set_global_assignment -name TOP_LEVEL_ENTITY {top_entity_name}");
            sw.WriteLine();
            sw.WriteLine("load_package flow");
            sw.WriteLine("execute_flow -compile");
            sw.WriteLine();
            sw.WriteLine("project_close");

            sw.Close();
            fs.Close();
        }

        public static void createBat(string project_name)
        {
            FileStream fs;
            StreamWriter sw;

            Directory.CreateDirectory($"{Settings.Get_project_path()}\\{project_name}");
            fs = new FileStream($"{Settings.Get_project_path()}\\{project_name}\\Compile.bat", FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            sw.WriteLine("C:");
            sw.WriteLine("cd \\");
            sw.WriteLine($"cd {Settings.Get_project_path()}\\{project_name}");
            sw.WriteLine($"{Settings.Get_path_to_quartus()}\\quartus_sh -t Setup.tcl");

            sw.Close();
            fs.Close();

        }
    }
}

