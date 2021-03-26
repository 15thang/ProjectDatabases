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
    // Week 4
    // Opdracht B
    public partial class TeacherForm : Form
    {

        SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
        public string panelName { get; set; }
        public TeacherForm(string panelName)
        {
            InitializeComponent();
            this.panelName = panelName;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            showPanel(panelName);
        }
        private void showPanel(string panelName)
        {
            if (panelName == "Addteacher")
            {
                pnl_AddTeacher.Show();
            }
        }

        // Inserts teach into database
        private void addteacherBTN_Click(object sender, EventArgs e)
        {
            string firstname = firstnameBox.Text;
            string lastname = lastnameBox.Text;
            DateTime birthdate = birthdatePicker.Value;

            Teacher teacher = new Teacher() {
                FirstName = firstname,
                LastName = lastname,
                BirthDate = birthdate,
            };

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                MessageBox.Show("Input from first or lastname is not correct", "Error");
                return;
            } else if (birthdate == DateTime.MinValue)
            {
                MessageBox.Show("Input from Date is not correct", "Error");
                return;
            } else
            {
                teachService.Insert_Teacher(teacher);
                Error_Show(teachService);
                this.Close();
            }
        }

        public void Error_Show(Base_Service service)
        {
            if (service.Error == true)
            {
                MessageBox.Show($"{service.ErrorText}", "Error!", MessageBoxButtons.OK);
            }
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
