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
                         + unStand.Id_partenaires + "' , '"
                         + unStand.Surface + "' );";

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

        public List<Stand> listeStand()
        {
            List<Stand> lesStands = new List<Stand>();

            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select * from stands;";
            SqlDataReader reader = db.excecSQLRead(req);



            while (reader.Read())
            {
                Stand St = new Stand(

                id: int.Parse(reader[0].ToString()),
                idAllee: reader[1].ToString(),
                idOrdre: reader[2].ToString(),
                id_equipement: int.Parse(reader[3].ToString()),
                montantFacture: reader[4].ToString(),
                nom: reader[5].ToString(),
                id_partenaires: int.Parse(reader[6].ToString()),
                surface: reader[7].ToString());


                lesStands.Add(St);


            }

            return lesStands;
        }
    }
}
