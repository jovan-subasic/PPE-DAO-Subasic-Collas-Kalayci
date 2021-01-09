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

        #region inscription d'un participant
        private void Cbx_inscriptionType_SelectedIndexChanged(object sender, EventArgs e)
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
                int id = lesParticipants.Count; // pour que l'id sont la nouvelle derniere valeur
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
                    bs.ajoutdbParticipant(); 
                    lesParticipants.Add(bs); 
                }
                else // construit un objet Participant uniquement.
                {
                    Participant pt = new Participant(
                                    id,
                                    txt_inscriptionNom.Text,
                                    txt_inscriptionPrenom.Text,
                                    txt_inscriptionAdresse.Text,
                                    txt_inscriptionNumtel.Text,
                                    Cbx_inscriptionType.Text
                                    );
                    pt.ajoutdbParticipant(); 
                    lesParticipants.Add(pt);
                }
            } else
            {
                MessageBox.Show(" un champs n\'est pas renseigné "); 
            }
        }
        #endregion

        #region modification d'un participant 
        private void btn_inscriptionModifier_Click(object sender, EventArgs e)
        {
            if (!cbx_inscriptionModifNom.SelectedIndex.Equals(null) &&
                 null != txt_modifInscriptionPrenom.Text &&
                 null != txt_modifInscriptionAdresse.Text &&
                 null != txt_modifInscriptionNumTel.Text
                 )
            {
                
                // de l'attribue id de la liste lesParticipants. 
                if ( cbx_modifInscreptionType.SelectedIndex.Equals("Benevole")) // construit un objet Benevole et Participant
                {
                   Participant unP =  lesParticipants.ElementAt(cbx_inscriptionModifNom.SelectedIndex);
                    Benevoles bs = (Benevoles)unP;
                    bs.Prenom = txt_modifInscriptionPrenom.Text ; 
                    bs.Adresse = txt_modifInscriptionAdresse.Text ;
                    bs.Portable = txt_modifInscriptionNumTel.Text ;
                    bs.Type = cbx_modifInscreptionType.Text; 
                    bs.Email = txt_modifInscriptionMail.Text;
                    bs.modifParticipant(); 
                    
                }
                else // construit un objet Participant uniquement.
                {
                    Participant unP = lesParticipants.ElementAt(cbx_inscriptionModifNom.SelectedIndex);
                    unP.Prenom = txt_modifInscriptionPrenom.Text;
                    unP.Adresse = txt_modifInscriptionAdresse.Text;
                    unP.Portable = txt_modifInscriptionNumTel.Text;
                    unP.Type = cbx_modifInscreptionType.Text;

                    unP.modifParticipant();

                }
            }
            else
            {
                MessageBox.Show(" un champs n\'est pas renseigné ");
            }
        }
        private void cbx_inscriptionModifNom_SelectedIndexChanged(object sender, EventArgs e)
        {
           Participant unP = lesParticipants.ElementAt(cbx_inscriptionModifNom.SelectedIndex); 

            txt_modifInscriptionAdresse.Text = unP.Adresse;
            txt_modifInscriptionPrenom.Text = unP.Prenom;
            txt_modifInscriptionNumTel.Text = unP.Portable;
            cbx_modifInscreptionType.SelectedItem.Equals(unP.Type);
           
            if (unP.Type == "Benevole")
            {
                Benevoles unB = (Benevoles)unP;
                txt_modifInscriptionMail.Text = unB.Email;
            }


        }
        #endregion

        #endregion

        #region Liste 
        private void tabPageListeParticipant_Click(object sender, EventArgs e)
        {
          
            int i = 0; 
            while ( i < lesAteliers.Count())
            {
                Atelier unA = lesAteliers.ElementAt(i); 
                cbx_choix_liste_Participant.Items.Add(" Atelier : " + unA.Nom ); 
                i++; 
            }
            cbx_choix_liste_Participant.Items.Add("Tous les participant");
            cbx_choix_liste_Participant.SelectedItem.Equals("Tous les participant"); 
        }
        private void cbx_choix_liste_Participant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            if (cbx_choix_liste_Participant.SelectedItem.ToString() == "Tous les participant")
            {
                while (i < lesParticipants.Count)
                {
                    Participant unP = lesParticipants.ElementAt(i);
                    DGV_ListeParticipant.Rows.Add(unP);
                }
            }
            else
            {
                Atelier unA;
                unA = lesAteliers.ElementAt(cbx_choix_liste_Participant.SelectedIndex);
                
                while (i < unA.Participants.Count())
                {
                    
                    Participant unP = unA.Participants.ElementAt(i);
                    DGV_ListeParticipant.Rows.Add(unP);
                }
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
