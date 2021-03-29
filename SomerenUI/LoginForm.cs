﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenUI;
using SomerenLogic;
using SomerenModel;

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
            Login_Service loginService = new Login_Service();
            SomerenUI SomerenApp = new SomerenUI();

            if (tb_UserName.Text != "" && tb_Password.Text != "")
            {
                try
                {
                    SomerenApp.SetUser(loginService.User_Login(tb_UserName.Text, tb_Password.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Login failed!", "Error!");
                    return;
                }
                this.Hide();
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
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void tb_UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {

        }
    }
}
