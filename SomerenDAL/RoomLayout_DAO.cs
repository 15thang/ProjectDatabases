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
    public class RoomLayout_DAO : Base
    {
        public List<RoomLayout> Db_Get_All_RoomLayout()
        {
            string query = "SELECT Persoon.Voornaam, Persoon.Achternaam, Persoon.KamerID, Kamer.KamerID FROM[Persoon] INNER JOIN[Kamer] ON Persoon.KamerID = Kamer.KamerID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<RoomLayout> ReadTables(DataTable dataTable)
        {
            List<RoomLayout> RoomLayout = new List<RoomLayout>();

            foreach (DataRow dr in dataTable.Rows)
            {
                RoomLayout roomlayout = new RoomLayout()
                {
                    Number = (int)dr["KamerID"],
                    FirstName = (String)dr["Voornaam"],
                    LastName = (String)dr["Achternaam"]
                };
                RoomLayout.Add(roomlayout);
            }
            return RoomLayout;
        }
    }
}
