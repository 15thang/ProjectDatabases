using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class WeekRoster_Service : Base_Service
    {
        // Thomas Eddyson
        private WeekRoster_DAO activityRoster_db = new WeekRoster_DAO();

        public List<WeekRoster> GetWeekRosters()
        {
            try
            {
                List<WeekRoster> roster = activityRoster_db.Db_Get_All_WeekRoster();
                return roster;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<WeekRoster> rosters = new List<WeekRoster>();
                WeekRoster a = new WeekRoster();
                a.DayOfWeek = 1;
                a.FirstName = "Bob";
                a.LastName = "Ross";
                a.ActivityName = "Happy Painting";
                a.BeginTime = new DateTime(2020, 12, 12, 12, 12, 12);
                a.EndTime = new DateTime(2020, 12, 12, 12, 12, 12);
                rosters.Add(a);

                return rosters;
            }
        }
    }
}