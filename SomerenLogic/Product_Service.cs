using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Product_Service : Base_Service
    {
        private Product_DAO product_db = new Product_DAO();

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
                Product a = new Product(100, true, "Test Product", 9.95, 25, 404);
                products.Add(a);

                return products;
            }
        }

        public List<Product> GetStock()
        {
            // Tim Roffelsen
            try
            {
                List<Product> products = product_db.Db_Get_All_Stock();
                return products;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
                List<Product> products = new List<Product>();
                Product a = new Product(100, true, "Test Product", 9.95, 25, 404);
                products.Add(a);

                return products;
            }
        }

        public void Add_Product(Product product)
        {
            // Tim Roffelsen
            try
            {
                product_db.Add_Product(product);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            }
        }

        public void Change_Product(Product product)
        {
            // Tim Roffelsen
            try
            {
                product_db.Change_Product(product);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                // something went wrong connecting to the database, so we will add a fake student to the list to make sure the rest of the application continues working!
            }
        }

        public void Delete_Product(Product product)
        {
            // Tim Roffelsen
            try
            {
                product_db.Delete_Product(product);
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