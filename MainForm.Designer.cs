namespace PE_File_Exporter
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbExportEntrys = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbUnusedEntrys = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbImportEntrys = new System.Windows.Forms.ListBox();
            this.btAddtoExportList = new System.Windows.Forms.Button();
            this.btRemoveFromImportList = new System.Windows.Forms.Button();
            this.btRemoveFromExportList = new System.Windows.Forms.Button();
            this.btAddToImportList = new System.Windows.Forms.Button();
            this.btExportEntryUp = new System.Windows.Forms.Button();
            this.btImportListEntryUp = new System.Windows.Forms.Button();
            this.btExportEntryDown = new System.Windows.Forms.Button();
            this.btImportListEntryDown = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.btDeleteEntryPoint = new System.Windows.Forms.Button();
            this.btSelectEntryPoint = new System.Windows.Forms.Button();
            this.tbEntryPoint = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbRefMin = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbRevMaj = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbSpecPublisher = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbSpecName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbSpecFunction = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.cbImportHeaderSelect = new System.Windows.Forms.ComboBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbExportEntrys
            // 
            this.lbExportEntrys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbExportEntrys.FormattingEnabled = true;
            this.lbExportEntrys.Location = new System.Drawing.Point(6, 19);
            this.lbExportEntrys.Name = "lbExportEntrys";
            this.lbExportEntrys.Size = new System.Drawing.Size(193, 290);
            this.lbExportEntrys.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBinFileToolStripMenuItem,
            this.openPeFileToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.exportFileToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.filesToolStripMenuItem.Text = "Files";
            // 
            // openBinFileToolStripMenuItem
            // 
            this.openBinFileToolStripMenuItem.Name = "openBinFileToolStripMenuItem";
            this.openBinFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.openBinFileToolStripMenuItem.Text = "new file";
            this.openBinFileToolStripMenuItem.Click += new System.EventHandler(this.openBinFileToolStripMenuItem_Click);
            // 
            // openPeFileToolStripMenuItem
            // 
            this.openPeFileToolStripMenuItem.Name = "openPeFileToolStripMenuItem";
            this.openPeFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.openPeFileToolStripMenuItem.Text = "open file";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.saveFileToolStripMenuItem.Text = "save file";
            // 
            // exportFileToolStripMenuItem
            // 
            this.exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
            this.exportFileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.exportFileToolStripMenuItem.Text = "export file";
            this.exportFileToolStripMenuItem.Click += new System.EventHandler(this.exportFileToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbExportEntrys);
            this.groupBox1.Location = new System.Drawing.Point(213, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 315);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "labels to export";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbUnusedEntrys);
            this.groupBox2.Location = new System.Drawing.Point(455, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(205, 315);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "labels found in list file";
            // 
            // lbUnusedEntrys
            // 
            this.lbUnusedEntrys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUnusedEntrys.FormattingEnabled = true;
            this.lbUnusedEntrys.Location = new System.Drawing.Point(6, 19);
            this.lbUnusedEntrys.Name = "lbUnusedEntrys";
            this.lbUnusedEntrys.Size = new System.Drawing.Size(193, 290);
            this.lbUnusedEntrys.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbImportEntrys);
            this.groupBox3.Location = new System.Drawing.Point(697, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 315);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "labels to import";
            // 
            // lbImportEntrys
            // 
            this.lbImportEntrys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbImportEntrys.FormattingEnabled = true;
            this.lbImportEntrys.Location = new System.Drawing.Point(6, 19);
            this.lbImportEntrys.Name = "lbImportEntrys";
            this.lbImportEntrys.Size = new System.Drawing.Size(193, 290);
            this.lbImportEntrys.TabIndex = 0;
            // 
            // btAddtoExportList
            // 
            this.btAddtoExportList.Location = new System.Drawing.Point(424, 108);
            this.btAddtoExportList.Name = "btAddtoExportList";
            this.btAddtoExportList.Size = new System.Drawing.Size(25, 26);
            this.btAddtoExportList.TabIndex = 5;
            this.btAddtoExportList.Text = "<-";
            this.btAddtoExportList.UseVisualStyleBackColor = true;
            this.btAddtoExportList.Click += new System.EventHandler(this.btAddtoExportList_Click);
            // 
            // btRemoveFromImportList
            // 
            this.btRemoveFromImportList.Location = new System.Drawing.Point(666, 108);
            this.btRemoveFromImportList.Name = "btRemoveFromImportList";
            this.btRemoveFromImportList.Size = new System.Drawing.Size(25, 26);
            this.btRemoveFromImportList.TabIndex = 6;
            this.btRemoveFromImportList.Text = "<-";
            this.btRemoveFromImportList.UseVisualStyleBackColor = true;
            this.btRemoveFromImportList.Click += new System.EventHandler(this.btRemoveFromImportList_Click);
            // 
            // btRemoveFromExportList
            // 
            this.btRemoveFromExportList.Location = new System.Drawing.Point(424, 140);
            this.btRemoveFromExportList.Name = "btRemoveFromExportList";
            this.btRemoveFromExportList.Size = new System.Drawing.Size(25, 26);
            this.btRemoveFromExportList.TabIndex = 7;
            this.btRemoveFromExportList.Text = "->";
            this.btRemoveFromExportList.UseVisualStyleBackColor = true;
            this.btRemoveFromExportList.Click += new System.EventHandler(this.btRemoveFromExportList_Click);
            // 
            // btAddToImportList
            // 
            this.btAddToImportList.Location = new System.Drawing.Point(666, 140);
            this.btAddToImportList.Name = "btAddToImportList";
            this.btAddToImportList.Size = new System.Drawing.Size(25, 26);
            this.btAddToImportList.TabIndex = 8;
            this.btAddToImportList.Text = "->";
            this.btAddToImportList.UseVisualStyleBackColor = true;
            this.btAddToImportList.Click += new System.EventHandler(this.btAddToImportList_Click);
            // 
            // btExportEntryUp
            // 
            this.btExportEntryUp.Location = new System.Drawing.Point(424, 201);
            this.btExportEntryUp.Name = "btExportEntryUp";
            this.btExportEntryUp.Size = new System.Drawing.Size(25, 26);
            this.btExportEntryUp.TabIndex = 9;
            this.btExportEntryUp.Text = "/\\";
            this.btExportEntryUp.UseVisualStyleBackColor = true;
            this.btExportEntryUp.Click += new System.EventHandler(this.btExportEntryUp_Click);
            // 
            // btImportListEntryUp
            // 
            this.btImportListEntryUp.Location = new System.Drawing.Point(666, 201);
            this.btImportListEntryUp.Name = "btImportListEntryUp";
            this.btImportListEntryUp.Size = new System.Drawing.Size(25, 26);
            this.btImportListEntryUp.TabIndex = 10;
            this.btImportListEntryUp.Text = "/\\";
            this.btImportListEntryUp.UseVisualStyleBackColor = true;
            this.btImportListEntryUp.Click += new System.EventHandler(this.btImportListEntryUp_Click);
            // 
            // btExportEntryDown
            // 
            this.btExportEntryDown.Location = new System.Drawing.Point(424, 233);
            this.btExportEntryDown.Name = "btExportEntryDown";
            this.btExportEntryDown.Size = new System.Drawing.Size(25, 26);
            this.btExportEntryDown.TabIndex = 11;
            this.btExportEntryDown.Text = "\\/";
            this.btExportEntryDown.UseVisualStyleBackColor = true;
            this.btExportEntryDown.Click += new System.EventHandler(this.btExportEntryDown_Click);
            // 
            // btImportListEntryDown
            // 
            this.btImportListEntryDown.Location = new System.Drawing.Point(666, 233);
            this.btImportListEntryDown.Name = "btImportListEntryDown";
            this.btImportListEntryDown.Size = new System.Drawing.Size(25, 26);
            this.btImportListEntryDown.TabIndex = 12;
            this.btImportListEntryDown.Text = "\\/";
            this.btImportListEntryDown.UseVisualStyleBackColor = true;
            this.btImportListEntryDown.Click += new System.EventHandler(this.btImportListEntryDown_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox16);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(0, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(207, 315);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "export Header specifications";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.btDeleteEntryPoint);
            this.groupBox16.Controls.Add(this.btSelectEntryPoint);
            this.groupBox16.Controls.Add(this.tbEntryPoint);
            this.groupBox16.Location = new System.Drawing.Point(6, 209);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(195, 88);
            this.groupBox16.TabIndex = 18;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Entry point for own thread";
            // 
            // btDeleteEntryPoint
            // 
            this.btDeleteEntryPoint.Location = new System.Drawing.Point(100, 45);
            this.btDeleteEntryPoint.Name = "btDeleteEntryPoint";
            this.btDeleteEntryPoint.Size = new System.Drawing.Size(88, 36);
            this.btDeleteEntryPoint.TabIndex = 20;
            this.btDeleteEntryPoint.Text = "Delete entry point";
            this.btDeleteEntryPoint.UseVisualStyleBackColor = true;
            this.btDeleteEntryPoint.Click += new System.EventHandler(this.btDeleteEntryPoint_Click);
            // 
            // btSelectEntryPoint
            // 
            this.btSelectEntryPoint.Location = new System.Drawing.Point(6, 45);
            this.btSelectEntryPoint.Name = "btSelectEntryPoint";
            this.btSelectEntryPoint.Size = new System.Drawing.Size(88, 36);
            this.btSelectEntryPoint.TabIndex = 19;
            this.btSelectEntryPoint.Text = "Set new entry point";
            this.btSelectEntryPoint.UseVisualStyleBackColor = true;
            this.btSelectEntryPoint.Click += new System.EventHandler(this.btSelectEntryPoint_Click);
            // 
            // tbEntryPoint
            // 
            this.tbEntryPoint.Location = new System.Drawing.Point(6, 19);
            this.tbEntryPoint.Name = "tbEntryPoint";
            this.tbEntryPoint.Size = new System.Drawing.Size(182, 20);
            this.tbEntryPoint.TabIndex = 19;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbRefMin);
            this.groupBox9.Location = new System.Drawing.Point(106, 161);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(94, 42);
            this.groupBox9.TabIndex = 17;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Rev Min. (0..9)";
            // 
            // cbRefMin
            // 
            this.cbRefMin.FormattingEnabled = true;
            this.cbRefMin.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbRefMin.Location = new System.Drawing.Point(6, 15);
            this.cbRefMin.Name = "cbRefMin";
            this.cbRefMin.Size = new System.Drawing.Size(82, 21);
            this.cbRefMin.TabIndex = 15;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbRevMaj);
            this.groupBox8.Location = new System.Drawing.Point(6, 161);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(94, 42);
            this.groupBox8.TabIndex = 16;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Rev Maj. (0..9)";
            // 
            // cbRevMaj
            // 
            this.cbRevMaj.FormattingEnabled = true;
            this.cbRevMaj.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbRevMaj.Location = new System.Drawing.Point(6, 15);
            this.cbRevMaj.Name = "cbRevMaj";
            this.cbRevMaj.Size = new System.Drawing.Size(82, 21);
            this.cbRevMaj.TabIndex = 14;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbSpecPublisher);
            this.groupBox7.Location = new System.Drawing.Point(6, 113);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(195, 42);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Spec Publisher(20 chars)";
            // 
            // tbSpecPublisher
            // 
            this.tbSpecPublisher.Location = new System.Drawing.Point(6, 16);
            this.tbSpecPublisher.Name = "tbSpecPublisher";
            this.tbSpecPublisher.Size = new System.Drawing.Size(183, 20);
            this.tbSpecPublisher.TabIndex = 16;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbSpecName);
            this.groupBox6.Location = new System.Drawing.Point(6, 65);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(195, 42);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Spec Name (20 chars)";
            // 
            // tbSpecName
            // 
            this.tbSpecName.Location = new System.Drawing.Point(6, 16);
            this.tbSpecName.Name = "tbSpecName";
            this.tbSpecName.Size = new System.Drawing.Size(183, 20);
            this.tbSpecName.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbSpecFunction);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(195, 42);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Spec Function (20 chars)";
            // 
            // tbSpecFunction
            // 
            this.tbSpecFunction.Location = new System.Drawing.Point(6, 16);
            this.tbSpecFunction.Name = "tbSpecFunction";
            this.tbSpecFunction.Size = new System.Drawing.Size(183, 20);
            this.tbSpecFunction.TabIndex = 14;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.button1);
            this.groupBox10.Controls.Add(this.groupBox11);
            this.groupBox10.Controls.Add(this.groupBox12);
            this.groupBox10.Controls.Add(this.groupBox13);
            this.groupBox10.Controls.Add(this.groupBox14);
            this.groupBox10.Controls.Add(this.groupBox15);
            this.groupBox10.Location = new System.Drawing.Point(908, 27);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(207, 315);
            this.groupBox10.TabIndex = 18;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "import Header specifications";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 42);
            this.button1.TabIndex = 18;
            this.button1.Text = "Search for an external lib/driver";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.comboBox1);
            this.groupBox11.Location = new System.Drawing.Point(106, 161);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(95, 42);
            this.groupBox11.TabIndex = 17;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Rev Min. (0..9)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox1.Location = new System.Drawing.Point(6, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(82, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.comboBox2);
            this.groupBox12.Location = new System.Drawing.Point(6, 161);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(94, 42);
            this.groupBox12.TabIndex = 16;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Rev Maj. (0..9)";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox2.Location = new System.Drawing.Point(6, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(82, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBox1);
            this.groupBox13.Location = new System.Drawing.Point(6, 113);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(195, 42);
            this.groupBox13.TabIndex = 15;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Spec Publisher(20 chars)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(183, 20);
            this.textBox1.TabIndex = 16;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.cbImportHeaderSelect);
            this.groupBox14.Location = new System.Drawing.Point(6, 19);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(195, 42);
            this.groupBox14.TabIndex = 15;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Import Header Name";
            // 
            // cbImportHeaderSelect
            // 
            this.cbImportHeaderSelect.FormattingEnabled = true;
            this.cbImportHeaderSelect.Location = new System.Drawing.Point(6, 16);
            this.cbImportHeaderSelect.Name = "cbImportHeaderSelect";
            this.cbImportHeaderSelect.Size = new System.Drawing.Size(182, 21);
            this.cbImportHeaderSelect.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.textBox3);
            this.groupBox15.Location = new System.Drawing.Point(6, 67);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(195, 42);
            this.groupBox15.TabIndex = 14;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Spec Function (20 chars)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 20);
            this.textBox3.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 346);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btImportListEntryDown);
            this.Controls.Add(this.btExportEntryDown);
            this.Controls.Add(this.btImportListEntryUp);
            this.Controls.Add(this.btExportEntryUp);
            this.Controls.Add(this.btAddToImportList);
            this.Controls.Add(this.btRemoveFromExportList);
            this.Controls.Add(this.btRemoveFromImportList);
            this.Controls.Add(this.btAddtoExportList);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "PE file uitilities";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbExportEntrys;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBinFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPeFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbUnusedEntrys;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbImportEntrys;
        private System.Windows.Forms.Button btAddtoExportList;
        private System.Windows.Forms.Button btRemoveFromImportList;
        private System.Windows.Forms.Button btRemoveFromExportList;
        private System.Windows.Forms.Button btAddToImportList;
        private System.Windows.Forms.Button btExportEntryUp;
        private System.Windows.Forms.Button btImportListEntryUp;
        private System.Windows.Forms.Button btExportEntryDown;
        private System.Windows.Forms.Button btImportListEntryDown;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbRefMin;
        private System.Windows.Forms.ComboBox cbRevMaj;
        private System.Windows.Forms.TextBox tbSpecPublisher;
        private System.Windows.Forms.TextBox tbSpecName;
        private System.Windows.Forms.TextBox tbSpecFunction;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TextBox tbEntryPoint;
        private System.Windows.Forms.Button btDeleteEntryPoint;
        private System.Windows.Forms.Button btSelectEntryPoint;
        private System.Windows.Forms.ComboBox cbImportHeaderSelect;
    }
}

