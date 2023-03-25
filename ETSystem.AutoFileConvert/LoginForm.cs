using ETSystem.AutoFileConvert.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace ETSystem.AutoFileConvert
{
    public partial class LoginForm : Form
    {
        /// <summary>
        /// 登录用户缓存文件地址
        /// </summary>
        private static readonly string cachePath = $"{Application.StartupPath}\\LoginCache.data";

        public LoginForm()
        {
            StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Login_Click(object sender, EventArgs e)
        {
            var account = tb_Account.Text.Trim();

            var password = tb_Password.Text.Trim();

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                lbl_Tip.Text = "登录失败：账号或者密码不能为空！";

                return;
            }

            // 登录并缓存用户A信息

            var cookieA = new CookieContainer();

            var responseA = Login(account, password, cookieA);

            if (!responseA.Success)
            {
                lbl_Tip.Text = responseA.Message;

                return;
            };

            PublicData.UserA = responseA.Data;

            // 登录并缓存用户B信息

            var cookieB = new CookieContainer();

            var serviceUserAccount = ConfigurationManager.AppSettings["Account"]?.ToString();

            var serviceUserPassword = ConfigurationManager.AppSettings["Password"]?.ToString();

            if (!string.IsNullOrEmpty(serviceUserAccount) && !string.IsNullOrEmpty(serviceUserPassword)) 
            {
                var responseB = Login(serviceUserAccount, serviceUserPassword, cookieB);

                if (responseB.Success)
                {
                    PublicData.UserB = responseB.Data;
                };
            }

            #region 记住密码

            if (cbx_SavePassword.Checked)
            {
                var userCache = JsonConvert.SerializeObject(new { Account = tb_Account.Text.Trim(), Password = tb_Password.Text.Trim() });

                File.WriteAllText(cachePath, userCache);
            }
            else 
            {
                if (File.Exists(cachePath)) File.Delete(cachePath);
            }

            #endregion

            var mainForm = new MainForm();

            mainForm.Show();

            this.Hide();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private Response<UserInfo> Login(string account, string password, CookieContainer cookie) 
        {
            var loginStr = JsonConvert.SerializeObject(new { username = account, password = password, lockinnum = "" });

            // 登录（获取TKOEN）

            var response = HttpHelper.HttpPost("https://file.etsystem.cn/cadapi/cuser/weblogin", loginStr, cookie);

            if (!response.Success) return new Response<UserInfo>(false, $"登录失败：{response.Message}");

            // 设置 TOKEN

            var token = ((JToken)JsonConvert.DeserializeObject(response.Message))["Data"]["token"].ToString();

            cookie.Add(new Cookie("ET-Token", token, "/", "file.etsystem.cn"));

            // 获取登录信息

            response = HttpHelper.HttpGet("https://file.etsystem.cn/cadapi/cuser/personInfo", "", cookie);

            if (!response.Success) return new Response<UserInfo>(false, $"获取登录信息失败：{response.Message}");

            var jTokenObj = (JToken)JsonConvert.DeserializeObject(response.Message);

            return new Response<UserInfo>(true, new UserInfo
            {
                CookieContainer = cookie,
                Token = token,
                CompanyId = jTokenObj["Data"]["CompanyId"].ToObject<int>(),
                CompanyName = jTokenObj["Data"]["CompanyName"].ToString(),
                UserName = jTokenObj["Data"]["UserName"].ToString(),
                UserId = jTokenObj["Data"]["Id"].ToObject<int>(),
            });
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);

            this.Dispose();

            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var downLoadCachePath = $"{Application.StartupPath}\\Download";

            DeleteDirectory(downLoadCachePath);

            if (File.Exists(cachePath)) 
            {
                var jTokenObj = (JToken)JsonConvert.DeserializeObject(File.ReadAllText(cachePath));

                tb_Account.Text = jTokenObj["Account"].ToString();

                tb_Password.Text = jTokenObj["Password"].ToString();

                cbx_SavePassword.Checked = true;
            }
        }

        /// <summary>
        /// 删除非空文件夹
        /// </summary>
        /// <param name="path">要删除的文件夹目录</param>
        private void DeleteDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                DirectoryInfo[] childs = dir.GetDirectories();

                foreach (DirectoryInfo child in childs)
                {
                    child.Delete(true);
                }

                dir.Delete(true);
            }
        }
    }
}
