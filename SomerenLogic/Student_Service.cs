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
    public class Student_Service : Base_Service
    {
        Student_DAO student_db = new Student_DAO();

        // Ruben Stoop
        // The logic layer fetches the list with students, if something goes wrong a test user is made
        public List<Student> GetStudents()
        {
            try
            {
                List<Student> student = student_db.Db_Get_All_Students();
                return student;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List <Student> student = new List<Student>();
                Student a = new Student();
                a.FirstName = "Mr. Test";
                a.LastName = "Student";
                a.StudentID = 474791;
                a.PersonID = 100;
                student.Add(a);
               
                return student;
                
            }

        }
    }
}
