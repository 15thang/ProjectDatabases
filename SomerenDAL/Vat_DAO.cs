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

        private string Quarter;

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
            List<double> ResultTaxTwntyOne = new List<double>();
            List<double> ResultTaxSix = new List<double>();
            List<double> ResultTotal = new List<double>();

            string QMonth = Quarter;

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                double Price = double.Parse(dr["Prijs"].ToString());
                DateTime date = (DateTime)dr["Datum"];

                //Checks which quarter months needs to be calculated
                if (QMonth == "Q1")
                {
                    if (date.Month >= 1 && date.Month <= 3)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            ResultTaxTwntyOne.Add(Price);
                        }
                        else
                        {
                            ResultTaxSix.Add(Price);
                        }
                    }
                }
                else if (QMonth == "Q2")
                {
                    if (date.Month >= 4 && date.Month <= 6)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            ResultTaxTwntyOne.Add(Price);
                        }
                        else
                        {
                            ResultTaxSix.Add(Price);
                        }
                    }
                }
                else if (QMonth == "Q3")
                {
                    if (date.Month >= 7 && date.Month <= 9)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            ResultTaxTwntyOne.Add(Price);
                        }
                        else
                        {
                            ResultTaxSix.Add(Price);
                        }
                    }
                }
                else if (QMonth == "Q4")
                {
                    if (date.Month >= 10 && date.Month <= 12)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            ResultTaxTwntyOne.Add(Price);
                        }
                        else
                        {
                            ResultTaxSix.Add(Price);
                        }
                    }
                }

                Vat vat = new Vat()
                {
                    VATTwntyOnePrcnt = ResultTaxTwntyOne.Sum() * taxTwntyOnePrcnt,
                    VATSixPrcnt = ResultTaxSix.Sum() * taxSixPrcnt,
                    TotalVAT = ResultTotal.Sum()
                };
                Vats.Add(vat);
            }
            return Vats;
        }

        //Sets the quarter
        public void SetQuaterString(string quarter)
        {
            Quarter = quarter;
        }
    }
}
