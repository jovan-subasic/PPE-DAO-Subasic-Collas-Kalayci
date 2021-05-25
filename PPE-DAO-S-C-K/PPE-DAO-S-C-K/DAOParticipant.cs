using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOParticipant
    {
        #region Méthodes 

        // recupere la liste de tous les participants existant en bdd
        public List<Participant> getAllParticipant()
        {
            // on  veut recuperai la liste de tous les participants et les rangers dans leurs Class : 
            // Soit Participant || Soit Benevoles 
            List<Participant> laListe = new List<Participant>();

            /**/

            String req = "select * from participants Pt " +
                "left join participer Pr on Pr.id = Pt.id " +
                "left join atelier Ar on Ar.id = Pr.id_atelier " +
                "left join intervenir Ir on  Pt.id = Ir.id " +
                "left join intervention I on Ir.email = I.email " +
                "left join participants Ps on Ps.id = Ar.id_participants " +
                "order by Pt.id;"; 
            
            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);

            int next = -1; // va servir a savoir si on change d'inscript 

            int? a = null;
            int b = a ?? -1;

            while (reader.Read()) // pour chaque ligne on associe 1 inscript a un atelier et son intervenant
            {
                // Permets d'avoir les information de l'inscript 
                int idP = int.Parse(reader[0].ToString()) ;
                String nomP = reader[1].ToString() ; 
                String prenomP = reader[2].ToString() ; 
                String adresseP = reader[3].ToString() ; 
                String portableP = reader[4].ToString() ; 
                String typeP = reader[5].ToString() ; 
                int nbParticipation = int.Parse(reader[6].ToString()) ;

                // permets d'avoir les informations sur l'atelier 

                int idAtelier = 0;
                String nomA = "";
                int capa = 0; 
                if (reader[9].ToString().Length > 0 &&
                    reader[10].ToString().Length > 0 &&
                    reader[11].ToString().Length > 0)
                {
                     idAtelier = int.Parse(reader[9].ToString());
                     nomA = reader[10].ToString();
                     capa = int.Parse(reader[11].ToString());
                }


                //int id_Responsable = int.Parse(reader[12].ToString()) ;

                // sert si l'inscript est un Benevole 
                String emailB; 
                if (reader[15].ToString().Length > 0)
                {
                    emailB = reader[15].ToString();
                }
                else
                {
                    emailB = "impossible"; 
                }


                // sert pour avoir les informations sur l'intervenant de l'atelier 

                int idI = 1;
                String nomI = " null "; 
                String prenomI = " null ";
                String adresseI = " null ";
                String portableI = " null ";
                String typeI = " null ";
                int nbParticipationI = 1;

                if (reader[17].ToString().Length > 0 &&
                    reader[18].ToString().Length > 0 &&
                    reader[19].ToString().Length > 0 &&
                    reader[20].ToString().Length > 0 &&
                    reader[21].ToString().Length > 0 &&
                    reader[22].ToString().Length > 0)
                {
              
                    idI = int.Parse(reader[17].ToString());
                    nomI = reader[18].ToString();
                    prenomI = reader[19].ToString();
                    adresseI = reader[20].ToString();
                    portableI = reader[21].ToString();
                    typeI = reader[22].ToString();
                    nbParticipationI = int.Parse(reader[23].ToString());
                }

                // on sait qu'il s'agit d'un intervenant, donc on peu l'initialiser ici
                Participant intervenant = new Participant(idI, nomI, prenomI, adresseI, portableI, typeI);

                // on initialise egalement l'atelier
                Atelier Ar = new Atelier(idAtelier, nomA, capa, intervenant);

                    
                if(typeP != "Benevole")
                {
                    Participant pt;
                    if (next != idP)
                    {
                        next = idP;
                        pt = new Participant(idP, nomP, prenomP, adresseP, portableP, typeP);

                        if(idAtelier.ToString().Length > 0 &&
                            nomA.ToString().Length > 0 &&
                            capa.ToString().Length > 0 &&
                            intervenant.ToString().Length > 0)
                        {

                            pt.ajouterAtelier(Ar); 
                        }

                        laListe.Add(pt);
                    }
                    else
                    {
                        if (idAtelier.ToString().Length > 0 &&
                            nomA.ToString().Length > 0 &&
                            capa.ToString().Length > 0 &&
                            intervenant.ToString().Length > 0)
                        {
                            pt = laListe[laListe.Count()-1];
                            pt.ajouterAtelier(Ar);
                        }
                    }
                }
                else
                {
                    Benevoles bs = new Benevoles(); 
                    if (next != idP)
                    {
                        next = idP;
                            bs = new Benevoles(idP,
                                                    nomP,
                                                    prenomP,
                                                    adresseP,
                                                    portableP,
                                                    typeP,
                                                    emailB);

                        if (idAtelier.ToString().Length > 0 &&
                            nomA.ToString().Length > 0 &&
                            capa.ToString().Length > 0 &&
                            intervenant.ToString().Length > 0)
                        {

                            bs.ajouterAtelier(Ar);
                        }
                        laListe.Add(bs);
                    }
                    else
                    {
                        if (idAtelier.ToString().Length > 0 &&
                            nomA.ToString().Length > 0 &&
                            capa.ToString().Length > 0 &&
                            intervenant.ToString().Length > 0)
                        {
                            Participant pt;
                            pt = laListe[laListe.Count() - 1]; // ou recup le dernier element de la liste

                            bs = (Benevoles)pt; // on lui rend sont type Benevole
                            bs.ajouterAtelier(Ar); // on ajoute l'atelier a la liste d'ateliers 
                        }
                    }
                }
            }
            /**/
             return laListe;
        } // fin getAllParticipant()

        #region execution BDD inscription 

        // inscript un participant en BDD
        public void executeSQLinscription(Participant unParticipant)
        {

            String req = "insert into participants values ( '" 
                         + unParticipant.Nom + "' , '"
                         + unParticipant.Prenom + "' , '"
                         + unParticipant.Adresse + "' , '"
                         + unParticipant.Portable + "' , '"
                         + unParticipant.Type + "' , '"
                         + unParticipant.NbParticipant + "' );";

           // req = "insert into participants ( nom, prenom, adresse, portable, type, nombre_Participation)  values ( 'aze' , 'aze', 'az', 'aze', 'truc', 1);"; 

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req); 
        } 
        // inscript un Benevole en BDD
        public void executeSQLinscription(Benevoles unParticipant)
        {
           
            String req = "insert into participants values ( '"
                         + unParticipant.Nom + "' , '"
                         + unParticipant.Prenom + "' , '"
                         + unParticipant.Adresse + "' , '"
                         + unParticipant.Portable + "' , '"
                         + unParticipant.Type + "' , '"
                         + unParticipant.NbParticipant + "' );" +

                         "insert into intervention values " + unParticipant.Email + ", '"
                         + 1 + "' ;" 
                         
                         +"insert into intervenir values " + unParticipant.Id + ", '"
                         + unParticipant.Email + "' ;"; 

            DAOFactory db = new DAOFactory();
            db.connecter(); 
            db.execSQLWrite(req); 
        }

        // ajoute une collection d'atelier a un participant pour la table participer : plusieurs nouvelles occurences possible
        public void dbAjoutAtelier(Participant unParticipant, List<Atelier> lesAteliers)
        {
            unParticipant.updateID();
            DAOFactory db = new DAOFactory();
            db.connecter();

            int i = 0 ; 
            while (lesAteliers.Count > i)
            {
                Atelier unA = lesAteliers[i]; 

                String req = "insert into participer values ( '"
                    + unParticipant.Id + "' , '"
                    + unA.Id + "' ); ";
               

                db.execSQLWrite(req);
                i++; 
            }
        }

        // ajoute une collection d'atelier a un participant pour la table participer : plusieurs nouvelles occurences possible
        public void dbAjoutAtelier(Benevoles unParticipant, List<Atelier> lesAteliers)
        {
            // ne va servir que lors de la creation d'un nouveau benevoles dans la bdd
            // va update l'id pour qu'il colle a celui en bdd puis va 
            unParticipant.updateID();
            DAOFactory db = new DAOFactory();
            db.connecter();

            int i = 0 ; 
            while (lesAteliers.Count > i)
            {
                Atelier unA = lesAteliers[i];

                String req = "insert into participer values ( '"
                    + unParticipant.Id + "' , '"
                    + unA.Id + "' ); ";


                db.execSQLWrite(req);
                i++;
            }
        }
        // recupere l'id du dernier participant crée en bdd pour le réaffecté au dernier participant inscript en local
        public void bddUpdateID(Participant unParticipant)
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select max(id) from participants;";
            SqlDataReader reader = db.excecSQLRead(req);

            reader.Read(); 
            unParticipant.Id = int.Parse(reader[0].ToString()); 
        }
        // recupere l'id du dernier Benevoles crée en bdd pour le réaffecté au dernier Benevoles inscript en local
        public void bddUpdateID(Benevoles unParticipant)
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "select max(id) from participants;";
            SqlDataReader reader = db.excecSQLRead(req);

            reader.Read();
            unParticipant.Id = int.Parse(reader[0].ToString());
        }
        #endregion

        #region modification BDD

        // modifie un participant en bdd
        public void executeSQLmodifInscription(Participant unParticipant, String exMail = null )
        {
            String req = "update participants set "
             + " nom = '" + unParticipant.Nom + "' , "
             + "prenom = '" + unParticipant.Prenom + "' , "
             + "adresse = '" + unParticipant.Adresse + "' , "
             + "portable = '" + unParticipant.Portable + "' , "
             + "type = '" + unParticipant.Type + "' , "
             + "nombre_Participation = " + unParticipant.NbParticipant
             + "where id = " + unParticipant.Id + " ;"; 

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req);
        }

        // modifie un Benevoles en bdd
        public void executeSQLmodifInscription(Benevoles unB, String exMail = null)
        {

             String req = "update participants set "
             + " nom = '" + unB.Nom + "' , "
             + "prenom = '" + unB.Prenom + "' , "
             + "adresse = '" + unB.Adresse + "' , "
             + "portable = '" + unB.Portable + "' , "
             + "type = '" + unB.Type + "' , "
             + "nombre_Participation = " + unB.NbParticipant
             + "where id = " + unB.Id + " ;" +

                         " update intervention set "
                         + " email = '" + unB.Email + "' " 
                         + "where email =" + exMail + " ;"
                         
                         +" update intervenir set "
                         + " email = '" + unB.Email + "' " 
                         + "where id ="+ unB.Id + " ;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req);
        }

        // recree les occurences de la table participer en bdd pour correspondre au derniere modification. 
        public void executeParticipe(Participant unP)
        {
            Atelier unA; 
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "Delete From participer where id = " + unP.Id + " ;";

            db.execSQLWrite(req);

            int i = 0;
            while ( i < unP.LesAtelier.Count)
            {
                unA = unP.LesAtelier.ElementAt(i); 
                req = "insert into participer values (" + unP.Id + ", "
                + unA.Id + ") ;";
                i++ ;
                db.execSQLWrite(req);
            }


        }

        // recree les occurences de la table participer en bdd pour correspondre au derniere modification. 
        public void executeParticipe(Benevoles unB)
        {
            Atelier unA; 
            DAOFactory db = new DAOFactory();
            db.connecter();

            String req = "Delete From participer where id = " + unB.Id + " ;";

            db.execSQLWrite(req);

            int i = 0;
            while ( i < unB.LesAtelier.Count)
            {
                unA = unB.LesAtelier.ElementAt(i); 
                req = "insert into participer values (" + unB.Id + ", "
                + unA.Id + ") ;";
                i++ ;
                db.execSQLWrite(req);
            }


        }
        #endregion

        #endregion
    }
}
