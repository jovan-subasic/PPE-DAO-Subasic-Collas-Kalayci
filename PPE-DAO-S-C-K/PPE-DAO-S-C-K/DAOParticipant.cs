using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOParticipant
    {
        #region Méthodes 

        public List<Participant> getAllParticipant()
        {
            List<Participant> laListe = new List<Participant>(); 
            string req; 
            req = "Select Pt.id,Pt.nom, Pt.prenom, Pt.adresse, Pt.portable, Pt.type " +
                  "From participant Pt " +
                  "order by Pt.id ;";

            DAOFactory db = new DAOFactory();            

            SqlDataReader reader = db.excecSQLRead(req);


            while (reader.Read())
            {
                req = "Select A.id, A.nom, A.capacite, A.id_participants" +
                      "From participer Pr " +
                      "inner join participant Pt Pt.id on Pr.id " +
                      "inner join atelier A A.id on Pr.id_atelier " +
                      "where Pt.id ="+int.Parse(reader[0].ToString()) + " order by Pt.id ;";

                SqlDataReader readerAt = db.excecSQLRead(req);
                if (reader[5].ToString() == "Benevole")
                {
                    req = "Select * From intervenir where id = " + int.Parse(reader[0].ToString()) + ";" ;
                    SqlDataReader readerBs = db.excecSQLRead(req);

                    readerBs.Read(); 
                    
                       String email = readerBs[1].ToString();
                        
                            Benevoles leParticipant = new Benevoles(int.Parse(reader[0].ToString()),
                                                                reader[1].ToString(),
                                                                reader[2].ToString(),
                                                                reader[3].ToString(),
                                                                reader[4].ToString(),
                                                                reader[5].ToString(),
                                                                email);
                       
                    
                }
                else
                {

                
                    Participant leParticipant = new Participant(
                                                            int.Parse(reader[0].ToString()),
                                                            reader[1].ToString(),
                                                            reader[2].ToString(),
                                                            reader[3].ToString(),
                                                            reader[4].ToString(),
                                                            reader[5].ToString()
                                                            );

                }
                while (readerAt.Read())
                {
                    req = "Select Pt.id,Pt.nom, Pt.prenom, Pt.adresse, Pt.portable, Pt.type " +
                          "From participant Pt where Pt.id = "+ int.Parse(readerAt[3].ToString()) + " " +
                          "order by Pt.id ;";
                    SqlDataReader readerIn = db.excecSQLRead(req);
                    Participant intervenant; 
                    while (readerIn.Read()) 
                    {
                        intervenant = new Participant(int.Parse(readerIn[0].ToString()), 
                                                                  readerIn[1].ToString(),
                                                                  readerIn[2].ToString(),
                                                                  readerIn[3].ToString(),
                                                                  readerIn[4].ToString(),
                                                                  readerIn[5].ToString()); 

                    

                        Atelier MonAtelier = new Atelier(int.Parse(readerAt[0].ToString()),
                                                     readerAt[1].ToString(),
                                                     int.Parse(readerAt[2].ToString()),
                                                     intervenant);

                        leParticipant.ajouterAtelier(MonAtelier);
                        laListe.Add(leParticipant);
                    }
                }
 
                                 
            }
            return laListe;
        } // fin getAllParticipant()

        #region execution BDD inscription 
        public void executeSQLinscription(Participant unParticipant)
        {
           
            String req = "insert into participants values " + unParticipant.Id + ", '"
                         + unParticipant.Nom + "' , '"
                         + unParticipant.Prenom + "' , '"
                         + unParticipant.Adresse + "' , '"
                         + unParticipant.Portable + "' , '"
                         + unParticipant.Type + "' ;";  
            DAOFactory db = new DAOFactory();
            db.execSQLWrite(req); 
        } 
        
        public void executeSQLinscription(Benevoles unParticipant)
        {
           
            String req = "insert into participants values " + unParticipant.Id + ", '"
                         + unParticipant.Nom + "' , '"
                         + unParticipant.Prenom + "' , '"
                         + unParticipant.Adresse + "' , '"
                         + unParticipant.Portable + "' , '"
                         + unParticipant.Type + "' ;" +

                         "insert into intervenir values " + unParticipant.Id + ", '"
                         + unParticipant.Email + "' ;"; 

            DAOFactory db = new DAOFactory();
            db.connecter(); 
            db.execSQLWrite(req); 
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
             + unParticipant.Type + "') "
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
                         + unB.Type + "') " 
                         + "where id ="+ unB.Id + " ;" +

                         "update intervenir set " + unB.Id + ", '"
                         + unB.Email + "' " 
                         + "where id ="+ unB.Id + " ;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            db.execSQLWrite(req);
        }
        #endregion

        #endregion
    }
}
