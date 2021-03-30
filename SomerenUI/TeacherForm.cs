using SomerenLogic;
using SomerenModel;
using System;
using System.Windows.Forms;

namespace SomerenUI
{
    // Ruben Stoop
    // Week 4
    // Opdracht B
    public partial class TeacherForm : Form
    {
        private Teacher editTeacher { get; set; }

        private SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
        public string panelName { get; set; }

        public TeacherForm(string panelName)
        {
            InitializeComponent();
            this.panelName = panelName;
        }

        public TeacherForm(string panelName, int TeacherID)
        {
            InitializeComponent();
            this.panelName = panelName;
            this.editTeacher = teachService.GetTeacher(TeacherID);
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {
            showPanel(panelName);
        }

        private void showPanel(string panelName)
        {
            if (panelName == "Addteacher")
            {
                pnl_EditTeacher.Hide();
                pnl_AddTeacher.Show();
            }
            else if (panelName == "EditTeacher")
            {
                pnl_EditTeacher.Show();
                pnl_AddTeacher.Hide();

                FillTeacher();
            }
        }

        private void FillTeacher()
        {
            editFirstNameBox.Text = editTeacher.FirstName;
            editLastNameBox.Text = editTeacher.LastName;
            editDateTimeBox.Text = editTeacher.BirthDate.ToString();
        }

        // Inserts teach into database
        private void addteacherBTN_Click(object sender, EventArgs e)
        {
            string firstname = firstnameBox.Text;
            string lastname = lastnameBox.Text;
            DateTime birthdate = birthdatePicker.Value;

            Teacher teacher = new Teacher()
            {
                FirstName = firstname,
                LastName = lastname,
                BirthDate = birthdate,
            };

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                MessageBox.Show("Input from first or lastname is not correct", "Error");
                return;
            }
            else if (birthdate == DateTime.MinValue)
            {
                MessageBox.Show("Input from Date is not correct", "Error");
                return;
            }
            else
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

        private void editBTN_Click(object sender, EventArgs e)
        {
            editTeacher.FirstName = editFirstNameBox.Text;
            editTeacher.LastName = editLastNameBox.Text;
            editTeacher.BirthDate = editDateTimeBox.Value;

            teachService.Update_Teacher(editTeacher);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelEditBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}