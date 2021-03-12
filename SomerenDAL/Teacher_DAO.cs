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
    public class Teacher_DAO : Base
    {
        // Tim Roffelsen
        // Data gets pulled from the database by the query, INNER JOIN is used to get data from 'Persoon' table
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT Docent.DocentID, Persoon.Voornaam, Persoon.Achternaam FROM [Docent] INNER JOIN[Persoon] ON Docent.PersoonID = Persoon.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    TeacherID = (int)dr["DocentID"],
                    FirstName = (String)dr["Voornaam"],
                    LastName = (String)dr["Achternaam"]
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

    }
}
