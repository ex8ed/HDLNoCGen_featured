namespace HDLNoCGen
{
    partial class FormQuartusCompilaton
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
            this.textBoxCLI = new System.Windows.Forms.TextBox();
            this.labelCompilationReportHeader = new System.Windows.Forms.Label();
            this.buttonCompile = new System.Windows.Forms.Button();
            this.labelProcessStatus = new System.Windows.Forms.Label();
            this.labelProcessHeader = new System.Windows.Forms.Label();
            this.textBoxCompilationReport = new System.Windows.Forms.TextBox();
            this.comboBoxRoutingAlgorithm = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelGraphSignature = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSaveTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTextCLI = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemCompilationReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemExportDB = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxLoadToTable = new System.Windows.Forms.CheckBox();
            this.buttonNet = new System.Windows.Forms.Button();
            this.buttonRouter = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCLI
            // 
            this.textBoxCLI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCLI.Location = new System.Drawing.Point(9, 24);
            this.textBoxCLI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCLI.Multiline = true;
            this.textBoxCLI.Name = "textBoxCLI";
            this.textBoxCLI.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCLI.Size = new System.Drawing.Size(559, 516);
            this.textBoxCLI.TabIndex = 0;
            // 
            // labelCompilationReportHeader
            // 
            this.labelCompilationReportHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCompilationReportHeader.AutoSize = true;
            this.labelCompilationReportHeader.Location = new System.Drawing.Point(572, 157);
            this.labelCompilationReportHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCompilationReportHeader.Name = "labelCompilationReportHeader";
            this.labelCompilationReportHeader.Size = new System.Drawing.Size(113, 13);
            this.labelCompilationReportHeader.TabIndex = 2;
            this.labelCompilationReportHeader.Text = "Отчет о компиляции:";
            // 
            // buttonCompile
            // 
            this.buttonCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCompile.Location = new System.Drawing.Point(752, 517);
            this.buttonCompile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCompile.Name = "buttonCompile";
            this.buttonCompile.Size = new System.Drawing.Size(163, 23);
            this.buttonCompile.TabIndex = 5;
            this.buttonCompile.Text = "Скомпилировать";
            this.buttonCompile.UseVisualStyleBackColor = true;
            this.buttonCompile.Click += new System.EventHandler(this.buttonCompile_Click);
            // 
            // labelProcessStatus
            // 
            this.labelProcessStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProcessStatus.AutoSize = true;
            this.labelProcessStatus.Location = new System.Drawing.Point(572, 118);
            this.labelProcessStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessStatus.Name = "labelProcessStatus";
            this.labelProcessStatus.Size = new System.Drawing.Size(82, 13);
            this.labelProcessStatus.TabIndex = 7;
            this.labelProcessStatus.Text = "Не стартовала";
            // 
            // labelProcessHeader
            // 
            this.labelProcessHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProcessHeader.AutoSize = true;
            this.labelProcessHeader.Location = new System.Drawing.Point(572, 92);
            this.labelProcessHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProcessHeader.Name = "labelProcessHeader";
            this.labelProcessHeader.Size = new System.Drawing.Size(109, 13);
            this.labelProcessHeader.TabIndex = 6;
            this.labelProcessHeader.Text = "Статус компиляции:";
            // 
            // textBoxCompilationReport
            // 
            this.textBoxCompilationReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCompilationReport.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxCompilationReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCompilationReport.Location = new System.Drawing.Point(571, 185);
            this.textBoxCompilationReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxCompilationReport.Multiline = true;
            this.textBoxCompilationReport.Name = "textBoxCompilationReport";
            this.textBoxCompilationReport.ReadOnly = true;
            this.textBoxCompilationReport.Size = new System.Drawing.Size(344, 276);
            this.textBoxCompilationReport.TabIndex = 8;
            // 
            // comboBoxRoutingAlgorithm
            // 
            this.comboBoxRoutingAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRoutingAlgorithm.FormattingEnabled = true;
            this.comboBoxRoutingAlgorithm.Location = new System.Drawing.Point(572, 519);
            this.comboBoxRoutingAlgorithm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxRoutingAlgorithm.Name = "comboBoxRoutingAlgorithm";
            this.comboBoxRoutingAlgorithm.Size = new System.Drawing.Size(176, 21);
            this.comboBoxRoutingAlgorithm.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(572, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Конфигурация сети:";
            // 
            // labelGraphSignature
            // 
            this.labelGraphSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGraphSignature.AutoSize = true;
            this.labelGraphSignature.Location = new System.Drawing.Point(572, 53);
            this.labelGraphSignature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelGraphSignature.Name = "labelGraphSignature";
            this.labelGraphSignature.Size = new System.Drawing.Size(10, 13);
            this.labelGraphSignature.TabIndex = 20;
            this.labelGraphSignature.Text = "-";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemSettings,
            this.ToolStripMenuItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(926, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSaveTxt,
            this.ToolStripMenuItemExportDB});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItemFile.Text = "Файл";
            // 
            // ToolStripMenuItemSaveTxt
            // 
            this.ToolStripMenuItemSaveTxt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemTextCLI,
            this.ToolStripMenuItemCompilationReport});
            this.ToolStripMenuItemSaveTxt.Name = "ToolStripMenuItemSaveTxt";
            this.ToolStripMenuItemSaveTxt.Size = new System.Drawing.Size(252, 22);
            this.ToolStripMenuItemSaveTxt.Text = "Сохранить текстовый файл";
            // 
            // ToolStripMenuItemTextCLI
            // 
            this.ToolStripMenuItemTextCLI.Name = "ToolStripMenuItemTextCLI";
            this.ToolStripMenuItemTextCLI.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItemTextCLI.Text = "Вывод терминала...";
            this.ToolStripMenuItemTextCLI.Click += new System.EventHandler(this.ToolStripMenuItemTextCLI_Click);
            // 
            // ToolStripMenuItemCompilationReport
            // 
            this.ToolStripMenuItemCompilationReport.Name = "ToolStripMenuItemCompilationReport";
            this.ToolStripMenuItemCompilationReport.Size = new System.Drawing.Size(198, 22);
            this.ToolStripMenuItemCompilationReport.Text = "Отчет о компиляции...";
            this.ToolStripMenuItemCompilationReport.Click += new System.EventHandler(this.ToolStripMenuItemCompilationReport_Click);
            // 
            // ToolStripMenuItemExportDB
            // 
            this.ToolStripMenuItemExportDB.Name = "ToolStripMenuItemExportDB";
            this.ToolStripMenuItemExportDB.Size = new System.Drawing.Size(252, 22);
            this.ToolStripMenuItemExportDB.Text = "Экспортировать в базу данных...";
            // 
            // ToolStripMenuItemSettings
            // 
            this.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings";
            this.ToolStripMenuItemSettings.Size = new System.Drawing.Size(79, 20);
            this.ToolStripMenuItemSettings.Text = "Настройки";
            this.ToolStripMenuItemSettings.Click += new System.EventHandler(this.ToolStripMenuItemSettings_Click);
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItemHelp.Text = "Справка";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(572, 513);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 2);
            this.label1.TabIndex = 12;
            // 
            // checkBoxLoadToTable
            // 
            this.checkBoxLoadToTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLoadToTable.AutoSize = true;
            this.checkBoxLoadToTable.Location = new System.Drawing.Point(572, 494);
            this.checkBoxLoadToTable.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLoadToTable.Name = "checkBoxLoadToTable";
            this.checkBoxLoadToTable.Size = new System.Drawing.Size(162, 17);
            this.checkBoxLoadToTable.TabIndex = 14;
            this.checkBoxLoadToTable.Text = "Выгрузить отчет в таблицу";
            this.checkBoxLoadToTable.UseVisualStyleBackColor = true;
            // 
            // buttonNet
            // 
            this.buttonNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNet.Location = new System.Drawing.Point(752, 465);
            this.buttonNet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNet.Name = "buttonNet";
            this.buttonNet.Size = new System.Drawing.Size(163, 23);
            this.buttonNet.TabIndex = 22;
            this.buttonNet.Text = "Создать маршрутизатор";
            this.buttonNet.UseVisualStyleBackColor = true;
            this.buttonNet.Click += new System.EventHandler(this.buttonNet_Click);
            // 
            // buttonRouter
            // 
            this.buttonRouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRouter.Location = new System.Drawing.Point(752, 492);
            this.buttonRouter.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRouter.Name = "buttonRouter";
            this.buttonRouter.Size = new System.Drawing.Size(163, 23);
            this.buttonRouter.TabIndex = 23;
            this.buttonRouter.Text = "Создать сеть";
            this.buttonRouter.UseVisualStyleBackColor = true;
            this.buttonRouter.Click += new System.EventHandler(this.buttonRouter_Click);
            // 
            // FormQuartusCompilaton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 555);
            this.Controls.Add(this.buttonRouter);
            this.Controls.Add(this.buttonNet);
            this.Controls.Add(this.labelGraphSignature);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxRoutingAlgorithm);
            this.Controls.Add(this.checkBoxLoadToTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCompilationReport);
            this.Controls.Add(this.labelProcessStatus);
            this.Controls.Add(this.labelProcessHeader);
            this.Controls.Add(this.buttonCompile);
            this.Controls.Add(this.labelCompilationReportHeader);
            this.Controls.Add(this.textBoxCLI);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(942, 591);
            this.Name = "FormQuartusCompilaton";
            this.Text = "Компиляция Quartus-проекта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormQuartusCompilaton_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCLI;
        private System.Windows.Forms.Label labelCompilationReportHeader;
        private System.Windows.Forms.Button buttonCompile;
        private System.Windows.Forms.Label labelProcessStatus;
        private System.Windows.Forms.Label labelProcessHeader;
        private System.Windows.Forms.TextBox textBoxCompilationReport;
        private System.Windows.Forms.ComboBox comboBoxRoutingAlgorithm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelGraphSignature;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSaveTxt;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTextCLI;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCompilationReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExportDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxLoadToTable;
        private System.Windows.Forms.Button buttonNet;
        private System.Windows.Forms.Button buttonRouter;
    }
}