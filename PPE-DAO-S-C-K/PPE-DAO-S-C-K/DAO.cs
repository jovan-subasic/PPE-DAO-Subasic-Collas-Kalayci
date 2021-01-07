using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_DAO_S_C_K
{
    public partial class Maison_des_ligues : Form
    {
        #region Attribue 
        private List<Participant> lesParticipants = new List<Participant>();
        private List<Atelier> lesAteliers = new List<Atelier>(); 
        #endregion

        public Maison_des_ligues()
        {
            InitializeComponent();
        }

        #region Formulaire M2L
        private void Maison_des_ligues_Load(object sender, EventArgs e)
        {
            remplirList(); 
        }
        #endregion

        #region Inscription 
        private void tabPageInscription_Click(object sender, EventArgs e)
        {
            int i = 0;
            int unId;

            String leNom;
            Participant unP; 
            while (i < lesParticipants.Count())
            {
                unP = lesParticipants.ElementAt(i);
                unId = unP.Id;
                leNom = unP.Nom;
                cbx_inscriptionModifNom.Items.Add("n°" + unId + " " + leNom);
                i++; 
            }

            Atelier unA;
            while (i < lesAteliers.Count())
            {
                unA = lesAteliers.ElementAt(i);
                leNom = unA.Nom; 
                CLB_inscriptionAtelier.Items.Add(leNom);
                CLB_inscriptionModificationAtelier.Items.Add(leNom); 
            }


        }

        private void lab_inscriptionNomP_Click(object sender, EventArgs e)
        {

        }

        private void Btn_valideInscription_Click(object sender, EventArgs e)
        {

            if ( null != txt_inscriptionNom.Text &&
                 null != txt_inscriptionAdresse.Text &&
                 null != txt_inscriptionNumtel.Text &&
                 null != txt_inscriptionPrenom.Text
                 )
            {
                int id = lesParticipants.Count; // pour que l'id sont la nouvelle derni_re valeur
                // de l'attribue id de la liste lesParticipants. 
                if (null != txt_inscriptionMail.Text) // construit un objet Benevole et Participant
                {

                    Benevoles bs = new Benevoles(
                                   id,
                                   txt_inscriptionNom.Text,
                                   txt_inscriptionPrenom.Text,
                                   txt_inscriptionAdresse.Text,
                                   txt_inscriptionNumtel.Text,
                                   Cbx_inscriptionType.Text,
                                   txt_inscriptionMail.Text
                                    );
                    lesParticipants.Add(bs); 
                }
                else // construit un objet Participant, uniquement.
                {
                    Participant pt = new Participant(
                                    id,
                                    txt_inscriptionNom.Text,
                                    txt_inscriptionPrenom.Text,
                                    txt_inscriptionAdresse.Text,
                                    txt_inscriptionNumtel.Text,
                                    Cbx_inscriptionType.Text
                                    );
                    lesParticipants.Add(pt);
                }
            } else
            {
                MessageBox.Show(" un champs n\'est pas renseigné "); 
            }
        }
        #endregion

        #region Méthodes  
        public void remplirList()
        {
            Participant unP = new Participant();
            Atelier unA = new Atelier();

            lesParticipants = unP.allParticipant();
            lesAteliers = unA.allAteliers();
        }

        #endregion


    }
}
