﻿using SomerenLogic;
using System;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Login_Service loginService = new Login_Service();
            SomerenUI SomerenApp = new SomerenUI();

            if (tb_UserName.Text != "" && tb_Password.Text != "") // check if login info is empty
            {
                try // try logging in
                {
                    SomerenApp.SetUser(loginService.User_Login(tb_UserName.Text, tb_Password.Text));
                }
                catch (Exception err) // if failed give error
                {
                    MessageBox.Show("Login failed!", "Error!");
                    return; // if failed stop
                }
                this.Hide(); // if success open the app
                SomerenApp.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("UserName and Password can not be empty!", "Error!");
            }
        }

        private void tb_Password_KeyDown(object sender, KeyEventArgs e)
        {
            // Tim Roffelsen
            if (e.KeyCode == Keys.Enter) // enter key press register
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void tb_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            // Tim Roffelsen
            if (e.KeyCode == Keys.Enter) // enter key press register
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm(); // logout

            registerForm.StartPosition = FormStartPosition.CenterParent;

            this.Hide();
            registerForm.ShowDialog(); // open login form
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void lbl_ForgotPassword_Click(object sender, EventArgs e)
        {
            // Forgot password code here
        }
    }
}