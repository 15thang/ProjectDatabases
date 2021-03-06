﻿using SomerenModel;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Order_Product_DAO : Base
    {
        // Ruben Stoop opdracht B
        public void Insert_Order_Product(Order_Product order_Product)
        {
            string query = "USE prjdb4 INSERT INTO Bestelling_Product (BestellingID, ProductID, Aantal) VALUES(@orderid, @productid, @aantal);";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@orderid", order_Product.OrderID);
            sqlParameters[1] = new SqlParameter("@productid", order_Product.ProductID);
            sqlParameters[2] = new SqlParameter("@aantal", order_Product.Amount);
            ExecuteEditQuery(query, sqlParameters);

            //Update products stock
            Product_DAO product_dao = new Product_DAO();
            product_dao.Update_Stock(order_Product);
        }
    }
}