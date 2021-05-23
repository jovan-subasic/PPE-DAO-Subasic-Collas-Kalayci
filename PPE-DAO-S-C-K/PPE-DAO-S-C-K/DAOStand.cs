using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOStand
    {
        public void AjouterStand(Stand unStand )
        {
            String req = "INSERT INTO stands values ( '"
                         + unStand.IdAllee + "' , '"
                         + unStand.IdOrdre + "' , '"
                         + unStand.Equipement + "' , '"
                         + unStand.MontantFacture + "' , '"
                         + unStand.Nom + "' , '"
                         + unStand.Id_partenaires + "' );";

            DAOFactory daoAddStand = new DAOFactory();
            daoAddStand.connecter();
            daoAddStand.excecSQLRead(req);
        }

        public int bddUpdateID()
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req1 = "select max(id) from equipements;";
            SqlDataReader reader1 = db.excecSQLRead(req1);

            reader1.Read();

            int idMax = int.Parse(reader1[0].ToString());

            return idMax;
        }
    }
}
