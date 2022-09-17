namespace ETSystem.AutoFileConvert
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.lbl_Account = new System.Windows.Forms.Label();
            this.tb_Account = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_Tip = new System.Windows.Forms.Label();
            this.cbx_SavePassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbl_Account
            // 
            this.lbl_Account.AutoSize = true;
            this.lbl_Account.Location = new System.Drawing.Point(55, 31);
            this.lbl_Account.Name = "lbl_Account";
            this.lbl_Account.Size = new System.Drawing.Size(41, 12);
            this.lbl_Account.TabIndex = 0;
            this.lbl_Account.Text = "账号：";
            // 
            // tb_Account
            // 
            this.tb_Account.Location = new System.Drawing.Point(104, 28);
            this.tb_Account.Name = "tb_Account";
            this.tb_Account.Size = new System.Drawing.Size(157, 21);
            this.tb_Account.TabIndex = 1;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(57, 61);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(41, 12);
            this.lbl_Password.TabIndex = 2;
            this.lbl_Password.Text = "密码：";
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(104, 58);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.PasswordChar = '*';
            this.tb_Password.Size = new System.Drawing.Size(157, 21);
            this.tb_Password.TabIndex = 2;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(134, 95);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_Tip
            // 
            this.lbl_Tip.AutoSize = true;
            this.lbl_Tip.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Tip.ForeColor = System.Drawing.Color.Red;
            this.lbl_Tip.Location = new System.Drawing.Point(83, 125);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(0, 12);
            this.lbl_Tip.TabIndex = 4;
            // 
            // cbx_SavePassword
            // 
            this.cbx_SavePassword.AutoSize = true;
            this.cbx_SavePassword.Location = new System.Drawing.Point(215, 99);
            this.cbx_SavePassword.Name = "cbx_SavePassword";
            this.cbx_SavePassword.Size = new System.Drawing.Size(72, 16);
            this.cbx_SavePassword.TabIndex = 5;
            this.cbx_SavePassword.Text = "记住密码";
            this.cbx_SavePassword.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 150);
            this.Controls.Add(this.cbx_SavePassword);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_Account);
            this.Controls.Add(this.lbl_Account);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Account;
        private System.Windows.Forms.TextBox tb_Account;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lbl_Tip;
        private System.Windows.Forms.CheckBox cbx_SavePassword;
    }
}