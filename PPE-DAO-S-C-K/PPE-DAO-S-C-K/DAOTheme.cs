using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PPE_DAO_S_C_K
{
    class DAOTheme
    {
        #region Attribue 
        private List<Theme> listAteliers = new List<Theme>();
        #endregion

        #region Méthodes  


        // méthode qui génére la liste de tous les Themes.

        public List<Theme> getAllThemes()
        {

            List<Theme> laListe = new List<Theme>();


            String req = "select * from themes;";

            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);

            return laListe;
        }

        // méthode qui génére la liste de tous les Themes.

        public List<Theme> themesParAtelier(int id)
        {

            List<Theme> laListe = new List<Theme>();


            String req = "select themes.nom from atelier INNER JOIN themes ON atelier.id = themes.id_atelier WHERE atelier.id=" + id + ";";

            DAOFactory db = new DAOFactory();
            db.connecter();
            SqlDataReader reader = db.excecSQLRead(req);

            return laListe;
        }





        #endregion
    }



}
