using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }
        private void HideAllPanels()
        {
            // to do
        }
        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();

                // show students
                pnl_Students.Show();
                
                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                // add grid lines, rows and enable sorting
                listViewStudents.View = View.Details;
                listViewStudents.GridLines = true;
                listViewStudents.FullRowSelect = true;
                listViewStudents.Sorting = SortOrder.Ascending;

                // add column headers
                listViewStudents.Columns.Add("StudentID", 70);
                listViewStudents.Columns.Add("First Name", 120);
                listViewStudents.Columns.Add("Last Name", 120);

                foreach (SomerenModel.Student s in studentList)
                {
                    string[] arr = new string[4];
                    ListViewItem li;

                    //Add first item
                    arr[0] = s.StudentID.ToString();
                    arr[1] = s.FirstName;
                    arr[2] = s.LastName;
                    li = new ListViewItem(arr);
                    listViewStudents.Items.Add(li);
                }
            }
            else if (panelName == "Teachers")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();

                // show teachers
                pnl_Teachers.Show();

                // fill the teachers listview within the teachers panel with a list of teachers
                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                // clear the listview before filling it again
                listViewTeachers.Clear();

                // add grid lines, rows and enable sorting
                listViewTeachers.View = View.Details;
                listViewTeachers.GridLines = true;
                listViewTeachers.FullRowSelect = true;
                listViewTeachers.Sorting = SortOrder.Ascending;

                // add column header
                listViewTeachers.Columns.Add("TeacherID", 70);
                listViewTeachers.Columns.Add("First Name", 120);
                listViewTeachers.Columns.Add("Last Name", 120);
                listViewTeachers.Columns.Add("Supervises", 120);

                foreach (SomerenModel.Teacher t in teacherList)
                {
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = t.TeacherID.ToString();
                    arr[1] = t.FirstName;
                    arr[2] = t.LastName;
                    itm = new ListViewItem(arr);
                    listViewTeachers.Items.Add(itm);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Students.Hide();
                pnl_Activities.Hide();

                // show rooms
                pnl_Rooms.Show();

                // fill the rooms listview within the rooms panel with a list of rooms
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                // clear the listview before filling it again
                listViewRooms.Clear();

                listViewRooms.View = View.Details;
                listViewRooms.GridLines = true;
                listViewRooms.FullRowSelect = true;
                listViewRooms.Sorting = SortOrder.Ascending;

                //Add column header
                listViewRooms.Columns.Add("Room Number", 90);
                listViewRooms.Columns.Add("Type Room", 70);
                listViewRooms.Columns.Add("Beds", 40);

                foreach (SomerenModel.Room r in roomList)
                {                    
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = r.Number.ToString();
                    arr[1] = r.RoomType.ToString();
                    arr[2] = r.Capacity.ToString();
                    itm = new ListViewItem(arr);
                    listViewRooms.Items.Add(itm);
                }
            }
            else if (panelName == "Activities")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Teachers.Hide();

                // show activities
                pnl_Activities.Show();

                // fill the students listview within the students panel with a list of teachers
                SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
                List<Activity> activityList = actService.GetActivities();

                // clear the listview before filling it again
                listViewActivities.Clear();

                // add grid lines, rows and enable sorting
                listViewActivities.View = View.Details;
                listViewActivities.GridLines = true;
                listViewActivities.FullRowSelect = true;
                listViewActivities.Sorting = SortOrder.Ascending;

                // add column header
                listViewActivities.Columns.Add("ActivityID", 70);
                listViewActivities.Columns.Add("Type", 120);
                listViewActivities.Columns.Add("Begin Time", 160);
                listViewActivities.Columns.Add("End Time", 160);

                foreach (SomerenModel.Activity a in activityList)
                {
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = a.ActivityId.ToString();
                    arr[1] = a.Type;
                    arr[2] = a.BeginTime.ToString("dd/MM/yyyy (dddd) HH:mm");
                    arr[3] = a.EndTime.ToString("dd/MM/yyyy (dddd) HH:mm");
                    itm = new ListViewItem(arr);
                    listViewActivities.Items.Add(itm);
                }
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
    }
}
