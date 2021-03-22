using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOStand
    {
        public List<Stand> tousLesStand()
        {
            List<Stand> laListe = new List<Stand>(); 
            string req;
            req = "Select * From stands order by id ;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);


            while (reader.Read())
            {
                req = "Select * From equipements eq inner join stands st eq.id on st.id where st.id =" + int.Parse(reader[0].ToString()) + " order by st.id ;";
                //db.connecter();
                SqlDataReader readerAt = db.excecSQLRead(req);

                Stand leStand = new Stand(
                                                           int.Parse(reader[0].ToString()),
                                                           reader[1].ToString(),
                                                           reader[2].ToString(),
                                                           reader[3].ToString(),
                                                           reader[4].ToString(),
                                                           reader[5].ToString(),
                                                           reader[6].ToString(),
                                                           reader[7].ToString()
                                                           );
            }
        }
    }
}