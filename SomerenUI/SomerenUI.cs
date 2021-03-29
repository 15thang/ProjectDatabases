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
using System.Globalization;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        // Tim Roffelsen
        private ListViewColumnSorter lvwColumnSorter; // column sort functionality
        private User User; // user perms

        // Ruben Stoop
        // Important list to check amounts
        public static List<Product> ProductsList = new List<Product>();
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
            this.SuperVisor_LV.ListViewItemSorter = lvwColumnSorter;
            this.SuperVisor_LV.ListViewItemSorter = lvwColumnSorter;
            this.ActivitySuperVisor_LV.ListViewItemSorter = lvwColumnSorter;
        }
        public void SetUser(User user)
        {
            // Tim Roffelsen
            this.User = user; // saves user
            string userLevel;
            if (User.IsAdmin == true) // set permissions text
            {
                userLevel = "admin";
            }
            else
            {
                userLevel = "user";
            }
            // hide admin panels if user is not admin
            if (user.IsAdmin == false)
            {
                pnl_TeachersChange.Hide();
                pnl_ActivityChange.Hide();
                orderDrinksToolStripMenuItem.Visible = false;
                pnl_StockChange.Hide();
                pnl_SupervisorsChange.Hide();
            }

            userToolStripMenuItem.Text = "Welcome! " + user.UserName;
            lbl_Dashboard.Text = $"Welcome to the Someren Application! You are logged in as '{user.UserName}' with {userLevel} level permissions."; // change welcome message
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            this.User = null; // sets user to null
            LoginForm loginForm = new LoginForm(); // logout
            
            this.Hide();
            loginForm.ShowDialog(); // open login form
            this.Close();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }
        private void AlignPanels()
        {
            Point point = new Point(10, 30);
            pnl_Supervisors.Location = point;
            pnl_Dashboard.Location = point;
            pnl_Teachers.Location = point;
            pnl_Students.Location = point;
            pnl_Rooms.Location = point;
            pnl_Activities.Location = point;
            pnl_Roomslayout.Location = point;
            pnl_OrderDrinks.Location = point;
            pnl_Stock.Location = point;
            pnl_Vat.Location = point;
            pnl_Supervisors.Location = point;
            pnl_WeekRoster.Location = point;
            pnl_User.Location = point;

        }

        private void HideAllPanels()
        {
            AlignPanels();
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_Teachers.Hide();
            pnl_Students.Hide();
            pnl_Rooms.Hide();
            pnl_Activities.Hide();
            pnl_Roomslayout.Hide();
            pnl_OrderDrinks.Hide();
            pnl_Stock.Hide();
            pnl_Vat.Hide();
            pnl_Supervisors.Hide();
            pnl_WeekRoster.Hide();
            pnl_User.Hide();
        }

        private void showPanel(string panelName)
        {
            if (panelName == "Dashboard")
            {
                // hide all other panels
                HideAllPanels();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if (panelName == "Students")
            {
                // Ruben Stoop
                // hide all other panels
                HideAllPanels();

                // show students
                pnl_Students.Show();

                // fill the students listview within the students panel with a list of students
                SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
                List<Student> studentList = studService.GetStudents();

                // Shows message box if there is an error
                Error_Show(studService);

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
                FillTeachersPanel();
            }
            else if (panelName == "Rooms")
            {
                // Thomas Eddyson
                // hide all other panels
                HideAllPanels();

                // show rooms
                pnl_Rooms.Show();

                // fill the rooms listview within the rooms panel with a list of rooms
                SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
                List<Room> roomList = roomService.GetRooms();

                // Shows message box if there is an error
                Error_Show(roomService);

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
                HideAllPanels();
                
                // show activities
                pnl_Activities.Show();

                // refresh list
                Activity_Refresh();
            }
            else if (panelName == "RoomsLayout")
            {
                // Thang Nguyen Anh
                // hide all other panels
                HideAllPanels();

                // show rooms
                pnl_Roomslayout.Show();

                // fill the Room listview within the Room panel with a list of Rooms
                SomerenLogic.RoomLayout_Service roomLayoutService = new SomerenLogic.RoomLayout_Service();
                List<RoomLayout> roomLayoutList = roomLayoutService.GetRoomLayout();

                // Shows message box if there is an error
                Error_Show(roomLayoutService);

                listViewRoomLayout.Clear();

                listViewRoomLayout.View = View.Details;
                listViewRoomLayout.Columns.Add("Rooms");
                List<int> UniqueRoom = new List<int>();
                foreach (SomerenModel.RoomLayout o in roomLayoutList)
                {
                    if (UniqueRoom.Contains(o.Number) == false)
                    {
                        UniqueRoom.Add(o.Number);
                    }
                }

                foreach (int i in UniqueRoom)
                {
                    listViewRoomLayout.Items.Add("");
                    listViewRoomLayout.Items.Add("Room " + i.ToString());
                    Console.WriteLine(i);
                    string[] arr = new string[16];
                    int counter = 0;
                    foreach (SomerenModel.RoomLayout o in roomLayoutList)
                    {
                        if (o.Number == i)
                        {
                            arr[counter] = o.FirstName + " " + o.LastName;
                            ListViewItem itm = new ListViewItem(arr);
                            listViewRoomLayout.Items.Add(itm);
                        }
                    }
                }

                foreach (ColumnHeader ch in listViewRoomLayout.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }
            else if (panelName == "OrderDrinks")
            {
                FillOrderDrink();
            }
            else if (panelName == "Supervisors")
            {
                // Ruben Stoop
                // Opdracht B Week 4

                //Hides all panels
                HideAllPanels();
                // show Supervisors
                pnl_Supervisors.Show();
                SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();
                List<Supervisor> supervisors = supService.GetSupervisorsWithActivitiesID();

                //Used to get activity linked with supervisor and all activities
                SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
                List<Activity> activities = actService.GetActivities();

                Error_Show(supService);
                Error_Show(actService);
                // clear the listview before filling it again
                SuperVisor_LV.Clear();
                ActivitySuperVisor_LV.Clear();

                //Setting up Activity listview
                ActivitySuperVisor_LV.View = View.Details;
                ActivitySuperVisor_LV.GridLines = true;
                ActivitySuperVisor_LV.FullRowSelect = true;
                ActivitySuperVisor_LV.MultiSelect = false;

                ActivitySuperVisor_LV.Columns.Add("Activity ID");
                ActivitySuperVisor_LV.Columns.Add("Activity Description");
                ActivitySuperVisor_LV.Columns.Add("Start time");
                ActivitySuperVisor_LV.Columns.Add("End time");

                foreach (SomerenModel.Activity a in activities)
                {
                    string[] arr = new string[4];
                    ListViewItem li;

                    // Add the items
                    arr[0] = a.ActivityId.ToString();
                    arr[1] = a.Type.ToString();
                    arr[2] = a.BeginTime.ToString("dd/MM/yyyy HH:mm");
                    arr[3] = a.EndTime.ToString("dd/MM/yyyy HH:mm");

                    li = new ListViewItem(arr);
                    ActivitySuperVisor_LV.Items.Add(li);
                }

                //Setting up Supervisor listview
                SuperVisor_LV.View = View.Details;
                SuperVisor_LV.GridLines = true;
                SuperVisor_LV.FullRowSelect = true;

                // add column header
                SuperVisor_LV.Columns.Add("Supervisor ID");
                SuperVisor_LV.Columns.Add("Supervisor Name");
                SuperVisor_LV.Columns.Add("Activity ID");
                SuperVisor_LV.Columns.Add("Activity Description");
                SuperVisor_LV.Columns.Add("Start time");
                SuperVisor_LV.Columns.Add("End time");

                foreach (SomerenModel.Supervisor sv in supervisors)
                {
                    Activity activity = new Activity();
                    foreach (Activity a in activities)
                    {
                        if (a.ActivityId == sv.ActivityID)
                        {
                            activity = a;
                        }
                    }


                    string[] arr = new string[6];
                    ListViewItem li;

                    // Add the items
                    arr[0] = sv.SuperVisorID.ToString();
                    arr[1] = sv.FirstName + " " + sv.LastName;
                    arr[2] = sv.ActivityID.ToString();
                    arr[3] = activity.Type.ToString();
                    arr[4] = activity.BeginTime.ToString("dd/MM/yyyy HH:mm");
                    arr[5] = activity.EndTime.ToString("dd/MM/yyyy HH:mm");

                    li = new ListViewItem(arr);
                    SuperVisor_LV.Items.Add(li);


                }
                foreach (ColumnHeader ch in SuperVisor_LV.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
                foreach (ColumnHeader ch in ActivitySuperVisor_LV.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }
            }

            else if (panelName == "Stock")
            {
                // Tim Roffelsen
                // hide all other panels
                HideAllPanels();

                // show stock
                pnl_Stock.Show();

                // refresh stock
                Stock_Refresh();
            } else if (panelName == "User")
            {
                LoadUserPanel();
            }
            else if (panelName == "Vat")
            {
                // Thomas Eddyson
                HideAllPanels();

                pnl_Vat.Show();

                Lbl_VatTarief.Text = "BTW Tarief Kwartaal";
                LblQrtlFirstMonth.Text = "_____";
                LblQrtlLastMonth.Text = "_____";
            }
            else if (panelName == "WeekRoster")
            {
                // Thomas Eddyson
                // Opdracht C Week 4

                // Hides all panels
                HideAllPanels();

                // show Week roster
                pnl_WeekRoster.Show();

                listViewWeekRoster.Clear();

                listViewWeekRoster.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listViewWeekRoster.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                SomerenLogic.WeekRoster_Service weekRosterService = new SomerenLogic.WeekRoster_Service();
                List<WeekRoster> weekRosters = weekRosterService.GetWeekRosters();

                ListViewGroup monday = new ListViewGroup("Maandagen", HorizontalAlignment.Left);
                ListViewGroup tuesday = new ListViewGroup("Dinsdagen", HorizontalAlignment.Left);
                ListViewGroup wednesday = new ListViewGroup("Woensdagen", HorizontalAlignment.Left);
                ListViewGroup thursday = new ListViewGroup("Donderdagen", HorizontalAlignment.Left);
                ListViewGroup friday = new ListViewGroup("Vrijdagen", HorizontalAlignment.Left);

                foreach (SomerenModel.WeekRoster wkr in weekRosters)
                {                    

                    switch (wkr.DayOfWeek)
                    {
                        case 1:                            
                            listViewWeekRoster.Items.Add(new ListViewItem(string.Format("Activiteit: {0} \nBegeleider: {1}, \nBegin tijd: {2}, \nEind tijd: {3}", wkr.ActivityName, wkr.FirstName + " " + wkr.LastName, wkr.BeginTime.ToString("MM dd HH:mm"), wkr.EndTime.ToString("MM HH:mm"), -2), monday));
                            break;
                        case 2:                            
                            listViewWeekRoster.Items.Add(new ListViewItem(string.Format("Activiteit: {0} \nBegeleider: {1}, \nBegin tijd: {2}, \n Eind tijd: {3}", wkr.ActivityName, wkr.FirstName + " " + wkr.LastName, wkr.BeginTime.ToString("MM HH:mm"), wkr.EndTime.ToString("MM HH:mm"), -2), tuesday));
                            break;
                        case 3:                            
                            listViewWeekRoster.Items.Add(new ListViewItem(string.Format("Activiteit: {0} \nBegeleider: {1}, \nBegin tijd: {2}, \nEind tijd: {3}", wkr.ActivityName, wkr.FirstName + " " + wkr.LastName, wkr.BeginTime.ToString("MM HH:mm"), wkr.EndTime.ToString("MM HH:mm"), -2), wednesday));
                            break;
                        case 4:                            
                            listViewWeekRoster.Items.Add(new ListViewItem(string.Format("Activiteit: {0} \nBegeleider: {1}, \nBegin tijd: {2}, \nEind tijd: {3}", wkr.ActivityName, wkr.FirstName + " " + wkr.LastName, wkr.BeginTime.ToString("MM MM HH:mm"), wkr.EndTime.ToString("MM HH:mm"), -2), thursday));                            
                            break;
                        case 5:
                            listViewWeekRoster.Items.Add(new ListViewItem(string.Format("Activiteit: {0} \nBegeleider: {1}, \nBegin tijd: {2}, \nEind tijd: {3}", wkr.ActivityName, wkr.FirstName + " " + wkr.LastName, wkr.BeginTime.ToString("MM HH:mm"), wkr.EndTime.ToString("MM HH:mm"), -2), friday));                            
                            break;
                        default:
                            break;
                    }
                }

                listViewWeekRoster.Groups.Add(monday);
                listViewWeekRoster.Groups.Add(tuesday);
                listViewWeekRoster.Groups.Add(wednesday);
                listViewWeekRoster.Groups.Add(thursday);
                listViewWeekRoster.Groups.Add(friday);                
            }

            switch (panelName)
            {
                // Thomas Eddyson
                case "Q1Click":
                    get_QuarterTaxResult("Q1");
                    Lbl_VatTarief.Text = "BTW Tarief Kwartaal 1";
                    LblQuartelYearText.Text = "Kwartaal 1";
                    LblQrtlFirstMonth.Text = "Januari";
                    LblQrtlLastMonth.Text = "Maart";
                    break;
                case "Q2Click":
                    get_QuarterTaxResult("Q2");
                    Lbl_VatTarief.Text = "BTW Tarief Kwartaal 2";
                    LblQuartelYearText.Text = "Kwartaal 4";
                    LblQrtlFirstMonth.Text = "April";
                    LblQrtlLastMonth.Text = "Juni";
                    break;
                case "Q3Click":
                    get_QuarterTaxResult("Q3");
                    Lbl_VatTarief.Text = "BTW Tarief Kwartaal 3";
                    LblQuartelYearText.Text = "Kwartaal 3";
                    LblQrtlFirstMonth.Text = "Juli";
                    LblQrtlLastMonth.Text = "September";
                    break;
                case "Q4Click":
                    get_QuarterTaxResult("Q4");
                    Lbl_VatTarief.Text = "BTW Tarief Kwartaal 4";
                    LblQuartelYearText.Text = "Kwartaal 4";
                    LblQrtlFirstMonth.Text = "October";
                    LblQrtlLastMonth.Text = "December";
                    break;
            }
        }

        private void get_QuarterTaxResult(string quarterName)
        {
            // Thomas Eddyson

            // Money formating
            CultureInfo eu = new CultureInfo("fr-FR");
            eu.NumberFormat.CurrencyPositivePattern = 0;
            eu.NumberFormat.CurrencyNegativePattern = 2;

            SomerenLogic.Vat_Service vatService = new SomerenLogic.Vat_Service();

            vatService.SetQuaterString(quarterName);

            List<Vat> vatList = vatService.GetVats();            

            foreach (SomerenModel.Vat a in vatList)
            {
                //Add items in the listview
                string[] arr = new string[4];

                //Add first item
                arr[0] = a.CurrentYear.ToString();
                arr[1] = a.VATTwntyOnePrcnt.ToString("C", eu);
                arr[2] = a.VATSixPrcnt.ToString("C", eu);
                arr[3] = a.TotalVAT.ToString("C", eu);

                LblYearResult.Text = arr[0];
                LblTwentOnePrcntTaxResult.Text = arr[1];
                LblSixPrcntTaxResult.Text = arr[2];
                LblTotalTaxResult.Text = arr[3];
            }
        }

        // Ruben Stoop
        private void update_TotalPrice()
        {
            // Total price
            double totalPrice = 0.00;
            foreach (ListViewItem item in selectedDrinks_lv.Items)
            {
                totalPrice += (Double.Parse(item.SubItems[2].Text) * int.Parse(item.SubItems[3].Text));
            }
            totalPriceLabel.Text = "€" + totalPrice.ToString("0.00");
        }

        //Ruben Stoop
        private void drinkLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Adds the item to selected items
            if (drinkLV.SelectedItems.Count > 0) 
            {


                int ProductID = int.Parse(drinkLV.SelectedItems[0].Text);
                
                // Checks if product already exists in Selected drinks
                foreach (ListViewItem item in selectedDrinks_lv.Items)
                {
                    int CProductID = int.Parse(item.Text);
                    if (ProductID == CProductID)
                    {
                        MessageBox.Show("Product already exists in Selected product. To add the product again remove the products first from selected products.", "Error!");
                        return;
                    }
                }

                string ProductName = drinkLV.SelectedItems[0].SubItems[1].Text;
                double Price = double.Parse(drinkLV.SelectedItems[0].SubItems[3].Text);
                Product selectProduct = new Product(ProductID, ProductName, Price);
                using (var form = new AddAmount(selectProduct, ProductsList))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string[] arr = new string[5];
                        ListViewItem li;

                        // Add the items
                        arr[0] = form.ProductID.ToString("00");
                        arr[1] = form.ProductName;
                        arr[2] = form.Price.ToString("0.00") ;
                        arr[3] = form.Amount.ToString();

                        li = new ListViewItem(arr);
                        selectedDrinks_lv.Items.Add(li);
                    }
                }
                update_TotalPrice();
            }
            else
            {
                return;
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

        private void orderDrinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("OrderDrinks");
        }
        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Stock");
        }

        private void btwToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Vat");
        }

        private void LblQ1Click_Click(object sender, EventArgs e)
        {
            showPanel("Q1Click");
        }

        private void LblQ2Click_Click(object sender, EventArgs e)
        {
            showPanel("Q2Click");
        }

        private void LblQ3Click_Click(object sender, EventArgs e)
        {
            showPanel("Q3Click");
        }

        private void LblQ4Click_Click(object sender, EventArgs e)
        {
            showPanel("Q4Click");
        }

        private void superVisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Supervisors");
        }

        private void weekRoosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("WeekRoster");
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("User");
        }


        private void ActivitySuperVisor_LV_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.ActivitySuperVisor_LV.Sort();
        }

        

        private void SuperVisor_LV_ColumnClick(object sender, ColumnClickEventArgs e)
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
            this.SuperVisor_LV.Sort();
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

        //Shows error message if an error occured
        public void Error_Show(Base_Service service)
        {
            if (service.Error == true)
            {
                MessageBox.Show($"{service.ErrorText}", "Error!", MessageBoxButtons.OK);
            }
        }

        private void tb_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Tim Roffelsen
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Check if '.' pressed
            char sepratorChar = 'a';
            if (e.KeyChar == '.')
            {
                // Check if it's in the beginning of text not accept
                if (tb_PriceAdd.Text.Length == 0) e.Handled = true;
                // Check if it's in the beginning of text not accept
                if (tb_PriceAdd.SelectionStart == 0) e.Handled = true;
                // Check if there is already exist a '.' , ','
                if (alreadyExist(tb_PriceAdd.Text, ref sepratorChar)) e.Handled = true;
                // Check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (tb_PriceAdd.SelectionStart != tb_PriceAdd.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = tb_PriceAdd.Text.Substring(tb_PriceAdd.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            // Check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                // Check if a dot exist
                if (alreadyExist(tb_PriceAdd.Text, ref sepratorChar))
                {
                    int sepratorPosition = tb_PriceAdd.Text.IndexOf(sepratorChar);
                    string afterSepratorString = tb_PriceAdd.Text.Substring(sepratorPosition + 1);
                    if (tb_PriceAdd.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private bool alreadyExist(string _text, ref char KeyChar)
        {
            // Tim Roffelsen
            // Check if textbox already contains a dot ('.')
            if (_text.IndexOf('.') > -1)
            {
                KeyChar = '.';
                return true;
            }
            
            return false;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Product_Service prodService = new Product_Service();
            List<Product> stockList = prodService.GetProducts(); // Get all products

            if ((!String.IsNullOrEmpty(tb_ProductNameAdd.Text)) && (!String.IsNullOrEmpty(tb_PriceAdd.Text))) // Product Name and Price can't be empty
            {
                foreach (Product p in stockList) // Check if product exists
                {
                    if (tb_ProductNameAdd.Text == p.ProductName)
                    {
                        MessageBox.Show("A product with that name already exists!", "Error!");
                        return;
                    }
                }
                // Get product values from input
                Product product = new Product(0, cb_AlcoholAdd.Checked, tb_ProductNameAdd.Text, Convert.ToDouble(tb_PriceAdd.Text), Convert.ToInt32(num_AmountAdd.Value), 0); 
                // Show confirmation box
                DialogResult confirm = MessageBox.Show($"The following item will be made:\n\nName:\t\t{tb_ProductNameAdd.Text}\nPrice:\t\t€ {double.Parse(tb_PriceAdd.Text).ToString("0.00")}\nAlcoholic:\t{cb_AlcoholAdd.Checked}\nAmount:\t\t{Convert.ToInt32(num_AmountAdd.Value)}", "Confirmation", MessageBoxButtons.OKCancel);
                // If confirmed, add item
                if (confirm == DialogResult.OK)
                {
                    prodService.Add_Product(product);
                    Stock_Refresh();
                }
            }
            else
            {
                MessageBox.Show("Product Name and Price can not be empty!", "Error!");
            }
        }

        private void cbox_ChangeProduct_DropDown(object sender, EventArgs e)
        {
            // Tim Roffelsen
            SomerenLogic.Product_Service prodService = new SomerenLogic.Product_Service();
            List<Product> stockList = prodService.GetProducts(); // Get all products
            cbox_ChangeProduct.Items.Clear(); // Clear combobox

            foreach (Product product in stockList) // Fill combobox
            {
                if (product.Stock != -1)
                {
                    cbox_ChangeProduct.Items.Add(product);
                }
            }
            cbox_ChangeProduct.Width = DropDownWidth(cbox_ChangeProduct); // Set width of combobox
        }
        int DropDownWidth(ComboBox myCombo)
        {
            // Get width of longest item in combobox
            int maxWidth = 0, temp = 0;
            foreach (var obj in myCombo.Items)
            {
                temp = TextRenderer.MeasureText(obj.ToString(), myCombo.Font).Width;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            return maxWidth;
        }
        private void cbox_ChangeProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Product product = (Product)cbox_ChangeProduct.SelectedItem;

            // Fill the textboxes with selected product
            if (cbox_ChangeProduct.SelectedIndex != -1)
            {
                tb_ProductNameChange.Text = product.ProductName;
                tb_PriceChange.Text = product.Price.ToString("0.00");
                num_AmountChange.Value = product.Stock;
                cb_AlcoholChange.Checked = product.IsAlcohol;
            }
        }

        private void btn_StockChange_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Product_Service prodService = new Product_Service();
            Product p = (Product)cbox_ChangeProduct.SelectedItem;
            if (cbox_ChangeProduct.SelectedIndex > -1)
            {
                if ((!String.IsNullOrEmpty(tb_ProductNameChange.Text)) && (!String.IsNullOrEmpty(tb_PriceChange.Text))) // Product Name and Price can't be empty
                {
                    // Get product values from input
                    Product product = new Product(p.ProductID, cb_AlcoholChange.Checked, tb_ProductNameChange.Text, Convert.ToDouble(tb_PriceChange.Text), Convert.ToInt32(num_AmountChange.Value), p.Sold);
                    if (!product.Equals(p)) // Checks if values were changed
                    {
                        // Show confirmation box
                        DialogResult confirm = MessageBox.Show($"The selected product will be changed to have the values:\n\nName:\t\t{tb_ProductNameChange.Text}\nPrice:\t\t€ {double.Parse(tb_PriceChange.Text).ToString("0.00")}\nAlcoholic:\t{cb_AlcoholChange.Checked}\nAmount:\t\t{Convert.ToInt32(num_AmountChange.Value)}\n\nThis action cannot be undone!", "Confirmation", MessageBoxButtons.OKCancel);
                        // If confirmed, change item
                        if (confirm == DialogResult.OK)
                        {
                            prodService.Change_Product(product);
                            Stock_Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Values were not changed!", "Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Product Name and Price can not be empty!", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Please select a product.", "Error!");
            }
        }

        private void cbox_DeleteProduct_DropDown(object sender, EventArgs e)
        {
            // Tim Roffelsen
            SomerenLogic.Product_Service prodService = new SomerenLogic.Product_Service();
            List<Product> stockList = prodService.GetProducts(); // Get all products
            cbox_DeleteProduct.Items.Clear(); // Clear combobox

            foreach (Product product in stockList) // Fill combobox
            {
                if (product.Stock != -1)
                {
                    cbox_DeleteProduct.Items.Add(product);
                }
            }
            cbox_DeleteProduct.Width = DropDownWidth(cbox_DeleteProduct); // Set width of combobox
        }

        private void cbox_DeleteProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Product product = (Product)cbox_DeleteProduct.SelectedItem;
        }

        private void btn_StockRemove_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            Product_Service prodService = new Product_Service();
            Product product = (Product)cbox_DeleteProduct.SelectedItem;

            if (cbox_DeleteProduct.SelectedItem != null)
            {
                // Show confirmation box
                DialogResult confirm = MessageBox.Show($"Are you sure you want to remove the product with the properties:\n\nName:\t\t{product.ProductName}\nPrice:\t\t€ {product.Price.ToString("0.00")}\nAlcoholic:\t{product.IsAlcohol}\nAmount:\t\t{product.Stock}\n\nThis action cannot be undone!", "Confirmation", MessageBoxButtons.OKCancel);
                // If confirmed, change item
                if (confirm == DialogResult.OK)
                {
                    prodService.Delete_Product(product);
                    Stock_Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to remove.", "Error!");
            }
        }
        void Stock_Refresh() // Refreshes listviews and dropdowns
        {
            // Tim Roffelsen
            // fill the stock listview within the stock panel with a list of products
            SomerenLogic.Product_Service prodService = new SomerenLogic.Product_Service();
            List<Product> stockList = prodService.GetStock();

            // Shows message box if there is an error
            Error_Show(prodService);

            // clear the listview and comboboxes
            listViewStock.Clear();
            cbox_ChangeProduct.SelectedIndex = -1;
            cbox_DeleteProduct.SelectedIndex = -1;
            tb_ProductNameChange.Clear();
            tb_PriceChange.Clear();
            num_AmountChange.ResetText();
            cb_AlcoholChange.ResetText();
            tb_ProductNameAdd.Clear();
            tb_PriceAdd.Clear();
            num_AmountAdd.ResetText();
            cb_AlcoholAdd.ResetText();
            // add grid lines, rows and enable sorting
            listViewStock.View = View.Details;
            listViewStock.GridLines = true;
            listViewStock.FullRowSelect = true;

            // add column header
            listViewStock.Columns.Add("DrinkID");
            listViewStock.Columns.Add("Product Name");
            listViewStock.Columns.Add("Contains Alcohol");
            listViewStock.Columns.Add("Price (€)");
            listViewStock.Columns.Add("Stock");
            listViewStock.Columns.Add("Sold");

            foreach (SomerenModel.Product p in stockList)
            {
                string[] arr = new string[6];
                ListViewItem li;

                // Add the items
                arr[0] = p.ProductID.ToString("00");
                arr[1] = p.ProductName;
                arr[2] = p.AlcoholString;
                arr[3] = p.Price.ToString("0.00");
                if (p.Stock < 10) // check stock amount
                {
                    if (p.Stock == 0)
                    {
                        arr[4] += $"Stock empty ({p.Stock.ToString()})";
                    }
                    else
                    {
                        arr[4] += $"Stock almost empty ({p.Stock.ToString()})";
                    }
                }
                else
                {
                    arr[4] += $"Sufficient stock ({p.Stock.ToString()})";
                }
                arr[5] = p.Sold.ToString();
                li = new ListViewItem(arr);
                listViewStock.Items.Add(li);
            }
            foreach (ColumnHeader ch in listViewStock.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
            foreach (ListViewItem item in listViewStock.Items) // if stock is empty or almost empty make text red
            {
                if (listViewStock.Items[item.Index].SubItems[4].Text.Contains(("empty")))
                {
                    listViewStock.Items[item.Index].UseItemStyleForSubItems = false;
                    listViewStock.Items[item.Index].SubItems[4].ForeColor = Color.Red;
                }
            }
            // Tim Roffelsen
            cbox_ChangeProduct.Items.Clear(); // Clear combobox
            foreach (Product product in stockList) // Fill combobox
            {
                cbox_ChangeProduct.Items.Add(product);
            }
            cbox_ChangeProduct.Width = DropDownWidth(cbox_ChangeProduct); // Set width of combobox
        }
        private void btn_StockRefresh_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            // Refresh stock list
            Stock_Refresh();
        }

        private void tb_PriceChange_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Tim Roffelsen
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Check if '.' pressed
            char sepratorChar = 'a';
            if (e.KeyChar == '.')
            {
                // Check if it's in the beginning of text not accept
                if (tb_PriceChange.Text.Length == 0) e.Handled = true;
                // Check if it's in the beginning of text not accept
                if (tb_PriceChange.SelectionStart == 0) e.Handled = true;
                // Check if there is already exist a '.' , ','
                if (alreadyExist(tb_PriceChange.Text, ref sepratorChar)) e.Handled = true;
                // Check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (tb_PriceChange.SelectionStart != tb_PriceChange.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = tb_PriceChange.Text.Substring(tb_PriceChange.SelectionStart);

                    if (AfterDotString.Length > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            // Check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                // Check if a dot exist
                if (alreadyExist(tb_PriceChange.Text, ref sepratorChar))
                {
                    int sepratorPosition = tb_PriceChange.Text.IndexOf(sepratorChar);
                    string afterSepratorString = tb_PriceChange.Text.Substring(sepratorPosition + 1);
                    if (tb_PriceChange.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        // OPDRACHT B WEEK 3 FUNCTIES
        // Ruben Stoop

        // This is the remove button
        private void removeBTN_Click(object sender, EventArgs e)
        {
            if (selectedDrinks_lv.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in selectedDrinks_lv.SelectedItems)
                {
                    item.Remove();
                }
            }
            else
            {
                MessageBox.Show("Select a drink.", "Error!");
            }
            update_TotalPrice();
        }


        // Ruben Stoop
        private void orderButton_Click(object sender, EventArgs e)
        {
            //Order
            //Makes The order service
            SomerenLogic.Order_Service order_Service = new SomerenLogic.Order_Service();


            List<Order_Product> orderProducts = new List<Order_Product>();

            //Order Product
            if(selectedDrinks_lv.Items.Count > 0)
            {
                foreach (ListViewItem item in selectedDrinks_lv.Items)
                {
                    Order_Product order_Product = new Order_Product();
                    string selectProduct = item.Text;
                    order_Product.ProductID = int.Parse(selectProduct);

                    order_Product.Amount = int.Parse(item.SubItems[3].Text);
                    orderProducts.Add(order_Product);
                }

                int studentID = 0;
                // Get the student
                if (studentLV.SelectedItems.Count > 0)
                {
                    string selectStudent = studentLV.SelectedItems[0].Text;
                    studentID = int.Parse(selectStudent);

                    //Get Date
                    DateTime date = DateTime.Now;

                    Order order = new Order();
                    order.OrderDate = date;
                    order.BarID = 100;
                    order.StudentID = studentID;

                    order_Service.Insert_Order(order, orderProducts);

                    //Shows messagebox and resets panel
                    MessageBox.Show("Order added.", "Succes");

                    FillOrderDrink();
                }
                else
                {
                    MessageBox.Show("Select a student.", "Error!");
                }

            } else
            {
                MessageBox.Show("There are no products in the order", "Error!");
            }
        }

        private void FillOrderDrink()
        {
            // Ruben Stoop
            // hide all other panels
            HideAllPanels();

            // show Order drinks
            pnl_OrderDrinks.Show();

            // fill the products listview within the products panel with a list of products
            SomerenLogic.Student_Service studService = new SomerenLogic.Student_Service();
            List<Student> studentList = studService.GetStudents();

            // Shows message box if there is an error
            Error_Show(studService);

            // clear the listview before filling it again
            studentLV.Clear();

            // add grid lines, rows and enable sorting
            studentLV.View = View.Details;
            studentLV.GridLines = true;
            studentLV.FullRowSelect = true;
            studentLV.Sorting = SortOrder.Ascending;
            studentLV.MultiSelect = false;

            // add column headers
            studentLV.Columns.Add("StudentID");
            studentLV.Columns.Add("Name");

            foreach (SomerenModel.Student s in studentList)
            {
                string[] arr = new string[4];
                ListViewItem li;

                //Add first item
                arr[0] = s.StudentID.ToString();
                arr[1] = s.FirstName + " " + s.LastName;

                li = new ListViewItem(arr);
                studentLV.Items.Add(li);
            }

            // Ruben Stoop
            //get The product from the database
            SomerenLogic.Product_Service prodService = new SomerenLogic.Product_Service();
            List<Product> productlist = prodService.GetProducts();

            Error_Show(prodService);

            drinkLV.Clear();

            // add grid lines, rows and enable sorting
            drinkLV.View = View.Details;
            drinkLV.GridLines = true;
            drinkLV.FullRowSelect = true;
            drinkLV.Sorting = SortOrder.Ascending;
            drinkLV.MultiSelect = false;
            // add column headers
            drinkLV.Columns.Add("DrinkID");
            drinkLV.Columns.Add("Product Name");
            drinkLV.Columns.Add("Contains Alcohol");
            drinkLV.Columns.Add("Price (€)");
            drinkLV.Columns.Add("Stock");

            foreach (SomerenModel.Product p in productlist)
            {
                string[] arr = new string[5];
                ListViewItem li;

                // Add to 
                Product listProd = new Product(p.ProductID, p.IsAlcohol, p.ProductName, p.Price, p.Stock, 0);
                ProductsList.Add(listProd);
                // Add the items
                arr[0] = p.ProductID.ToString("00");
                arr[1] = p.ProductName;
                arr[2] = p.AlcoholString;
                arr[3] = p.Price.ToString("0.00");
                if (p.Stock == -1)
                {
                    arr[4] += $"Sufficient stock (infinite)"; // if water (-1 stock) set stock infinite
                }
                else if (p.Stock < 10) // check stock amount
                {
                    if (p.Stock == 0)
                    {
                        arr[4] += $"Stock empty ({p.Stock.ToString()})";
                    }
                    else
                    {
                        arr[4] += $"Stock almost empty ({p.Stock.ToString()})";
                    }
                }
                else
                {
                    arr[4] += $"Sufficient stock ({p.Stock.ToString()})";
                }

                li = new ListViewItem(arr);
                drinkLV.Items.Add(li);
            }

            // Ruben Stoop
            // Selected Drinks
            selectedDrinks_lv.Clear();


            selectedDrinks_lv.View = View.Details;
            selectedDrinks_lv.GridLines = true;
            selectedDrinks_lv.FullRowSelect = true;
            selectedDrinks_lv.Sorting = SortOrder.Ascending;
            selectedDrinks_lv.MultiSelect = true;
            // add column headers
            selectedDrinks_lv.Columns.Add("DrinkID");
            selectedDrinks_lv.Columns.Add("Product Name");
            selectedDrinks_lv.Columns.Add("Price (€)");
            selectedDrinks_lv.Columns.Add("Amount ordered");

            foreach (ColumnHeader ch in drinkLV.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }

            foreach (ColumnHeader ch in studentLV.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
            foreach (ColumnHeader ch in selectedDrinks_lv.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
        }

        private void ActivitySuperVisor_LV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Gets activity FROM Listview
            if (ActivitySuperVisor_LV.SelectedItems.Count > 0)
            {
                int ActivityID = int.Parse(ActivitySuperVisor_LV.SelectedItems[0].Text);

                using (var form = new SuperVisor(ActivityID))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                    }
                }
            }
        }

        public void Activity_Refresh() // Refresh listview
        {
            // Tim Roffelsen
            // fill the students listview within the students panel with a list of teachers
            SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = actService.GetActivities();

            //list supervisors
            SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();
            List<Supervisor> supList = supService.GetSupervisorsWithActivitiesID();

            // Shows message box if there is an error
            Error_Show(actService);

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
            listViewActivities.Columns.Add("Supervised by");

            foreach (SomerenModel.Activity a in activityList)
            {
                //Add items in the listview
                string[] arr = new string[5];
                ListViewItem itm;

                //Add first item
                arr[0] = a.ActivityId.ToString();
                arr[1] = a.Type;
                arr[2] = a.BeginTime.ToString("dd/MM/yyyy (dddd) HH:mm");
                arr[3] = a.EndTime.ToString("dd/MM/yyyy (dddd) HH:mm");
                arr[4] = supService.FindSupervisors(a.ActivityId, supList);
                itm = new ListViewItem(arr);
                listViewActivities.Items.Add(itm);
            }
            foreach (ColumnHeader ch in listViewActivities.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
        }
        private void listViewActivities_DoubleClick(object sender, EventArgs e)
        {
            // Tim Roffelsen
            // Change or Delete an activity
            int activityId = int.Parse(listViewActivities.SelectedItems[0].Text);

            SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = actService.GetActivities();

            Activity activity = activityList.Find(x => x.ActivityId == activityId); // find activity in list
            var ChangeActivity = new ChangeActivity(activity, activityList);

            ChangeActivity.ShowDialog();
            Activity_Refresh();
        }

        private void btn_ActivityRefresh_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            // Refresh activity list
            Activity_Refresh();
        }

        private void btn_AddActivity_Click(object sender, EventArgs e)
        {
            // Tim Roffelsen
            // Add an activity
            SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
            List<Activity> activityList = actService.GetActivities();

            var AddActivity = new AddActivity(activityList); // adds list to check for duplicate names

            AddActivity.ShowDialog();
            Activity_Refresh();
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Add, edit and delete functions Teacher
        private void GoToTeachersBTN_Click(object sender, EventArgs e)
        {
            showPanel("Teachers");
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Opens form to add teacher
        private void addTeacherBTN_Click(object sender, EventArgs e)
        {
            string panelName = "Addteacher";
            TeacherForm form = new TeacherForm(panelName);
            form.ShowDialog();
            FillTeachersPanel();
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Removes the teacher
        private void removeTbtn_Click(object sender, EventArgs e)
        {
            SomerenLogic.Teacher_Service teach_Service = new SomerenLogic.Teacher_Service();

            int teacherID = 0;
            // Get the student
            if (listViewTeachers.SelectedItems.Count > 0)
            {
                string selectTeacher = listViewTeachers.SelectedItems[0].Text;
                teacherID = int.Parse(selectTeacher);

                teach_Service.Delete_Teacher(teacherID);
                Error_Show(teach_Service);
                //Shows messagebox and resets panel
                FillTeachersPanel();
                MessageBox.Show("Teacher succesfully deleted", "Succes");
            }
            else
            {
                MessageBox.Show("Select a teacher to remove", "Error!");
            }
        }

        public void FillTeachersPanel()
        {
            // Tim Roffelsen
            // hide all other panels
            HideAllPanels();

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

            // Shows message box if there is an error
            Error_Show(teachService);
            Error_Show(actService);
            Error_Show(supService);

            // clear the listview before filling it again
            listViewTeachers.Clear();

            // add grid lines, rows and enable sorting
            listViewTeachers.View = View.Details;
            listViewTeachers.GridLines = true;
            listViewTeachers.FullRowSelect = true;
            listViewTeachers.Sorting = SortOrder.Ascending;
            listViewTeachers.MultiSelect = false;


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
                arr[3] = supService.FindActivities(t.TeacherID, activityList, supList); // find type of activities
                itm = new ListViewItem(arr);
                listViewTeachers.Items.Add(itm);
            }
            foreach (ColumnHeader ch in listViewTeachers.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
        }

        private void editBTN_Click(object sender, EventArgs e)
        {

            int teacherID = 0;
            string panelName = "EditTeacher";
            // Get the student
            if (listViewTeachers.SelectedItems.Count > 0)
            {
                string selectTeacher = listViewTeachers.SelectedItems[0].Text;
                teacherID = int.Parse(selectTeacher);

                using (var form = new TeacherForm(panelName, teacherID))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Teacher succesfully edited", "Succes");
                    }
                }
                //Shows messagebox and resets panel
                FillTeachersPanel();
            }
            else
            {
                MessageBox.Show("Select a teacher to edit", "Error!");
            }
        }

        //Ask for admin permission button
        private void askAdminBTN_Click(object sender, EventArgs e)
        {
            SomerenLogic.AdminRequest_Service adminrequest = new SomerenLogic.AdminRequest_Service();
            if (User.AdminRequest)
            {
                MessageBox.Show("U have already requested to be an admin!", "Error!");
            } else
            {
                adminrequest.InsertAdminRequest(User.UserID);
                if(adminrequest.Error)
                {
                    MessageBox.Show(adminrequest.ErrorText, "Error!");
                } else
                {
                    User.AdminRequest = true;
                    MessageBox.Show("Your request to become an admin has been sent", "Succes!");
                    LoadUserPanel();
                }
            }
        }

        // Ruben Stoop
        // Loads the admin request listview

        public void LoadUserAdminRequestLV()
        {
            SomerenLogic.AdminRequest_Service adminrequest = new SomerenLogic.AdminRequest_Service();
            List<User> Usersadminreq = adminrequest.GetUsersWithRequest();

            // clear the listview and comboboxes
            adminRequest_LV.Clear();


            //Setting up Supervisor listview
            adminRequest_LV.View = View.Details;
            adminRequest_LV.GridLines = true;
            adminRequest_LV.FullRowSelect = true;
            adminRequest_LV.Sorting = SortOrder.Ascending;


            // add column header
            adminRequest_LV.Columns.Add("User ID");
            adminRequest_LV.Columns.Add("UserName");
            adminRequest_LV.Columns.Add("Name");

            foreach (SomerenModel.User ua in Usersadminreq)
            {
                string[] arr = new string[3];
                ListViewItem li;

                // Add the items
                arr[0] = ua.UserID.ToString();
                arr[1] = ua.UserName;
                arr[2] = ua.Name;

                li = new ListViewItem(arr);
                adminRequest_LV.Items.Add(li);
            }

            foreach (ColumnHeader ch in adminRequest_LV.Columns) // dynamically change column width
            {
                ch.Width = -2;
            }
        }

        //Load two different panels if user is admin or not
        public void LoadUserPanel()
        {
            HideAllPanels();
            pnl_User.Show();

            userNamelbl.Text = "Username: " + User.UserName;
            profileNamelbl.Text = "Name: " + User.Name;
            if (User.IsAdmin == true)
            {
                pnl_UserUser.Hide();
                pnl_UserAdmin.Show();
                LoadUserAdminRequestLV();

            }
            else if (User.IsAdmin == false)
            {
                pnl_UserUser.Show();
                pnl_UserAdmin.Hide();
            }
        }
    }
}
