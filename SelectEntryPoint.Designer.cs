namespace PE_File_Exporter
{
    partial class SelectEntryPoint
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
            this.lbEntrys = new System.Windows.Forms.ListBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbEntrys
            // 
            this.lbEntrys.FormattingEnabled = true;
            this.lbEntrys.Location = new System.Drawing.Point(12, 12);
            this.lbEntrys.Name = "lbEntrys";
            this.lbEntrys.Size = new System.Drawing.Size(309, 355);
            this.lbEntrys.TabIndex = 0;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(12, 373);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(146, 31);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(175, 373);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(146, 31);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // SelectEntryPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 408);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbEntrys);
            this.Name = "SelectEntryPoint";
            this.Text = "Select new entry point";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbEntrys;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
    }
}