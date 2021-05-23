using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOPartenaire
    {
        private List<TypePartenaire> lesIdTypesPartenaires = new List<TypePartenaire>();

        public void AjouterPartenaire(Partenaire unPartenaire)
        {
            String req = "INSERT INTO partenaires values ( '"
                         + unPartenaire.Nom + "' , '"
                         + unPartenaire.TypePartenaire + "' );";

            DAOFactory daoAddPartenaire = new DAOFactory();
            daoAddPartenaire.connecter();
            daoAddPartenaire.excecSQLRead(req);
        }

        public List<TypePartenaire> listeTypePartenaire()
        {
            List<TypePartenaire> lesTypesPartenaires = new List<TypePartenaire>();

            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select * from typePartenaire;";
            SqlDataReader reader = db.excecSQLRead(req);

            

            while (reader.Read()) 
            {
                TypePartenaire TP = new TypePartenaire(

                id:int.Parse(reader[0].ToString()),
                nom:reader[1].ToString());

                lesTypesPartenaires.Add(TP);


            }

            return lesTypesPartenaires;
        }

        public int getIdTypePartenaire(string type)
        {

            DAOPartenaire dp = new DAOPartenaire();
            lesIdTypesPartenaires = dp.listeTypePartenaire();

            foreach (var nomtypePartenaire in lesIdTypesPartenaires)
            {
                if(nomtypePartenaire.Nom == type)
                {
                    return nomtypePartenaire.Id;
                }
            }

            return 0;
        }

    }
}
