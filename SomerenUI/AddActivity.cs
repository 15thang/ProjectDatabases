using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddActivity : Form
    {
        public List<Activity> ActivityList { get; set; }

        public AddActivity(List<Activity> activityList)
        {
            InitializeComponent();

            this.ActivityList = activityList; // Saves list
            dtp_ActivityBeginTime.Format = DateTimePickerFormat.Time; // Format time datetimepickers to display time
            dtp_ActivityBeginTime.ShowUpDown = true;
            dtp_ActivityEndTime.Format = DateTimePickerFormat.Time;
            dtp_ActivityEndTime.ShowUpDown = true;

            DateTime dt = DateTime.Now; // sets current time
            DateTime rounded = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0); // sets all times except for minutes and seconds
            if (dt.Minute > 0 || dt.Second > 0) // round to nearest hour
            {
                rounded = rounded.AddHours(1);
            }
            dtp_ActivityBeginDate.Value = dt;
            dtp_ActivityBeginTime.Value = rounded;
            dtp_ActivityEndDate.Value = dt;
            dtp_ActivityEndTime.Value = rounded;
        }

        private void btn_AddChange_Click(object sender, EventArgs e)
        {
            DateTime beginTime = dtp_ActivityBeginDate.Value.Date + dtp_ActivityBeginTime.Value.TimeOfDay; // Add Date and Time values together
            DateTime endTime = dtp_ActivityEndDate.Value.Date + dtp_ActivityEndTime.Value.TimeOfDay;
            string type = tb_type.Text;
            if (beginTime < endTime && beginTime > DateTime.Now)
            {
                Activity activity = new Activity() // Makes new activity object
                {
                    Type = type,
                    BeginTime = beginTime,
                    EndTime = endTime
                };
                bool exists = false;

                foreach (var item in ActivityList)
                {
                    if (item.Type == type)
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    DialogResult confirm = MessageBox.Show($"The activity with the following values will be added:\n\nActivity Name:\t{activity.Type}\nBegin Time:\t{activity.BeginTime.ToString("dd/MM/yyyy HH:mm")}\nEnd Time:\t{activity.EndTime.ToString("dd/MM/yyyy HH:mm")}", "Confirmation", MessageBoxButtons.OKCancel);
                    if (confirm == DialogResult.OK) // If confirmed, change item
                    {
                        Activity_Service actServ = new Activity_Service();
                        actServ.Add_Activity(activity); // Change activity
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("An activity with that name already exists!", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Begin Time can not be later or equal to End Time, and not be in the past!", "Error!");
            }
        }
    }
}