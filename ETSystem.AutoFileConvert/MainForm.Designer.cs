namespace ETSystem.AutoFileConvert
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_1 = new System.Windows.Forms.TabPage();
            this.tabPage_2 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_1);
            this.tabControl.Controls.Add(this.tabPage_2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(529, 251);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage_1
            // 
            this.tabPage_1.Location = new System.Drawing.Point(4, 22);
            this.tabPage_1.Name = "tabPage_1";
            this.tabPage_1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_1.Size = new System.Drawing.Size(447, 225);
            this.tabPage_1.TabIndex = 0;
            this.tabPage_1.Tag = "ETSystem.AutoFileConvert.EasyFileConvertForm";
            this.tabPage_1.Text = "文件转换";
            this.tabPage_1.UseVisualStyleBackColor = true;
            // 
            // tabPage_2
            // 
            this.tabPage_2.Location = new System.Drawing.Point(4, 22);
            this.tabPage_2.Name = "tabPage_2";
            this.tabPage_2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_2.Size = new System.Drawing.Size(521, 225);
            this.tabPage_2.TabIndex = 1;
            this.tabPage_2.Tag = "ETSystem.AutoFileConvert.FileLibraryForm";
            this.tabPage_2.Text = "文件库";
            this.tabPage_2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 275);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ET文件转换工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_1;
        private System.Windows.Forms.TabPage tabPage_2;
    }
}