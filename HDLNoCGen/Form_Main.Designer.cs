using System;

namespace HDL_NoC_CodeGen
{
    partial class Form_Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_node_count = new System.Windows.Forms.Label();
            this.textBox_topology_signature = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listView_ROU = new System.Windows.Forms.ListView();
            this.column_destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_route = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_l = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_diam_graph = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_Deikstra = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_Simple = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView_APM = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView_APO = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.listView_XY = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.listView_WestFirst = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_efficiency_algorithm = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.симуляцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonCompile = new System.Windows.Forms.Button();
            this.ButtonRouting = new System.Windows.Forms.Button();
            this.BuildTopology = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(18, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 593);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1016, 593);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label_node_count
            // 
            this.label_node_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_node_count.AutoSize = true;
            this.label_node_count.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_node_count.Location = new System.Drawing.Point(1042, 31);
            this.label_node_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_node_count.Name = "label_node_count";
            this.label_node_count.Size = new System.Drawing.Size(77, 16);
            this.label_node_count.TabIndex = 2;
            this.label_node_count.Text = "Топология";
            // 
            // textBox_topology_signature
            // 
            this.textBox_topology_signature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_topology_signature.Location = new System.Drawing.Point(1107, 28);
            this.textBox_topology_signature.Margin = new System.Windows.Forms.Padding(4, 5, 4, 0);
            this.textBox_topology_signature.Name = "textBox_topology_signature";
            this.textBox_topology_signature.Size = new System.Drawing.Size(201, 22);
            this.textBox_topology_signature.TabIndex = 4;
            this.textBox_topology_signature.DoubleClick += new System.EventHandler(this.BuildTopology_Click);
            this.textBox_topology_signature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_topology_signature_KeyDown);
            // 
            // listView_ROU
            // 
            this.listView_ROU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ROU.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_destination,
            this.column_route,
            this.column_l});
            this.listView_ROU.FullRowSelect = true;
            this.listView_ROU.GridLines = true;
            this.listView_ROU.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ROU.HideSelection = false;
            this.listView_ROU.Location = new System.Drawing.Point(0, 0);
            this.listView_ROU.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_ROU.MultiSelect = false;
            this.listView_ROU.Name = "listView_ROU";
            this.listView_ROU.Size = new System.Drawing.Size(331, 479);
            this.listView_ROU.TabIndex = 16;
            this.listView_ROU.UseCompatibleStateImageBehavior = false;
            this.listView_ROU.View = System.Windows.Forms.View.Details;
            this.listView_ROU.ItemActivate += new System.EventHandler(this.listView_routes_ItemActivate);
            // 
            // column_destination
            // 
            this.column_destination.Text = "A-B";
            this.column_destination.Width = 40;
            // 
            // column_route
            // 
            this.column_route.Text = "Маршрут";
            this.column_route.Width = 233;
            // 
            // column_l
            // 
            this.column_l.Text = "L";
            this.column_l.Width = 30;
            // 
            // label_diam_graph
            // 
            this.label_diam_graph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_diam_graph.AutoSize = true;
            this.label_diam_graph.Location = new System.Drawing.Point(1074, 570);
            this.label_diam_graph.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_diam_graph.Name = "label_diam_graph";
            this.label_diam_graph.Size = new System.Drawing.Size(24, 16);
            this.label_diam_graph.TabIndex = 17;
            this.label_diam_graph.Text = "D=";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Location = new System.Drawing.Point(1050, 56);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(343, 513);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView_Deikstra);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(335, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Дейкстра";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView_Deikstra
            // 
            this.listView_Deikstra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Deikstra.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Deikstra.FullRowSelect = true;
            this.listView_Deikstra.GridLines = true;
            this.listView_Deikstra.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Deikstra.HideSelection = false;
            this.listView_Deikstra.Location = new System.Drawing.Point(0, 0);
            this.listView_Deikstra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_Deikstra.MultiSelect = false;
            this.listView_Deikstra.Name = "listView_Deikstra";
            this.listView_Deikstra.Size = new System.Drawing.Size(335, 484);
            this.listView_Deikstra.TabIndex = 17;
            this.listView_Deikstra.UseCompatibleStateImageBehavior = false;
            this.listView_Deikstra.View = System.Windows.Forms.View.Details;
            this.listView_Deikstra.ItemActivate += new System.EventHandler(this.listView_deikstra_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "A-B";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Маршрут";
            this.columnHeader2.Width = 233;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "L";
            this.columnHeader3.Width = 30;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_Simple);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(335, 484);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Почасовой";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_Simple
            // 
            this.listView_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Simple.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView_Simple.FullRowSelect = true;
            this.listView_Simple.GridLines = true;
            this.listView_Simple.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Simple.HideSelection = false;
            this.listView_Simple.Location = new System.Drawing.Point(0, 0);
            this.listView_Simple.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_Simple.MultiSelect = false;
            this.listView_Simple.Name = "listView_Simple";
            this.listView_Simple.Size = new System.Drawing.Size(338, 484);
            this.listView_Simple.TabIndex = 17;
            this.listView_Simple.UseCompatibleStateImageBehavior = false;
            this.listView_Simple.View = System.Windows.Forms.View.Details;
            this.listView_Simple.ItemActivate += new System.EventHandler(this.listView_circle_ItemActivate);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "A-B";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Маршрут";
            this.columnHeader5.Width = 233;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "L";
            this.columnHeader6.Width = 30;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView_ROU);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(335, 484);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "ROU";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView_APM);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage4.Size = new System.Drawing.Size(335, 484);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "АПМ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView_APM
            // 
            this.listView_APM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_APM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView_APM.FullRowSelect = true;
            this.listView_APM.GridLines = true;
            this.listView_APM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_APM.HideSelection = false;
            this.listView_APM.Location = new System.Drawing.Point(0, 0);
            this.listView_APM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_APM.MultiSelect = false;
            this.listView_APM.Name = "listView_APM";
            this.listView_APM.Size = new System.Drawing.Size(339, 474);
            this.listView_APM.TabIndex = 17;
            this.listView_APM.UseCompatibleStateImageBehavior = false;
            this.listView_APM.View = System.Windows.Forms.View.Details;
            this.listView_APM.ItemActivate += new System.EventHandler(this.listView_APM_ItemActivate);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "A-B";
            this.columnHeader7.Width = 40;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Маршрут";
            this.columnHeader8.Width = 233;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "L";
            this.columnHeader9.Width = 30;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView_APO);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage5.Size = new System.Drawing.Size(335, 484);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "АПО";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView_APO
            // 
            this.listView_APO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_APO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView_APO.FullRowSelect = true;
            this.listView_APO.GridLines = true;
            this.listView_APO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_APO.HideSelection = false;
            this.listView_APO.Location = new System.Drawing.Point(0, 0);
            this.listView_APO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_APO.MultiSelect = false;
            this.listView_APO.Name = "listView_APO";
            this.listView_APO.Size = new System.Drawing.Size(339, 484);
            this.listView_APO.TabIndex = 18;
            this.listView_APO.UseCompatibleStateImageBehavior = false;
            this.listView_APO.View = System.Windows.Forms.View.Details;
            this.listView_APO.ItemActivate += new System.EventHandler(this.listView_APO_ItemActivate);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "A-B";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Маршрут";
            this.columnHeader11.Width = 233;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "L";
            this.columnHeader12.Width = 30;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.listView_XY);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(335, 484);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "XY";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // listView_XY
            // 
            this.listView_XY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_XY.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.listView_XY.FullRowSelect = true;
            this.listView_XY.GridLines = true;
            this.listView_XY.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_XY.HideSelection = false;
            this.listView_XY.Location = new System.Drawing.Point(-4, 0);
            this.listView_XY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_XY.MultiSelect = false;
            this.listView_XY.Name = "listView_XY";
            this.listView_XY.Size = new System.Drawing.Size(339, 476);
            this.listView_XY.TabIndex = 19;
            this.listView_XY.UseCompatibleStateImageBehavior = false;
            this.listView_XY.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "A-B";
            this.columnHeader13.Width = 40;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Маршрут";
            this.columnHeader14.Width = 233;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "L";
            this.columnHeader15.Width = 30;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.listView_WestFirst);
            this.tabPage7.Location = new System.Drawing.Point(4, 25);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(335, 484);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "WestFirst";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // listView_WestFirst
            // 
            this.listView_WestFirst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_WestFirst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.listView_WestFirst.FullRowSelect = true;
            this.listView_WestFirst.GridLines = true;
            this.listView_WestFirst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_WestFirst.HideSelection = false;
            this.listView_WestFirst.Location = new System.Drawing.Point(-4, 0);
            this.listView_WestFirst.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_WestFirst.MultiSelect = false;
            this.listView_WestFirst.Name = "listView_WestFirst";
            this.listView_WestFirst.Size = new System.Drawing.Size(339, 484);
            this.listView_WestFirst.TabIndex = 19;
            this.listView_WestFirst.UseCompatibleStateImageBehavior = false;
            this.listView_WestFirst.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "A-B";
            this.columnHeader16.Width = 40;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Маршрут";
            this.columnHeader17.Width = 233;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "L";
            this.columnHeader18.Width = 30;
            // 
            // label_efficiency_algorithm
            // 
            this.label_efficiency_algorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_efficiency_algorithm.AutoSize = true;
            this.label_efficiency_algorithm.Location = new System.Drawing.Point(1275, 570);
            this.label_efficiency_algorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_efficiency_algorithm.Name = "label_efficiency_algorithm";
            this.label_efficiency_algorithm.Size = new System.Drawing.Size(23, 16);
            this.label_efficiency_algorithm.TabIndex = 21;
            this.label_efficiency_algorithm.Text = "E=";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.настройкиToolStripMenuItem,
            this.ToolStripMenuItemDataBase,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(15000, 15385);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1405, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьИзображениеToolStripMenuItem});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(59, 24);
            this.ToolStripMenuItem_File.Text = "Файл";
            // 
            // сохранитьИзображениеToolStripMenuItem
            // 
            this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
            this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отображенияToolStripMenuItem,
            this.симуляцииToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // отображенияToolStripMenuItem
            // 
            this.отображенияToolStripMenuItem.Name = "отображенияToolStripMenuItem";
            this.отображенияToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.отображенияToolStripMenuItem.Text = "Отрисовка";
            this.отображенияToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // симуляцииToolStripMenuItem
            // 
            this.симуляцииToolStripMenuItem.Name = "симуляцииToolStripMenuItem";
            this.симуляцииToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.симуляцииToolStripMenuItem.Text = "Симуляция";
            this.симуляцииToolStripMenuItem.Click += new System.EventHandler(this.симуляцииToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemDataBase
            // 
            this.ToolStripMenuItemDataBase.Name = "ToolStripMenuItemDataBase";
            this.ToolStripMenuItemDataBase.Size = new System.Drawing.Size(114, 24);
            this.ToolStripMenuItemDataBase.Text = "Базы данных";
            this.ToolStripMenuItemDataBase.Click += new System.EventHandler(this.ToolStripMenuItemDataBase_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // ButtonCompile
            // 
            this.ButtonCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCompile.Location = new System.Drawing.Point(1234, 591);
            this.ButtonCompile.Name = "ButtonCompile";
            this.ButtonCompile.Size = new System.Drawing.Size(155, 29);
            this.ButtonCompile.TabIndex = 27;
            this.ButtonCompile.Text = "Скомпилировать";
            this.ButtonCompile.UseVisualStyleBackColor = true;
            this.ButtonCompile.Click += new System.EventHandler(this.ButtonCompile_Click);
            // 
            // ButtonRouting
            // 
            this.ButtonRouting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRouting.Location = new System.Drawing.Point(1054, 591);
            this.ButtonRouting.Name = "ButtonRouting";
            this.ButtonRouting.Size = new System.Drawing.Size(174, 29);
            this.ButtonRouting.TabIndex = 28;
            this.ButtonRouting.Text = "Сгенерировать маршруты";
            this.ButtonRouting.UseVisualStyleBackColor = true;
            this.ButtonRouting.Click += new System.EventHandler(this.ButtonRouting_Click);
            // 
            // BuildTopology
            // 
            this.BuildTopology.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildTopology.Location = new System.Drawing.Point(1315, 27);
            this.BuildTopology.Name = "BuildTopology";
            this.BuildTopology.Size = new System.Drawing.Size(74, 21);
            this.BuildTopology.TabIndex = 29;
            this.BuildTopology.Text = "Построить";
            this.BuildTopology.UseVisualStyleBackColor = true;
            this.BuildTopology.Click += new System.EventHandler(this.BuildTopology_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1405, 638);
            this.Controls.Add(this.BuildTopology);
            this.Controls.Add(this.ButtonRouting);
            this.Controls.Add(this.ButtonCompile);
            this.Controls.Add(this.label_efficiency_algorithm);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_diam_graph);
            this.Controls.Add(this.textBox_topology_signature);
            this.Controls.Add(this.label_node_count);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(388, 185);
            this.Name = "Form_Main";
            this.Text = "Визуализация топологий";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_node_count;
        private System.Windows.Forms.TextBox textBox_topology_signature;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListView listView_ROU;
        private System.Windows.Forms.ColumnHeader column_destination;
        private System.Windows.Forms.ColumnHeader column_route;
        private System.Windows.Forms.ColumnHeader column_l;
        private System.Windows.Forms.Label label_diam_graph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView_Deikstra;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label_efficiency_algorithm;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView_Simple;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listView_APM;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView_APO;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListView listView_XY;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ListView listView_WestFirst;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Button ButtonCompile;
        private System.Windows.Forms.Button ButtonRouting;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem симуляцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDataBase;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.Button BuildTopology;
    }
}

