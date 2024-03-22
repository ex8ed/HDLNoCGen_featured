using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDLNoCGen
{
    public partial class Form_data_base : Form
    {
        private DatabaseManager databaseManager;
        public Form_data_base()
        {
            databaseManager = new DatabaseManager("C:\\Users\\anpro\\Documents\\HSE\\HLIMDS_HW\\HDLNoCGen_featured\\database\\hdl_db.db");
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridViewDataBase.Rows.Clear();
            // databaseManager.insertSimulation(0, "CIRCULANT", "ALU", "De1-Soc", 777, 666, 1000, 1, 13, 12, 11);
            // databaseManager.insertDevice(); // check-the results
            var dataTable = databaseManager.getAllSimulations();
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridViewDataBase.Rows.Add(row.ItemArray);
            }

        }

        private void fillGrid(object sender, EventArgs e)
        {
            dataGridViewDataBase.Rows.Clear();
            var dataTable = databaseManager.getAllSimulations();
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridViewDataBase.Rows.Add(row.ItemArray);
            }

        }

        private void fillWithQuery(object sender, EventArgs e)
        {
            dataGridViewDataBase.Rows.Clear();
            string filterString = textBox1.Text;
            var dataTable = databaseManager.getCustomSimulationsQuery(filterString);
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridViewDataBase.Rows.Add(row.ItemArray);
            }
        }
    }
}
