using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Theme
    {
        #region attribue Privé 
        private int id;
        private String nom;
        private Atelier unAtelier;
        #endregion

        #region Constructeur 
        public Theme()
        {

        }
        public Theme(int id, string nom, int capacite, Atelier unAtelier)
        {
            this.id = id;
            this.nom = nom;
            this.unAtelier = unAtelier;
        }
        #endregion

        #region Getter & Setter 
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public Atelier Atelier { get => unAtelier; set => unAtelier = value; }

        public List<Theme> allThemes()
        {
            DAOTheme dbT = new DAOTheme();
            
            List<Theme> laList = dbT.getAllThemes();

            return laList;
        }

        public List<Theme> allThemes2(int i)
        {
            DAOTheme dbT = new DAOTheme();

            List<Theme> laList = dbT.themesParAtelier(i);

            return laList;
        }




        #endregion



    }
}
