using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOAtelier
    {
        #region Attribue 
        private List <Atelier> listAteliers = new List< Atelier >();
        #endregion

        #region Méthodes  


        // méthode qui génére la liste de tous les ateliers.
        public List<Atelier> tousLesAteliers()
        {
            // on  veut recuperai la liste de tous les participants et les rangers dans leurs Class : 
            // Soit Participant || Soit Benevoles 
            List<Atelier> laListe = new List<Atelier>();

            /**//*

            String req = "select * from participants Pt " +
                "left join participer Pr on Pr.id = Pt.id " +
                "left join atelier Ar on Ar.id = Pr.id " +
                "left join intervenir Ir on  Pt.id = Ir.id " +
                "left join intervention I on Ir.email = I.email " +
                "left join participants on Pt.id = Ar.id_participants " +
                "order by Pt.id;"; 
            */
            String req = "select * from atelier Ar " +
                "left join participants Pt on Pt.id = Ar.id_participants " +
                "left join participer Pr on Ar.id = Pr.id_atelier " +
                "left join participants Ps on Pr.id = Ps.id " +
                "left join intervenir Ir on Pt.id = Ir.id " +
                "left join intervention I on Ir.email = I.email " +
                "order by Ar.id;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);

            int next = -1; // va servir a savoir si on change d'inscript 


            while (reader.Read()) // pour chaque ligne on associe 1 inscript a un atelier et son intervenant
            {

                // permets d'avoir les informations sur l'atelier 
                int idAtelier = 0;
                String nomA = " null ";
                int capa = 0;
                if (reader[0].ToString().Length > 0 &&
                    reader[1].ToString().Length > 0 &&
                    reader[2].ToString().Length > 0)
                {
                    idAtelier = int.Parse(reader[0].ToString());
                    nomA = reader[1].ToString();
                    capa = int.Parse(reader[2].ToString());
                }

                // sert pour avoir les informations sur l'intervenant de l'atelier 
                int idI = 0;
                String nomI = " null ";
                String prenomI = " null ";
                String adresseI = " null ";
                String portableI = " null ";
                String typeI = " null ";
                int nbParticipationI = 0;

                if (reader[4].ToString().Length > 0 &&
                    reader[5].ToString().Length > 0 &&
                    reader[6].ToString().Length > 0 &&
                    reader[7].ToString().Length > 0 &&
                    reader[8].ToString().Length > 0 &&
                    reader[9].ToString().Length > 0 &&
                    reader[10].ToString().Length > 0)
                {

                    idI = int.Parse(reader[4].ToString());
                    nomI = reader[5].ToString();
                    prenomI = reader[6].ToString();
                    adresseI = reader[7].ToString();
                    portableI = reader[8].ToString();
                    typeI = reader[9].ToString();
                    nbParticipationI = int.Parse(reader[10].ToString());
                }

                // Permets d'avoir les informations de l'inscript 
                int idP = 0 ;
                String nomP = "";
                String prenomP = "";
                String adresseP = "";
                String portableP = "";
                String typeP = "";
                // int nbParticipation = 0;

                if(reader[12].ToString().Length > 0 &&
                   reader[13].ToString().Length > 0 &&
                   reader[14].ToString().Length > 0 &&
                   reader[15].ToString().Length > 0 &&
                   reader[16].ToString().Length > 0 &&
                   reader[17].ToString().Length > 0 &&
                   reader[18].ToString().Length > 0)
                {
                                    
                     idP = int.Parse(reader[13].ToString());
                     nomP = reader[14].ToString();
                     prenomP = reader[15].ToString();
                     adresseP = reader[16].ToString();
                     portableP = reader[17].ToString();
                     typeP = reader[18].ToString();
                    // nbParticipation = int.Parse(reader[18].ToString());
                }

                // sert si l'inscript est un Benevole 
                String emailB;
                if (reader[20].ToString().Length > 0)
                {
                    emailB = reader[20].ToString();
                } 
                else
                {
                    emailB = "impossible";
                }


                

                // on sait qu'il s'agit d'un intervenant, donc on peu l'initialiser ici
                Participant intervenant = new Participant(idI, nomI, prenomI, adresseI, portableI, typeI);

                // on initialise egalement l'atelier
                Atelier Ar = new Atelier(idAtelier, nomA, capa, intervenant);

                // on verifie qu'on a bien toute les donnee pour cree le Participant
                if (idP.ToString().Length > 0 &&
                    nomP.ToString().Length > 0 &&
                    prenomP.ToString().Length > 0 &&
                    adresseP.ToString().Length > 0 &&
                    portableP.ToString().Length > 0 &&
                    typeP.ToString().Length > 0)
                {

                    // on verifie s'il ne s'agit pas d'un Benevole
                    if (emailB == "impossible")
                    {

                        Participant pt = new Participant(idP, nomP, prenomP, adresseP, portableP, typeP);

                        Ar.ajouterParticipant(pt);
                    }
                    else // sinon il s'agit d'un Benevole
                    {

                        Benevoles bs = new Benevoles(idP,
                            nomP,
                            prenomP,
                            adresseP,
                            portableP,
                            typeP,
                            emailB);

                        Ar.ajouterParticipant(bs);
                    }
                }
                if (next != Ar.Id)
                {
                    next = Ar.Id;

                    laListe.Add(Ar);
                }
                else
                {
                    // il ne se passe rien 
                }


            } /**/
            return laListe;
        } // fin tousLesAteliers()

        // permets de définir la liste de participant a un atelier 
        public void dbParticipantunAtelier( Atelier unAtelier )
        {
            Participant unP = new Participant();
            List<Participant> listParticipents = unP.allParticipant();

            int idA = unAtelier.Id;  
            String req = "Select Pt.id " +
                      "From participer Pr " +
                      "inner join participants Pt Pt.id on Pr.id " +
                      "inner join atelier A A.id on Pr.id_atelier " +
                      "where A.id =" + idA + " order by Pt.id ;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                int index = int.Parse(reader[0].ToString());
                unP = listParticipents.ElementAt(index);
                unAtelier.ajouterParticipant(unP);
            }

        }

        #endregion
    }

        

}
