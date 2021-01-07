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
        public Participant() // pour pouvoir déclare des objet Participant sans attribue
        {

        }
        public Participant(int id, string nom, string prenom, string adresse, string portable, string type)
        {
            this.id = id;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            this.adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            this.portable = portable ?? throw new ArgumentNullException(nameof(portable));
            this.type = type ?? throw new ArgumentNullException(nameof(type));

            //this.participantAtelier();
        }
        public Participant(int id, string nom, string prenom, string adresse, string portable, string type, List<Atelier> lesAtelier)
        {
            this.id = id;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            this.adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            this.portable = portable ?? throw new ArgumentNullException(nameof(portable));
            this.type = type ?? throw new ArgumentNullException(nameof(type));

            this.lesAtelier = lesAtelier;
            
            //this.participantAtelier();
        }

        public Participant(int id, string nom, string prenom, string adresse, string portable, string type, int nbParticipant, List<Atelier> lesAtelier)
        {
            this.id = id;
            this.nom = nom ?? throw new ArgumentNullException(nameof(nom));
            this.prenom = prenom ?? throw new ArgumentNullException(nameof(prenom));
            this.adresse = adresse ?? throw new ArgumentNullException(nameof(adresse));
            this.portable = portable ?? throw new ArgumentNullException(nameof(portable));
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            this.nbParticipant = nbParticipant;
            
            this.lesAtelier = lesAtelier;
            
            //this.participantAtelier(); 
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
        public void participantAtelier()
        {
            int i = 0;
            while (i < this.lesAtelier.Count())
            {
                this.lesAtelier.ElementAt(i).ajouterParticipant(this);
                i++;
            }
        }

        public void ajouterAtelier(Atelier atelier)
        {
            this.lesAtelier.Add(atelier);
        }

        // Supprimer un participant 
        public void supprimerAtelier(Atelier atelier)
        {
            this.lesAtelier.Remove(atelier);
        }

        public List<Participant> allParticipant()
        {
            DAOParticipant dbP = new DAOParticipant();
            List<Participant> laList = dbP.getAllParticipant(); 
           
            return laList; 
        }

        public void ajoutdbParticipant()
        {
            DAOParticipant db = new DAOParticipant();
            db.executeSQLwrite(this); 
        }
        #endregion

    }
}
