using SomerenDAL;
using SomerenModel;
using System;

namespace SomerenLogic
{
    public class Login_Service : Base_Service
    {
        // Tim Roffelsen
        // Login functionality to database layer
        private Login_DAO login_db = new Login_DAO();

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