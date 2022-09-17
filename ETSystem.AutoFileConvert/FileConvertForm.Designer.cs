namespace ETSystem.AutoFileConvert
{
    partial class FileConvertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileConvertForm));
            this.btn_OpenFile = new System.Windows.Forms.Button();
            this.btn_UploadFile = new System.Windows.Forms.Button();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lbl_FliePath = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbx_FileName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_xdf = new System.Windows.Forms.RadioButton();
            this.rb_prj = new System.Windows.Forms.RadioButton();
            this.btn_Download = new System.Windows.Forms.Button();
            this.lv_DownFileList = new System.Windows.Forms.ListView();
            this.DownFileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConvertDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Convert = new System.Windows.Forms.Button();
            this.lv_FileList = new System.Windows.Forms.ListView();
            this.FileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UploadDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Search = new System.Windows.Forms.Button();
            this.tbx_Search = new System.Windows.Forms.TextBox();
            this.lbl_SearchFileName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OpenFile
            // 
            this.btn_OpenFile.Location = new System.Drawing.Point(286, 30);
            this.btn_OpenFile.Name = "btn_OpenFile";
            this.btn_OpenFile.Size = new System.Drawing.Size(75, 23);
            this.btn_OpenFile.TabIndex = 0;
            this.btn_OpenFile.Text = "选取文件";
            this.btn_OpenFile.UseVisualStyleBackColor = true;
            this.btn_OpenFile.Click += new System.EventHandler(this.btn_OpenFile_Click);
            // 
            // btn_UploadFile
            // 
            this.btn_UploadFile.Location = new System.Drawing.Point(286, 63);
            this.btn_UploadFile.Name = "btn_UploadFile";
            this.btn_UploadFile.Size = new System.Drawing.Size(75, 23);
            this.btn_UploadFile.TabIndex = 0;
            this.btn_UploadFile.Text = "上传";
            this.btn_UploadFile.UseVisualStyleBackColor = true;
            this.btn_UploadFile.Click += new System.EventHandler(this.btn_UploadFile_Click);
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(15, 33);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(77, 12);
            this.lbl_FileName.TabIndex = 1;
            this.lbl_FileName.Text = "待上传文件：";
            // 
            // lbl_FliePath
            // 
            this.lbl_FliePath.AutoSize = true;
            this.lbl_FliePath.Location = new System.Drawing.Point(15, 68);
            this.lbl_FliePath.Name = "lbl_FliePath";
            this.lbl_FliePath.Size = new System.Drawing.Size(0, 12);
            this.lbl_FliePath.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_FileName);
            this.groupBox1.Controls.Add(this.lbl_FliePath);
            this.groupBox1.Controls.Add(this.btn_OpenFile);
            this.groupBox1.Controls.Add(this.lbl_FileName);
            this.groupBox1.Controls.Add(this.btn_UploadFile);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 92);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tbx_FileName
            // 
            this.tbx_FileName.Location = new System.Drawing.Point(98, 30);
            this.tbx_FileName.Name = "tbx_FileName";
            this.tbx_FileName.ReadOnly = true;
            this.tbx_FileName.Size = new System.Drawing.Size(182, 21);
            this.tbx_FileName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb_xdf);
            this.groupBox2.Controls.Add(this.rb_prj);
            this.groupBox2.Controls.Add(this.btn_Download);
            this.groupBox2.Controls.Add(this.lv_DownFileList);
            this.groupBox2.Controls.Add(this.btn_Convert);
            this.groupBox2.Controls.Add(this.lv_FileList);
            this.groupBox2.Controls.Add(this.btn_Search);
            this.groupBox2.Controls.Add(this.tbx_Search);
            this.groupBox2.Controls.Add(this.lbl_SearchFileName);
            this.groupBox2.Location = new System.Drawing.Point(15, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 534);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // rb_xdf
            // 
            this.rb_xdf.AutoSize = true;
            this.rb_xdf.Location = new System.Drawing.Point(280, 257);
            this.rb_xdf.Name = "rb_xdf";
            this.rb_xdf.Size = new System.Drawing.Size(113, 16);
            this.rb_xdf.TabIndex = 8;
            this.rb_xdf.Text = "DXF(格柏和力克)";
            this.rb_xdf.UseVisualStyleBackColor = true;
            // 
            // rb_prj
            // 
            this.rb_prj.AutoSize = true;
            this.rb_prj.Checked = true;
            this.rb_prj.Location = new System.Drawing.Point(7, 257);
            this.rb_prj.Name = "rb_prj";
            this.rb_prj.Size = new System.Drawing.Size(95, 16);
            this.rb_prj.TabIndex = 8;
            this.rb_prj.TabStop = true;
            this.rb_prj.Text = "ET非正版文件";
            this.rb_prj.UseVisualStyleBackColor = true;
            // 
            // btn_Download
            // 
            this.btn_Download.Location = new System.Drawing.Point(114, 490);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(147, 33);
            this.btn_Download.TabIndex = 7;
            this.btn_Download.Text = "下载";
            this.btn_Download.UseVisualStyleBackColor = true;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // lv_DownFileList
            // 
            this.lv_DownFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DownFileId,
            this.DownFileName,
            this.ConvertDate});
            this.lv_DownFileList.FullRowSelect = true;
            this.lv_DownFileList.HideSelection = false;
            this.lv_DownFileList.Location = new System.Drawing.Point(7, 283);
            this.lv_DownFileList.Name = "lv_DownFileList";
            this.lv_DownFileList.Size = new System.Drawing.Size(385, 197);
            this.lv_DownFileList.TabIndex = 6;
            this.lv_DownFileList.UseCompatibleStateImageBehavior = false;
            this.lv_DownFileList.View = System.Windows.Forms.View.Details;
            // 
            // DownFileId
            // 
            this.DownFileId.Text = "文件ID";
            this.DownFileId.Width = 70;
            // 
            // DownFileName
            // 
            this.DownFileName.Text = "文件名";
            this.DownFileName.Width = 126;
            // 
            // ConvertDate
            // 
            this.ConvertDate.Text = "转换完成时间";
            this.ConvertDate.Width = 180;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Location = new System.Drawing.Point(108, 254);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(165, 23);
            this.btn_Convert.TabIndex = 5;
            this.btn_Convert.Text = "↓ 选中文件进行转换 ↓";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // lv_FileList
            // 
            this.lv_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileId,
            this.FileName,
            this.UploadDate});
            this.lv_FileList.FullRowSelect = true;
            this.lv_FileList.HideSelection = false;
            this.lv_FileList.Location = new System.Drawing.Point(6, 47);
            this.lv_FileList.Name = "lv_FileList";
            this.lv_FileList.Size = new System.Drawing.Size(386, 201);
            this.lv_FileList.TabIndex = 3;
            this.lv_FileList.UseCompatibleStateImageBehavior = false;
            this.lv_FileList.View = System.Windows.Forms.View.Details;
            // 
            // FileId
            // 
            this.FileId.Text = "文件ID";
            this.FileId.Width = 70;
            // 
            // FileName
            // 
            this.FileName.Text = "文件名";
            this.FileName.Width = 126;
            // 
            // UploadDate
            // 
            this.UploadDate.Text = "上传时间";
            this.UploadDate.Width = 180;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(286, 18);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tbx_Search
            // 
            this.tbx_Search.Location = new System.Drawing.Point(98, 18);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(182, 21);
            this.tbx_Search.TabIndex = 1;
            // 
            // lbl_SearchFileName
            // 
            this.lbl_SearchFileName.AutoSize = true;
            this.lbl_SearchFileName.Location = new System.Drawing.Point(15, 21);
            this.lbl_SearchFileName.Name = "lbl_SearchFileName";
            this.lbl_SearchFileName.Size = new System.Drawing.Size(77, 12);
            this.lbl_SearchFileName.TabIndex = 0;
            this.lbl_SearchFileName.Text = "已上传文件：";
            // 
            // FileConvertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 657);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileConvertForm";
            this.Text = "文件转换";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileConvertForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenFile;
        private System.Windows.Forms.Button btn_UploadFile;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_FliePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_FileName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lv_FileList;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader UploadDate;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tbx_Search;
        private System.Windows.Forms.Label lbl_SearchFileName;
        private System.Windows.Forms.ColumnHeader FileId;
        private System.Windows.Forms.Button btn_Convert;
        private System.Windows.Forms.ListView lv_DownFileList;
        private System.Windows.Forms.ColumnHeader DownFileId;
        private System.Windows.Forms.ColumnHeader DownFileName;
        private System.Windows.Forms.ColumnHeader ConvertDate;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.RadioButton rb_xdf;
        private System.Windows.Forms.RadioButton rb_prj;
    }
}

