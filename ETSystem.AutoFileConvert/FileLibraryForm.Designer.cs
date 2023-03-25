namespace ETSystem.AutoFileConvert
{
    partial class FileLibraryForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tbx_Search = new System.Windows.Forms.TextBox();
            this.lbl_SearchFileName = new System.Windows.Forms.Label();
            this.lv_DownFileList = new System.Windows.Forms.ListView();
            this.DownFileId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConvertDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Download = new System.Windows.Forms.Button();
            this.UploadUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn_Download);
            this.groupBox1.Controls.Add(this.lv_DownFileList);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.tbx_Search);
            this.groupBox1.Controls.Add(this.lbl_SearchFileName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 196);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(413, 16);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 27);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "搜索";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tbx_Search
            // 
            this.tbx_Search.BackColor = System.Drawing.Color.White;
            this.tbx_Search.Location = new System.Drawing.Point(72, 19);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(335, 21);
            this.tbx_Search.TabIndex = 4;
            // 
            // lbl_SearchFileName
            // 
            this.lbl_SearchFileName.AutoSize = true;
            this.lbl_SearchFileName.BackColor = System.Drawing.Color.White;
            this.lbl_SearchFileName.Location = new System.Drawing.Point(13, 23);
            this.lbl_SearchFileName.Name = "lbl_SearchFileName";
            this.lbl_SearchFileName.Size = new System.Drawing.Size(53, 12);
            this.lbl_SearchFileName.TabIndex = 3;
            this.lbl_SearchFileName.Text = "文件名：";
            // 
            // lv_DownFileList
            // 
            this.lv_DownFileList.BackColor = System.Drawing.Color.White;
            this.lv_DownFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DownFileId,
            this.DownFileName,
            this.UploadUserName,
            this.ConvertDate});
            this.lv_DownFileList.FullRowSelect = true;
            this.lv_DownFileList.HideSelection = false;
            this.lv_DownFileList.Location = new System.Drawing.Point(15, 49);
            this.lv_DownFileList.Name = "lv_DownFileList";
            this.lv_DownFileList.Size = new System.Drawing.Size(392, 141);
            this.lv_DownFileList.TabIndex = 7;
            this.lv_DownFileList.UseCompatibleStateImageBehavior = false;
            this.lv_DownFileList.View = System.Windows.Forms.View.Details;
            // 
            // DownFileId
            // 
            this.DownFileId.Text = "文件ID";
            this.DownFileId.Width = 0;
            // 
            // DownFileName
            // 
            this.DownFileName.Text = "文件名";
            this.DownFileName.Width = 158;
            // 
            // ConvertDate
            // 
            this.ConvertDate.Text = "创建时间";
            this.ConvertDate.Width = 130;
            // 
            // btn_Download
            // 
            this.btn_Download.BackColor = System.Drawing.Color.White;
            this.btn_Download.Location = new System.Drawing.Point(413, 49);
            this.btn_Download.Name = "btn_Download";
            this.btn_Download.Size = new System.Drawing.Size(75, 141);
            this.btn_Download.TabIndex = 8;
            this.btn_Download.Text = "下载";
            this.btn_Download.UseVisualStyleBackColor = false;
            this.btn_Download.Click += new System.EventHandler(this.btn_Download_Click);
            // 
            // UploadUserName
            // 
            this.UploadUserName.Text = "发送方";
            this.UploadUserName.Width = 80;
            // 
            // FileLibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(518, 220);
            this.Controls.Add(this.groupBox1);
            this.Name = "FileLibraryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FileLibraryForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tbx_Search;
        private System.Windows.Forms.Label lbl_SearchFileName;
        private System.Windows.Forms.ListView lv_DownFileList;
        private System.Windows.Forms.ColumnHeader DownFileId;
        private System.Windows.Forms.ColumnHeader DownFileName;
        private System.Windows.Forms.ColumnHeader ConvertDate;
        private System.Windows.Forms.Button btn_Download;
        private System.Windows.Forms.ColumnHeader UploadUserName;
    }
}