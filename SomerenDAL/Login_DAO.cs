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
    public class Login_DAO : Base
    {
        public User User_Login(string Username, string Password)
        {
            string query = "SELECT GebruikerID, Gebruikersnaam, Wachtwoord, IsAdmin FROM Gebruiker WHERE Gebruikersnaam = @username AND Wachtwoord = @password;";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", Username);
            sqlParameters[1] = new SqlParameter("@password", Password);
            return ReadUser(ExecuteSelectQuery(query, sqlParameters));
        }
        private User ReadUser(DataTable dataTable)
        {
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];

            User user = new User()
            {
                UserID = (int)dr["GebruikerID"],
                UserName = (String)dr["Gebruikersnaam"],
                Password = (String)dr["Wachtwoord"],
                IsAdmin = (bool)dr["IsAdmin"]
            };

            return user;
        }
    }
}
