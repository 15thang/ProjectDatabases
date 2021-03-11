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
    public class Room_Service
    {
        Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception e)
            {
                // throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<Room> room = new List<Room>();
                Room a = new Room();
                a.Number = 0;
                a.Capacity = 404;
                a.Type = false;
                a.RoomType = "Teacher";
                room.Add(a);

                return room;

            }

        }
    }
}
