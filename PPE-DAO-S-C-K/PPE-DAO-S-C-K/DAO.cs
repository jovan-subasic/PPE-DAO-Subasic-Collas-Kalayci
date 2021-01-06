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

        private void Maison_des_ligues_Load(object sender, EventArgs e)
        {
            remplirList(); 
        }

        private void lab_inscriptionNomP_Click(object sender, EventArgs e)
        {

        }

        public void remplirList(){
            Participant unP = new Participant(); 
            Atelier unA = new Atelier(); 

            lesParticipants = unP.allParticipant(); 
            lesAteliers = unA.allAteliers();
    }
}
