using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class RoomLayout_DAO : Base
    {
        // Thang Nguyen Anh
        // Data gets pulled from the database by the query, INNER JOIN is used to get data from 'Kamer' table

        public List<RoomLayout> Db_Get_All_RoomLayout()
        {
            string query = "USE prjdb4 SELECT Persoon.Voornaam, Persoon.Achternaam, Persoon.KamerID, Kamer.KamerID FROM[Persoon] INNER JOIN[Kamer] ON Persoon.KamerID = Kamer.KamerID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        // Thang Nguyen Anh
        // The returned data gets saved in a list
        private List<RoomLayout> ReadTables(DataTable dataTable)
        {
            List<RoomLayout> RoomLayout = new List<RoomLayout>();

            // Check if datatable is null
            if (dataTable == null)
            {
                throw new Exception("Datatable is null");
            }

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