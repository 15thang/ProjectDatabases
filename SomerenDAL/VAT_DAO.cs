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
    public class VAT : Base
    {
        // Thomas Eddyson
        public List<Vat> Db_Get_All_Rooms()
        {
            string query = "SELECT Bestelling.Datum, Bestelling_Product.Aantal, Product.Prijs, Product.isAlcohol FROM Bestelling JOIN Bestelling_Product ON Bestelling.BestellingID = Bestelling_Product.BestellingID JOIN Product ON Bestelling_Product.ProductID = Product.ProductID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Vat> ReadTables(DataTable dataTable)
        {
            List<Vat> Vats = new List<Vat>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }            

            foreach (DataRow dr in dataTable.Rows)
            {

                Vat Result = new Vat();
                int Amount;

                Amount = (int)dr["Aantal"];

                // Determines if the price is either taxed by 21% or 6%.
                if ((bool)dr["isAlcohol"] == true)
                {                    
                    Result.VATTwntyOnePrcnt += (int)dr["Prijs"] * Amount;
                }
                else
                {
                    Result.VATSixPrcnt += (int)dr["Prijs"] * Amount;
                }

                Vat vat = new Vat()
                {
                    VATSixPrcnt = Result.VATSixPrcnt,
                    VATTwntyOnePrcnt = Result.VATTwntyOnePrcnt,
                    TotalVAT = Result.VATSixPrcnt + Result.VATTwntyOnePrcnt
                };
                Vats.Add(vat);
            }
            return Vats;
        }

    }
}
