using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Partenaire
    {
        #region attribue Privé 

        private int id;
        private String nom;
        private int typePartenaire;

        #endregion

        #region constructeur

        public Partenaire(int id, String nom, int typePartenaire)
        {
            this.id = id;
            this.nom = nom;
            this.typePartenaire = typePartenaire;
        }

        #endregion

        #region Getter & Setter 

        public int Id
        {
            get => id; set => id = value;
        }

        public String Nom
        {
            get => nom; set => nom = value;
        }

        public int TypePartenaire
        {
            get => typePartenaire; set => typePartenaire = value;
        }

        #endregion

        #region Methode 

        public void ajoutdbPartenaire()
        {
            DAOPartenaire db = new DAOPartenaire();
            db.AjouterPartenaire(this);
        }

        #endregion
    }
}
