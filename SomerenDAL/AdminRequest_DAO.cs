using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

namespace SomerenDAL
{
    public class AdminRequest_DAO : Base
    {
        // Ruben Stoop
        // Opdracht B Week 5
        // sets the admin to true
        public void Make_Admin(int ID)
        {
            string query = "UPDATE Gebruiker SET IsAdmin = 1, AdminRequest = 0 WHERE GebruikerID = @id;";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@id", ID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Opdracht B week 5
        // sets the admin request to false
        public void Reject_Admin(int ID)
        {
            string query = "UPDATE Gebruiker SET IsAdmin = 0, AdminRequest = 0 WHERE GebruikerID = @id;";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@id", ID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Opdracht B Week 5
        // sets the adminrequest to true
        public void Insert_AdminRequest(int ID)
        {
            string query = "UPDATE Gebruiker SET AdminRequest = 1 WHERE GebruikerID = @id; ";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@id", ID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Opdracht B Week 5 Get all user with admin request
        public List<User> Db_Get_All_User_With_Request()
        {
            string query = "SELECT GebruikerID, Gebruikersnaam, IsAdmin, Naam, AdminRequest FROM Gebruiker WHERE AdminRequest = @true; ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@true", true);

            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Opdracht B week 5
        // The returned data gets saved in a list
        private List<User> ReadTables(DataTable dataTable)
        {
            List<User> users = new List<User>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                User user = new User()
                {
                    UserID = (int)dr["GebruikerID"],
                    UserName = (String)dr["Gebruikersnaam"],
                    IsAdmin = (bool)dr["IsAdmin"],
                    Name = (string)dr["Naam"],
                    AdminRequest = (bool)dr["AdminRequest"],
                };
                users.Add(user);
            }
            return users;
        }
    }
}
