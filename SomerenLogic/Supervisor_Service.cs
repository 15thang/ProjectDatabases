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
    public class Supervisor_Service : Base_Service
    {
        Supervisor_DAO supervisor_db = new Supervisor_DAO();

        // Ruben Stoop
        // Opdracht B Week 4
        // Inserts supervisor for activty
        public void Insert_Supervisor(Supervisor supervisor)
        {
            try
            {
                supervisor_db.InsertSupervisor(supervisor);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Retrieves List with the Supervisors for 1 activity
        public List<Supervisor> GetSupervisorsForOneActicity(int ID)
        {
            try
            {
                List<Supervisor> supervisors = supervisor_db.Db_Get_All_Supervisors_For_Activity(ID);
                return supervisors;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                //something went wrong with the query. A fake supervisor is made and returned.
                List<Supervisor> supervisors = new List<Supervisor>();
                Supervisor s = new Supervisor();
                s.ActivityID = -1;
                s.FirstName = "TestVoornaam";
                s.LastName = "TestAchternaam";
                s.TeacherID = -1;
                return supervisors;
            }
        }

        // Ruben Stoop
        // Opdracht B Week 4
        // Retrieves List with a row for each supervisor for a event
        public List<Supervisor> GetSupervisorsWithActivitiesID()
        {
            try
            {
                List<Supervisor> supervisors = supervisor_db.Db_Get_All_Supervisors_With_ActivitiesID();
                return supervisors;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                //something went wrong with the query. A fake supervisor is made and returned.
                List<Supervisor> supervisors = new List<Supervisor>();
                Supervisor s = new Supervisor();
                s.ActivityID = -1;
                s.FirstName = "TestVoornaam";
                s.LastName = "TestAchternaam";
                s.TeacherID = -1;
                return supervisors;
            }
        }

        // Tim Roffelsen
        // The logic layer fetches the list with supervisors, if something goes wrong a test supervisor is made
        public List<Supervisor> GetSupervisors()
        {
            try
            {
                List<Supervisor> supervisors = supervisor_db.Db_Get_All_Supervisors();
                return supervisors;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                //something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                List<Supervisor> supervisors = new List<Supervisor>();
                Supervisor s = new Supervisor();
                s.ActivityID = -1;
                s.TeacherID = -1; 
                return supervisors;
            }
        }
        // Tim Roffelsen
        // Searches for activities supervised by the teacher with given teacherID
        public string FindType(int tId, List<Activity> activities, List<Supervisor> supervisors)
        {
            string activitiesString = "";
            List<Supervisor> sups = new List<Supervisor>();
            List<Activity> acts = new List<Activity>();

            if (supervisors[0].TeacherID == -1) // if adding supervises failed print substitute message
            {
                return "Checking errors in code";
            }
            foreach (Supervisor supervisor in supervisors.FindAll(item => item.TeacherID == tId)) // find all items in supervisors matching teacherId
            {
                sups.Add(supervisor); // add into list sups when found
            }
            foreach (Supervisor supervisor in sups) // run through list sups
            {
                foreach (Activity activity in activities) // run through list activities
                {
                    if (supervisor.ActivityID == activity.ActivityId) // true if activityID matches for both the supervisor and activity
                    {   
                        if (activitiesString != "")
                        {
                            activitiesString += ", "; // add comma after first word, but not after last
                        }
                        activitiesString += activity.Type; // add to string
                    }
                }
            }
            return activitiesString; // return string with all activities
        }
    }
}
