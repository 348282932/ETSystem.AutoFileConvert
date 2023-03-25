using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

namespace ETSystem.AutoFileConvert
{
    public partial class MainForm : Form
    {
        private static readonly Collection<string> showForms = new Collection<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var formName = ((TabControl)sender).SelectedTab.Tag.ToString();

            if (!showForms.Contains(formName)) 
            {
                GenerateForm(formName, sender);
            }     
        }

        /// <summary>
        /// 初始化选项卡窗体
        /// </summary>
        /// <param name="formNanme"></param>
        /// <param name="sender"></param>
        public void GenerateForm(string formNanme, object sender) 
        {
            Form form = (Form)Assembly.GetExecutingAssembly().CreateInstance(formNanme);

            form.FormBorderStyle = FormBorderStyle.None;

            form.TopLevel = false;

            form.Parent = ((TabControl)sender).SelectedTab;

            form.ControlBox = false;

            form.Dock = DockStyle.Fill;

            form.Show();

            showForms.Add(formNanme);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateForm((string)tabPage_1.Tag, tabControl);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
