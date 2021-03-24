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

            string QMonth = Quarter;

            double isAlcDrink = 0;
            double isNotAlcDrink = 0;
            double total;

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

            foreach (DataRow dr in dataTable.Rows)
            {
                double Price = double.Parse(dr["Prijs"].ToString());
                double amount = double.Parse(dr["Aantal"].ToString());
                DateTime date = (DateTime)dr["Datum"];
                DateTime dateNow = DateTime.Now;

                //Checks which quarter months of the same year needs to be calculated
                if (QMonth == "Q1")
                {
                    if (date.Month >= 1 && date.Month <= 3 && date.Year == dateNow.Year)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            isAlcDrink = (Price * amount) + isAlcDrink;
                        }
                        else
                        {
                            isNotAlcDrink = (Price * amount) + isNotAlcDrink;
                        }
                    }
                }
                else if (QMonth == "Q2")
                {
                    if (date.Month >= 4 && date.Month <= 6 && date.Year == dateNow.Year)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            isAlcDrink = (Price * amount) + isAlcDrink;
                        }
                        else
                        {
                            isNotAlcDrink = (Price * amount) + isNotAlcDrink;
                        }
                    }
                }
                else if (QMonth == "Q3")
                {
                    if (date.Month >= 7 && date.Month <= 9 && date.Year == dateNow.Year)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            isAlcDrink = (Price * amount) + isAlcDrink;
                        }
                        else
                        {
                            isNotAlcDrink = (Price * amount) + isNotAlcDrink;
                        }
                    }
                }
                else if (QMonth == "Q4")
                {
                    if (date.Month >= 10 && date.Month <= 12 && date.Year == dateNow.Year)
                    {
                        if ((bool)dr["isAlcohol"] == true)
                        {
                            isAlcDrink = (Price * amount) + isAlcDrink;
                        }
                        else
                        {
                            isNotAlcDrink = (Price * amount) + isNotAlcDrink;
                        }
                    }
                }                

                Vat vat = new Vat()
                {
                    VATTwntyOnePrcnt = isAlcDrink * taxTwntyOnePrcnt,
                    VATSixPrcnt = isNotAlcDrink * taxSixPrcnt,
                    TotalVAT = (isNotAlcDrink * taxSixPrcnt) + (isAlcDrink * taxTwntyOnePrcnt)
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
