using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDLNoCGen
{
    public partial class Form_data_base : Form
    {
        public Form_data_base()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewDataBase.Rows.Clear();
            var databaseManager = new DatabaseManager("C:\\Users\\anpro\\Documents\\HSE\\HLIMDS_HW\\HDLNoCGen_featured\\database\\hdl_db.db");
            var dataTable = databaseManager.getAllSimulations();
            Console.WriteLine(dataTable.Rows.Count);
            dataGridViewDataBase.DataSource = dataTable;

        }


    }
}
