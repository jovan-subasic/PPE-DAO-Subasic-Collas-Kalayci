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

                Participant leParticipant = new Participant(int.Parse(reader[0].ToString()),
                                                            reader[1].ToString(),
                                                            reader[2].ToString(),
                                                            reader[3].ToString(),
                                                            reader[4].ToString(),
                                                            reader[5].ToString());


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

                    }

                    Atelier MonAtelier = new Atelier(int.Parse(readerAt[0].ToString()),
                                                     readerAt[1].ToString(),
                                                     int.Parse(readerAt[2].ToString()),
                                                     intervenant);

                    leParticipant.ajouterAtelier(MonAtelier);
                }
 
                laListe.Add(leParticipant);                   
            }
            return laListe; 
        }
        #endregion
    }
}
