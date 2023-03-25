using ETSystem.AutoFileConvert.Common;
using ETSystem.AutoFileConvert.Model;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace ETSystem.AutoFileConvert
{
    public partial class FileLibraryForm : Form
    {
        public FileLibraryForm()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            lv_DownFileList.Items.Clear();

            var param = $"pageIndex=1&pageSize=20&queryType=0&query={tbx_Search.Text.Trim()}";

            var response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/files/needDowloadFiles", param, PublicData.UserA.CookieContainer);

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
                    UploadDate = jToken["Time"].ToObject<DateTime>().ToString("yyyy-MM-dd hh:mm:ss"),
                    TypeAfter = jToken["TypeAfter"].ToObject<string>()
                };

                var item = new ListViewItem();

                item.SubItems[0].Text = file.FileId;

                item.SubItems.Add(file.FileName);

                item.SubItems.Add(file.UploadCompany);

                item.SubItems.Add(file.UploadDate);

                lv_DownFileList.Items.Add(item);
            }
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
                var response = HttpHelper.HttpGet($"https://file.etsystem.cn/cadapi/files/dowonload?fileIds={lv_DownFileList.SelectedItems[0].SubItems[0].Text}", "", PublicData.UserA.CookieContainer);

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
