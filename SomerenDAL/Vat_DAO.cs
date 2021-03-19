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
    public class Vat_DAO : Base
    {
        const double taxTwntyOnePrcnt = 0.21;
        const double taxSixPrcnt = 0.06;

        // Thomas Eddyson
        public List<Vat> Db_Get_All_Vats()
        {
            string query = "SELECT Bestelling.Datum, Bestelling_Product.Aantal, Product.Prijs, Product.isAlcohol FROM[Bestelling] JOIN [Bestelling_Product] ON Bestelling.BestellingID = Bestelling_Product.BestellingID JOIN[Product] ON Bestelling_Product.ProductID = Product.ProductID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Vat> ReadTables(DataTable dataTable)
        {
            List<Vat> Vats = new List<Vat>();
            List<double> TaxTwentyOne = new List<double>();
            List<double> TaxSix = new List<double>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                double Price = double.Parse(dr["Prijs"].ToString());

                if ((bool)dr["isAlcohol"] == true)
                {
                    TaxTwentyOne.Add(Price);
                }
                else
                {
                    TaxSix.Add(Price);
                }
                double total = (TaxTwentyOne.Sum() * taxTwntyOnePrcnt) + (TaxSix.Sum() * taxSixPrcnt);


                Vat vat = new Vat()
                {
                    VATTwntyOnePrcnt = TaxTwentyOne.Sum() * taxTwntyOnePrcnt,
                    VATSixPrcnt = TaxSix.Sum() * taxSixPrcnt,
                    TotalVAT = total
                };
                Vats.Add(vat);
            }
            return Vats;
        }

    }
}
