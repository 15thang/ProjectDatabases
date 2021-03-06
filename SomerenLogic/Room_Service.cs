﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Room_Service : Base_Service
    {
        // Thomas Eddyson
        private Room_DAO room_db = new Room_DAO();

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> room = room_db.Db_Get_All_Rooms();
                return room;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<Room> room = new List<Room>();
                Room a = new Room();
                a.Number = 0;
                a.Capacity = 404;
                a.Type = "Docent";
                room.Add(a);

                return room;
            }
        }
    }
}