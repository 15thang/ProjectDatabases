﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Order_Service : Base_Service
    {
        private Order_DAO order_db = new Order_DAO();

        // Ruben Stoop
        // Opdracht B
        // This gets the highest id of Bestellingen, return an id of 0 if the table is empty
        public void Insert_Order(Order order, List<Order_Product> order_Products)
        {
            try
            {
                order_db.Insert_Order(order, order_Products);
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
        // This gets the highest id of Bestellingen, return an id of 0 if the table is empty
        public int Get_MaxId()
        {
            try
            {
                int max = order_db.Get_Highest_ID();
                return max;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;

                return 0;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            }
        }
    }
}