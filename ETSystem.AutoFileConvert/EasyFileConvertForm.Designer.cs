namespace ETSystem.AutoFileConvert
{
    partial class EasyFileConvertForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasyFileConvertForm));
            this.lbl_FliePath = new System.Windows.Forms.Label();
            this.btn_ConvertFile = new System.Windows.Forms.Button();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lbl_OutputPath = new System.Windows.Forms.Label();
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_OpenPath = new System.Windows.Forms.Button();
            this.tbx_FileName = new System.Windows.Forms.TextBox();
            this.tbx_OutputPath = new System.Windows.Forms.TextBox();
            this.rb_prj = new System.Windows.Forms.RadioButton();
            this.rb_xdf = new System.Windows.Forms.RadioButton();
            this.lbl_Format = new System.Windows.Forms.Label();
            this.cbx_dxfType = new System.Windows.Forms.ComboBox();
            this.rb_ets = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_FliePath
            // 
            this.lbl_FliePath.AutoSize = true;
            this.lbl_FliePath.Location = new System.Drawing.Point(30, 189);
            this.lbl_FliePath.Name = "lbl_FliePath";
            this.lbl_FliePath.Size = new System.Drawing.Size(0, 12);
            this.lbl_FliePath.TabIndex = 2;
            this.lbl_FliePath.Visible = false;
            // 
            // btn_ConvertFile
            // 
            this.btn_ConvertFile.BackColor = System.Drawing.Color.White;
            this.btn_ConvertFile.Location = new System.Drawing.Point(175, 152);
            this.btn_ConvertFile.Name = "btn_ConvertFile";
            this.btn_ConvertFile.Size = new System.Drawing.Size(133, 32);
            this.btn_ConvertFile.TabIndex = 0;
            this.btn_ConvertFile.Text = "一键转换";
            this.btn_ConvertFile.UseVisualStyleBackColor = false;
            this.btn_ConvertFile.Click += new System.EventHandler(this.btn_ConvertFile_Click);
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.BackColor = System.Drawing.Color.White;
            this.lbl_FileName.Location = new System.Drawing.Point(74, 34);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(65, 12);
            this.lbl_FileName.TabIndex = 1;
            this.lbl_FileName.Text = "上传文件：";
            // 
            // lbl_OutputPath
            // 
            this.lbl_OutputPath.AutoSize = true;
            this.lbl_OutputPath.BackColor = System.Drawing.Color.White;
            this.lbl_OutputPath.Location = new System.Drawing.Point(74, 108);
            this.lbl_OutputPath.Name = "lbl_OutputPath";
            this.lbl_OutputPath.Size = new System.Drawing.Size(65, 12);
            this.lbl_OutputPath.TabIndex = 1;
            this.lbl_OutputPath.Text = "输出目录：";
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.BackColor = System.Drawing.Color.White;
            this.btn_OpenFile.Location = new System.Drawing.Point(333, 31);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(90, 23);
            this.btn_OpenFile.TabIndex = 0;
            this.btn_OpenFile.Text = "选取文件";
            this.btn_OpenFile.UseVisualStyleBackColor = false;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_OpenPath
            // 
            this.btn_OpenPath.BackColor = System.Drawing.Color.White;
            this.btn_OpenPath.Location = new System.Drawing.Point(333, 103);
            this.btn_OpenPath.Name = "btn_OpenPath";
            this.btn_OpenPath.Size = new System.Drawing.Size(90, 23);
            this.btn_OpenPath.TabIndex = 0;
            this.btn_OpenPath.Text = "设置目录";
            this.btn_OpenPath.UseVisualStyleBackColor = false;
            this.btn_OpenPath.Click += new System.EventHandler(this.btn_OpenPath_Click);
            // 
            // tbx_FileName
            // 
            this.tbx_FileName.BackColor = System.Drawing.Color.White;
            this.tbx_FileName.Location = new System.Drawing.Point(145, 31);
            this.tbx_FileName.Name = "tbx_FileName";
            this.tbx_FileName.ReadOnly = true;
            this.tbx_FileName.Size = new System.Drawing.Size(182, 21);
            this.tbx_FileName.TabIndex = 2;
            // 
            // tbx_OutputPath
            // 
            this.tbx_OutputPath.BackColor = System.Drawing.Color.White;
            this.tbx_OutputPath.Location = new System.Drawing.Point(145, 104);
            this.tbx_OutputPath.Name = "tbx_OutputPath";
            this.tbx_OutputPath.ReadOnly = true;
            this.tbx_OutputPath.Size = new System.Drawing.Size(182, 21);
            this.tbx_OutputPath.TabIndex = 2;
            // 
            // rb_prj
            // 
            this.rb_prj.AutoSize = true;
            this.rb_prj.BackColor = System.Drawing.Color.White;
            this.rb_prj.Checked = true;
            this.rb_prj.Location = new System.Drawing.Point(145, 70);
            this.rb_prj.Name = "rb_prj";
            this.rb_prj.Size = new System.Drawing.Size(47, 16);
            this.rb_prj.TabIndex = 8;
            this.rb_prj.TabStop = true;
            this.rb_prj.Text = "盗版";
            this.rb_prj.UseVisualStyleBackColor = false;
            // 
            // rb_xdf
            // 
            this.rb_xdf.AutoSize = true;
            this.rb_xdf.BackColor = System.Drawing.Color.White;
            this.rb_xdf.Location = new System.Drawing.Point(283, 70);
            this.rb_xdf.Name = "rb_xdf";
            this.rb_xdf.Size = new System.Drawing.Size(41, 16);
            this.rb_xdf.TabIndex = 8;
            this.rb_xdf.Text = "DXF";
            this.rb_xdf.UseVisualStyleBackColor = false;
            this.rb_xdf.CheckedChanged += new System.EventHandler(this.rb_xdf_CheckedChanged);
            // 
            // lbl_Format
            // 
            this.lbl_Format.AutoSize = true;
            this.lbl_Format.BackColor = System.Drawing.Color.White;
            this.lbl_Format.Location = new System.Drawing.Point(74, 70);
            this.lbl_Format.Name = "lbl_Format";
            this.lbl_Format.Size = new System.Drawing.Size(65, 12);
            this.lbl_Format.TabIndex = 9;
            this.lbl_Format.Text = "转换格式：";
            // 
            // cbx_dxfType
            // 
            this.cbx_dxfType.BackColor = System.Drawing.Color.White;
            this.cbx_dxfType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_dxfType.FormattingEnabled = true;
            this.cbx_dxfType.Location = new System.Drawing.Point(333, 67);
            this.cbx_dxfType.Name = "cbx_dxfType";
            this.cbx_dxfType.Size = new System.Drawing.Size(90, 20);
            this.cbx_dxfType.TabIndex = 10;
            // 
            // rb_ets
            // 
            this.rb_ets.AutoSize = true;
            this.rb_ets.BackColor = System.Drawing.Color.White;
            this.rb_ets.Location = new System.Drawing.Point(214, 70);
            this.rb_ets.Name = "rb_ets";
            this.rb_ets.Size = new System.Drawing.Size(47, 16);
            this.rb_ets.TabIndex = 11;
            this.rb_ets.TabStop = true;
            this.rb_ets.Text = "正版";
            this.rb_ets.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_ets);
            this.groupBox1.Controls.Add(this.cbx_dxfType);
            this.groupBox1.Controls.Add(this.lbl_Format);
            this.groupBox1.Controls.Add(this.rb_xdf);
            this.groupBox1.Controls.Add(this.rb_prj);
            this.groupBox1.Controls.Add(this.tbx_OutputPath);
            this.groupBox1.Controls.Add(this.tbx_FileName);
            this.groupBox1.Controls.Add(this.btn_OpenPath);
            this.groupBox1.Controls.Add(this.btn_OpenFile);
            this.groupBox1.Controls.Add(this.lbl_OutputPath);
            this.groupBox1.Controls.Add(this.lbl_FileName);
            this.groupBox1.Controls.Add(this.btn_ConvertFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 196);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // EasyFileConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 220);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_FliePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EasyFileConvertForm";
            this.Text = "文件转换";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EasyFileConvertForm_FormClosing);
            this.Load += new System.EventHandler(this.EasyFileConvertForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_FliePath;
        private System.Windows.Forms.Button btn_ConvertFile;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_OutputPath;
        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_OpenPath;
        private System.Windows.Forms.TextBox tbx_FileName;
        private System.Windows.Forms.TextBox tbx_OutputPath;
        private System.Windows.Forms.RadioButton rb_prj;
        private System.Windows.Forms.RadioButton rb_xdf;
        private System.Windows.Forms.Label lbl_Format;
        private System.Windows.Forms.ComboBox cbx_dxfType;
        private System.Windows.Forms.RadioButton rb_ets;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

