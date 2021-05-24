using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOPartenaire
    {
        private List<TypePartenaire> lesIdTypesPartenaires = new List<TypePartenaire>();
        private List<Partenaire> lesIdPartenaires = new List<Partenaire>();


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

        public List<Partenaire> listePartenaire()
        {
            List<Partenaire> lesPartenaires = new List<Partenaire>();

            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select * from partenaires;";
            SqlDataReader reader = db.excecSQLRead(req);



            while (reader.Read())
            {
                Partenaire P = new Partenaire(

                id: int.Parse(reader[0].ToString()),
                nom: reader[1].ToString(),
                typePartenaire: int.Parse(reader[0].ToString()));

                lesPartenaires.Add(P);


            }

            return lesPartenaires;
        }

        public int getIdTypePartenaire(string type)
        {

            lesIdTypesPartenaires = listeTypePartenaire();

            foreach (var nomtypePartenaire in lesIdTypesPartenaires)
            {
                if(nomtypePartenaire.Nom == type)
                {
                    return nomtypePartenaire.Id;
                }
            }

            return 0;
        }


        public int getIdPartenaire(string type)
        {

            lesIdPartenaires = listePartenaire();

            foreach (var nomPartenaire in lesIdPartenaires)
            {
                if (nomPartenaire.Nom == type)
                {
                    return nomPartenaire.Id;
                }
            }

            return 0;
        }

        public String getNomTypePartenaire(string nom)
        {

            lesIdPartenaires = listePartenaire();
            String nomTypePartenaire;

            foreach (var nomPartenaire in lesIdPartenaires)
            {
                if (nomPartenaire.Nom == nom)
                {
                    int IdTypePartenaires = nomPartenaire.TypePartenaire;

                    if(IdTypePartenaires == 1)
                    {
                        nomTypePartenaire = "equipementier";
                    }
                    else
                    {
                        nomTypePartenaire = "club";
                    }
                }
            }
            return nomTypePartenaire;

        }

    }
}
