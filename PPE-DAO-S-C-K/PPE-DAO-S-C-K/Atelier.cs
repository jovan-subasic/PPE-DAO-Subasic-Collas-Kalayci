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
        private List<Participant> participants;
        #endregion




        #region Constructeur 
        public Atelier()
        {

        }
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


        #region Méthodes 
        // Ajouter un participant a la liste 
        public void ajouterParticipant(Participant participant)
        {
            this.participants.Add(participant); 
        }

        // Supprimer un participant 
        public void supprimerParticipant(Participant participant)
        {
            this.participants.Remove(participant);
        }

        // Instancie une collection de tous le Atelier existant dans la table Atelier
        public List<Atelier> allAteliers()
        {
            DAOAtelier dbA = new DAOAtelier(); 
            List<Atelier> listAteliers;
            listAteliers = dbA.tousLesAteliers();
           
            return listAteliers;
        }
        public void participe()
        {
            DAOAtelier db = new DAOAtelier();
            db.dbParticipe(this); 
        }
        #endregion
    }
}
