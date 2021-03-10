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
    public class Student_DAO : Base
    {
      
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT Student.StudentID, Persoon.Naam, Persoon.Geboortedatum FROM [Student] INNER JOIN[Persoon] ON Student.PersoonID = Persoon.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentID = (int)dr["StudentID"],
                    Name = (String)dr["Naam"],
                    BirthDate = (DateTime)(dr["GeboorteDatum"])
                };
                students.Add(student);
            }
            return students;
        }

    }
}
