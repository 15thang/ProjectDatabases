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
    public class Order_DAO : Base
    {
        // Ruben Stoop
        public void Insert_Order(Order order)
        {
            //Datetime to a format sql can understand
            string sqlDate = order.OrderDate.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "INSERT INTO Bestelling (Datum, BarID, StudentID) VALUES(@date, @barid, @studentid);";

            //Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[3];

            sqlParameters[0] = new SqlParameter("@date", sqlDate);
            sqlParameters[1] = new SqlParameter("@barid", order.BarID);
            sqlParameters[2] = new SqlParameter("@studentid", order.StudentID);
            ExecuteEditQuery(query, sqlParameters);
        }

        // Ruben Stoop
        // Gets the highest id of the table Bestelling
        public int Get_Highest_ID()
        {
            string query = "SELECT MAX(BestellingID) as BestellingID FROM Bestelling;";
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
    }
}
