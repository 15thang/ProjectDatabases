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

        //Ruben Stoop
        //Hier wordt de query geschreven. We maken gebruik van een inner join omdat de meeste gegevens van de student staan opgeslagen in de Persoon tabel.
        public List<Student> Db_Get_All_Students()
        {
            string query = "SELECT Student.StudentID, Persoon.Voornaam, Persoon.Achternaam FROM [Student] INNER JOIN[Persoon] ON Student.PersoonID = Persoon.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        //Ruben Stoop
        //De data die de database terug geeft wordt hier in een list opgeslagen.
        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                    Student student = new Student()
                    {
                        StudentID = (int)dr["StudentID"],

                        FirstName = (String)dr["Voornaam"],
                        LastName = (String)dr["Achternaam"],
                    };
                    students.Add(student);
            }
            return students;
        }

    }
}
