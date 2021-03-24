using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Activity_Service : Base_Service
    {
        Activity_DAO activity_db = new Activity_DAO();

        public Activity GetActivity(int ID)
        {
            try
            {
                Activity activity = activity_db.Db_Get_Activity(ID);
                return activity;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                Activity a = new Activity();
                a.Type = "Errors Checken";
                a.ActivityId = 404;
                a.BeginTime = DateTime.ParseExact("11/11/2011 11:11", "dd/MM/yyyy HH:mm", null);
                a.EndTime = DateTime.ParseExact("22/12/2022 22:22", "dd/MM/yyyy HH:mm", null);

                return a;
            }
        }
        // Tim Roffelsen
        // The logic layer fetches the list with students, if something goes wrong a test activity is made
        public List<Activity> GetActivities()
        {
            try
            {
                List<Activity> activities = activity_db.Db_Get_All_Activities();
                return activities;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                List<Activity> activities = new List<Activity>();
                Activity a = new Activity();
                a.Type = "Errors Checken";
                a.ActivityId = 404;
                a.BeginTime = DateTime.ParseExact("11/11/2011 11:11", "dd/MM/yyyy HH:mm", null);
                a.EndTime = DateTime.ParseExact("22/12/2022 22:22", "dd/MM/yyyy HH:mm", null);
                activities.Add(a);

                return activities;
            }
        }
    }
}
