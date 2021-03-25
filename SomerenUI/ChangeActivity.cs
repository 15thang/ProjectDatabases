using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class ChangeActivity : Form
    {
        public Activity Activity { get; set; }
        public List<Activity> ActivityList { get; set; }

        public ChangeActivity(Activity activity, List<Activity> activityList)
        {
            InitializeComponent();

            this.Activity = activity; // Saves Activity
            this.ActivityList = activityList; // Saves list
            dtp_ActivityBeginTime.Format = DateTimePickerFormat.Time; // Format time datetimepickers to display time
            dtp_ActivityBeginTime.ShowUpDown = true;
            dtp_ActivityEndTime.Format = DateTimePickerFormat.Time;
            dtp_ActivityEndTime.ShowUpDown = true;

            lbl_ActivityID.Text = activity.ActivityId.ToString(); // Fill in fields
            dtp_ActivityBeginDate.Value = activity.BeginTime;
            dtp_ActivityBeginTime.Value = activity.BeginTime;
            dtp_ActivityEndDate.Value = activity.EndTime;
            dtp_ActivityEndTime.Value = activity.EndTime;
            tb_type.Text = activity.Type;
        }

        private void btn_ActivityChange_Click(object sender, EventArgs e)
        {
            DateTime beginTime = dtp_ActivityBeginDate.Value.Date + dtp_ActivityBeginTime.Value.TimeOfDay; // Add Date and Time values together
            DateTime endTime = dtp_ActivityEndDate.Value.Date + dtp_ActivityEndTime.Value.TimeOfDay;
            string type = tb_type.Text;
            if (beginTime < endTime && beginTime > DateTime.Now)
            {
                Activity activity = new Activity() // Makes new activity object
                {
                    ActivityId = Activity.ActivityId,
                    Type = type,
                    BeginTime = beginTime,
                    EndTime = endTime
                };

                if (!Activity.Equals(activity)) // Checks if values were changed
                {
                    bool exists = false;
                    foreach (var item in ActivityList)
                    {
                        if (item.Type == type && item.ActivityId != activity.ActivityId)
                        {
                            exists = true;
                        }
                    }
                    if (exists == false)
                    {
                        DialogResult confirm = MessageBox.Show($"The selected activity will be changed to have the values:\n\nActivity Name:\t{activity.Type}\nBegin Time:\t{activity.BeginTime.ToString("dd/MM/yyyy HH:mm")}\nEnd Time:\t{activity.EndTime.ToString("dd/MM/yyyy HH:mm")}", "Confirmation", MessageBoxButtons.OKCancel);
                        if (confirm == DialogResult.OK) // If confirmed, change item
                        {
                            Activity_Service actServ = new Activity_Service();
                            actServ.Change_Activity(activity); // Change activity
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
                    MessageBox.Show("Values were not changed!", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Begin Time can not be later or equal to End Time, and not be in the past!", "Error!");
            }
        }

        private void btn_ActivityDelete_Click(object sender, EventArgs e)
        {
            DateTime beginTime = dtp_ActivityBeginDate.Value.Date + dtp_ActivityBeginTime.Value.TimeOfDay; // Add Date and Time values together
            DateTime endTime = dtp_ActivityEndDate.Value.Date + dtp_ActivityEndTime.Value.TimeOfDay;
            string type = tb_type.Text;

            Activity activity = new Activity() // Makes new activity object
            {
                ActivityId = Activity.ActivityId,
                Type = type,
                BeginTime = beginTime,
                EndTime = endTime
            };

            DialogResult confirm = MessageBox.Show($"This activity will be deleted, are you sure?", "Warning!", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Activity_Service actServ = new Activity_Service();
                actServ.Delete_Activity(activity); // Delete activity
                this.Close();
            }
        }
    }
}