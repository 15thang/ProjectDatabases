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
    public class Teacher_Service
    {
        Teacher_DAO teacher_db = new Teacher_DAO();

        // Tim Roffelsen
        // The logic layer fetches the list with students, if something goes wrong a test user is made
        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = teacher_db.Db_Get_All_Teachers();
                return teachers;
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                List <Teacher> teachers = new List<Teacher>();
                Teacher a = new Teacher();
                a.FirstName = "Mr. Test";
                a.LastName = "Teacher";
                a.TeacherID = 474791;
                a.PersonID = 100;
                teachers.Add(a);
               
                return teachers;
                
            }

        }
    }
}
