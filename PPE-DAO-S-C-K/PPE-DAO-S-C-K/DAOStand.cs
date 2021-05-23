using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOStand
    {
        public void AjouterStand(Stands unStand)
        {
            String req = "INSERT INTO stands values ( '"
                         + unStand.IdAllee + "' , '"
                         + unStand.IdOrdre + "' , '"
                         + unStand.Equipement + "' , '"
                         + unStand.MontantFacture + "' , '"
                         + unStand.Prix + "' , '"
                         + unStand.Nom + "' , '"
                         + unStand.Id_partenaires + "' );";

            DAOFactory daoAddStand = new DAOFactory();
            daoAddStand.connecter();
            daoAddStand.excecSQLRead(req);
        }

        public void AjouterEquipement(Equipements unEquipement)
        {
            String req = "INSERT INTO equipements values ( '"
                         + unEquipement.connexionReseauFilaire + "' , '"
                         + unEquipement.bar + "' , '"
                         + unEquipement.salonReception + "' , '"
                         + unEquipement.cabineEssayage + "' , '"
                         + unEquipement.tablesFournis + "' , '"
                         + unEquipement.nbrSiege + "' );";

            DAOFactory daoAddEquipement = new DAOFactory();
            daoAddEquipement.connecter();
            daoAddEquipement.excecSQLRead(req);
        }

        public void typePartenaire()
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select nom from typePartenaire;";
            SqlDataReader reader = db.excecSQLRead(req);

            reader.Read();
        }
    }
}