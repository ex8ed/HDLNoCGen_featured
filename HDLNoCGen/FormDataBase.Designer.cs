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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_data_base));
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
            this.dataGridViewDataBase.Location = new System.Drawing.Point(13, 63);
            this.dataGridViewDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.RowHeadersWidth = 51;
            this.dataGridViewDataBase.Size = new System.Drawing.Size(1038, 476);
            this.dataGridViewDataBase.TabIndex = 0;
            // 
            // signature
            // 
            this.signature.HeaderText = "Сигнатура";
            this.signature.MinimumWidth = 6;
            this.signature.Name = "signature";
            this.signature.Width = 125;
            // 
            // algMarsh
            // 
            this.algMarsh.HeaderText = "Алгоритм маршрутизации";
            this.algMarsh.MinimumWidth = 6;
            this.algMarsh.Name = "algMarsh";
            this.algMarsh.Width = 125;
            // 
            // countRegisters
            // 
            this.countRegisters.HeaderText = "Количество регистров";
            this.countRegisters.MinimumWidth = 6;
            this.countRegisters.Name = "countRegisters";
            this.countRegisters.Width = 125;
            // 
            // Form_data_base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dataGridViewDataBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_data_base";
            this.Text = "База данных";
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