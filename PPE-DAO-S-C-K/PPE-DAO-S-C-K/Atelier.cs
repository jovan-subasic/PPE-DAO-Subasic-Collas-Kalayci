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

            this.participants = new List<Participant>(); 
        }
        #endregion

        #region Getter & Setter 
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        internal Participant Intervenant { get => intervenant; set => intervenant = value; }
        internal List<Participant> Participants { get => participants; set => participants = value; }

        #endregion


        #region Méthodes 

        #region Ajout / Suppression Participant
        // Ajouter un participant a la liste 
        public void ajouterParticipant(Participant participant)
        {
            this.participants.Add(participant); 
        } public void ajouterParticipant(Benevoles benevole)
        {
            this.participants.Add(benevole); 
        }

        // Supprimer un participant 
        public void supprimerParticipant(Participant participant)
        {
            this.participants.Remove(participant);
        }
        #endregion

        #region Liste Atelier
        // Instancie une collection de tous le Atelier existant dans la table Atelier en utilisant tousLesAteliers() de DAOAtelier
        public List<Atelier> allAteliers()
        {
            DAOAtelier dbA = new DAOAtelier(); 
            List<Atelier> listAteliers;
            listAteliers = dbA.tousLesAteliers();
           
            return listAteliers;
        }


        #endregion

        #region participer
        // Appel la fonction dbParticipe( Atelier ) de DAOAtelier pour inscrire ou modifier une occurence de la table participer en BDD
        public void participe()
        {
            DAOAtelier db = new DAOAtelier();
            db.dbParticipantunAtelier(this); 
        }
        #endregion
        public void modifAtelier()
        {
            DAOAtelier da = new DAOAtelier();
            da.executeSQLmodifAtelier(this);
        }
        #endregion
    }
}
