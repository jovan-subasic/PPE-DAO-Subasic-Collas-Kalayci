using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Stand
    {
        #region attribue Privé 

            private int id;
            private int idAllee;
            private int idOrdre;
            private int id_equipement;
            private int montantFacture;
            private String nom;
            private int id_partenaires;
            private List<Stand> lesStands;


        #endregion

        #region constructeur

        public Stand(int id, int idAllee, int idOrdre, int id_equipement, int montantFacture, string nom, int id_partenaires)
            {
                this.id = id;
                this.idAllee = idAllee;
                this.idOrdre = idOrdre;
                this.id_equipement = id_equipement;
                this.montantFacture = montantFacture;
                this.nom = nom;
                this.id_patenaires = id_partenaires;
                this.lesStands = new List<Stand>();

        }

        #endregion

        #region Getter & Setter 

            public int Id 
            { 
                get => id; set => id = value; 
            }

            public int IdAllee
            {
                get => idAllee; set => idAllee = value;
            }

            public int IdOrdre
            {
                get => idOrdre; set => idOrdre = value;
            }

            public int Equipement
            {
                get => id_equipement; set => id_equipement = value;
            }

            public int MontantFacture
            {
                get => montantFacture; set => montantFacture = value;
            }

            public string Nom 
            { 
                get => nom; set => nom = value; 
            }

            public int Id_partenaires
            {
                get => id_partenaires; set => id_partenaires = value;
            }

            internal List<Stand> lesStands { get => lesStands; set => lesStands = value; }


        #endregion

        #region Methode 

        public void ajoutdbStand()
            {
                DAOStand db = new DAOStand();
                db.executeSQLinscription(this);
            }

            public void dbStand()
            {
                DAOStand db = new DAOStand();
                db.executeParticipe(this);

            }

        #endregion
    }
}