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
    public class Register_DAO : Base
    {
        // Ruben Stoop
        // Opdracht B Week 5
        // Inserts the user in the table
        public void InsertUser(User user)
        {
            string query = "INSERT INTO Gebruiker (Gebruikersnaam, Wachtwoord, IsAdmin, Naam) VALUES (@gebruikersnaam, @wachtwoord, @isadmin, @naam);";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@gebruikersnaam", user.UserName);
            sqlParameters[1] = new SqlParameter("@wachtwoord", user.Password);
            sqlParameters[2] = new SqlParameter("@isadmin", false);
            sqlParameters[3] = new SqlParameter("@naam", user.Name);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
