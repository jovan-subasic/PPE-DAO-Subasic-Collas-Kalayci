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
