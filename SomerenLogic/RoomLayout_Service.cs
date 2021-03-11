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
        RoomLayout_DAO roomLayout_db = new RoomLayout_DAO();

        public List<RoomLayout> GetRoomLayout()
        {
            try
            {
                List<RoomLayout> roomLayout = roomLayout_db.Db_Get_All_RoomLayout();
                return roomLayout;
            }
            catch (Exception e)
            {
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<RoomLayout> roomLayout = new List<RoomLayout>();
                RoomLayout o = new RoomLayout();
                o.Number = 0;
                o.FirstName = "Jan";
                o.LastName = "Jansen";
                roomLayout.Add(o);

                return roomLayout;

            }

        }
    }
}
