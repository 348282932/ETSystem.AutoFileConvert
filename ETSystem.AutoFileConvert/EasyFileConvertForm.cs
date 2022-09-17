using ETSystem.AutoFileConvert.Common;
using ETSystem.AutoFileConvert.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ETSystem.AutoFileConvert
{
    public partial class EasyFileConvertForm : BaseForm
    {
        public static List<ETFile> uploadFileList = new List<ETFile>();

        public static List<ETFile> downFileList = new List<ETFile>();

        public static string id = string.Empty;

        public static string fileConversionID = string.Empty;


        public EasyFileConvertForm()
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
        /// 上传ETS文件
        /// </summary>
        /// <returns></returns>
        private bool UploadFile(string filePath) 
        {
            var uploadStr = JsonConvert.SerializeObject(new { buyCompanyId = PublicData.UserB.CompanyId, saleCompanyName = PublicData.UserA.CompanyName, ext = "ets" });

            var response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/deal/getossparas", uploadStr, PublicData.UserA.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
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

            fileConversionID = ossConfig.FileName;

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

            response = HttpHelper.HttpUpload(ossConfig.OssHost, filePath, data);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
            }

            uploadStr = JsonConvert.SerializeObject(new
            {
                fileName = tbx_FileName.Text,
                proId = 0,
                fileSize = new FileInfo(filePath).Length,
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
                MessageBox.Show("转换失败！");

                return false; 
            }

            return true;
        }

        /// <summary>
        /// 搜索文件
        /// </summary>
        /// <returns></returns>
        private bool SearchFile() 
        {
            uploadFileList.Clear();

            downFileList.Clear();

            var param = $"pageIndex=1&pageSize=20&queryType=0&query=";

            var response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/files/needDowloadFiles", param, PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
            }

            var jArray = ((JToken)JsonConvert.DeserializeObject(response.Message))["Data"]["Rows"] as JArray;

            foreach (var jToken in jArray)
            {
                var file = new ETFile
                {
                    FileId = jToken["Id"].ToObject<string>(),
                    FileConversionID = jToken["FileConversionID"].ToObject<string>(),
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
                        uploadFileList.Add(file);
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
                            file.FileName = string.Join("_", arr.Skip(3));

                            downFileList.Add(file);
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 转换文件
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="convertFileName"></param>
        /// <returns></returns>
        private bool ConvertFile(string fileId, string convertFileName) 
        {
            var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={fileId}", "", PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
            }

            var downUrl = ((JArray)((JToken)JsonConvert.DeserializeObject(response.Message))["pathList"])[0].ToObject<string>();

            var fileName = $"{PublicData.UserA.CompanyName}_{PublicData.UserA.UserName}_{DateTime.Now:yyyyMMddHHmmss}_{convertFileName}";

            response = HttpHelper.HttpDownload(downUrl, fileName);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
            }

            var typeAfter = rb_prj.Checked ? "db" : "dxf";

            var paramStr = $"toCompanyId={PublicData.UserB.CompanyId}&fileCount=1&projectId=0&typeAfter={typeAfter}&ext=ets";

            response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/FileConvert/getOssPara", paramStr, PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
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

            fileConversionID = ossConfig.FileName;

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
                MessageBox.Show("转换失败！");

                return false;
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
                MessageBox.Show("转换失败！");

                return false;
            }

            return true;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="fileName"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private bool Download(string fileId, string fileName, string savePath) 
        {
            var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={fileId}", "", PublicData.UserB.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show("转换失败！");

                return false;
            }

            var jArry = (JArray)((JToken)JsonConvert.DeserializeObject(response.Message))["pathList"];

            for (int i = 0; i < jArry.Count; i++)
            {
                var downUrl = jArry[i].ToObject<string>();

                if (downUrl.IndexOf(".rul?") > -1) fileName = fileName.Replace(".dxf", ".rul");

                response = HttpHelper.HttpDownload(downUrl, fileName, savePath);

                if (!response.Success)
                {
                    MessageBox.Show("转换失败！");

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ConvertFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_FliePath.Text))
            {
                MessageBox.Show("请选择要转换的文件后再操作！");

                return;
            }

            if (string.IsNullOrEmpty(tbx_OutputPath.Text))
            {
                MessageBox.Show("请设置转换后文件的保存路径后再操作！");

                return;
            }

            this.DoWorkAsync((o) => //耗时逻辑处理(此处不能操作UI控件，因为是在异步中)
            {
                if (!UploadFile(lbl_FliePath.Text)) return false;

                var file = new ETFile();

                var num = 0;

                do
                {
                    Thread.Sleep(3000);

                    SearchFile();

                    file = uploadFileList.FirstOrDefault(f => f.FileConversionID == fileConversionID);

                    if (++num > 6) return false;

                } while (file == null);

                if (!ConvertFile(file.FileId, file.FileName)) return false; 

                num = 0;

                do
                {
                    Thread.Sleep(3000);

                    SearchFile();

                    file = downFileList.FirstOrDefault(f => f.FileConversionID == fileConversionID);

                    if (++num > 8) return false;

                } while (file == null);

                return Download(file.FileId, file.FileName, tbx_OutputPath.Text);

            }, null, (success) => //显示结果（此处用于对上面结果的处理，比如显示到界面上）
            {
                if (success)
                {
                    lbl_FliePath.Text = string.Empty;

                    tbx_FileName.Text = string.Empty;

                    MessageBox.Show($"转换成功！");
                }
                else
                {
                    MessageBox.Show("转换失败！");
                }
            });
        }

        private void EasyFileConvertForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_OpenPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.Description = "请选择转换后文件的保存路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbx_OutputPath.Text = dialog.SelectedPath;
            }
        }

        private void EasyFileConvertForm_Load(object sender, EventArgs e)
        {
            var format = ConfigurationManager.AppSettings["Format"]?.ToString();

            string[] formatArray;

            if (string.IsNullOrEmpty(format) || (formatArray = format.Split('|')).Length != 2)
            {
                lbl_Format.Text = "转换格式：  转换格式未授权，请授权后再使用！";

                rb_prj.Visible = false;

                rb_xdf.Visible = false;

                this.btn_ConvertFile.Enabled = false;

                return;
            }

            if (formatArray[0] != "1")
            {
                rb_prj.Visible = false;

                rb_prj.Checked = false;

                rb_prj.Location = new Point(0, 0);

                rb_xdf.Checked = true;

                rb_xdf.Location = new Point(98, 69);
            }

            if (formatArray[1] != "1") 
            { 
                rb_xdf.Visible = false;

                rb_xdf.Checked = false;
            }

            if (!rb_prj.Visible && !rb_xdf.Visible) 
            {
                lbl_Format.Text = "转换格式：  转换格式未授权，请授权后再使用！";

                this.btn_ConvertFile.Enabled = false;
            }
        }
    }
}
