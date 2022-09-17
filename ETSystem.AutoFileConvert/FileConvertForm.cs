using ETSystem.AutoFileConvert.Common;
using ETSystem.AutoFileConvert.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ETSystem.AutoFileConvert
{
    public partial class FileConvertForm : Form
    {
        public FileConvertForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            //定义一个文件打开控件

            OpenFileDialog ofd = new OpenFileDialog();

            //设置打开对话框的初始目录，默认目录为exe运行文件所在的路径

            ofd.InitialDirectory = Application.StartupPath;

            //设置打开对话框的标题

            ofd.Title = "请选择要打开的文件";

            //设置打开对话框可以多选

            ofd.Multiselect = false;

            //设置对话框打开的文件类型

            ofd.Filter = "ETS文件|*.ets";

            //设置文件对话框当前选定的筛选器的索引

            ofd.FilterIndex = 2;

            //设置对话框是否记忆之前打开的目录

            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件完整路径

                lbl_FliePath.Text = ofd.FileName;

                //获取对话框中所选文件的文件名和扩展名，文件名不包括路径

                tbx_FileName.Text = ofd.SafeFileName;
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UploadFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_FliePath.Text)) 
            {
                MessageBox.Show("请选择要上传的文件后再操作！");

                return;
            }

            var uploadStr = JsonConvert.SerializeObject(new { buyCompanyId = PublicData.UserB.CompanyId, saleCompanyName = PublicData.UserA.CompanyName, ext = "ets" });

            var response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/deal/getossparas", uploadStr, PublicData.UserA.CookieContainer);

            if (!response.Success) 
            {
                MessageBox.Show($"获取oss配置失败：{response.Message}");

                return;
            }

            var jTokenObj = (JToken)JsonConvert.DeserializeObject(response.Message);

            var ossConfig = new OssConfig
            {
                AccessId = jTokenObj["Data"]["accessid"].ToString(),
                Dir = jTokenObj["Data"]["dir"].ToString(),
                FileName = jTokenObj["Data"]["FileName"].ToString(),
                OssHost = jTokenObj["Data"]["osshost"].ToString(),
                Policy = jTokenObj["Data"]["policy"].ToString(),
                Signature = jTokenObj["Data"]["signature"].ToString(),
                Mode = jTokenObj["Mode"].ToString()
            };

            var data = new NameValueCollection
            {
                { "policy", ossConfig.Policy},
                { "OSSAccessKeyId", ossConfig.AccessId },
                { "success_action_status", "200" },
                { "signature", ossConfig.Signature},
                { "region", ossConfig.OssHost},
                { "dic", ossConfig.Dir},
                { "name", $"{ossConfig.FileName}.ets" },
                { "key", $"{ossConfig.Dir}{ossConfig.FileName}.ets" },
            };

            response = HttpHelper.HttpUpload(ossConfig.OssHost, lbl_FliePath.Text, data);

            if (!response.Success)
            {
                MessageBox.Show($"上传文件失败：{response.Message}");

                return;
            }
            

            uploadStr = JsonConvert.SerializeObject(new 
            {
                fileName = tbx_FileName.Text,
                proId = 0,
                fileSize = new FileInfo(lbl_FliePath.Text).Length,
                FileConverId = ossConfig.FileName,
                remark = "",
                isMark = false,
                gridType = 0,
                Bid = PublicData.UserB.CompanyId,
                filePath = ossConfig.Dir,
                Mode = ossConfig.Mode,
                ReceiveCompanyId = PublicData.UserB.CompanyId,
                sourceKey = $"{ossConfig.Dir}{ossConfig.FileName}.ets"
            });

            response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/deal/uploadFile", uploadStr, PublicData.UserA.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"更新上传信息失败：{response.Message}");

                return;
            }

            lbl_FliePath.Text = string.Empty;

            tbx_FileName.Text = string.Empty;

            MessageBox.Show($"上传成功！");
        }

        private void FileConvertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //询问是否关闭窗体

            DialogResult result = MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.OKCancel);

            //关闭窗体判断

            if (result == DialogResult.OK)
            {
                this.Hide();

                Environment.Exit(Environment.ExitCode);

                this.Dispose();

                this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            lv_FileList.Items.Clear();

            lv_DownFileList.Items.Clear();

            var param = $"pageIndex=1&pageSize=20&queryType=0&query={tbx_Search.Text.Trim()}";

            var response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/files/needDowloadFiles", param, PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"搜索失败，请尝试关闭程序重新登录后再试！");

                return;
            }

            var jArray = ((JToken)JsonConvert.DeserializeObject(response.Message))["Data"]["Rows"] as JArray;

            foreach (var jToken in jArray)
            {
                var file = new ETFile
                {
                    FileId = jToken["Id"].ToObject<string>(),
                    FileName = jToken["FileName"].ToObject<string>(),
                    UploadCompany = jToken["Name"].ToObject<string>(),
                    UploadUser = jToken["UserName"].ToObject<string>(),
                    UploadDate = jToken["Time"].ToObject<DateTime>().ToString("yyyy-MM-dd HH:mm:ss"),
                    TypeAfter = jToken["TypeAfter"].ToObject<string>()
                };

                if (file.UploadCompany == PublicData.UserA.CompanyName || file.UploadUser == PublicData.UserA.UserName) 
                {
                    if (file.TypeAfter == "ets")
                    {
                        var item = new ListViewItem();

                        item.SubItems[0].Text = file.FileId;

                        item.SubItems.Add(file.FileName);

                        item.SubItems.Add(file.UploadDate);

                        lv_FileList.Items.Add(item);
                    }
                }

                if (file.UploadCompany == PublicData.UserB.CompanyName || file.UploadUser == PublicData.UserB.UserName)
                {
                    if (file.TypeAfter == "prj" || file.TypeAfter == "dxf")
                    {
                        var item = new ListViewItem();

                        item.SubItems[0].Text = file.FileId;

                        var arr = file.FileName.Replace(".ets", $".{file.TypeAfter}").Split('_');

                        if (arr.Length < 4) continue;

                        if (arr[0] == PublicData.UserA.CompanyName && arr[1] == PublicData.UserA.UserName) 
                        {
                            var fileName = string.Join("_", arr.Skip(3));

                            item.SubItems.Add(fileName);

                            item.SubItems.Add(file.UploadDate);

                            lv_DownFileList.Items.Add(item);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 格式转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Convert_Click(object sender, EventArgs e)
        {
            if (lv_FileList.SelectedItems.Count == 0) 
            {
                MessageBox.Show($"请选中待转换的文件！");

                return;
            }

            var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={lv_FileList.SelectedItems[0].SubItems[0].Text}", "", PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"获取下载信息失败：{response.Message}");

                return;
            }

            var downUrl = ((JArray)((JToken)JsonConvert.DeserializeObject(response.Message))["pathList"])[0].ToObject<string>();

            var fileName = $"{PublicData.UserA.CompanyName}_{PublicData.UserA.UserName}_{DateTime.Now:yyyyMMddHHmmss}_{lv_FileList.SelectedItems[0].SubItems[1].Text}";

            response = HttpHelper.HttpDownload(downUrl, fileName);

            if (!response.Success)
            {
                MessageBox.Show($"下载待传输文件失败：{response.Message}");

                return;
            }

            var typeAfter = rb_prj.Checked ? "db" : "dxf";
            
            var paramStr = $"toCompanyId={PublicData.UserB.CompanyId}&fileCount=1&projectId=0&typeAfter={typeAfter}&ext=ets";

            response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/FileConvert/getOssPara", paramStr, PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"获取oss配置失败：{response.Message}");

                return;
            }

            var jTokenObj = (JToken)JsonConvert.DeserializeObject(response.Message);

            var ossConfig = new OssConfig
            {
                AccessId = jTokenObj["Data"]["accessid"].ToString(),
                Dir = jTokenObj["Data"]["dir"].ToString(),
                FileName = jTokenObj["Data"]["FileName"].ToString(),
                OssHost = jTokenObj["Data"]["osshost"].ToString(),
                Policy = jTokenObj["Data"]["policy"].ToString(),
                Signature = jTokenObj["Data"]["signature"].ToString(),
            };

            var data = new NameValueCollection
            {
                { "policy", ossConfig.Policy},
                { "OSSAccessKeyId", ossConfig.AccessId },
                { "success_action_status", "200" },
                { "signature", ossConfig.Signature},
                { "region", ossConfig.OssHost},
                { "dic", ossConfig.Dir},
                { "name", $"{ossConfig.FileName}.ets" },
                { "key", $"{ossConfig.Dir}{ossConfig.FileName}.ets" },
            };

            var filePath = $"{Application.StartupPath}\\Download\\{fileName}";

            response = HttpHelper.HttpUpload(ossConfig.OssHost, filePath, data);

            if (!response.Success)
            {
                MessageBox.Show($"上传文件失败：{response.Message}");

                return;
            }

            var users = new int[] { PublicData.UserB.UserId };

            var exportType = rb_prj.Checked ? "DB" : "HGGT";

            var uploadStr = JsonConvert.SerializeObject(new
            {
                fileName = fileName,
                fileSize = new FileInfo(filePath).Length,
                FileConverId = ossConfig.FileName,
                users = users,
                companyId = PublicData.UserB.CompanyId,
                exportType = exportType,
                projectId = 0
            });

            response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/FileConvert/uploadFile", uploadStr, PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败：{response.Message}");

                return;
            }

            MessageBox.Show($"转换成功！");

            btn_Search.PerformClick();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            if (lv_DownFileList.SelectedItems.Count == 0)
            {
                MessageBox.Show($"请选中要下载的文件！");

                return;
            }

            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "请要保存选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={lv_DownFileList.SelectedItems[0].SubItems[0].Text}", "", PublicData.UserB.CookieContainer);

                if (!response.Success)
                {
                    MessageBox.Show($"获取下载信息失败：{response.Message}");

                    return;
                }

                var downUrl = ((JArray)((JToken)JsonConvert.DeserializeObject(response.Message))["pathList"])[0].ToObject<string>();

                var fileName = lv_DownFileList.SelectedItems[0].SubItems[1].Text;

                response = HttpHelper.HttpDownload(downUrl, fileName, dialog.SelectedPath);

                if (!response.Success)
                {
                    MessageBox.Show($"下载文件失败：{response.Message}");

                    return;
                }

                MessageBox.Show($"下载成功！");

                btn_Search.PerformClick();
            }
        }
    }
}
