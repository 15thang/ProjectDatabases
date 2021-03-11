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
    public class Room_DAO : Base
    {
        string roomType;

        public List<Room> Db_Get_All_Rooms()
        {            
            string query = "SELECT Kamer.KamerID, Kamer.isDocentenKamer, kamer.KamerType FROM Kamer";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> Rooms = new List<Room>();            

            foreach (DataRow dr in dataTable.Rows)
            {
                Room roomType = new Room();
                // Determins if the roomtype is either for students or teachers
                if ((bool)dr["isDocentenKamer"] == true)
                {
                    roomType.RoomType = "Teacher";
                }
                else
                {
                    roomType.RoomType = "Student";
                }

                Room room = new Room()
                {
                    Number = (int)dr["KamerID"],
                    Capacity = (int)dr["KamerType"],
                    RoomType = roomType.RoomType
                };
                Rooms.Add(room);
            }
            return Rooms;
        }

    }
}
