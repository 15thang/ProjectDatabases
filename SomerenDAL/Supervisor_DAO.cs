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
    public class Supervisor_DAO : Base
    {
        // Ruben Stoop
        // Opdracht B Week 4
        // Deletes supervisor for activity
        public void DeleteSupervisor(int SupervisorID)
        {
            string query = "DELETE FROM Begeleider WHERE BegeleiderID = @supervisor;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@supervisor", SupervisorID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Inserts supervisor for activity
        public void InsertSupervisor(Supervisor supervisor)
        {
            string query = "INSERT INTO Begeleider (ActiviteitID, DocentID) VALUES (@activiteitid, @docentid);";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@activiteitid", supervisor.ActivityID);
            sqlParameters[1] = new SqlParameter("@docentid", supervisor.TeacherID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Gets all Supervisors with one specific activity ID
        public List<Supervisor> Db_Get_All_Supervisors_For_Activity(int ID)
        {
            string query = "SELECT B.BegeleiderID, P.Voornaam, P.Achternaam, D.DocentID FROM Begeleider AS B INNER JOIN Docent AS D on B.DocentID = D.DocentID INNER JOIN Persoon AS P on D.PersoonID = P.PersoonID WHERE B.ActiviteitID = @id;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", ID);
            return ReadSupervisorWithID(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // puts all supervisors into a list
        public List<Supervisor> ReadSupervisorWithID(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    SuperVisorID = (int)dr["BegeleiderID"],
                    FirstName = (string)dr["Voornaam"],
                    LastName = (string)dr["Achternaam"],
                    TeacherID = (int)dr["DocentID"],
                };
                supervisors.Add(supervisor);
            }
            return supervisors;
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Gets all Supervisors with activities ID
        public List<Supervisor> Db_Get_All_Supervisors_With_ActivitiesID()
        {
            string query = "SELECT B.BegeleiderID, P.Voornaam, P.Achternaam, B.ActiviteitID FROM Begeleider AS B INNER JOIN Docent AS D on B.DocentID = D.DocentID INNER JOIN Persoon AS P on D.PersoonID = P.PersoonID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadSuperVisors(ExecuteSelectQuery(query, sqlParameters));
        }


        // Ruben Stoop
        // Opdracht B Week 4
        // Reads all supervisors
        public List<Supervisor> ReadSuperVisors(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();
            
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    SuperVisorID = (int)dr["BegeleiderID"],
                    FirstName = (string)dr["Voornaam"],
                    LastName = (string)dr["Achternaam"],
                    ActivityID = (int)dr["ActiviteitID"],
                };
                supervisors.Add(supervisor);
            }
            return supervisors;

        }

        // Tim Roffelsen
        // Data gets pulled from the database by the query
        public List<Supervisor> Db_Get_All_Supervisors()
        {
            string query = "USE prjdb4 SELECT D.DocentID, A.ActiviteitID FROM Docent AS D INNER JOIN Begeleider AS B ON B.DocentID = D.DocentID INNER JOIN Activiteit AS A ON A.ActiviteitID = B.ActiviteitID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Supervisor> ReadTables(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    TeacherID = (int)dr["DocentID"],
                    ActivityID = (int)dr["ActiviteitID"]
                };
                supervisors.Add(supervisor);
            }
            return supervisors;
        }
    }
}
