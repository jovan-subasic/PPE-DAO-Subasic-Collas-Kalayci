﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE_DAO_S_C_K
{
    public partial class Maison_des_ligues : Form
    {
        #region Attribue 
        private List<Participant> lesParticipants = new List<Participant>();
        private List<Stand> lesStands = new List<Stand>();
        private List<Equipement> lesEquipements = new List<Equipement>();
        private List<Atelier> lesAteliers = new List<Atelier>();
        private List<TypePartenaire> lesTypesPartenaires = new List<TypePartenaire>();
        private List<Partenaire> lesPartenaires = new List<Partenaire>();

        private bool connexionReseauFilaire;
        private bool bar;
        private bool salonReception;
        private bool cabineEssayage;
        private bool tablesFournis;

        #endregion

        public Maison_des_ligues()
        {
            InitializeComponent();
        }

        #region Formulaire M2L
        private void Maison_des_ligues_Load(object sender, EventArgs e)
        {
            remplirList();

            DAOStand daoStand = new DAOStand();
            DAOPartenaire dp = new DAOPartenaire();
            lesTypesPartenaires = dp.listeTypePartenaire();

            foreach (var typePartenaire in lesTypesPartenaires)
            {
                cbx_typePartenaire.Items.Add(typePartenaire.Nom);
            }

            lesPartenaires = dp.listePartenaire();

            foreach (var Partenaire in lesPartenaires)
            {
                cbx_partenaire.Items.Add(Partenaire.Nom);
            }

            lesStands = daoStand.listeStand();

            foreach (var Stand in lesStands)
            {
                if (Stand.Id_partenaires == 0)
                {
                    cbx_stands.Items.Add(Stand.Nom);
                }
            }
        }
        #endregion

        #region Inscription 
        private void tabPageInscription_Enter(object sender, EventArgs e)
        {
            int i = 0;
            int unId;

            if(cbx_inscriptionModif_Id.Items.Count < lesParticipants.Count())
            {

            
                // ajoute la possibilite de cree un participants 
               cbx_inscriptionModif_Id.Items.Add("New inscription");

                // par default on selectionne le fait de realiser une nouvelle inscription 
               cbx_inscriptionModif_Id.SelectedIndex = 0;

                // boucle pour afficher la liste de tous les participants 
                String leNom;
                Participant unP;
                while (i < lesParticipants.Count())
                {
                    unP = lesParticipants.ElementAt(i);
                    unId = unP.Id;
                    leNom = unP.Nom;
                    cbx_inscriptionModif_Id.Items.Add("n°" + unId + " " + leNom);
                    i++;
                }

                i = 0; // on remet la variable iterateur a 0 
                Atelier unA;
                while (i < lesAteliers.Count())
                {
                    unA = lesAteliers.ElementAt(i);
                    leNom = unA.Nom;
                    CLB_inscriptionModificationAtelier.Items.Add(leNom);
                    i++;
                }
            }

        }
         private void tabPageInscription_Click(object sender, EventArgs e)
        {
           // inutile 
        }

        private void lab_inscriptionNomP_Click(object sender, EventArgs e)
        {

        }

        #region modification d'un participant 
        private void btn_inscriptionModifier_Click(object sender, EventArgs e)
        {

            String erreur = "";
            if (
                 "" != txt_modifInscriptionNom.Text &&
                 "" != txt_modifInscriptionPrenom.Text &&
                 "" != txt_modifInscriptionAdresse.Text &&
                 "" != txt_modifInscriptionNumTel.Text
                 )
            {


                /****************** on realise toute les verification neccessaire pour valider les champs de formulaire ********************/
                #region verification 
                // verifie la validiter du Prenom et du Nom
                // /[a-zA-Z]+/g
                Regex myString = new Regex(@"^\s*[a-zA-Z]+\s*$", RegexOptions.IgnoreCase);

                // verifie la validiter du num de telephone 
                // ^(0|\+33)[1-9]( *[0-9]{2}){4}$
                Regex myTel = new Regex(@"^\s*(0|\+33)[1-9]( *[0-9]{2}){4}\s*$", RegexOptions.IgnoreCase);

                // expression qui verifie la validiter d'un mail
                Regex myMail = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)\s*$", RegexOptions.IgnoreCase);


                if (cbx_inscriptionModif_Id.SelectedItem == null || cbx_inscriptionModif_Id.Items.Contains(cbx_inscriptionModif_Id.SelectedItem.ToString()) == false )
                { // si l'id selectionner n'existe pas 
                    erreur += Environment.NewLine + " erreur : id selectionner invalide ! "; 

                } if (txt_modifInscriptionNom.Text.Length >= 50 || myString.IsMatch(txt_modifInscriptionNom.Text) == false )
                { // si le nom n'est pas bon 
                    erreur += Environment.NewLine + " erreur : Nom invalide ! "; 

                } if (txt_modifInscriptionPrenom.Text.Length >= 50 || myString.IsMatch(txt_modifInscriptionPrenom.Text) == false)
                { // si le prenom n'est pas bon 
                    erreur += Environment.NewLine + " erreur : Prenom invalide ! "; 

                }if (txt_modifInscriptionAdresse.Text.Length >= 50)
                {// si l'adresse n'est pas bon 
                    erreur += Environment.NewLine + " erreur : Adresse invalide ! ";
                    
                }if (txt_modifInscriptionNumTel.Text.Length >= 50 || myTel.IsMatch(txt_modifInscriptionNumTel.Text) == false)
                {// si le numero de telephone n'est pas bon 
                    erreur += Environment.NewLine + " erreur : numero de telephone invalide ! "; 

                }if (cbx_modifInscreptionType.SelectedItem == null || cbx_modifInscreptionType.Items.Contains(cbx_modifInscreptionType.SelectedItem) == false)
                {// si le type selectionner n'existe pas 
                    erreur += Environment.NewLine + " erreur : type selectionner invalide ! "; 

                }if (cbx_modifInscreptionType.Items.Equals("Benevole") && myMail.IsMatch(txt_modifInscriptionMail.Text) == false)
                {// si le mail n'est pas bon 
                    erreur += Environment.NewLine + " erreur : mail invalide ! ";
                    
                }
                #endregion
                /******************************************* fin des verification ! *************************************************/


                // s'il n'y a pas d'erreur alors le message d'erreur a une longeur inferieur a 1 
                if (erreur.Length < 1)
                {
                    #region nouvelle Inscript 
                    // si l'index selectionner est 0, alors il s'agit d'une nouvelle inscription ! 
                    if (cbx_inscriptionModif_Id.SelectedIndex.Equals(0))
                    {
                        int id = lesParticipants.Count; // pour que l'id soit la nouvelle derniere valeur
                                                        // de l'attribue id de la liste lesParticipants. 

                        if (cbx_modifInscreptionType.Items.Equals("Benevole")) // verif s'il s'agit d'un Benevole
                        {
                            // construit un objet Benevole et Participant
                            Benevoles bs = new Benevoles(
                                           id,
                                           txt_modifInscriptionNom.Text,
                                           txt_modifInscriptionPrenom.Text,
                                           txt_modifInscriptionAdresse.Text,
                                           txt_modifInscriptionNumTel.Text,
                                           cbx_modifInscreptionType.Text,
                                           txt_modifInscriptionMail.Text
                                            );
                            bs.ajoutdbParticipant(); // ajout le benevole en bdd
                            lesParticipants.Add(bs); // ajout le benevole a la liste d'inscript 

                            txt_modifInscriptionMail.Text = "";
                            int i = 0;
                            while (i < CLB_inscriptionModificationAtelier.CheckedItems.Count)
                            {
                                Atelier unA;
                                unA = lesAteliers.ElementAt(CLB_inscriptionModificationAtelier.CheckedIndices[i]);
                                bs.ajouterAtelier(unA);
                                i++;
                            }
                            bs.inscriptiondbParticipe();  // permets l'inscription en bdd table participer
                        }
                        else // construit un objet Participant uniquement.
                        {

                            Participant pt = new Participant(
                                            id,
                                            txt_modifInscriptionNom.Text,
                                            txt_modifInscriptionPrenom.Text,
                                            txt_modifInscriptionAdresse.Text,
                                            txt_modifInscriptionNumTel.Text,
                                            cbx_modifInscreptionType.Text
                                            );
                            pt.ajoutdbParticipant(); // ajout le Participant en bdd
                            lesParticipants.Add(pt); // ajout le Participant a la liste d'inscript 

                            int i = 0;
                            while (i < CLB_inscriptionModificationAtelier.CheckedItems.Count)
                            {
                                Atelier unA; 
                                unA = lesAteliers.ElementAt(CLB_inscriptionModificationAtelier.CheckedIndices[i]);
                                pt.ajouterAtelier(unA);
                                i++;
                            }
                            pt.inscriptiondbParticipe(); // permets l'inscription en bdd table participer
                        }
                    }
                    #endregion

                    #region modifier un Inscript  
                    else // l'index selectionner n'est pas 0, on modifie donc un inscript ! 
                    { 
                        // verifie si la valeurs de l'objet selectionne est Benevole
                        if (cbx_modifInscreptionType.SelectedItem.Equals("Benevole")) // construit un objet Benevole et Participant
                        {
                            Participant unP = lesParticipants.ElementAt(cbx_inscriptionModif_Id.SelectedIndex - 1);// la collection est decaler de 1 
                            Benevoles bs = (Benevoles)unP;
                            bs.Prenom = txt_modifInscriptionPrenom.Text;
                            bs.Adresse = txt_modifInscriptionAdresse.Text;
                            bs.Portable = txt_modifInscriptionNumTel.Text;
                            bs.Type = cbx_modifInscreptionType.Text;
                            bs.Email = txt_modifInscriptionMail.Text;
                            bs.modifParticipant();

                            unP.LesAtelier.Clear(); // permets de reset la liste d'atelier
                            int i = 0;
                            while (i < CLB_inscriptionModificationAtelier.CheckedItems.Count)
                            {
                                Atelier unA;
                                unA = lesAteliers.ElementAt(CLB_inscriptionModificationAtelier.CheckedIndices[i]);
                                bs.ajouterAtelier(unA);
                                i++;
                            }
                            bs.dbParticipe();

                        }
                        else // construit un objet Participant uniquement.
                        {
                            Participant unP = lesParticipants.ElementAt(cbx_inscriptionModif_Id.SelectedIndex - 1);// la collection est decaler de 1 
                            unP.Prenom = txt_modifInscriptionPrenom.Text;
                            unP.Adresse = txt_modifInscriptionAdresse.Text;
                            unP.Portable = txt_modifInscriptionNumTel.Text;
                            unP.Type = cbx_modifInscreptionType.Text;

                            // modifier le participant 
                            unP.modifParticipant();

                            unP.LesAtelier.Clear(); // permets de reset la liste d'atelier
                            int i = 0;
                            while (i < CLB_inscriptionModificationAtelier.CheckedItems.Count)
                            {
                                Atelier unA;
                                unA = lesAteliers.ElementAt(CLB_inscriptionModificationAtelier.CheckedIndices[i]);
                                unP.ajouterAtelier(unA);
                                i++;
                            }
                            unP.dbParticipe();
                        }
                    }
                    #endregion

                    // remise a 0 des champs du formulaire 
                    txt_modifInscriptionNom.Text = "" ; 
                    txt_modifInscriptionPrenom.Text = "" ; 
                    txt_modifInscriptionAdresse.Text = "" ; 
                    txt_modifInscriptionNumTel.Text = "" ; 
                    txt_modifInscriptionMail.Text = "" ;
                }
                else // il y a un ou plusieurs messages d'erreur a retourner ! 
                {
                    MessageBox.Show("Liste des erreurs rencontrer : " + Environment.NewLine + erreur);
                }
            }
            else
            {
                MessageBox.Show(" un champs n\'est pas renseigné ");
            }
        }
        private void cbx_inscriptionModifNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // on mets un type par defaut pour le cbx
            cbx_modifInscreptionType.SelectedItem = "Participant";

            // on clear le reste 
            txt_modifInscriptionAdresse.Text = "";
            txt_modifInscriptionNom.Text = "";
            txt_modifInscriptionPrenom.Text = "";
            txt_modifInscriptionNumTel.Text = "";
            txt_modifInscriptionMail.Text = "";


            if(cbx_inscriptionModif_Id.SelectedIndex != 0)
            {
                            
                Participant unP = lesParticipants.ElementAt(cbx_inscriptionModif_Id.SelectedIndex-1);

                txt_modifInscriptionAdresse.Text = unP.Adresse;
                txt_modifInscriptionNom.Text = unP.Nom;
                txt_modifInscriptionPrenom.Text = unP.Prenom;
                txt_modifInscriptionNumTel.Text = unP.Portable;

               
                if (cbx_modifInscreptionType.Items.Contains(unP.Type))
                {
                    cbx_modifInscreptionType.SelectedItem = unP.Type;

                }

                #region nouvelle occurence 
                if (unP.LesAtelier is null)
                {
                   
                }
                else
                { // SelectedValue
                    int i = 0; 
                    while (i < unP.LesAtelier.Count)
                    {
                        
                        int a = 0; // iterateur de la nouvelle boucle 
                        int index = default; // recup le resultat

                        Atelier atelier = unP.LesAtelier[i];

                        while (a <lesAteliers.Count)
                        {
                            if (lesAteliers[a].Equals(atelier))
                            {
                                 index = a; 
                            }
                        }
                        
                        CLB_inscriptionModificationAtelier.SetItemChecked(index, true);

                        i++; 
                    }

                }
                #endregion

                if (unP.Type == "Benevole")
                {
                    Benevoles unB = (Benevoles)unP;
                    txt_modifInscriptionMail.Text = unB.Email;
                }
            }

        }
        private void cbx_modifInscreptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_modifInscreptionType.Text == "Benevole")
            {
                txt_modifInscriptionMail.Visible = true;
                lab_modificationInscriptionMail.Visible = true;
            }
            else
            {
                txt_modifInscriptionMail.Visible = false;
                lab_modificationInscriptionMail.Visible = false;
                txt_modifInscriptionMail.Text = "";
            }
        }
        #endregion

        #endregion

        #region Liste 
        private void tabPageListeParticipant_Enter(object sender, EventArgs e)
        {
            try
            {

                int i = 0;
                while (i < lesAteliers.Count())
                {
                    Atelier unA = lesAteliers.ElementAt(i);
                    cbx_choix_liste_Participant.Items.Add(" Atelier : " + unA.Nom);
                    i++;
                }

                cbx_choix_liste_Participant.Items.Add("Tous les participant");
                cbx_choix_liste_Participant.SelectedItem = "Tous les participant";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void tabPageListeParticipant_Click(object sender, EventArgs e)
        {
            // methode inutile ! 
        }
        private void cbx_choix_liste_Participant_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_ListeParticipant.ClearSelection();
            DGV_ListeParticipant.Rows.Clear(); 
            int i = 0;
            if (cbx_choix_liste_Participant.SelectedItem.ToString() == "Tous les participant")
            {
                while (i < lesParticipants.Count)
                {
                    Participant unP = lesParticipants.ElementAt(i);
                    DGV_ListeParticipant.Rows.Add(unP.Id, unP.Type, unP.Nom, unP.Prenom, unP.Adresse);

                    i++; 
                }
            }
            else
            {
                Atelier unA;
                unA = lesAteliers.ElementAt(cbx_choix_liste_Participant.SelectedIndex);
                if (unA.Participants is null)
                {
                    MessageBox.Show("Cette Liste est actuellement vide"); // on informe l'utilisateur du probleme 
                    cbx_choix_liste_Participant.SelectedItem = "Tous les participant"; // on renvoie la liste de tous les participants
                }
                else
                {

                    while (i < unA.Participants.Count())
                    {

                        Participant unP = unA.Participants.ElementAt(i);
                        DGV_ListeParticipant.Rows.Add(unP.Id, unP.Type, unP.Nom, unP.Prenom, unP.Adresse);

                        i++;
                    }
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

        private void tabPageStand_Click(object sender, EventArgs e)
        {

        }

        #region Création Stand
        private void Btn_creationStand_Click(object sender, EventArgs e)
        {
            if (0 != txt_nomStand.Text.Length &&
                0 != txt_montantFacture.Text.Length &&
                0 != txt_Nalle.Text.Length &&
                0 != txt_Nordre.Text.Length &&
                0 != txt_surface.Text.Length 
                )
            {
                DAOStand DAOdbStand = new DAOStand();

                int id = lesStands.Count; // pour que l'id sont la nouvelle derniere valeur
                id = id + 1 ;

        

                int id_equipement = lesEquipements.Count; // pour que l'id sont la nouvelle derniere valeur
                id = id + 1 ;

                int id_partenaire = 0; 

                if(cbx_connexionReseauFilaire.Checked)
                {
                    connexionReseauFilaire = true;
                }
                else
                {
                    connexionReseauFilaire = false;
                }

                if (cbx_bar.Checked)
                {
                    bar = true;
                }
                else
                {
                    bar = false;
                }
                if (cbx_salonReception.Checked)
                {
                    salonReception = true;
                }
                else
                {
                    salonReception = false;
                }
                if (cbx_cabineEssayage.Checked)
                {
                    cabineEssayage = true;
                }
                else
                {
                    cabineEssayage = false;
                }
                if (cbx_tablesFournis.Checked)
                {
                    tablesFournis = true;
                }
                else
                {
                    tablesFournis = false;
                }

                // DAOStand DAOdbStand = new DAOStand();

                Equipement eq = new Equipement(
                                id_equipement,
                                connexionReseauFilaire,
                                bar,
                                salonReception,
                                cabineEssayage,
                                tablesFournis,
                                tbx_nbrSiege.Text
                                );
                lesEquipements.Add(eq);
                eq.ajoutdbEquipement();
                


                Stand Sd = new Stand(
                                id,
                                txt_Nalle.Text,
                                txt_Nordre.Text,
                                DAOdbStand.bddUpdateID(),
                                txt_montantFacture.Text,
                                txt_nomStand.Text,
                                id_partenaire,
                                txt_surface.Text
                                );
                lesStands.Add(Sd);
                Sd.ajoutdbStand();

                //DAOdbStand.AjouterStand(Sd, eq);

            }
            else
            {
                MessageBox.Show(" Veuillez remplir tous les champs ");
            }

            txt_Nalle.Clear();
            txt_Nordre.Clear();
            txt_montantFacture.Clear();
            txt_nomStand.Clear();
            txt_surface.Clear();
            tbx_nbrSiege.Clear();
            cbx_connexionReseauFilaire.Checked = false;
            cbx_bar.Checked = false;
            cbx_salonReception.Checked = false;
            cbx_cabineEssayage.Checked = false;
            cbx_tablesFournis.Checked = false;

        }

        #endregion

        private void tabPageAteliers_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            // non neccessaire 
        }

        private void cbx_typePartenaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              
        }

        private void txt_montantFacture_TextChanged(object sender, EventArgs e)
        {

        }

        #region Caractère numérique seulement

        private void txt_Nalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractères numériques seulement", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_montantFacture_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractères numériques seulement", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Nordre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractères numériques seulement", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_surface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractères numériques seulement", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void tbx_nbrSiege_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Caractères numériques seulement", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Création Partenaire

        private void Btn_creationPartenaire_Click(object sender, EventArgs e)
        {
            if (0 != txt_nomPartenaire.Text.Length &&
                0 != cbx_typePartenaire.Text.Length )
            {
                DAOPartenaire DAOdbPartenaire = new DAOPartenaire();

                int id_partenaire = lesPartenaires.Count;

                int idTypePartenaire = DAOdbPartenaire.getIdTypePartenaire(cbx_typePartenaire.SelectedItem.ToString());

                Partenaire Part = new Partenaire(
                                id_partenaire,
                                txt_nomPartenaire.Text,
                                idTypePartenaire
                                );
                lesPartenaires.Add(Part);
                Part.ajoutdbPartenaire();

            }
            else
            {
                MessageBox.Show(" Veuillez remplir tous les champs ");
            }

            txt_nomPartenaire.Clear();
            cbx_typePartenaire.Items.Clear();
            cbx_typePartenaire.ResetText();

            
        }
        #endregion

        #region Affectation Stand
        private void Btn_affectationStand_Click(object sender, EventArgs e)
        {

            if (0 != cbx_stands.Text.Length &&
                0 != cbx_partenaire.Text.Length)
            {
                DAOPartenaire DAOdbPartenaire = new DAOPartenaire();
                DAOStand DAOdbStand = new DAOStand();


                int idStand = DAOdbStand.getIdStand(cbx_stands.SelectedItem.ToString());

                int idPartenaire = DAOdbPartenaire.getIdPartenaire(cbx_partenaire.SelectedItem.ToString());

                String montantDepart = DAOdbStand.getMontantStand(cbx_stands.SelectedItem.ToString());

                int montantDepartInt = int.Parse(montantDepart);

                String NomTypePartenaire = DAOdbPartenaire.getNomTypePartenaire(cbx_stands.SelectedItem.ToString());

                if (NomTypePartenaire == "equipementier")
                {
                    String montantFinal = montantDepart;

                    DAOdbStand.ModifierStand(idPartenaire, montantFinal, idStand);
                }
                else
                {
                    int montantFinalInt = montantDepartInt * 2;
                    String montantFinal = montantFinalInt.ToString();

                    DAOdbStand.ModifierStand(idPartenaire, montantFinal, idStand);
                }

                cbx_stands.Items.Clear();
                cbx_partenaire.Items.Clear();



            }
            else
            {
                MessageBox.Show(" Veuillez remplir tous les champs ");
            }

        }

        #endregion

        private void cbx_stands_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbx_partenaire_SelectedValueChanged(object sender, EventArgs e)
        {
            DAOStand DAOdbStand = new DAOStand();
            DAOPartenaire DAOdbPartenaire = new DAOPartenaire();

            String montantDepart = DAOdbStand.getMontantStand(cbx_stands.SelectedItem.ToString());

            String NomTypePartenaire = DAOdbPartenaire.getNomTypePartenaire(cbx_stands.SelectedItem.ToString());

            int montantDepartInt = int.Parse(montantDepart);

            if (NomTypePartenaire == "equipementier")
            {
                String montantFinal = montantDepart;
                lbl_prix.Text = montantFinal;
            }
            else 
            {
                int montantFinalInt = montantDepartInt * 2;
                String montantFinal = montantFinalInt.ToString();

                lbl_prix.Text = montantFinal;
            }

            
        }
    }
}
