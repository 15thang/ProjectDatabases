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
            Supervisor_LV.Columns.Add("Teacher ID");
            Supervisor_LV.Columns.Add("Supervisor ID");
            Supervisor_LV.Columns.Add("Supervisor First name");
            Supervisor_LV.Columns.Add("Supervisor Last name");

            foreach (SomerenModel.Supervisor sv in supervisors)
            {
                string[] arr = new string[4];
                ListViewItem li;

                // Add the items
                arr[0] = sv.TeacherID.ToString();
                arr[1] = sv.SuperVisorID.ToString();
                arr[2] = sv.FirstName;
                arr[3] = sv.LastName;

                li = new ListViewItem(arr);
                Supervisor_LV.Items.Add(li);


            }
            foreach (ColumnHeader ch in Supervisor_LV.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }

            //Teachers listview
            //VALIDATION
            List<Teacher> Allteachers = teachService.GetTeachers();
            List<Supervisor> Allsupervisors = supService.GetSupervisors();
            List<Activity> Allactivities = actService.GetActivities();
            List<Teacher> selectedTeachers = checkAvailableTeachers(Allteachers, supervisors, Allsupervisors, Allactivities);


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


        public List<Teacher> checkAvailableTeachers(List<Teacher> teacher, List<Supervisor> supervisors, List<Supervisor> Allsupervisors, List<Activity> Allactivities)
        {

            List<Teacher> selectedTeachers = new List<Teacher>();

            //Checks if teacher is already supervising activity
            foreach (Teacher t in teacher)
            {
                bool contains = supervisors.Any(p => p.TeacherID == t.TeacherID);
                if (!contains)
                {
                    selectedTeachers.Add(t);
                }
            }

            List<Teacher> SuperSelectedTeachers = new List<Teacher>();

            foreach (Teacher t in selectedTeachers)
            {
                List<Activity> activitiesTeacher = GetActivitiesForTeacher(Allactivities, Allsupervisors, t.TeacherID);

                bool Checktime = true;
                foreach (Activity a in activitiesTeacher)
                {
                    Checktime = CheckTime(a, Activity);

                    if(!Checktime)
                    {
                        break;
                    }
                }
                if(Checktime)
                {
                    SuperSelectedTeachers.Add(t);
                } 
            }
            return SuperSelectedTeachers;
        }

        public bool CheckTime(Activity ActCheck, Activity activity )
        {   
            bool Check = true;

            
            if (activity.BeginTime < ActCheck.EndTime && ActCheck.BeginTime < activity.EndTime)
            {
                Check = false;
            }
            return Check;
        }

        public List<Activity> GetActivitiesForTeacher(List<Activity> Allactivities, List<Supervisor> Allsupervisors, int TeacherID)
        {
            List<Activity> activities = new List<Activity>();
            List<Supervisor> SelectSupervisors = new List<Supervisor>();
            foreach(Supervisor sv in Allsupervisors)
            {
                if(sv.TeacherID == TeacherID)
                {
                    SelectSupervisors.Add(sv);
                }
            }

            foreach(Activity a in Allactivities)
            {
                bool contains = SelectSupervisors.Any(p => p.ActivityID == a.ActivityId);
                if(contains)
                {
                    activities.Add(a);
                }
            }
            return activities;
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
                FillListViews();
                MessageBox.Show("Teacher added to supervisors for this activity", "Succes");


            }
            else
            {
                MessageBox.Show("Select a teacher to add to the supervisor for this activity", "Error!");
            }
        }

        private void removeBTN_Click(object sender, EventArgs e)
        {
            SomerenLogic.Supervisor_Service sup_Service = new SomerenLogic.Supervisor_Service();

            int SupervisorID = 0;
            // Get the student
            if (Supervisor_LV.SelectedItems.Count > 0)
            {
                string selectSupervisor = Supervisor_LV.SelectedItems[0].SubItems[1].Text;
                SupervisorID = int.Parse(selectSupervisor);

                sup_Service.DeleteSupervisorForActivity(SupervisorID);

                //Shows messagebox and resets panel
                FillListViews();
                MessageBox.Show("Supervisor succesfully deleted from activity", "Succes");
            }
            else
            {
                MessageBox.Show("Select a teacher to add to the supervisor for this activity", "Error!");
            }
        }
    }
}
