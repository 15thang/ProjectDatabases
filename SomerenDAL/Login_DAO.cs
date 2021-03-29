using SomerenModel;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Login_DAO : Base
    {
        // Tim Roffelsen
        // Login functionality to database
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