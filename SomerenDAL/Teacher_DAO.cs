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
      
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "SELECT Docent.DocentID, Persoon.Naam FROM [Docent] INNER JOIN[Persoon] ON Docent.PersoonID = Persoon.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    TeacherID = (int)dr["DocentID"],
                    Name = (String)dr["Naam"],
                };
                teachers.Add(teacher);
            }
            return teachers;
        }

    }
}
