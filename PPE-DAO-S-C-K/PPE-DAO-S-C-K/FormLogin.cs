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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtpassword.Text == "admin")
            {
                new Maison_des_ligues().Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Mauvais logins, appuyez sur 'Indice'");
                txtUsername.Clear();
                txtpassword.Clear();
                txtUsername.Focus();


            }
        }

        private void lbl_clear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtUsername.Focus();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_indice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nom d'utilisateur : admin" + Environment.NewLine + "Mot de passe : admin");
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
