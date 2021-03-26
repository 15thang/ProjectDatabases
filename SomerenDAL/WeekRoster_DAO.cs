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
    public class WeekRoster_DAO : Base
    {
        // Thomas Eddyson
        public List<WeekRoster> Db_Get_All_WeekRoster()
        {            
            string query = "SELECT p.Voornaam, p.Achternaam, a.Begintijd, a.Eindtijd, a.Soort FROM[Persoon] as p JOIN[Docent] AS d ON p.PersoonID = d.PersoonID JOIN[Begeleider] AS b ON d.DocentID = b.DocentID JOIN[Activiteit] as a ON b.ActiviteitID = a.ActiviteitID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<WeekRoster> ReadTables(DataTable dataTable)
        {
            List<WeekRoster> activityRosters = new List<WeekRoster>();
            WeekRoster date = new WeekRoster();            

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                date.Date = (DateTime)dr["Begintijd"];
                date.DayOfWeek = (int)date.Date.DayOfWeek;

                WeekRoster activityRoster = new WeekRoster()
                {
                    DayOfWeek = date.DayOfWeek,
                    FirstName = (string)dr["Voornaam"],
                    LastName = (string)dr["Achternaam"],
                    ActivityName = (string)dr["Soort"],
                    BeginTime = (DateTime)dr["Begintijd"],
                    EndTime = (DateTime)dr["Eindtijd"]
                };
                activityRosters.Add(activityRoster);
            }

            return activityRosters;
        }

    }
}