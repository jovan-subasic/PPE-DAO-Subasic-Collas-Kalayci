using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOStand
    {
        public void AjouterStand(Stand unStand, Equipement unEquipement)
        {
            String req = "INSERT INTO stands values ( '"
                         + unStand.IdAllee + "' , '"
                         + unStand.IdOrdre + "' , '"
                         + unEquipement.Id + "' , '"
                         + unStand.MontantFacture + "' , '"
                         + unStand.Nom + "' , '"
                         + unStand.Id_partenaires + "' );";

            DAOFactory daoAddStand = new DAOFactory();
            daoAddStand.connecter();
            daoAddStand.excecSQLRead(req);
        }

    }
}
