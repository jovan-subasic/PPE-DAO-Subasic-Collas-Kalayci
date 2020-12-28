using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Atelier
    {
        #region attribue Privé 
        private int id;
        private String nom; 
        private int capacite;
        private Participant intervenant;
        #endregion




        #region Constructeur 
        public Atelier(int id, string nom, int capacite, Participant intervenant)
        {
            this.id = id;
            this.nom = nom;
            this.capacite = capacite;
            this.intervenant = intervenant;
        }
        #endregion

        #region Getter & Setter 
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        internal Participant Intervenant { get => intervenant; set => intervenant = value; }
        #endregion

    }
}
