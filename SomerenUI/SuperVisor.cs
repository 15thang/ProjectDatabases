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
    //Ruben Stoop
    // Opdracht B Week 4
    public partial class SuperVisor : Form
    {
        public Activity Activity;

        SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();

        SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();

        SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();


        public SuperVisor(int ID)
        {
            InitializeComponent();
            this.Activity = actService.GetActivity(ID);
        }

        private void SuperVisor_Load(object sender, EventArgs e)
        {
            SetLabels();
            FillListViews();
        }

        private void SetLabels()
        {
            idLbl.Text += Activity.ActivityId.ToString();
            ActivityTitleLabel.Text = Activity.Type.ToString();
            startTimeLbl.Text += Activity.BeginTime.ToString("dd/MM/yyyy HH:mm");
            endTimeLbl.Text += Activity.EndTime.ToString("dd/MM/yyyy HH:mm");
        }

        private void FillListViews()
        {
            List<Supervisor> supervisors = supService.GetSupervisorsForOneActicity(Activity.ActivityId);

            // clear the listview and comboboxes
            Supervisor_LV.Clear();
            TeacherListView.Clear();


            //Setting up Supervisor listview
            Supervisor_LV.View = View.Details;
            Supervisor_LV.GridLines = true;
            Supervisor_LV.FullRowSelect = true;

            // add column header
            Supervisor_LV.Columns.Add("Supervisor ID");
            Supervisor_LV.Columns.Add("Supervisor First name");
            Supervisor_LV.Columns.Add("Supervisor Last name");

            foreach (SomerenModel.Supervisor sv in supervisors)
            {
                string[] arr = new string[3];
                ListViewItem li;

                // Add the items
                arr[0] = sv.SuperVisorID.ToString();
                arr[1] = sv.FirstName;
                arr[2] = sv.LastName;

                li = new ListViewItem(arr);
                Supervisor_LV.Items.Add(li);


            }
            foreach (ColumnHeader ch in Supervisor_LV.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }

            //Teachers listview
            List<Teacher> Allteachers = teachService.GetTeachers();
            List<Teacher> selectedTeachers = checkAvailableTeachers(Allteachers, supervisors);


            TeacherListView.View = View.Details;
            TeacherListView.GridLines = true;
            TeacherListView.FullRowSelect = true;
            TeacherListView.MultiSelect = false;

            // add column header
            TeacherListView.Columns.Add("Teacher ID");
            TeacherListView.Columns.Add("Teacher First name");
            TeacherListView.Columns.Add("Teacher Last name");

            foreach (SomerenModel.Teacher t in selectedTeachers)
            {
                string[] arr = new string[3];
                ListViewItem li;

                // Add the items
                arr[0] = t.TeacherID.ToString();
                arr[1] = t.FirstName;
                arr[2] = t.LastName;

                li = new ListViewItem(arr);
                TeacherListView.Items.Add(li);
            }

            foreach (ColumnHeader ch in TeacherListView.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
        }


        public List<Teacher> checkAvailableTeachers(List<Teacher> teacher, List<Supervisor> supervisors)
        {
            List<Teacher> selectedTeachers = new List<Teacher>();

            foreach (Teacher t in teacher)
            {
                bool contains = supervisors.Any(p => p.TeacherID == t.TeacherID);
                if (!contains)
                {
                    selectedTeachers.Add(t);
                }
            }
            return selectedTeachers;
        }

        private void AddTeacherBTN_Click(object sender, EventArgs e)
        {

            //Order
            //Makes The order service
            SomerenLogic.Supervisor_Service sup_Service = new SomerenLogic.Supervisor_Service();


                int teacherID = 0;
                // Get the student
                if (TeacherListView.SelectedItems.Count > 0)
                {
                    string selectTeacher = TeacherListView.SelectedItems[0].Text;
                    teacherID = int.Parse(selectTeacher);

                    Supervisor supervisor = new Supervisor();
                    supervisor.TeacherID = teacherID;
                    supervisor.ActivityID = Activity.ActivityId;
                    sup_Service.Insert_Supervisor(supervisor);

                    //Shows messagebox and resets panel
                    MessageBox.Show("Order added.", "Succes");

                    FillListViews();
                }
                else
                {
                    MessageBox.Show("Select a teacher to add to the supervisor for this activity", "Error!");
                }
        }
    }
}
