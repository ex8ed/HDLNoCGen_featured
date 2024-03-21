namespace HDL_NoC_CodeGen
{
    partial class Form_Settings
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Отрисовка графа");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Симуляция");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Прочее");
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownnode_naming_interval = new System.Windows.Forms.NumericUpDown();
            this.checkBox_alternative_draw_graph = new System.Windows.Forms.CheckBox();
            this.checkBox_graph_color = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_route_size = new System.Windows.Forms.NumericUpDown();
            this.panel_route_color = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown_strinhg_offset = new System.Windows.Forms.NumericUpDown();
            this.textBox_vertex_font = new System.Windows.Forms.TextBox();
            this.button_node_naming_font_select = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_preview = new System.Windows.Forms.Panel();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.numericUpDown_vertex_size = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_edge_thickness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_node_naming_start_index = new System.Windows.Forms.ComboBox();
            this.checkBox_node_naming = new System.Windows.Forms.CheckBox();
            this.panel_backcolor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Settings_mesh_west_first_routing = new System.Windows.Forms.CheckBox();
            this.Settings_torus_XY_routing = new System.Windows.Forms.CheckBox();
            this.Settings_label_routing_torus = new System.Windows.Forms.Label();
            this.Settings_mesh_XY_routing = new System.Windows.Forms.CheckBox();
            this.Settings_label_routing_mesh = new System.Windows.Forms.Label();
            this.Settings_circulant_APO_routing = new System.Windows.Forms.CheckBox();
            this.Settings_circulant_APM_routing = new System.Windows.Forms.CheckBox();
            this.Settings_circulant_ROU_routing = new System.Windows.Forms.CheckBox();
            this.Settings_circulant_simple_routing = new System.Windows.Forms.CheckBox();
            this.Settings_label_routing_circulant = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            this.buttonProjectPath = new System.Windows.Forms.Button();
            this.textBoxDataBase = new System.Windows.Forms.TextBox();
            this.textBoxQuartus = new System.Windows.Forms.TextBox();
            this.addDataBase = new System.Windows.Forms.Button();
            this.buttonQuartusPath = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.button_ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownnode_naming_interval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_route_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_strinhg_offset)).BeginInit();
            this.panel_preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vertex_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_edge_thickness)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(859, 514);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.treeView1.FullRowSelect = true;
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.treeView1.Location = new System.Drawing.Point(3, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            treeNode7.Name = "Display_Graph_Settings";
            treeNode7.Tag = "0";
            treeNode7.Text = "Отрисовка графа";
            treeNode8.Name = "Simulstion_Settings";
            treeNode8.Tag = "1";
            treeNode8.Text = "Симуляция";
            treeNode9.Name = "Other_Settings";
            treeNode9.Tag = "2";
            treeNode9.Text = "Прочее";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(278, 511);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(3, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(577, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.numericUpDownnode_naming_interval);
            this.tabPage1.Controls.Add(this.checkBox_alternative_draw_graph);
            this.tabPage1.Controls.Add(this.checkBox_graph_color);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.numericUpDown_route_size);
            this.tabPage1.Controls.Add(this.panel_route_color);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.numericUpDown_strinhg_offset);
            this.tabPage1.Controls.Add(this.textBox_vertex_font);
            this.tabPage1.Controls.Add(this.button_node_naming_font_select);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.panel_preview);
            this.tabPage1.Controls.Add(this.numericUpDown_vertex_size);
            this.tabPage1.Controls.Add(this.numericUpDown_edge_thickness);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox_node_naming_start_index);
            this.tabPage1.Controls.Add(this.checkBox_node_naming);
            this.tabPage1.Controls.Add(this.panel_backcolor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(25, 4);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(548, 498);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 431);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Интервал нумерации";
            // 
            // numericUpDownnode_naming_interval
            // 
            this.numericUpDownnode_naming_interval.Location = new System.Drawing.Point(11, 454);
            this.numericUpDownnode_naming_interval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownnode_naming_interval.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownnode_naming_interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownnode_naming_interval.Name = "numericUpDownnode_naming_interval";
            this.numericUpDownnode_naming_interval.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownnode_naming_interval.TabIndex = 23;
            this.numericUpDownnode_naming_interval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownnode_naming_interval.ValueChanged += new System.EventHandler(this.numericUpDown_number_interval_ValueChanged);
            // 
            // checkBox_alternative_draw_graph
            // 
            this.checkBox_alternative_draw_graph.AutoSize = true;
            this.checkBox_alternative_draw_graph.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_alternative_draw_graph.Location = new System.Drawing.Point(5, 409);
            this.checkBox_alternative_draw_graph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_alternative_draw_graph.Name = "checkBox_alternative_draw_graph";
            this.checkBox_alternative_draw_graph.Size = new System.Drawing.Size(294, 20);
            this.checkBox_alternative_draw_graph.TabIndex = 22;
            this.checkBox_alternative_draw_graph.Text = "Альтернативная отрисовка образующих";
            this.checkBox_alternative_draw_graph.UseVisualStyleBackColor = true;
            this.checkBox_alternative_draw_graph.CheckedChanged += new System.EventHandler(this.checkBox_alternative_draw_graph_CheckedChanged);
            // 
            // checkBox_graph_color
            // 
            this.checkBox_graph_color.AutoSize = true;
            this.checkBox_graph_color.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_graph_color.Location = new System.Drawing.Point(5, 385);
            this.checkBox_graph_color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_graph_color.Name = "checkBox_graph_color";
            this.checkBox_graph_color.Size = new System.Drawing.Size(229, 20);
            this.checkBox_graph_color.TabIndex = 21;
            this.checkBox_graph_color.Text = "Черно-белая отрисовка графа";
            this.checkBox_graph_color.UseVisualStyleBackColor = true;
            this.checkBox_graph_color.CheckedChanged += new System.EventHandler(this.checkBox_graph_color_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 338);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(176, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Толщина линий маршрута";
            // 
            // numericUpDown_route_size
            // 
            this.numericUpDown_route_size.Location = new System.Drawing.Point(11, 362);
            this.numericUpDown_route_size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_route_size.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_route_size.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_route_size.Name = "numericUpDown_route_size";
            this.numericUpDown_route_size.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_route_size.TabIndex = 19;
            this.numericUpDown_route_size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_route_size.ValueChanged += new System.EventHandler(this.numericUpDown_route_size_ValueChanged);
            // 
            // panel_route_color
            // 
            this.panel_route_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_route_color.Location = new System.Drawing.Point(196, 316);
            this.panel_route_color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_route_color.Name = "panel_route_color";
            this.panel_route_color.Size = new System.Drawing.Size(17, 17);
            this.panel_route_color.TabIndex = 18;
            this.panel_route_color.Click += new System.EventHandler(this.panel_route_color_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 316);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Цвет отрисовки маршрута";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 265);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Смещение подписи узлов";
            // 
            // numericUpDown_strinhg_offset
            // 
            this.numericUpDown_strinhg_offset.Location = new System.Drawing.Point(11, 288);
            this.numericUpDown_strinhg_offset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_strinhg_offset.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_strinhg_offset.Name = "numericUpDown_strinhg_offset";
            this.numericUpDown_strinhg_offset.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_strinhg_offset.TabIndex = 15;
            this.numericUpDown_strinhg_offset.ValueChanged += new System.EventHandler(this.numericUpDown_strinhg_offset_ValueChanged);
            // 
            // textBox_vertex_font
            // 
            this.textBox_vertex_font.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_vertex_font.Location = new System.Drawing.Point(5, 204);
            this.textBox_vertex_font.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_vertex_font.Name = "textBox_vertex_font";
            this.textBox_vertex_font.ReadOnly = true;
            this.textBox_vertex_font.Size = new System.Drawing.Size(151, 22);
            this.textBox_vertex_font.TabIndex = 14;
            // 
            // button_node_naming_font_select
            // 
            this.button_node_naming_font_select.AutoSize = true;
            this.button_node_naming_font_select.Location = new System.Drawing.Point(5, 231);
            this.button_node_naming_font_select.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_node_naming_font_select.Name = "button_node_naming_font_select";
            this.button_node_naming_font_select.Size = new System.Drawing.Size(97, 32);
            this.button_node_naming_font_select.TabIndex = 5;
            this.button_node_naming_font_select.Text = "Выбрать";
            this.button_node_naming_font_select.UseVisualStyleBackColor = true;
            this.button_node_naming_font_select.Click += new System.EventHandler(this.button_node_naming_font_select_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Шрифт подписи узлов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Размер маркера узла";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Толщина линий графа";
            // 
            // panel_preview
            // 
            this.panel_preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_preview.Controls.Add(this.pictureBox_preview);
            this.panel_preview.Location = new System.Drawing.Point(168, 60);
            this.panel_preview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_preview.Name = "panel_preview";
            this.panel_preview.Size = new System.Drawing.Size(165, 200);
            this.panel_preview.TabIndex = 8;
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_preview.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_preview.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(163, 198);
            this.pictureBox_preview.TabIndex = 0;
            this.pictureBox_preview.TabStop = false;
            // 
            // numericUpDown_vertex_size
            // 
            this.numericUpDown_vertex_size.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_vertex_size.Location = new System.Drawing.Point(11, 153);
            this.numericUpDown_vertex_size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_vertex_size.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_vertex_size.Name = "numericUpDown_vertex_size";
            this.numericUpDown_vertex_size.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_vertex_size.TabIndex = 4;
            this.numericUpDown_vertex_size.ValueChanged += new System.EventHandler(this.numericUpDown_vertex_size_ValueChanged);
            // 
            // numericUpDown_edge_thickness
            // 
            this.numericUpDown_edge_thickness.Location = new System.Drawing.Point(11, 102);
            this.numericUpDown_edge_thickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown_edge_thickness.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown_edge_thickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_edge_thickness.Name = "numericUpDown_edge_thickness";
            this.numericUpDown_edge_thickness.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_edge_thickness.TabIndex = 3;
            this.numericUpDown_edge_thickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_edge_thickness.ValueChanged += new System.EventHandler(this.numericUpDown_edge_thickness_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(125, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Нумерация узлов";
            // 
            // comboBox_node_naming_start_index
            // 
            this.comboBox_node_naming_start_index.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_node_naming_start_index.Items.AddRange(new object[] {
            "начиать с нуля",
            "начинать с единицы"});
            this.comboBox_node_naming_start_index.Location = new System.Drawing.Point(137, 30);
            this.comboBox_node_naming_start_index.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_node_naming_start_index.Name = "comboBox_node_naming_start_index";
            this.comboBox_node_naming_start_index.Size = new System.Drawing.Size(195, 24);
            this.comboBox_node_naming_start_index.TabIndex = 1;
            this.comboBox_node_naming_start_index.SelectedIndexChanged += new System.EventHandler(this.comboBox_node_naming_start_index_SelectedIndexChanged);
            // 
            // checkBox_node_naming
            // 
            this.checkBox_node_naming.AutoSize = true;
            this.checkBox_node_naming.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_node_naming.Location = new System.Drawing.Point(5, 6);
            this.checkBox_node_naming.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_node_naming.Name = "checkBox_node_naming";
            this.checkBox_node_naming.Size = new System.Drawing.Size(172, 20);
            this.checkBox_node_naming.TabIndex = 0;
            this.checkBox_node_naming.Text = "Подпись узлов графа";
            this.checkBox_node_naming.UseVisualStyleBackColor = true;
            this.checkBox_node_naming.CheckedChanged += new System.EventHandler(this.checkBox_node_naming_CheckedChanged);
            // 
            // panel_backcolor
            // 
            this.panel_backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_backcolor.Location = new System.Drawing.Point(92, 57);
            this.panel_backcolor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_backcolor.Name = "panel_backcolor";
            this.panel_backcolor.Size = new System.Drawing.Size(17, 17);
            this.panel_backcolor.TabIndex = 2;
            this.panel_backcolor.Click += new System.EventHandler(this.panel_back_color_graph_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Цвет фона";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.Settings_mesh_west_first_routing);
            this.tabPage2.Controls.Add(this.Settings_torus_XY_routing);
            this.tabPage2.Controls.Add(this.Settings_label_routing_torus);
            this.tabPage2.Controls.Add(this.Settings_mesh_XY_routing);
            this.tabPage2.Controls.Add(this.Settings_label_routing_mesh);
            this.tabPage2.Controls.Add(this.Settings_circulant_APO_routing);
            this.tabPage2.Controls.Add(this.Settings_circulant_APM_routing);
            this.tabPage2.Controls.Add(this.Settings_circulant_ROU_routing);
            this.tabPage2.Controls.Add(this.Settings_circulant_simple_routing);
            this.tabPage2.Controls.Add(this.Settings_label_routing_circulant);
            this.tabPage2.Location = new System.Drawing.Point(25, 4);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(548, 498);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // Settings_mesh_west_first_routing
            // 
            this.Settings_mesh_west_first_routing.AutoSize = true;
            this.Settings_mesh_west_first_routing.Location = new System.Drawing.Point(8, 192);
            this.Settings_mesh_west_first_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_mesh_west_first_routing.Name = "Settings_mesh_west_first_routing";
            this.Settings_mesh_west_first_routing.Size = new System.Drawing.Size(83, 20);
            this.Settings_mesh_west_first_routing.TabIndex = 9;
            this.Settings_mesh_west_first_routing.Text = "West first";
            this.Settings_mesh_west_first_routing.UseVisualStyleBackColor = true;
            this.Settings_mesh_west_first_routing.CheckedChanged += new System.EventHandler(this.Settings_torus_west_first_routing_CheckedChanged);
            // 
            // Settings_torus_XY_routing
            // 
            this.Settings_torus_XY_routing.AutoSize = true;
            this.Settings_torus_XY_routing.Location = new System.Drawing.Point(8, 249);
            this.Settings_torus_XY_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_torus_XY_routing.Name = "Settings_torus_XY_routing";
            this.Settings_torus_XY_routing.Size = new System.Drawing.Size(46, 20);
            this.Settings_torus_XY_routing.TabIndex = 8;
            this.Settings_torus_XY_routing.Text = "XY";
            this.Settings_torus_XY_routing.UseVisualStyleBackColor = true;
            this.Settings_torus_XY_routing.CheckedChanged += new System.EventHandler(this.Settings_torus_XY_routing_CheckedChanged);
            // 
            // Settings_label_routing_torus
            // 
            this.Settings_label_routing_torus.AutoSize = true;
            this.Settings_label_routing_torus.Location = new System.Drawing.Point(3, 229);
            this.Settings_label_routing_torus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Settings_label_routing_torus.Name = "Settings_label_routing_torus";
            this.Settings_label_routing_torus.Size = new System.Drawing.Size(320, 16);
            this.Settings_label_routing_torus.TabIndex = 7;
            this.Settings_label_routing_torus.Text = "Алгоритмы маршрутизации для топологии torus:";
            // 
            // Settings_mesh_XY_routing
            // 
            this.Settings_mesh_XY_routing.AutoSize = true;
            this.Settings_mesh_XY_routing.Location = new System.Drawing.Point(8, 164);
            this.Settings_mesh_XY_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_mesh_XY_routing.Name = "Settings_mesh_XY_routing";
            this.Settings_mesh_XY_routing.Size = new System.Drawing.Size(46, 20);
            this.Settings_mesh_XY_routing.TabIndex = 6;
            this.Settings_mesh_XY_routing.Text = "XY";
            this.Settings_mesh_XY_routing.UseVisualStyleBackColor = true;
            this.Settings_mesh_XY_routing.CheckedChanged += new System.EventHandler(this.Settings_mesh_XY_routing_CheckedChanged);
            // 
            // Settings_label_routing_mesh
            // 
            this.Settings_label_routing_mesh.AutoSize = true;
            this.Settings_label_routing_mesh.Location = new System.Drawing.Point(3, 144);
            this.Settings_label_routing_mesh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Settings_label_routing_mesh.Name = "Settings_label_routing_mesh";
            this.Settings_label_routing_mesh.Size = new System.Drawing.Size(324, 16);
            this.Settings_label_routing_mesh.TabIndex = 5;
            this.Settings_label_routing_mesh.Text = "Алгоритмы маршрутизации для топологии mesh:";
            // 
            // Settings_circulant_APO_routing
            // 
            this.Settings_circulant_APO_routing.AutoSize = true;
            this.Settings_circulant_APO_routing.Location = new System.Drawing.Point(8, 107);
            this.Settings_circulant_APO_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_circulant_APO_routing.Name = "Settings_circulant_APO_routing";
            this.Settings_circulant_APO_routing.Size = new System.Drawing.Size(57, 20);
            this.Settings_circulant_APO_routing.TabIndex = 4;
            this.Settings_circulant_APO_routing.Text = "APO";
            this.Settings_circulant_APO_routing.UseVisualStyleBackColor = true;
            this.Settings_circulant_APO_routing.CheckedChanged += new System.EventHandler(this.Settings_circulant_APO_routing_CheckedChanged);
            // 
            // Settings_circulant_APM_routing
            // 
            this.Settings_circulant_APM_routing.AutoSize = true;
            this.Settings_circulant_APM_routing.Location = new System.Drawing.Point(8, 79);
            this.Settings_circulant_APM_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_circulant_APM_routing.Name = "Settings_circulant_APM_routing";
            this.Settings_circulant_APM_routing.Size = new System.Drawing.Size(58, 20);
            this.Settings_circulant_APM_routing.TabIndex = 3;
            this.Settings_circulant_APM_routing.Text = "APM";
            this.Settings_circulant_APM_routing.UseVisualStyleBackColor = true;
            this.Settings_circulant_APM_routing.CheckedChanged += new System.EventHandler(this.Settings_circulant_APM_routing_CheckedChanged);
            // 
            // Settings_circulant_ROU_routing
            // 
            this.Settings_circulant_ROU_routing.AutoSize = true;
            this.Settings_circulant_ROU_routing.Location = new System.Drawing.Point(8, 50);
            this.Settings_circulant_ROU_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_circulant_ROU_routing.Name = "Settings_circulant_ROU_routing";
            this.Settings_circulant_ROU_routing.Size = new System.Drawing.Size(59, 20);
            this.Settings_circulant_ROU_routing.TabIndex = 2;
            this.Settings_circulant_ROU_routing.Text = "ROU";
            this.Settings_circulant_ROU_routing.UseVisualStyleBackColor = true;
            this.Settings_circulant_ROU_routing.CheckedChanged += new System.EventHandler(this.Settings_circulant_ROU_routing_CheckedChanged);
            // 
            // Settings_circulant_simple_routing
            // 
            this.Settings_circulant_simple_routing.AutoSize = true;
            this.Settings_circulant_simple_routing.Location = new System.Drawing.Point(8, 22);
            this.Settings_circulant_simple_routing.Margin = new System.Windows.Forms.Padding(4);
            this.Settings_circulant_simple_routing.Name = "Settings_circulant_simple_routing";
            this.Settings_circulant_simple_routing.Size = new System.Drawing.Size(71, 20);
            this.Settings_circulant_simple_routing.TabIndex = 1;
            this.Settings_circulant_simple_routing.Text = "Simple";
            this.Settings_circulant_simple_routing.UseVisualStyleBackColor = true;
            this.Settings_circulant_simple_routing.CheckedChanged += new System.EventHandler(this.Settings_circulant_simple_routing_CheckedChanged);
            // 
            // Settings_label_routing_circulant
            // 
            this.Settings_label_routing_circulant.AutoSize = true;
            this.Settings_label_routing_circulant.Location = new System.Drawing.Point(4, 2);
            this.Settings_label_routing_circulant.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Settings_label_routing_circulant.Name = "Settings_label_routing_circulant";
            this.Settings_label_routing_circulant.Size = new System.Drawing.Size(340, 16);
            this.Settings_label_routing_circulant.TabIndex = 0;
            this.Settings_label_routing_circulant.Text = "Алгоритмы маршрутизации для топологии circulant:";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.textBoxProject);
            this.tabPage3.Controls.Add(this.buttonProjectPath);
            this.tabPage3.Controls.Add(this.textBoxDataBase);
            this.tabPage3.Controls.Add(this.textBoxQuartus);
            this.tabPage3.Controls.Add(this.addDataBase);
            this.tabPage3.Controls.Add(this.buttonQuartusPath);
            this.tabPage3.Location = new System.Drawing.Point(25, 4);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(548, 498);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxProject
            // 
            this.textBoxProject.Location = new System.Drawing.Point(269, 68);
            this.textBoxProject.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(132, 22);
            this.textBoxProject.TabIndex = 6;
            // 
            // buttonProjectPath
            // 
            this.buttonProjectPath.Location = new System.Drawing.Point(8, 65);
            this.buttonProjectPath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonProjectPath.Name = "buttonProjectPath";
            this.buttonProjectPath.Size = new System.Drawing.Size(237, 28);
            this.buttonProjectPath.TabIndex = 5;
            this.buttonProjectPath.Text = "Путь проекта...";
            this.buttonProjectPath.UseVisualStyleBackColor = true;
            this.buttonProjectPath.Click += new System.EventHandler(this.buttonProjectPath_Click);
            // 
            // textBoxDataBase
            // 
            this.textBoxDataBase.Location = new System.Drawing.Point(269, 105);
            this.textBoxDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDataBase.Name = "textBoxDataBase";
            this.textBoxDataBase.Size = new System.Drawing.Size(132, 22);
            this.textBoxDataBase.TabIndex = 4;
            // 
            // textBoxQuartus
            // 
            this.textBoxQuartus.Location = new System.Drawing.Point(269, 31);
            this.textBoxQuartus.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxQuartus.Name = "textBoxQuartus";
            this.textBoxQuartus.Size = new System.Drawing.Size(132, 22);
            this.textBoxQuartus.TabIndex = 3;
            // 
            // addDataBase
            // 
            this.addDataBase.Location = new System.Drawing.Point(8, 102);
            this.addDataBase.Margin = new System.Windows.Forms.Padding(4);
            this.addDataBase.Name = "addDataBase";
            this.addDataBase.Size = new System.Drawing.Size(237, 28);
            this.addDataBase.TabIndex = 2;
            this.addDataBase.Text = "Путь базы данных...";
            this.addDataBase.UseVisualStyleBackColor = true;
            this.addDataBase.Click += new System.EventHandler(this.addDataBase_Click);
            // 
            // buttonQuartusPath
            // 
            this.buttonQuartusPath.Location = new System.Drawing.Point(8, 28);
            this.buttonQuartusPath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonQuartusPath.Name = "buttonQuartusPath";
            this.buttonQuartusPath.Size = new System.Drawing.Size(237, 28);
            this.buttonQuartusPath.TabIndex = 1;
            this.buttonQuartusPath.Text = "Путь Quartus...";
            this.buttonQuartusPath.UseVisualStyleBackColor = true;
            this.buttonQuartusPath.Click += new System.EventHandler(this.addQuartus_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(664, 532);
            this.button_ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(100, 30);
            this.button_ok.TabIndex = 2;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(771, 532);
            this.button_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(100, 30);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 601);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(898, 648);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(898, 648);
            this.Name = "Form_Settings";
            this.Text = "Настройки";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownnode_naming_interval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_route_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_strinhg_offset)).EndInit();
            this.panel_preview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_vertex_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_edge_thickness)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel_backcolor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_node_naming_start_index;
        private System.Windows.Forms.CheckBox checkBox_node_naming;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_preview;
        private System.Windows.Forms.NumericUpDown numericUpDown_vertex_size;
        private System.Windows.Forms.NumericUpDown numericUpDown_edge_thickness;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.Button button_node_naming_font_select;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_vertex_font;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown_strinhg_offset;
        private System.Windows.Forms.Panel panel_route_color;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_route_size;
        private System.Windows.Forms.CheckBox checkBox_graph_color;
        private System.Windows.Forms.CheckBox checkBox_alternative_draw_graph;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownnode_naming_interval;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox Settings_mesh_west_first_routing;
        private System.Windows.Forms.CheckBox Settings_torus_XY_routing;
        private System.Windows.Forms.Label Settings_label_routing_torus;
        private System.Windows.Forms.CheckBox Settings_mesh_XY_routing;
        private System.Windows.Forms.Label Settings_label_routing_mesh;
        private System.Windows.Forms.CheckBox Settings_circulant_APO_routing;
        private System.Windows.Forms.CheckBox Settings_circulant_APM_routing;
        private System.Windows.Forms.CheckBox Settings_circulant_ROU_routing;
        private System.Windows.Forms.CheckBox Settings_circulant_simple_routing;
        private System.Windows.Forms.Label Settings_label_routing_circulant;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button addDataBase;
        private System.Windows.Forms.Button buttonQuartusPath;
        private System.Windows.Forms.TextBox textBoxDataBase;
        private System.Windows.Forms.TextBox textBoxQuartus;
        private System.Windows.Forms.Button buttonProjectPath;
        private System.Windows.Forms.TextBox textBoxProject;
    }
}
