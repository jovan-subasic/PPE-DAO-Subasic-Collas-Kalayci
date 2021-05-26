using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPE_DAO_S_C_K
{
    sealed class Benevoles : Participant  
    {
        #region Attribue 
        private String email;
        #endregion

        #region Constructeur 
        public Benevoles()
        {

        }

        public Benevoles(int id,
                         string nom,
                         string prenom,
                         string adresse,
                         string portable,
                         string type,
                         string email)
                         : 
                      base(id,
                           nom,
                           prenom,
                           adresse,
                           portable,
                           type)
        {

            this.Email = email;
        }
        #endregion

        #region Getter & Setter
        public string Email { get => email; set => email = value; }
        #endregion

        #region
        // Appel la fonction dbAjoutAtelier(Participant ou Benevoles, Liste <Atelier>)
        // de DAOParticipant pour modifier une occurence de la table participer en BDD
        public new void inscriptiondbParticipe(List<Atelier> mesAteliers = null)
        {
            if (mesAteliers is null)
            {
                mesAteliers = this.LesAtelier;
            }
            DAOParticipant db = new DAOParticipant();
            db.dbAjoutAtelier(this, mesAteliers);

        }
        // Appel la fonction executeSQLinscription(Participant ou Benevole) de DAOParticipant pour ajouter une occurence de la table participants en BDD
        public new void ajoutdbParticipant()
        {
            DAOParticipant db = new DAOParticipant();
            db.executeSQLinscription(this);
        }
        // Appel la fonction executeSQLinscription(Participant ou Benevole) de DAOParticipant pour ajouter une occurence de la table participer en BDD
        public void dbParticipe(String exMail = null)
        {
            DAOParticipant db = new DAOParticipant();
            db.executeParticipe(this, exMail);

        }
        #endregion
    }
}
