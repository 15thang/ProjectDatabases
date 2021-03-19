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
            sqlParameters[2] = new SqlParameter("@aantal", 1);
            ExecuteEditQuery(query, sqlParameters);
        }

    }
}
