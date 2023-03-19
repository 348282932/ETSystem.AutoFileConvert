using ETSystem.AutoFileConvert.Common;
using ETSystem.AutoFileConvert.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ETSystem.AutoFileConvert
{
    public partial class EasyFileConvertForm : BaseForm
    {
        /// <summary>
        /// 历史搜索缓存文件地址
        /// </summary>
        private static readonly string serchCachePath = $"{Application.StartupPath}\\SeachCache.data";

        public static List<ETFile> downFileList = new List<ETFile>();

        public static string id = string.Empty;

        public static string fileConversionID = string.Empty;

        public static string dxfType = string.Empty;

        public static string initialDirectory = Application.StartupPath;


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

            ofd.InitialDirectory = initialDirectory;

            //设置打开对话框的标题

            ofd.Title = "请选择要打开的文件";

            //设置打开对话框可以多选

            ofd.Multiselect = false;

            //设置对话框打开的文件类型

            ofd.Filter = "ET系统文件（*.ets,*.prj）|*.ets;*.prj";

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

                initialDirectory = Path.GetDirectoryName(ofd.FileName);
            }
        }

        /// <summary>
        /// 搜索文件
        /// </summary>
        /// <param name="isSimpleConvert"></param>
        /// <returns></returns>
        private bool SearchFile() 
        {
            downFileList.Clear();

            var param = $"pageIndex=1&pageSize=20&queryType=0&query=";

            var user = PublicData.UserA;

            var response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/files/needDowloadFiles", param, user.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败！{response.Message}");

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

                if (file.UploadCompany == user.CompanyName || file.UploadUser == user.UserName)
                {
                    if (file.TypeAfter == "prj" || file.TypeAfter == "ets" || file.TypeAfter == "dxf")
                    {
                        downFileList.Add(file);
                    }
                }
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
            var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={fileId}", "", PublicData.UserA.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败！{response.Message}");

                return false;
            }

            var jArry = (JArray)((JToken)JsonConvert.DeserializeObject(response.Message))["pathList"];

            for (int i = 0; i < jArry.Count; i++)
            {
                var downUrl = jArry[i].ToObject<string>();

                if (downUrl.IndexOf(".rul?") > -1)
                {
                    fileName = fileName.Replace(".dxf", ".rul");
                    fileName = fileName.Replace(".ets", ".rul");
                }
                if (downUrl.IndexOf(".dxf?") > -1)
                {
                    fileName = fileName.Replace(".ets", ".dxf");
                }

                if (downUrl.IndexOf(".prj?") > -1)
                {
                    fileName = fileName.Replace(".ets", ".prj");
                }

                if (downUrl.IndexOf(".ets?") > -1)
                {
                    fileName = fileName.Replace(".prj", ".ets");
                }

                response = HttpHelper.HttpDownload(downUrl, fileName, savePath);

                if (!response.Success)
                {
                    MessageBox.Show($"转换失败！{response.Message}");

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 简单转换文件（直接用A账户转）
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool SimpleConvertFile(string filePath, string fileName)
        {
            var typeAfter = rb_prj.Checked ? "db" : rb_ets.Checked ? "" : "dxf";

            var ext = rb_ets.Checked ? "prj" : "ets";

            var paramStr = $"toCompanyId={PublicData.UserA.CompanyId}&fileCount=1&projectId=0&typeAfter={typeAfter}&ext={ext}";

            var response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/FileConvert/getOssPara", paramStr, PublicData.UserA.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败！{response.Message}");

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
                { "name", $"{ossConfig.FileName}.{ext}" },
                { "key", $"{ossConfig.Dir}{ossConfig.FileName}.{ext}" },
            };

            response = HttpHelper.HttpUpload(ossConfig.OssHost, filePath, data);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败！{response.Message}");

                return false;
            }

            var users = new int[] { PublicData.UserA.UserId };

            var exportType = rb_prj.Checked ? "DB" : dxfType;

            var uploadStr = JsonConvert.SerializeObject(new
            {
                fileName = fileName,
                fileSize = new FileInfo(filePath).Length,
                FileConverId = ossConfig.FileName,
                users = users,
                companyId = PublicData.UserA.CompanyId,
                exportType = exportType,
                sourceKey = $"{ossConfig.Dir}{ossConfig.FileName}.{ext}",
                projectId = 0
            });

            response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/FileConvert/uploadFile", uploadStr, PublicData.UserA.CookieContainer);

            if (!response.Success)
            {
                MessageBox.Show($"转换失败！{response.Message}");

                return false;
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

            dxfType = cbx_dxfType.SelectedValue.ToString();

            if (rb_prj.Checked && !lbl_FliePath.Text.EndsWith(".ets", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("转正版请上传.ets格式的文件后再操作！");

                return;
            }

            if (rb_ets.Checked && !lbl_FliePath.Text.EndsWith(".prj", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("转正版请上传.prj格式的文件后再操作！");

                return;
            }

            if (rb_xdf.Checked && !lbl_FliePath.Text.EndsWith(".ets", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("转DXF请上传.ets格式的文件后再操作！");

                return;
            }

            var userSeachCache = JsonConvert.SerializeObject(new { FliePath = Path.GetDirectoryName(lbl_FliePath.Text), OutputPath = tbx_OutputPath.Text });

            File.WriteAllText(serchCachePath, userSeachCache);

            this.DoWorkAsync((o) => //耗时逻辑处理(此处不能操作UI控件，因为是在异步中)
            {
                var file = new ETFile();

                var num = 0;

                if (!SimpleConvertFile(lbl_FliePath.Text, tbx_FileName.Text)) return false;

                do
                {
                    Thread.Sleep(3000);

                    SearchFile();

                    file = downFileList.FirstOrDefault(f => f.FileConversionID == fileConversionID);

                    if (++num > 20) return false;

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
            BindDxfTypeCbx(); // 绑定 DXF 选项

            LoadSeachCache(); // 加载搜索缓存

            LoadConvertAuth(); // 加载转换类型授权
        }

        /// <summary>
        /// 绑定 DXF 选项
        /// </summary>
        private void BindDxfTypeCbx()
        {
            var dxfTypeList = new List<DxfType>() 
            {
                new DxfType() { Text = "格伯和力克", Value = "HGGT" },
                new DxfType() { Text = "格柏低版本", Value = "LGGT" },
                new DxfType() { Text = "艾维丝", Value = "AWS" },
                new DxfType() { Text = "度卡DXF", Value = "UK" },
                new DxfType() { Text = "AUTOCAD", Value = "ACAD" },
                new DxfType() { Text = "AI DXF", Value = "AI" },
                new DxfType() { Text = "其它DXF", Value = "OTHER" }
            };
            cbx_dxfType.DataSource = dxfTypeList;

            cbx_dxfType.ValueMember = "Value";

            cbx_dxfType.DisplayMember = "Text";

            cbx_dxfType.Visible = false;
        }

        private void rb_xdf_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_xdf.Checked)
            {
                cbx_dxfType.Visible = true;
            }
            else 
            {
                cbx_dxfType.Visible = false;
            }
        }

        /// <summary>
        /// 加载搜索缓存
        /// </summary>
        private void LoadSeachCache() 
        {
            if (File.Exists(serchCachePath))
            {
                var jTokenObj = (JToken)JsonConvert.DeserializeObject(File.ReadAllText(serchCachePath));

                var fliePath = jTokenObj["FliePath"].ToString();

                if (Directory.Exists(fliePath)) initialDirectory = fliePath;

                var outputPath = jTokenObj["OutputPath"].ToString();

                if (Directory.Exists(outputPath)) tbx_OutputPath.Text = outputPath;
            }
        }

        /// <summary>
        /// 加载转换类型授权
        /// </summary>
        private void LoadConvertAuth()
        {
            var format = ConfigurationManager.AppSettings["Format"]?.ToString();

            string[] formatArray;

            if (string.IsNullOrEmpty(format) || (formatArray = format.Split('|')).Length != 3)
            {
                lbl_Format.Text = "转换格式：  转换格式未授权，请授权后再使用！";

                rb_prj.Visible = false;

                rb_ets.Visible = false;

                rb_xdf.Visible = false;

                this.btn_ConvertFile.Enabled = false;

                return;
            }

            if (formatArray[0] != "1") rb_prj.Visible = false;

            if (formatArray[1] != "1") rb_ets.Visible = false;

            if (formatArray[2] != "1") rb_xdf.Visible = false;

            if (rb_prj.Visible)
            {
                rb_prj.Checked = true;
            }
            else if (rb_ets.Visible)
            {
                rb_ets.Checked = true;

                rb_prj.Location = new System.Drawing.Point(0, 0);

                rb_ets.Location = new System.Drawing.Point(98, 69);
            }
            else if (rb_xdf.Visible)
            {
                rb_prj.Location = new System.Drawing.Point(0, 0);

                rb_xdf.Location = new System.Drawing.Point(98, 69);

                cbx_dxfType.Location = new System.Drawing.Point(148, 66);

                rb_xdf.Checked = true;
            }
            else 
            {
                lbl_Format.Text = "转换格式：  转换格式未授权，请授权后再使用！";

                this.btn_ConvertFile.Enabled = false;
            }
        }
    }
}
