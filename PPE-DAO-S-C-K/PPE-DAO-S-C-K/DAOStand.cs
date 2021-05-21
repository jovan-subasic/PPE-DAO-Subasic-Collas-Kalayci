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
                         + unStand.Nom + "' , '"
                         + unStand.Prenom + "' , '"
                         + unStand.Adresse + "' , '"
                         + unStand.Portable + "' , '"
                         + unStand.Type + "' , '"
                         + unStand.NbParticipant + "' );";

            DAOFactory daoAddStand = new DAOFactory();
            daoAddStand.connecter();
            daoAddStand.excecSQLRead(req);
        }
    }
}