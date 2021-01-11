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

            List<Atelier> laList = new List<Atelier>();/*/*/
            String req = "select * From Atelier;";

            DAOFactory db = new DAOFactory();
            db.connecter(); 
            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                int idIntervenant = int.Parse(reader[3].ToString()); 
                req = "select * From participants where id = "+ idIntervenant + ";";
                //db.connecter();
                SqlDataReader readerP = db.excecSQLRead(req);
                Participant intervenant;
                while (readerP.Read())
                {
                    intervenant = new Participant(int.Parse(readerP[0].ToString()),
                                                     readerP[1].ToString(),
                                                     readerP[2].ToString(),
                                                     readerP[3].ToString(),
                                                     readerP[4].ToString(),
                                                     readerP[5].ToString());

                    Atelier unAtelier = new Atelier(int.Parse(reader[0].ToString()),
                                                    reader[1].ToString(),
                                                    int.Parse(reader[2].ToString()),
                                                    intervenant);

                    unAtelier.participe(); // insère la liste des participants

                    laList.Add(unAtelier); 
                } // fin while 
               
            } // fin while /*/
            return laList;
        } // fin tousLesAteliers()

        // permets de définir la liste de participant a un atelier 
        public void dbParticipe( Atelier unAtelier )
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
