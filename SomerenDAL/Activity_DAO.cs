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
    public class Activity_DAO : Base
    {
        // Tim Roffelsen
        // Data gets pulled from the database by the query
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "SELECT ActiviteitID, Soort, Begintijd, Eindtijd FROM [Activiteit]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityId = (int)dr["ActiviteitID"],
                    Type = (String)dr["Soort"],
                    BeginTime = (DateTime)dr["Begintijd"],
                    EndTime = (DateTime)dr["Eindtijd"]
                };
                activities.Add(activity);
            }
            return activities;
        }

    }
}
