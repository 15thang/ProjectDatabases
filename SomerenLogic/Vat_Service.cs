using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class Vat_Service : Base_Service
    {
        // Thomas Eddyson
        private Vat_DAO vat_db = new Vat_DAO();

        public List<Vat> GetVats()
        {
            try
            {
                List<Vat> vat = vat_db.Db_Get_All_Vats();
                return vat;
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
                //throw new Exception(e.Message);
                // something went wrong connecting to the database, so we will add a fake room to the list to make sure the rest of the application continues working!
                List<Vat> vat = new List<Vat>();
                Vat a = new Vat();
                a.VATSixPrcnt = 404;
                a.VATTwntyOnePrcnt = 404;
                vat.Add(a);

                return vat;
            }
        }

        public void SetQuaterString(string quarter)
        {
            try
            {
                vat_db.SetQuaterString(quarter);
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
                Error = true;
            }
        }
    }
}