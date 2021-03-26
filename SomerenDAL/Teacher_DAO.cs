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
        // Ruben Stoop
        // Opdracht B Week 4
        // Gets teacher for the edit function
        public Teacher Db_Get_Teacher(int ID)
        {
            string query = "SELECT DocentID, D.PersoonID, Geboortedatum, Voornaam, Achternaam FROM Persoon as P INNER JOIN Docent AS D ON P.PersoonID = D.PersoonID WHERE D.DocentID = @id;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", ID);
            return ReadTeacher(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Gets activity for the supervisors
        private Teacher ReadTeacher(DataTable dataTable)
        {
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];
            Teacher teacher = new Teacher()
            {
                TeacherID = (int)dr["DocentID"],
                PersonID = (int)dr["PersoonID"],
                BirthDate = (DateTime)dr["Geboortedatum"],
                FirstName = (string)dr["Voornaam"],
                LastName = (string)dr["Achternaam"]
            };
            return teacher;
        }


        // Ruben Stoop
        // Opdracht B Week 4 Also uses this method
        // Tim Roffelsen
        // Data gets pulled from the database by the query, INNER JOIN is used to get data from 'Persoon' table
        public List<Teacher> Db_Get_All_Teachers()
        {
            string query = "USE prjdb4 SELECT D.DocentID, P.Voornaam, P.Achternaam FROM [Docent] AS D INNER JOIN [Persoon] AS P ON D.PersoonID = P.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

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

        // Ruben Stoop
        // Gets the highest id of the table Teacher
        public int Get_Highest_ID_For_Teacher()
        {
            string query = "SELECT MAX(DocentID) as DocentID FROM Docent;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadIntDocent(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // INSERT Teacher
        public void Insert_Teacher(Teacher teacher)
        {
            //Datetime to a format sql can understand
            string sqlDate = teacher.BirthDate.ToString("yyyy-MM-dd");

            //Fills the person table
            string query = "INSERT INTO Persoon (PersoonID, Geboortedatum, GroepID, Voornaam, Achternaam) VALUES(@personid, @birthdate, @groupid, @firstname, @lastname);";

            teacher.PersonID = Get_Highest_ID_For_Person() + 1;
            teacher.TeacherID = Get_Highest_ID_For_Teacher() + 1;
            //Setting the parameters from the parameter Teacher
            SqlParameter[] sqlParameters = new SqlParameter[5];

            sqlParameters[0] = new SqlParameter("@personid", teacher.PersonID);
            sqlParameters[1] = new SqlParameter("@birthdate", sqlDate);
            sqlParameters[2] = new SqlParameter("@groupid", 1);
            sqlParameters[3] = new SqlParameter("@firstname", teacher.FirstName);
            sqlParameters[4] = new SqlParameter("@lastname", teacher.LastName);
            ExecuteEditQuery(query, sqlParameters);

            //Ruben Stoop
            //Fills the Teacher Table
            string query2 = "INSERT INTO Docent (DocentID, PersoonID) VALUES(@docentid, @personid);";

            SqlParameter[] sqlParameters2 = new SqlParameter[2];
            sqlParameters2[0] = new SqlParameter("@docentid", teacher.TeacherID);
            sqlParameters2[1] = new SqlParameter("@personid", teacher.PersonID);
            ExecuteEditQuery(query2, sqlParameters2);
        }

        // Ruben Stoop
        // Gets the highest id of the table Person
        public int Get_Highest_ID_For_Person()
        {
            string query = "SELECT MAX(PersoonID) as PersonID FROM Persoon;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadInt(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Reads the datatable and returns the PersonID
        private int ReadInt(DataTable dataTable)
        {
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];
            return (int)dr["PersonID"];
        }        
        
        // Ruben Stoop
        // Reads the datatable and returns the DocentID
        private int ReadIntDocent(DataTable dataTable)
        {
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];
            return (int)dr["DocentID"];
        }

        // Ruben Stoop
        // Deletes the teacher
        public void DeleteTeacher(int TeacherID)
        {
            int PersonID = GetPersonIDWithTeacherID(TeacherID);

            string query = "DELETE FROM Begeleider WHERE DocentID = @teacherid;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@teacherid", TeacherID);
            ExecuteEditQuery(query, sqlParameters);

            string query2= "DELETE FROM Docent WHERE DocentID = @teacherid;";
            SqlParameter[] sqlParameters2 = new SqlParameter[1];
            sqlParameters2[0] = new SqlParameter("@teacherid", TeacherID);
            ExecuteEditQuery(query2, sqlParameters2);

            string query3 = "DELETE FROM Persoon WHERE PersoonID = @personid;";
            SqlParameter[] sqlParameters3 = new SqlParameter[1];
            sqlParameters3[0] = new SqlParameter("@personid", PersonID);
            ExecuteEditQuery(query3, sqlParameters3);
        }

        // Ruben Stoop
        // Gets the id for the Deleteteacher method
        public int GetPersonIDWithTeacherID(int TeacherID)
        {
            string query = "SELECT PersoonID as PersonID FROM Docent WHERE DocentID = @teacherid; ";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@teacherid", TeacherID);
            return ReadInt(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Update Teachers
        public void UpdateTeacher(Teacher teacher)
        {
            string sqlDate = teacher.BirthDate.ToString("yyyy-MM-dd");

            string query = "UPDATE Persoon SET Geboortedatum = @geboortedatum, Voornaam = @voornaam, Achternaam = @achternaam WHERE PersoonID = @persoonid; ";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@persoonid", teacher.PersonID);
            sqlParameters[1] = new SqlParameter("@voornaam", teacher.FirstName);
            sqlParameters[2] = new SqlParameter("@achternaam", teacher.LastName);
            sqlParameters[3] = new SqlParameter("@geboortedatum", sqlDate);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
