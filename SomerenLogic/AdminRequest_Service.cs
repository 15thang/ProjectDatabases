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

    public class AdminRequest_Service : Base_Service
    {
        AdminRequest_DAO adminrequest_db = new AdminRequest_DAO();

        // Ruben Stoop
        // Opdracht B Week 5
        // Sets the admin request to true for gebruiker
        public bool CheckRequests()
        {
            try
            {
                return adminrequest_db.Check_Requests();
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                return false;
            }
        }


        // Ruben Stoop
        // Opdracht B Week 5
        // Sets the admin request to true for gebruiker
        public void InsertAdminRequest(int ID)
        {
            try
            {
                adminrequest_db.Insert_AdminRequest(ID);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }

        // Ruben Stoop
        // Opdracht B Week 5
        // Sets the admin to true for gebruiker
        public void MakeAdmin(int ID)
        {
            try
            {
                adminrequest_db.Make_Admin(ID);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }

        // Ruben Stoop
        // Opdracht B Week 5
        // Sets the admin to false for and deletes request for user
        public void RejectAdmin(int ID)
        {
            try
            {
                adminrequest_db.Reject_Admin(ID);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }

        // Ruben Stoop
        // The logic layer fetches the list with Users, if something goes wrong a test User is made
        public List<User> GetUsersWithRequest()
        {
            try
            {
                List<User> teachers = adminrequest_db.Db_Get_All_User_With_Request();
                return teachers;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                List<User> users = new List<User>();
                User t = new User();
                t.UserID = 0;
                t.UserName = "Mr. Error";
                t.IsAdmin = false;
                t.Name = "Test naam";
                t.AdminRequest = true;
                users.Add(t);

                return users;
            }
        }
    }
}
