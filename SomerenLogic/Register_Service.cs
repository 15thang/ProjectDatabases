using SomerenDAL;
using SomerenModel;
using System;

namespace SomerenLogic
{
    public class Register_Service : Base_Service
    {
        private Register_DAO register_db = new Register_DAO();

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