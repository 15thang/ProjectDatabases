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
        // Tim Roffelsen
        // Data gets pulled from the database by the query
        public List<Supervisor> Db_Get_All_Supervisors()
        {
            string query = "SELECT D.DocentID, A.ActiviteitID FROM Docent AS D INNER JOIN Begeleider AS B ON B.DocentID = D.DocentID INNER JOIN Activiteit AS A ON A.ActiviteitID = B.ActiviteitID;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Supervisor> ReadTables(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    teacherID = (int)dr["DocentID"],
                    activityID = (int)dr["ActiviteitID"]
                };
                supervisors.Add(supervisor);
            }
            return supervisors;
        }
    }
}
