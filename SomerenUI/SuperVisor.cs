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
    public partial class SuperVisor : Form
    {
        public Activity Activity;

        SomerenLogic.Activity_Service actService = new SomerenLogic.Activity_Service();

        SomerenLogic.Supervisor_Service supService = new SomerenLogic.Supervisor_Service();

        public SuperVisor(int ID)
        {
            InitializeComponent();
            this.Activity = actService.GetActivity(ID);
        }

        private void SuperVisor_Load(object sender, EventArgs e)
        {
            SetLabels();
            FillListView();
        }

        private void SetLabels()
        {
            idLbl.Text += Activity.ActivityId.ToString();
            ActivityTitleLabel.Text = Activity.Type.ToString();
            startTimeLbl.Text += Activity.BeginTime.ToString("dd/MM/yyyy HH:mm");
            endTimeLbl.Text += Activity.EndTime.ToString("dd/MM/yyyy HH:mm");
        }


        private void FillListView()
        {
            List<Supervisor> supervisors = supService.GetSupervisorsForOneActicity(Activity.ActivityId);


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
        }

    }
}
