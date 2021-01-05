using System;
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
            Participant unP = new Participant();
            List<Participant> listParticipent = unP.allParticipant(); 

            List<Atelier> laList = new List<Atelier>();
            String req = "select * From Atelier;";

            DAOFactory db = new DAOFactory();
            SqlDataReader reader = db.excecSQLRead(req);

            while (reader.Read())
            {
                int idIntervenant = int.Parse(reader[3].ToString()); 
                req = "select * From participants where id = "+ idIntervenant + ";";
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
                    laList.Add(unAtelier); 
                } // fin while 
               
            } // fin while 
            return laList;
        }
        #endregion
    }



}
