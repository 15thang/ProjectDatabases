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
    public class RoomLayout_Service
    {
        RoomLayout_DAO room_db = new RoomLayout_DAO();

        public List<RoomLayout> GetRoomLayout()
        {
            try
            {
                List<RoomLayout> roomLayout = room_db.Db_Get_All_RoomLayout();
                return roomLayout;
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<RoomLayout> roomLayout = new List<RoomLayout>();
                RoomLayout a = new RoomLayout();
                a.Number = 0;
                a.FirstName = "Jan";
                a.LastName = "Jansen";
                roomLayout.Add(a);

                return roomLayout;

            }

        }
    }
}
