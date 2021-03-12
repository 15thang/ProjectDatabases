﻿using SomerenLogic;
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
        private ListViewColumnSorter lvwColumnSorter;

        public SomerenUI()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it
            // to the ListView control.
            // Makes columns sortable
            lvwColumnSorter = new ListViewColumnSorter();
            this.listViewStudents.ListViewItemSorter = lvwColumnSorter;
            this.listViewTeachers.ListViewItemSorter = lvwColumnSorter;
            this.listViewRooms.ListViewItemSorter = lvwColumnSorter;
            this.listViewActivities.ListViewItemSorter = lvwColumnSorter;
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
                pnl_Roomslayout.Hide();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
            {
                // Ruben Stoop
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();
                pnl_Roomslayout.Hide();

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
                listViewStudents.Columns.Add("StudentID");
                listViewStudents.Columns.Add("First Name");
                listViewStudents.Columns.Add("Last Name");

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
                foreach (ColumnHeader ch in listViewStudents.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }
            else if (panelName == "Teachers")
            {
                // Tim Roffelsen
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();
                pnl_Roomslayout.Hide();

                // show teachers
                pnl_Teachers.Show();

                // fill the teachers listview within the teachers panel with a list of teachers
                SomerenLogic.Teacher_Service teachService = new SomerenLogic.Teacher_Service();
                List<Teacher> teacherList = teachService.GetTeachers();

                //list supervisors
                SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();
                List<Supervisor> supList = supService.GetSupervisors();

                //list activities
                SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
                List<Activity> activityList = actService.GetActivities();


                // clear the listview before filling it again
                listViewTeachers.Clear();

                // add grid lines, rows and enable sorting
                listViewTeachers.View = View.Details;
                listViewTeachers.GridLines = true;
                listViewTeachers.FullRowSelect = true;
                listViewTeachers.Sorting = SortOrder.Ascending;

                // add column header
                listViewTeachers.Columns.Add("TeacherID");
                listViewTeachers.Columns.Add("First Name");
                listViewTeachers.Columns.Add("Last Name");
                listViewTeachers.Columns.Add("Supervises");

                foreach (SomerenModel.Teacher t in teacherList)
                {
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = t.TeacherID.ToString();
                    arr[1] = t.FirstName;
                    arr[2] = t.LastName;
                    arr[3] = supService.FindType(t.TeacherID, activityList, supList); // find type of activities
                    itm = new ListViewItem(arr);
                    listViewTeachers.Items.Add(itm);
                }
                foreach (ColumnHeader ch in listViewTeachers.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }
            else if (panelName == "Rooms")
            {
                // Thomas Eddyson
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Students.Hide();
                pnl_Activities.Hide();
                pnl_Roomslayout.Hide();

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
                listViewRooms.Columns.Add("Room Number");
                listViewRooms.Columns.Add("Type Room");
                listViewRooms.Columns.Add("Beds");

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
                foreach (ColumnHeader ch in listViewRooms.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }
            else if (panelName == "Activities")
            {
                // Tim Roffelsen
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Teachers.Hide();
                pnl_Roomslayout.Hide();

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
                listViewActivities.Columns.Add("ActivityID");
                listViewActivities.Columns.Add("Type");
                listViewActivities.Columns.Add("Begin Time");
                listViewActivities.Columns.Add("End Time");

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
                foreach (ColumnHeader ch in listViewActivities.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }
            else if (panelName == "RoomsLayout")
            {
                // Thomas Eddyson
                // hide all other panels
                pnl_Dashboard.Hide();
                img_Dashboard.Hide();
                pnl_Teachers.Hide();
                pnl_Students.Hide();
                pnl_Rooms.Hide();
                pnl_Activities.Hide();

                // show rooms
                pnl_Roomslayout.Show();

                // fill the Room listview within the Room panel with a list of Rooms
                SomerenLogic.RoomLayout_Service roomLayoutService = new SomerenLogic.RoomLayout_Service();
                List<RoomLayout> roomLayoutList = roomLayoutService.GetRoomLayout();

                listViewRoomLayout.Clear();

                listViewRoomLayout.View = View.Details;
                listViewRoomLayout.GridLines = true;
                listViewRoomLayout.FullRowSelect = true;
                listViewRoomLayout.Sorting = SortOrder.Ascending;
                //Add column header
                listViewRoomLayout.Columns.Add("Number", 70);
                listViewRoomLayout.Columns.Add("FirstName", 120);
                listViewRoomLayout.Columns.Add("LastName", 120);

                foreach (SomerenModel.RoomLayout o in roomLayoutList)
                {

                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;

                    //Add first item
                    arr[0] = o.Number.ToString();
                    arr[1] = o.FirstName.ToString();
                    arr[2] = o.LastName.ToString();
                    itm = new ListViewItem(arr);
                    listViewRoomLayout.Items.Add(itm);
                }
                foreach (ColumnHeader ch in listViewRoomLayout.Columns) // dynamically change column width
                {
                    ch.Width = -2;
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

        private void roomLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("RoomsLayout");
        }

        private void listViewActivities_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Tim Roffelsen
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewActivities.Sort();
        }

        private void listViewRooms_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Tim Roffelsen
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewRooms.Sort();
        }

        private void listViewStudents_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Tim Roffelsen
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewStudents.Sort();
        }

        private void listViewTeachers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Tim Roffelsen
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listViewTeachers.Sort();
        }        
    }
}
