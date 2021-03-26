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
    public class Teacher_Service : Base_Service
    {
        Teacher_DAO teacher_db = new Teacher_DAO();

        // Tim Roffelsen
        // The logic layer fetches the list with teachers, if something goes wrong a test teacher is made
        public List<Teacher> GetTeachers()
        {
            try
            {
                List<Teacher> teachers = teacher_db.Db_Get_All_Teachers();
                return teachers;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake teacher to the list to make sure the rest of the application continues working!
                List <Teacher> teachers = new List<Teacher>();
                Teacher t = new Teacher();
                t.FirstName = "Mr. Error";
                t.LastName = "Meneer";
                t.TeacherID = 474791;
                t.PersonID = 100;
                teachers.Add(t);
               
                return teachers;
            }
        }

        // Ruben Stoop
        // Opdracht B
        // adds the teacher
        public void Insert_Teacher(Teacher teacher)
        {
            try
            {
                teacher_db.Insert_Teacher(teacher);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            }
        }

        // Ruben Stoop
        // Opdracht B
        // Week 4
        // Deletes the teacher
        public void Delete_Teacher(int TeacherID)
        {
            try
            {
                teacher_db.DeleteTeacher(TeacherID);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            }
        }
    }
}
