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
                // hacking way. Not Good.
                if ((bool)dr["isDocentenKamer"] == true)
                {
                    roomType = "docent";
                }
                else
                {
                    roomType = "Student";
                }

                Room room = new Room()
                {
                    Number = (int)dr["KamerID"],
                    Type = roomType,
                    Capacity = (int)dr["KamerType"]
                };
                Rooms.Add(room);
            }
            return Rooms;
        }

    }
}
