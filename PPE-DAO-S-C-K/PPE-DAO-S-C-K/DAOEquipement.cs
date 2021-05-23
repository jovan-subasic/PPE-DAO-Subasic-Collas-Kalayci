using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOEquipement
    {
        public void AjouterEquipement(Equipement unEquipement)
        {
            String req = "INSERT INTO equipements values ( '"
                         + unEquipement.ConnexionReseauFilaire + "' , '"
                         + unEquipement.Bar + "' , '"
                         + unEquipement.SalonReception + "' , '"
                         + unEquipement.CabineEssayage + "' , '"
                         + unEquipement.NbrSiege + "' , '"
                         + unEquipement.TablesFournis + "' );";

            DAOFactory daoAddEquipement = new DAOFactory();
            daoAddEquipement.connecter();
            daoAddEquipement.excecSQLRead(req);
        }
    }
}
