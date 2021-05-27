using System;
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
        private List<Theme> lesThemes = new List<Theme>();

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

            initBddDonnee();
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
                cbx_stands.Items.Add(Stand.Nom);
            }

            
        }
        #endregion

        #region Ateliers
        private void tabPageAteliers_Enter(object sender, EventArgs e)
        {
            if (cbx_ChoixAteliers.Items.Count < lesAteliers.Count())
            {

                try
                {

                    int i = 0;
                    while (i < lesAteliers.Count())
                    {
                        Atelier unA = lesAteliers.ElementAt(i);
                        cbx_ChoixAteliers.Items.Add(unA.Nom);
                        i++;
                    }

                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btn_afficheLesAteliers_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_DGAteliers_Click_1(object sender, EventArgs e)
        {
            
            /*try
            {

                int i = 3;


                DAOTheme dt = new DAOTheme();
                Theme unT = new Theme();
                List<String> laListe = new List<String>();
                i = 1;
                foreach (Theme unT2 in lesThemes)
                {
                    unT2.allThemes2(i);
                    lab_ThemeAteliers.Text = unT2.Nom;
                    //lab_ThemeAteliers.Text = "gr0000000000000000000";
                    i++;
                }
                    
             
                    
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        /*private void btn_afficheTheme_Click(object sender, EventArgs e)
        {
            cbx_ChoixAteliers.Items.Add("ggfh");
            lab_ThemeAteliers.Text = "gr";
        }*/
        private void btn_afficheTheme_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbx_ChoixAteliers.Text))
            {
                System.Windows.Forms.MessageBox.Show("Veuillez choisir un atelier");
            }

            else
            {
                foreach (Atelier unA in lesAteliers)
                {
                    if (cbx_ChoixAteliers.SelectedItem.ToString() == unA.Nom)
                    {
                        DGV_ListeParticipant.ClearSelection();
                        DGV_ListeParticipant.Rows.Clear();
                        DGV_Ateliers.Rows.Add(unA.Id, unA.Nom, unA.Capacite, unA.Intervenant);
                        txt_Capacite.Text = unA.Capacite.ToString();
                       // lab_ThemeAteliers.Text = unA.Nom;
                        lab_nomAtelier.Text = unA.Nom;
                        string ateliers = cbx_ChoixAteliers.Text;
                        switch (ateliers)
                        {
                            case "La Maison des Ligues et son projet":
                                lab_ThemeAteliers.Text = "-Diagnostic et identification des critères de la ligue " + Environment.NewLine + "-Analyse systémique de l'environnement" + Environment.NewLine + "-Méthodologie de mise en oeuvre du projet " +
                                                    Environment.NewLine + "-Actions solidaires et innovantes " + Environment.NewLine + "-Financement Outils et documentation " + Environment.NewLine + "-Valoriser et communiquer sur le projet";
                                break;

                            case "Observatoire du metier des sports":
                                lab_ThemeAteliers.Text = "-Observation et analyse de l'encadrement actuel" + Environment.NewLine + "-Proposition de nouveaux schémas d'organisation " + Environment.NewLine + "-Profils types " + Environment.NewLine + "-Pratiques innovantes " + Environment.NewLine + "-Critères et seuils nécessaires à la pérennité de l'emploi " + Environment.NewLine + "-Avantages et inconvénients du métier d'enseignant ";
                                break;

                            case "Le fonctionnement de la Maison des Ligues":
                                lab_ThemeAteliers.Text = "Création (obligations légales) " + Environment.NewLine + "-Gestion du personnel, de la structure et des conflits " + Environment.NewLine + "-Relations internes, externes avec les départements et les fédérations " + Environment.NewLine + "-Conventions " + Environment.NewLine + "-Partenariats";
                                break;

                            case "Le sport lorrain et les collectivités":
                                lab_ThemeAteliers.Text = "-Relations entre les collectivités et les clubs " + Environment.NewLine + "-Subventions" + Environment.NewLine + "-Communication";
                                break;
                            case "Les outils à disposition et remis aux clubs":
                                lab_ThemeAteliers.Text = "-Logiciels de gestion des compétitions" + Environment.NewLine + "-Présentation du document << arbitrage en images >>" + Environment.NewLine + "-Labellisation des clubs" + Environment.NewLine + "-Aménagement des équipements" + Environment.NewLine;
                                break;
                            case "Développement durable":
                                lab_ThemeAteliers.Text = "-Les enjeux climatiques, énergétiques et économiques" + Environment.NewLine + "-Sport et développement durable" + Environment.NewLine + "-Démarches fédérales" + Environment.NewLine + "-Echanges";
                                break;
                            default:
                                lab_ThemeAteliers.Text = "";
                                break;
                        }
                    }
                   


                }

                
            }

        }
        #endregion

        #region Inscription 
        private void tabPageInscription_Enter(object sender, EventArgs e)
        {
            int i = 0;
            int unId;

            if(cbx_inscriptionModif_Id.Items.Count < lesParticipants.Count()+1)
            {
                // on s'assure qu'on ne va pas avoir de duplication de la liste 
                cbx_inscriptionModif_Id.Items.Clear(); 

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
                Regex myString = new Regex(@"^\s*[a-zA-Z]+(\s?[-]\s?[a-zA-Z]+)?\s*$", RegexOptions.IgnoreCase);

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

                }if (CLB_inscriptionModificationAtelier.CheckedItems.Count > 5 )
                {// si le type selectionner n'existe pas 
                    erreur += Environment.NewLine + " erreur : nombres d'ateliers inscrit trop elevez ( + de 5) ! "; 

                }if (cbx_modifInscreptionType.SelectedItem.Equals("Benevole") && CLB_inscriptionModificationAtelier.CheckedItems.Count < 1 )
                {// si le nombre d'atelier est inferieur a 1 pour un Benevole 
                    erreur += Environment.NewLine + " erreur : un Benevoles doit être liée a au moins un atelier ! "; 

                }if (cbx_modifInscreptionType.SelectedItem.Equals("Benevole") && myMail.IsMatch(txt_modifInscriptionMail.Text) == false)
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

                        if (cbx_modifInscreptionType.SelectedItem.Equals("Benevole")) // verif s'il s'agit d'un Benevole
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
                        // remise a 0 des champs du formulaire 
                        txt_modifInscriptionNom.Text = "";
                        txt_modifInscriptionPrenom.Text = "";
                        txt_modifInscriptionAdresse.Text = "";
                        txt_modifInscriptionNumTel.Text = "";
                        txt_modifInscriptionMail.Text = "";
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
                            String exMail = bs.Email; 
                            bs.Prenom = txt_modifInscriptionPrenom.Text;
                            bs.Adresse = txt_modifInscriptionAdresse.Text;
                            bs.Portable = txt_modifInscriptionNumTel.Text;
                            bs.Type = cbx_modifInscreptionType.Text;
                            bs.Email = txt_modifInscriptionMail.Text;

                            bs.LesAtelier.Clear(); // permets de reset la liste d'atelier
                            int i = 0;
                            while (i < CLB_inscriptionModificationAtelier.CheckedItems.Count)
                            {
                                Atelier unA;
                                unA = lesAteliers.ElementAt(CLB_inscriptionModificationAtelier.CheckedIndices[i]);
                                bs.ajouterAtelier(unA);
                                i++;
                            }
                            bs.modifParticipant();
                            bs.dbParticipe(exMail);

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
                        MessageBox.Show(" Modification effectué avec succès ! "); 
                    }
                    #endregion


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

            int rebout = 0; 
            while (rebout < CLB_inscriptionModificationAtelier.Items.Count)
            {
                CLB_inscriptionModificationAtelier.SetItemChecked(rebout, false);
                rebout++; 
            }

            if (cbx_inscriptionModif_Id.SelectedIndex != 0)
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
                            if (lesAteliers[a].Id.Equals(atelier.Id))
                            {
                                 index = a;
                                 
                            }
                            a++;
                        }
                        
                        CLB_inscriptionModificationAtelier.SetItemChecked(index, true);

                        i++; 
                    }
                   
                }
                

                if (unP.Type == "Benevole")
                {
                    Benevoles unB = (Benevoles)unP;
                    txt_modifInscriptionMail.Text = unB.Email;
                }/**/
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
                if(cbx_choix_liste_Participant.Items.Count < lesAteliers.Count())
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

                    String nomAteliers = ""; 
                    int indexA = 0; 
                    while (indexA < unP.LesAtelier.Count)
                    {
                        Atelier collectionA = unP.LesAtelier.ElementAt(indexA);
                        nomAteliers += collectionA.Id + " : "+ collectionA.Nom + Environment.NewLine;

                        indexA++; 
                    }
                    
                    DGV_ListeParticipant.Rows.Add(unP.Id, unP.Type, unP.Nom, unP.Prenom, unP.Adresse, nomAteliers);

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

                        int indexP = 0; 
                        while (indexP < lesParticipants.Count)
                        {
                            if(unP.Id.Equals(lesParticipants.ElementAt(indexP).Id)) {
                                unP = lesParticipants.ElementAt(indexP);
                            }
                            indexP++; 
                        }
                        String nomAteliers = "";
                        int indexA = 0;
                        while (indexA < unP.LesAtelier.Count)
                        {
                            Atelier collectionA = unP.LesAtelier.ElementAt(indexA);
                            nomAteliers += collectionA.Id + " : " + collectionA.Nom + Environment.NewLine;

                            indexA++;
                        }
                        DGV_ListeParticipant.Rows.Add(unP.Id, unP.Type, unP.Nom, unP.Prenom, unP.Adresse, nomAteliers);

                        i++;
                    }
                }
            }

            
        }
        #endregion

        #region Méthodes  

        public void initBddDonnee()
        {
            Participant unP = new Participant();
            Atelier unA = new Atelier();

            // on verifie seulement sur 2 tables de la bdd pour savoir si elle est vide 
            if (unP.allParticipant().Count() < 1 && unA.allAteliers().Count() < 1)
            {
              insertJeuDeTest(); 
            }
        }

        public void remplirList()
        {
            Participant unP = new Participant();
            Atelier unA = new Atelier();
            Theme unT = new Theme();

            lesParticipants = unP.allParticipant();
            lesAteliers = unA.allAteliers();
            lesThemes = unT.allThemes();
        }
        public void insertJeuDeTest()
        {
            DAOFactory db = new DAOFactory();
            db.connecter();

            /************** Attention ******************/
            /* pour pouvoir reutiliser SET IDENTITY_INSERT dbo.uneTable on; 
            /* il faut d'abord utiliser SET IDENTITY_INSERT dbo.uneTable off; 
            /*
            /* de toute façon preferer toujours utiliser SET IDENTITY_INSERT dbo.uneTable off;par securiter 
            */
            // on s'assure qu'il n'y a pas de donnée, puis en les recreers 
            String req = "" 
            + "DELETE FROM dbo.atelier; "
            + "DELETE FROM Date; "
            + "DELETE FROM equipements; "
            + "DELETE FROM intervenir; "
            + "DELETE FROM Intervention; "
            + "DELETE FROM partenaires; "
            + "DELETE FROM participants; "
            + "DELETE FROM participer; "
            + "DELETE FROM stands; "
            + "DELETE FROM themes; "
            + "DELETE FROM typePartenaire; "

            + "ALTER TABLE dbo.themes ALTER COLUMN nom VARCHAR(350) NOT NULL; "


            + "SET IDENTITY_INSERT dbo.participants on;  "

            + "INSERT INTO ASL.dbo.participants (id, nom, prenom, adresse, portable, type, nombre_Participation) VALUES"
            + "(1, 'Cypth', 'Patrick', '12 rue des Participants', '0147258369', 'Participant', 0), "
            + "(2, 'Vole', 'Bene', '12 rue des Benevoles', '0123456789', 'Benevole', 0), "
            + "(3, 'Lee', 'Paul', '12 avenue fairy', '0369258741', 'Intervenant', 0), "
            + "(4, 'Dupon', 'Valentin', '12 rue des Intervenant', '0987654321', 'Intervenant', 0), "
            + "(5, 'hide', 'yoshi', '12 rue des Marioles', '0147963285', 'Participant', 0), "
            + "(6, 'Durand', 'Richard', '12 rue des halles', '0987654321', 'Participant', 0); "

             + "SET IDENTITY_INSERT dbo.participants off;  "


            + " SET IDENTITY_INSERT dbo.atelier on; "

            + "INSERT INTO ASL.dbo.atelier(id, nom, capacite, id_participants) VALUES"
            + "(1, 'La Maison des Ligues et son projet', 50, 3), "
            + "(2, 'Observatoire du metier des sports', 80, 3), "
            + "(3, 'Le fonctionnement de la Maison des Ligues', 70, 3), "
            + "(4, 'Le sport lorrain et les collectivités', 60, 4), "
            + "(5, 'Les outils à disposition et remis aux clubs', 40, 5), "
            + "(6, 'Développement durable', 90, 1); "

            + " SET IDENTITY_INSERT dbo.atelier off; "

            + "INSERT INTO ASL.dbo.Date (id, date_debut, date_fin) VALUES"
            + "(1, 2021-09-12-8-00-00, 2021-09-12-14-00-00), "
            + "(2, 2021-09-12-14-00-00, 2021-09-12-20-00-00), "
            + "(3, 2021-09-13-8-00-00, 2021-09-13-14-00-00), "
            + "(4, 2021-09-13-14-00-00, 2021-09-13-20-00-00), "
            + "(5, 2021-09-14-8-00-00, 2021-09-14-14-00-00), "
            + "(6, 2021-09-14-14-00-00, 2021-09-14-20-00-00); "


            + " SET IDENTITY_INSERT dbo.equipements on; "
            + "INSERT INTO ASL.dbo.equipements (id, connexionReseauFilaire, bar, salonReception, cabineEssayage, nbrSiege, tablesFournis) VALUES"
            + "(1, 1, 1, 0, 0, 10, 1), "
            + "(2, 1, 0, 0, 0, 15, 1), "
            + "(3, 1, 0, 0, 0, 7, 1), "
            + "(4, 1, 1, 1, 1, 20, 1); "
            + " SET IDENTITY_INSERT dbo.equipements off; "


            + "INSERT INTO ASL.dbo.Intervention (email, id) VALUES"
            + "('paul.lee@yahoo.com', 1), "
            + "('paul.lee@free.fr', 2), "
            + "('paul.lee@orange.com', 3), "
            + "('valentin.dupon@yahoo.com', 4), "
            + "('valentin.dupon@free.fr', 5), "
            + "('valentin.dupon@orange.com', 6); "


            + "INSERT INTO ASL.dbo.intervenir (email, id) VALUES"
            + "('paul.lee@yahoo.com', 3), "
            + "('paul.lee@free.fr', 3), "
            + "('paul.lee@orange.com', 3), "
            + "('valentin.dupon@yahoo.com', 4), "
            + "('valentin.dupon@free.fr', 4), "
            + "('valentin.dupon@orange.com', 4); "


            + "INSERT INTO ASL.dbo.typePartenaire (id, nom) VALUES"
            + "(1, 'equipementier'), "
            + "(2, 'club'); "

            + " SET IDENTITY_INSERT dbo.partenaires on; "
            + "INSERT INTO ASL.dbo.partenaires (id, nom, typePartenaire) VALUES"
            + "(1, 'Partenaire1', 1), "
            + "(2, 'Partenaire2', 1), "
            + "(3, 'Partenaire3', 2), "
            + "(4, 'Partenaire4', 2); "
            + " SET IDENTITY_INSERT dbo.partenaires off; "


            + "INSERT INTO ASL.dbo.participer (id, id_atelier) VALUES"
            + "(1, 1), "
            + "(1, 2), "
            + "(1, 3), "
            + "(1, 4), "
            + "(5, 5), "
            + "(5, 6), "
            + "(6, 1), "
            + "(6, 6); "


            + " SET IDENTITY_INSERT dbo.stands on; "
            + "INSERT INTO ASL.dbo.stands (id, idAllee, idOrdre, equipement, montantFacture, nom, id_partenaires, surface) VALUES"
            + "(1, 1, 1, 1, 150, 'Stand1', 0, 30), "
            + "(2, 2, 2, 2, 220, 'Stand2', 0, 45), "
            + "(3, 3, 3, 3, 110, 'Stand3', 0, 25), "
            + "(4, 4, 4, 4, 400, 'Stand4', 0, 60); "
            + " SET IDENTITY_INSERT dbo.stands off; "


            + "INSERT INTO ASL.dbo.posseder (id, id_stands) VALUES"
            + "(1, 1), "
            + "(2, 2), "
            + "(3, 3), "
            + "(4, 4); "


            + "INSERT INTO ASL.dbo.themes (nom, id_atelier) VALUES"
            + "('-Diagnostic et identification des critères de la ligue - Analyse systémique de l environnement - Méthodologie de mise en oeuvre du projet - Actions solidaires et innovantes - Financement Outils et documentation - Valoriser et communiquer sur le projet',1), "
            + "('-Observation et analyse de l encadrement actuel -Proposition de nouveaux schémas d organisation -Profils types -Pratiques innovantes -Critères et seuils nécessaires à la pérennité de l emploi -Avantages et inconvénients du métier d enseignant', 2), "
            + "('-Création (obligations légales) -Gestion du personnel, de la structure et des conflits -Relations internes, externes avec les départements et les fédérations -Conventions -Partenariats', 3), "
            + "('-Relations entre les collectivités et les clubs -Subventions -Communication', 4), "
            + "('-Logiciels de gestion des compétitions -Présentation du document << arbitrage en images >> -Labellisation des clubs -Aménagement des équipements', 5), "
            + "('-Les enjeux climatiques, énergétiques et économiques -Sport et développement durable -Démarches fédérales -Echanges', 6); "


            ;

            db.execSQLWrite(req);
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

            cbx_partenaire.Items.Clear();
            cbx_partenaire.ResetText();

            foreach (var Partenaire in lesPartenaires)
            {
                cbx_partenaire.Items.Add(Partenaire.Nom);
            }

            cbx_stands.Items.Clear();
            cbx_stands.ResetText();

            foreach (var Stand in lesStands)
            {
                cbx_stands.Items.Add(Stand.Nom);
            }

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
            cbx_typePartenaire.ResetText();

            cbx_partenaire.Items.Clear();
            cbx_partenaire.ResetText();

            foreach (var Partenaire in lesPartenaires)
            {
                cbx_partenaire.Items.Add(Partenaire.Nom);
            }

            cbx_stands.Items.Clear();
            cbx_stands.ResetText();

            foreach (var Stand in lesStands)
            {
                cbx_stands.Items.Add(Stand.Nom);
            }

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

                String NomTypePartenaire = DAOdbPartenaire.getNomTypePartenaire(cbx_partenaire.SelectedItem.ToString());

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

            }
            else
            {
                MessageBox.Show(" Veuillez remplir tous les champs ");
            }
            cbx_stands.ResetText();
            cbx_partenaire.ResetText();
  
        }

        #endregion


        private void cbx_stands_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        #region SelectedValueChanged 

        private void cbx_partenaire_SelectedValueChanged(object sender, EventArgs e)
        {
            if (0 != cbx_stands.Text.Length)
            {
                DAOStand DAOdbStand = new DAOStand();
                DAOPartenaire DAOdbPartenaire = new DAOPartenaire();

                String montantDepart = DAOdbStand.getMontantStand(cbx_stands.SelectedItem.ToString());

                String NomTypePartenaire = DAOdbPartenaire.getNomTypePartenaire(cbx_partenaire.SelectedItem.ToString());

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
            else
            {
                MessageBox.Show(" Veuillez selectionner un Stand ");
            }
        }

        #endregion

        private void GrB_creationPartenaire_Enter(object sender, EventArgs e)
        {

        }

        private void btn_afficheAteliers_Click_1(object sender, EventArgs e)
        {

        }

        private void lab_ThemeAteliers_Click(object sender, EventArgs e)
        {

        }

        private void DGV_ListeParticipant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // inutil 
        }



        /* private void btn_afficheLesAteliers_Click(object sender, EventArgs e)
         {

         }*/

        /* private void btn_DGAteliers_Click_1(object sender, EventArgs e)
         {

         }*/
    }
}
