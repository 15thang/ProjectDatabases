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
            pnl_Dashboard.Hide();
            img_Dashboard.Hide();
            pnl_Teachers.Hide();
            pnl_Students.Hide();
            pnl_Rooms.Hide();
            pnl_Activities.Hide();
            pnl_Roomslayout.Hide();
            pnl_OrderDrinks.Hide();
            pnl_Stock.Hide();
        }

        private void showPanel(string panelName)
        {
            if(panelName == "Dashboard")
            {
                // hide all other panels
                HideAllPanels();

                // show dashboard
                pnl_Dashboard.Show();
                img_Dashboard.Show();
            }
            else if(panelName == "Students")
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

                // fill the students listview within the students panel with a list of teachers
                SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();
                List<Activity> activityList = actService.GetActivities();

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
                    if(UniqueRoom.Contains(o.Number) == false)
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
            else if(panelName == "OrderDrinks")
            {
                // Ruben Stoop
                // hide all other panels
                HideAllPanels();
                
                // show Order drinks
                pnl_OrderDrinks.Show();

                // fill the students listview within the students panel with a list of students
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
                drinkLV.MultiSelect = true;
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
                        arr[4] += $"Stock almost empty ({p.Stock.ToString()})";
                    }
                    else
                    {
                        arr[4] += $"Sufficient stock ({p.Stock.ToString()})";
                    }

                    li = new ListViewItem(arr);
                    drinkLV.Items.Add(li);
                }

                foreach (ColumnHeader ch in drinkLV.Columns) // dynamically change column width
                {
                    ch.Width = -2;
                }

                foreach (ColumnHeader ch in studentLV.Columns) // dynamically change column width
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

                // fill the students listview within the students panel with a list of teachers
                SomerenLogic.Product_Service prodService = new SomerenLogic.Product_Service();
                List<Product> stockList = prodService.GetStock();

                // Shows message box if there is an error
                Error_Show(prodService);

                // clear the listview before filling it again
                listViewStock.Clear();

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
                        arr[4] += $"Stock almost empty ({p.Stock.ToString()})";
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
            }
        }

        //Ruben Stoop
        private void drinkLV_SelectedIndexChanged(object sender, EventArgs e)
        {
            double totalPrice = 0.00;
            foreach (ListViewItem item in drinkLV.SelectedItems)
            {
                totalPrice += Double.Parse(item.SubItems[3].Text);
            }
            totalPriceLabel.Text = "€" + totalPrice.ToString("0.00");
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

        // Ruben Stoop
        private void orderButton_Click(object sender, EventArgs e)
        {
            //Order
            //Makes The order service
            SomerenLogic.Order_Service order_Service = new SomerenLogic.Order_Service();


            List<Order_Product> orderProducts = new List<Order_Product>();

            //Order Product
            foreach (ListViewItem item in drinkLV.SelectedItems)
            {
                Order_Product order_Product = new Order_Product();
                string selectProduct = item.Text;
                order_Product.ProductID = int.Parse(selectProduct);
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
                studentLV.SelectedItems.Clear();
                drinkLV.SelectedItems.Clear();
                pnl_OrderDrinks.Refresh();
                pnl_OrderDrinks.Update();
            }
            else
            {
                MessageBox.Show("Select a student.");
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
                if (tb_Price.Text.Length == 0) e.Handled = true;
                // Check if it's in the beginning of text not accept
                if (tb_Price.SelectionStart == 0) e.Handled = true;
                // Check if there is already exist a '.' , ','
                if (alreadyExist(tb_Price.Text, ref sepratorChar)) e.Handled = true;
                // Check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (tb_Price.SelectionStart != tb_Price.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = tb_Price.Text.Substring(tb_Price.SelectionStart);

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
                if (alreadyExist(tb_Price.Text, ref sepratorChar))
                {
                    int sepratorPosition = tb_Price.Text.IndexOf(sepratorChar);
                    string afterSepratorString = tb_Price.Text.Substring(sepratorPosition + 1);
                    if (tb_Price.SelectionStart > sepratorPosition && afterSepratorString.Length > 1)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        private bool alreadyExist(string _text, ref char KeyChar)
        {
            // Tim Roffelsen
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
            if ((!String.IsNullOrEmpty(tb_ProductName.Text)) && !String.IsNullOrEmpty(tb_Price.Text))
            {
                Product product = new Product(0, cb_Alcohol.Checked, tb_ProductName.Text, Convert.ToDouble(tb_Price.Text), Convert.ToInt32(num_Amount.Value), 0);
                prodService.Add_Product(product);
            }
            else
            {
                MessageBox.Show("Product name and Price can not be empty!", "Error!");
            }
            
        }
    }
}
