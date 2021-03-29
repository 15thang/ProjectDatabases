using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    // Ruben Stoop
    // Week 5
    // Opdracht B
    public partial class RegisterForm : Form
    {
        SomerenLogic.Register_Service registerService = new SomerenLogic.Register_Service();


        public RegisterForm()
        {
            InitializeComponent();

            passwordBOX.PasswordChar = '\u25CF';
        }

        private void registerBTN_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string username = usernameBOX.Text;
            string password = passwordBOX.Text;
            string license = licenceBOX.Text;
            string LicenseCheck = "XsZAb-tgz3PsD-qYh69un-WQCEx";

            User user = new User() 
            { 
              Name = name, 
              UserName = username, 
              Password = password 
            };

            // Checks licence
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password is empty", "Error!");
            } else
            {
                // Checks if string aren't empty
                if (String.Equals(license, LicenseCheck, StringComparison.CurrentCulture))
                {
                    registerService.Insert_User(user);
                    this.Hide();
                    if (registerService.Error == true)
                    {
                        MessageBox.Show(registerService.ErrorText, "Error!");
                    }

                    MessageBox.Show("Registration was succesful", "Succes!");
                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("License is invalid.", "Error!");
                }
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
