namespace HDLNoCGen
{
    partial class Form_data_base
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewDataBase = new System.Windows.Forms.DataGridView();
            this.signature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.algMarsh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countRegisters = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDataBase
            // 
            this.dataGridViewDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.signature,
            this.algMarsh,
            this.countRegisters});
            this.dataGridViewDataBase.Location = new System.Drawing.Point(12, 131);
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.Size = new System.Drawing.Size(776, 307);
            this.dataGridViewDataBase.TabIndex = 0;
            // 
            // signature
            // 
            this.signature.HeaderText = "Сигнатура";
            this.signature.Name = "signature";
            // 
            // algMarsh
            // 
            this.algMarsh.HeaderText = "Алгоритм маршрутизации";
            this.algMarsh.Name = "algMarsh";
            // 
            // countRegisters
            // 
            this.countRegisters.HeaderText = "Количество регистров";
            this.countRegisters.Name = "countRegisters";
            // 
            // Form_data_base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewDataBase);
            this.Name = "Form_data_base";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDataBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn signature;
        private System.Windows.Forms.DataGridViewTextBoxColumn algMarsh;
        private System.Windows.Forms.DataGridViewTextBoxColumn countRegisters;
    }
}