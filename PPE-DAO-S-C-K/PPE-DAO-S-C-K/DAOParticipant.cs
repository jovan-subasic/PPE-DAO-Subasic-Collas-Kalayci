using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOParticipant
    {
        #region Méthodes 

        public List<Participant> getAllParticipant()
        {
            // on  veut recuperai la liste de tous les participants et les rangers dans leurs Class : 
            // Soit Participant || Soit Benevoles 
            List<Participant> laListe = new List<Participant>();

            /**/

            String req = "select * from participants Pt " +
                "left join participer Pr on Pr.id = Pt.id " +
                "left join atelier Ar on Ar.id = Pr.id " +
                "left join intervenir Ir on  Pt.id = Ir.id " +
                "left join intervention I on Ir.email = I.email " +
                "left join participants on Pt.id = Ar.id_participants " +
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
                    Participant pt = new Participant(); 
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

                            bs.ajouterAtelier(Ar);
                        }
                    }
                }
            }
            /**/
             return laListe;
        } // fin getAllParticipant()
        #region execution BDD inscription 
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
        
        public void executeSQLinscription(Benevoles unParticipant)
        {
           
            String req = "insert into participants values ( '"
                         + unParticipant.Nom + "' , '"
                         + unParticipant.Prenom + "' , '"
                         + unParticipant.Adresse + "' , '"
                         + unParticipant.Portable + "' , '"
                         + unParticipant.Type + "' , '"
                         + unParticipant.NbParticipant + "' );" +

                         "insert into intervenir values " + unParticipant.Id + ", '"
                         + unParticipant.Email + "' ;"; 

            DAOFactory db = new DAOFactory();
            db.connecter(); 
            db.execSQLWrite(req); 
        }

        public void dbAjoutAtelier(Participant unParticipant, List<Atelier> lesAteliers)
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            while (lesAteliers.GetEnumerator().MoveNext())
            {
                Atelier unA = lesAteliers.GetEnumerator().Current;

                String req = "insert into participer values ( '"
                    + unParticipant.Id + "' , '"
                    + unA.Id + "' , '";
               

                db.execSQLWrite(req); 
            }
        } 
        public void dbAjoutAtelier(Benevoles unParticipant, List<Atelier> lesAteliers)
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            while (lesAteliers.GetEnumerator().MoveNext())
            {
                Atelier unA = lesAteliers.GetEnumerator().Current;

                String req = "insert into participer values ( '"
                    + unParticipant.Id + "' , '"
                    + unA.Id + "' , '";
               

                db.execSQLWrite(req); 
            }
        }
        #endregion

        #region modification BDD
        public void executeSQLmodifInscription(Participant unParticipant )
        {
            String req = "update participants set (" + unParticipant.Id + ", '"
             + unParticipant.Nom + "' , '"
             + unParticipant.Prenom + "' , '"
             + unParticipant.Adresse + "' , '"
             + unParticipant.Portable + "' , '"
             + unParticipant.Type + "' , '"
             + unParticipant.NbParticipant + "') "
             + "where id =" + unParticipant.Id + " ;"; 

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req);
        }
        public void executeSQLmodifInscription(Benevoles unB)
        {
            String req = "update participants set (" + unB.Id + ", '"
                         + unB.Nom + "' , '"
                         + unB.Prenom + "' , '"
                         + unB.Adresse + "' , '"
                         + unB.Portable + "' , '"
                         + unB.Type + "' , '"
                         + unB.NbParticipant + "') " 
                         + "where id ="+ unB.Id + " ;" +

                         "update intervenir set " + unB.Id + ", '"
                         + unB.Email + "' " 
                         + "where id ="+ unB.Id + " ;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req);
        }

        public void executeParticipe(Participant unP)
        {
            Atelier unA; 
            DAOFactory db = new DAOFactory();
            db.connecter();
            String req = "Delete From participer where id =" + unP.Id + ";";
            db.execSQLWrite(req);

            int i = 0;
            while ( i < unP.LesAtelier.Count)
            {
                unA = unP.LesAtelier.ElementAt(i); 
                req = "insert into participer values " + unP.Id + ", "
                + unA.Id + ";";
                i++ ;
                db.execSQLWrite(req);
            }


        }
        #endregion

        #endregion


        /* CODE GENERER LES ATELIERS 
          
        SET IDENTITY_INSERT dbo.atelier ON
        INSERT INTO ASL.dbo.atelier(id,nom,capacite,id_participants) VALUES 
        (1,'La Maison des Ligues et son projet',50,1),
        (2,'Observatoire du metier des sports',80,1),
        (3,'Le fonctionnement de la Maison des Ligues',70,1),
        (4,'Le sport lorrain et les collectivités',60,1),
        (5,'Les outils à disposition et remis aux clubs',40,1),
        (6,'Développement durable',90,1); /**/
    }
}
