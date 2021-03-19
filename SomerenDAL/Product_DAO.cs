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
            string query = "SELECT DISTINCT P.ProductID, [ProductNaam], [isAlcohol], [Prijs], [Voorraad], SUM(CASE WHEN B.ProductID = P.ProductID THEN B.Aantal ELSE 0 END) AS 'Verkocht' FROM Product AS P, Bestelling_Product AS B GROUP BY P.ProductID, [ProductNaam], [isAlcohol], [ProductNaam], [Prijs], [Voorraad]; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        // Tim Roffelsen
        // Data gets pulled from the database and ordered by Stock, then Price, then Amount sold
        public List<Product> Db_Get_All_Stock()
        {
            string query = "SELECT DISTINCT P.ProductID, [ProductNaam], [isAlcohol], [Prijs], [Voorraad], SUM(CASE WHEN B.ProductID = P.ProductID THEN B.Aantal ELSE 0 END) AS 'Verkocht' FROM Product AS P, Bestelling_Product AS B WHERE[Voorraad] > 1 GROUP BY P.ProductID, [ProductNaam], [isAlcohol], [ProductNaam], [Prijs], [Voorraad] ORDER BY[Voorraad] DESC, Prijs ASC, Verkocht DESC; ";
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
                Product product = new Product
                    (
                    (int)dr["ProductID"],
                    (bool)dr["isAlcohol"],
                    (String)dr["ProductNaam"],
                    (double)dr["Prijs"],
                    (int)dr["Voorraad"],
                    (int)dr["Verkocht"]
                    );

                products.Add(product);
            }
            return products;
        }
        // Tim Roffelsen
        public void Add_Product(Product product)
        {
            string query = "INSERT INTO Product (isAlcohol, ProductNaam, Prijs, Voorraad) VALUES(@isalcohol, @productname, @price, @stock)";

            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@isalcohol", Convert.ToInt32(product.IsAlcohol));
            sqlParameters[1] = new SqlParameter("@productname", product.ProductName);
            sqlParameters[2] = new SqlParameter("@price", product.Price);
            sqlParameters[3] = new SqlParameter("@stock", product.ProductID);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
