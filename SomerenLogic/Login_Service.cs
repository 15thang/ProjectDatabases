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
    public class Login_Service : Base_Service
    {
        Login_DAO login_db = new Login_DAO();

        public User User_Login(string Username, string Password)
        {
            try
            {
                User user = login_db.User_Login(Username, Password);
                return user;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
