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
