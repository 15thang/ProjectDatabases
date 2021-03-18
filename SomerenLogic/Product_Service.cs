﻿using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class Product_Service : Base_Service
    {
        Product_DAO product_db = new Product_DAO();

        // Ruben Stoop
        // Opdracht B
        // The logic layer fetches the list with products, if something goes wrong a test user is made
        public List<Product> GetProducts()
        {
            try
            {
                List<Product> products = product_db.Db_Get_All_Products();
                return products;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Product> products = new List<Product>();
                Product a = new Product(100, true, "Test Product", 9.95, 25);
                products.Add(a);

                return products;
            }

        }
    }
}
