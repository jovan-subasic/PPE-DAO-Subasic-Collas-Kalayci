using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    class Participant
    {
        #region attribue Privé 
        private int id ; 
        private String nom ; 
        private String prenom ; 
        private String adresse ; 
        private String portable ; 
        private String type ; 
        private int nbParticipant ;
        private List<Atelier> lesAtelier ; 
        #endregion

        #region constructeur
        public Participant(int id, string nom, string prenom, string adresse, string portable, string type)
        {
            this.id = id;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            this.adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            this.portable = portable ?? throw new ArgumentNullException(nameof(portable));
            this.type = type ?? throw new ArgumentNullException(nameof(type));

            lesAtelier
        }

        public Participant(int id, string nom, string prenom, string adresse, string portable, string type, int nbParticipant)
        {
            this.id = id;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            this.adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            this.portable = portable ?? throw new ArgumentNullException(nameof(portable));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.nbParticipant = nbParticipant;
        }
        #endregion

        #region Getter & Setter 
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Portable { get => portable; set => portable = value; }
        public string Type { get => type; set => type = value; }
        public int NbParticipant { get => nbParticipant; set => nbParticipant = value; }
        #endregion

        #region Methode 

        #endregion

    }
}
