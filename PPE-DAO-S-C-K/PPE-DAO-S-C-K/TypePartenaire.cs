using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class TypePartenaire
    {
        #region attribue Privé 

        private int id;
        private String nom;

        #endregion

        #region constructeur

        public TypePartenaire(int id, String nom)
        {
            this.id = id;
            this.nom = nom;
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

        #endregion


    }
}
