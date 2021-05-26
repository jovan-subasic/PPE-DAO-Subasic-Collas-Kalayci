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

        public void dbParticipe(String exMail = null)
        {
            DAOParticipant db = new DAOParticipant();
            db.executeParticipe(this, exMail);

        }
    }
}
