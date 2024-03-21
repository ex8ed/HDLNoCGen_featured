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
            int rowCount = 5;
            int columnCount = 3;

            dataGridViewDataBase.Rows.Clear();
            Random random = new Random();

            for (int row = 0; row < rowCount; row++)
            {
                dataGridViewDataBase.Rows.Add();

                for (int col = 0; col < columnCount; col++)
                {
                    dataGridViewDataBase.Rows[row].Cells[col].Value = random.Next(1, 100);
                }
            }
        }
    }
}
