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

        private void showPanel(string panelName)
        {

            if(panelName == "Dashboard")
            {

                // hide all other panels
                pnl_Students.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();

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

                // show students
                pnl_Students.Show();
                



                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // clear the listview before filling it again
                listViewStudents.Clear();

                foreach (SomerenModel.Student s in studentList)
                {

                    ListViewItem li = new ListViewItem(s.Name);
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

                // show students
                pnl_Teachers.Show();


                // fill the students listview within the students panel with a list of students
                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                // clear the listview before filling it again
                listViewTeachers.Clear();

                listViewTeachers.View = View.Details;
                listViewTeachers.GridLines = true;
                listViewTeachers.FullRowSelect = true;
                listViewTeachers.Sorting = SortOrder.Ascending;
                //Add column header
                listViewTeachers.Columns.Add("TeacherID", 70);
                listViewTeachers.Columns.Add("Name", 120);


                foreach (SomerenModel.Teacher t in teacherList)
                {
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = t.TeacherID.ToString();
                    arr[1] = t.Name;
                    itm = new ListViewItem(arr);
                    listViewTeachers.Items.Add(itm);


                    //ListViewItem li = new ListViewItem(t.Name);
                    //ListViewItem li2 = new ListViewItem(t.TeacherID.ToString());
                    //listViewTeachers.Items.Add(li2);
                    //listViewTeachers.Items.Add(li);

                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Students.Hide();

                // show room
                pnl_Rooms.Show();




                // fill the students listview within the students panel with a list of students
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                listViewRooms.Clear();

                listViewRooms.View = View.Details;
                listViewRooms.GridLines = true;
                listViewRooms.FullRowSelect = true;
                listViewRooms.Sorting = SortOrder.Ascending;
                //Add column header
                listViewRooms.Columns.Add("number", 70);
                listViewRooms.Columns.Add("Type", 120);
                listViewRooms.Columns.Add("Capacity", 120);

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void img_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }

        private void listViewStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }
    }
}
