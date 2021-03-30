using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Order_DAO : Base
    {
        // Ruben Stoop
        // Opdracht B Week 4
        public void Insert_Order(Order order, List<Order_Product> order_Product)
        {
            //Datetime to a format sql can understand
            string sqlDate = order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "USE prjdb4 INSERT INTO Bestelling (Datum, BarID, StudentID) VALUES(@date, @barid, @studentid);";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@date", sqlDate);
            sqlParameters[1] = new SqlParameter("@barid", order.BarID);
            sqlParameters[2] = new SqlParameter("@studentid", order.StudentID);
            ExecuteEditQuery(query, sqlParameters);

            //Ruben Stoop
            //Fills the Order_Product Table
            Order_Product_DAO order_product_dao = new Order_Product_DAO();
            int recentOrder = GetLatest();
            foreach (Order_Product op in order_Product)
            {
                op.OrderID = recentOrder;
                order_product_dao.Insert_Order_Product(op);
            }
        }

        // Ruben Stoop
        // Gets the highest id of the table Bestelling
        public int Get_Highest_ID()
        {
            string query = "USE prjdb4 SELECT MAX(BestellingID) as BestellingID FROM Bestelling;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadInt(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Reads the datatable and returns the BestellingID
        private int ReadInt(DataTable dataTable)
        {
            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            DataRow dr = dataTable.Rows[0];
            return (int)dr["BestellingID"];
        }

        // Ruben Stoop
        // Gets Latest Order for Order_Product
        private int GetLatest()
        {
            string query = "USE prjdb4 SELECT TOP 1 BestellingID, [Datum] FROM Bestelling ORDER BY [Datum] DESC";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadInt(ExecuteSelectQuery(query, sqlParameters));
        }
    }
}