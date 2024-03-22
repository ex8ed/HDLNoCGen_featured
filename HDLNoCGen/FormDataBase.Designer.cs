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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.configuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.algorithm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.device = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logic_elements = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memory_bits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mult_elements = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDataBase
            // 
            this.dataGridViewDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.configuration,
            this.algorithm,
            this.device,
            this.logic_elements,
            this.pins,
            this.memory_bits,
            this.mult_elements,
            this.plls,
            this.ufms,
            this.adcs});
            this.dataGridViewDataBase.Location = new System.Drawing.Point(13, 63);
            this.dataGridViewDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewDataBase.Name = "dataGridViewDataBase";
            this.dataGridViewDataBase.RowHeadersWidth = 51;
            this.dataGridViewDataBase.Size = new System.Drawing.Size(1035, 476);
            this.dataGridViewDataBase.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(893, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 36);
            this.button2.TabIndex = 2;
            this.button2.Text = "Все симуляции";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(513, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "Запрос ...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(450, 22);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Параметры запроса";
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 47;
            // 
            // configuration
            // 
            this.configuration.HeaderText = "Конфигурация";
            this.configuration.MinimumWidth = 6;
            this.configuration.Name = "configuration";
            this.configuration.Width = 125;
            // 
            // algorithm
            // 
            this.algorithm.HeaderText = "Алгоритм маршрутизации";
            this.algorithm.MinimumWidth = 6;
            this.algorithm.Name = "algorithm";
            this.algorithm.Width = 125;
            // 
            // device
            // 
            this.device.HeaderText = "Устройство";
            this.device.MinimumWidth = 6;
            this.device.Name = "device";
            this.device.Width = 90;
            // 
            // logic_elements
            // 
            this.logic_elements.HeaderText = "Логические элементы";
            this.logic_elements.MinimumWidth = 6;
            this.logic_elements.Name = "logic_elements";
            this.logic_elements.Width = 90;
            // 
            // pins
            // 
            this.pins.HeaderText = "Количество пинов";
            this.pins.MinimumWidth = 6;
            this.pins.Name = "pins";
            this.pins.Width = 90;
            // 
            // memory_bits
            // 
            this.memory_bits.HeaderText = "Количество битов памяти";
            this.memory_bits.MinimumWidth = 6;
            this.memory_bits.Name = "memory_bits";
            // 
            // mult_elements
            // 
            this.mult_elements.HeaderText = "Многототечные блоки";
            this.mult_elements.MinimumWidth = 6;
            this.mult_elements.Name = "mult_elements";
            this.mult_elements.Width = 125;
            // 
            // plls
            // 
            this.plls.HeaderText = "Блоки PLL";
            this.plls.MinimumWidth = 6;
            this.plls.Name = "plls";
            this.plls.Width = 60;
            // 
            // ufms
            // 
            this.ufms.HeaderText = "Блоки UFM";
            this.ufms.MinimumWidth = 6;
            this.ufms.Name = "ufms";
            this.ufms.Width = 60;
            // 
            // adcs
            // 
            this.adcs.HeaderText = "Блоки ADC";
            this.adcs.MinimumWidth = 6;
            this.adcs.Name = "adcs";
            this.adcs.Width = 125;
            // 
            // Form_data_base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridViewDataBase);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_data_base";
            this.Text = "База данных";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDataBase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDataBase;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn configuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn algorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn device;
        private System.Windows.Forms.DataGridViewTextBoxColumn logic_elements;
        private System.Windows.Forms.DataGridViewTextBoxColumn pins;
        private System.Windows.Forms.DataGridViewTextBoxColumn memory_bits;
        private System.Windows.Forms.DataGridViewTextBoxColumn mult_elements;
        private System.Windows.Forms.DataGridViewTextBoxColumn plls;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufms;
        private System.Windows.Forms.DataGridViewTextBoxColumn adcs;
    }
}