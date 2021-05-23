using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Equipement
    {
        #region attribue Privé 

        private int id;
        private bool connexionReseauFilaire;
        private bool bar;
        private bool salonReception;
        private bool cabineEssayage;
        private bool tablesFournis;
        private int nbrSiege;

        #endregion

        #region constructeur

        public Equipement(int id, bool connexionReseauFilaire, bool bar, bool salonReception, bool cabineEssayage, bool tablesFournis, int nbrSiege)
        {
            this.id = id;
            this.connexionReseauFilaire = connexionReseauFilaire;
            this.bar = bar;
            this.salonReception = salonReception;
            this.cabineEssayage = cabineEssayage;
            this.tablesFournis = tablesFournis;
            this.nbrSiege = nbrSiege;
        }


        #endregion

        #region Getter & Setter 

        public int Id
        {
            get => id; set => id = value;
        }

        public bool ConnexionReseauFilaire
        {
            get => connexionReseauFilaire; set => connexionReseauFilaire = value;
        }

        public bool Bar
        {
            get => bar; set => bar = value;
        }

        public bool SalonReception
        {
            get => salonReception; set => salonReception = value;
        }

        public bool CabineEssayage
        {
            get => cabineEssayage; set => cabineEssayage = value;
        }

        public bool TablesFournis
        {
            get => tablesFournis; set => tablesFournis = value;
        }

        public int NbrSiege
        {
            get => nbrSiege; set => nbrSiege = value;
        }

        #endregion

        #region Methode 


        #endregion
    }
}
