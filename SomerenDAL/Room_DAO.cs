using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Room_DAO : Base
    {
        // Thomas Eddyson
        public List<Room> Db_Get_All_Rooms()
        {
            string query = "USE prjdb4 SELECT Kamer.KamerID, Kamer.isDocentenKamer, kamer.KamerGrootte FROM Kamer";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> Rooms = new List<Room>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

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
                    Capacity = (int)dr["KamerGrootte"],
                    RoomType = roomType.RoomType
                };
                Rooms.Add(room);
            }
            return Rooms;
        }
    }
}