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
        // Ruben Stoop
        // Opdracht B Week 4
        // Gets activity for the supervisors
        public Activity Db_Get_Activity(int ID)
        {
            string query = "SELECT ActiviteitID, Soort, Begintijd, Eindtijd  FROM Activiteit WHERE ActiviteitID = @id;";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", ID);
            return ReadActivity(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Gets activity for the supervisors
        private Activity ReadActivity(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];

            Activity activity = new Activity()
            {
                    ActivityId = (int)dr["ActiviteitID"],
                    Type = (String)dr["Soort"],
                    BeginTime = (DateTime)dr["Begintijd"],
                    EndTime = (DateTime)dr["Eindtijd"]
            };

            return activity;
        }

        // Tim Roffelsen
        // Data gets pulled from the database by the query
        public List<Activity> Db_Get_All_Activities()
        {
            string query = "USE prjdb4 SELECT ActiviteitID, Soort, Begintijd, Eindtijd FROM [Activiteit]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public void Change_Activity(Activity activity)
        {
            // Tim Roffelsen
            // Data gets changed in database
            string query = "USE prjdb4 UPDATE Activiteit SET Soort = @type, Begintijd = @begintime, Eindtijd = @endtime WHERE ActiviteitID = @activityid; ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@type", activity.Type);
            sqlParameters[1] = new SqlParameter("@begintime", activity.BeginTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            sqlParameters[2] = new SqlParameter("@endtime", activity.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            sqlParameters[3] = new SqlParameter("@activityid", activity.ActivityId);

            ExecuteEditQuery(query, sqlParameters);
        }
        public void Delete_Activity(Activity activity)
        {
            // Tim Roffelsen
            // Data gets changed in database
            string query = "USE prjdb4 DELETE FROM Activiteit WHERE ActiviteitID = @activityid; ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@activityid", activity.ActivityId);

            ExecuteEditQuery(query, sqlParameters);
        }
        public void Add_Activity(Activity activity)
        {
            // Tim Roffelsen
            // Data gets written to database, primary key is automatically made
            string query = "USE prjdb4 INSERT INTO Activiteit (Soort, Begintijd, Eindtijd) VALUES(@type, @begintime, @endtime); ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@type", activity.Type);
            sqlParameters[1] = new SqlParameter("@begintime", activity.BeginTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            sqlParameters[2] = new SqlParameter("@endtime", activity.EndTime.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            ExecuteEditQuery(query, sqlParameters);
        }
        // Tim Roffelsen
        // The returned data gets saved in a list
        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

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
