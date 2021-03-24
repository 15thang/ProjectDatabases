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

        public SuperVisor(int ID)
        {
            InitializeComponent();
            this.Activity = actService.GetActivity(ID);
        }

        private void SuperVisor_Load(object sender, EventArgs e)
        {

        }
    }
}
