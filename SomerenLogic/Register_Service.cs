using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Register_Service : Base_Service
    {
        Register_DAO register_db = new Register_DAO();

        public void Insert_User(User user)
        {
            try
            {
                register_db.InsertUser(user);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }
    }
}
