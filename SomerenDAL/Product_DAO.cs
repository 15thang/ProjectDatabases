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
    public class Product_DAO : Base
    {

        // Ruben Stoop
        // Opdracht B
        // Data gets pulled from the database by the query from the 'Product' table
        public List<Product> Db_Get_All_Products()
        {
            string query = "SELECT [ProductID], [isAlcohol], [ProductNaam], [Prijs], [Voorraad] FROM Product;";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Product> Db_Get_All_Stock()
        {
            string query = "SELECT [ProductID], [isAlcohol], [ProductNaam], [Prijs], [Voorraad] FROM Product WHERE Voorraad > 1 ORDER BY Voorraad DESC, Prijs ASC;";

            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Ruben Stoop
        // Opdracht B
        // The returned data gets saved in a list
        private List<Product> ReadTables(DataTable dataTable)
        {
            List<Product> products = new List<Product>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                Product product = new Product(
                    (int)dr["ProductID"],
                    (bool)dr["isAlcohol"],
                    (String)dr["ProductNaam"],
                    (double)dr["Prijs"],
                    (int)dr["Voorraad"])
                {
                };

                products.Add(product);
            }
            return products;
        }
    }
}
