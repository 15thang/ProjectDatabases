using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class Product_DAO : Base
    {
        // Ruben Stoop
        // Opdracht B
        // Data gets pulled from the database by the query from the 'Product' table
        public List<Product> Db_Get_All_Products()
        {
            string query = "USE prjdb4 SELECT DISTINCT P.ProductID, [ProductNaam], [isAlcohol], [Prijs], [Voorraad], SUM(CASE WHEN B.ProductID = P.ProductID THEN B.Aantal ELSE 0 END) AS 'Verkocht' FROM Product AS P, Bestelling_Product AS B GROUP BY P.ProductID, [ProductNaam], [isAlcohol], [ProductNaam], [Prijs], [Voorraad]; ";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Tim Roffelsen
        // Data gets pulled from the database and ordered by Stock, then Price, then Amount sold
        public List<Product> Db_Get_All_Stock()
        {
            string query = "USE prjdb4 SELECT DISTINCT P.ProductID, [ProductNaam], [isAlcohol], [Prijs], [Voorraad], SUM(CASE WHEN B.ProductID = P.ProductID THEN B.Aantal ELSE 0 END) AS 'Verkocht' FROM Product AS P, Bestelling_Product AS B WHERE[Voorraad] > 1 GROUP BY P.ProductID, [ProductNaam], [isAlcohol], [ProductNaam], [Prijs], [Voorraad] ORDER BY[Voorraad] DESC, Prijs ASC, Verkocht DESC; ";
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

        // Ruben Stoop
        // Opdracht B
        public void Update_Stock(Order_Product order_Product)
        {
            string query = "UPDATE Product SET Product.Voorraad = CASE WHEN Product.ProductID != 1 THEN Product.Voorraad - @amount ELSE Product.Voorraad - 0 END WHERE Product.ProductID = @productid; ";
            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@amount", order_Product.Amount);
            sqlParameters[1] = new SqlParameter("@productid", order_Product.ProductID);

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Add_Product(Product product)
        {
            // Tim Roffelsen
            // Data gets written to database, primary key is automatically made
            string query = "USE prjdb4 INSERT INTO Product (isAlcohol, ProductNaam, Prijs, Voorraad) VALUES(@isalcohol, @productname, @price, @stock); ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[4];

            sqlParameters[0] = new SqlParameter("@isalcohol", Convert.ToInt32(product.IsAlcohol));
            sqlParameters[1] = new SqlParameter("@productname", product.ProductName);
            sqlParameters[2] = new SqlParameter("@price", product.Price);
            sqlParameters[3] = new SqlParameter("@stock", product.Stock);

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Change_Product(Product product)
        {
            // Tim Roffelsen
            // Data gets changed in database
            string query = "USE prjdb4 UPDATE Product SET ProductNaam = @productname, Prijs = @price, Voorraad = @stock, isAlcohol = @isalcohol  WHERE ProductID = @productid; ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[5];

            sqlParameters[0] = new SqlParameter("@isalcohol", Convert.ToInt32(product.IsAlcohol));
            sqlParameters[1] = new SqlParameter("@productname", product.ProductName);
            sqlParameters[2] = new SqlParameter("@price", product.Price);
            sqlParameters[3] = new SqlParameter("@stock", product.Stock);
            sqlParameters[4] = new SqlParameter("@productid", product.ProductID);

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Delete_Product(Product product)
        {
            // Tim Roffelsen
            // Data gets changed in database
            string query = "USE prjdb4 DELETE FROM Product WHERE ProductID = @productid; ";

            // Setting the parameters from the parameter order
            SqlParameter[] sqlParameters = new SqlParameter[1];

            sqlParameters[0] = new SqlParameter("@productid", product.ProductID);

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}