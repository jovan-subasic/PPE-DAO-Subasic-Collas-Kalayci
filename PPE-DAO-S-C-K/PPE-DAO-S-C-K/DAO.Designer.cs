namespace PPE_DAO_S_C_K
{
    partial class Maison_des_ligues
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAteliers = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbx_ChoixAteliers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageStand = new System.Windows.Forms.TabPage();
            this.tabPageInscription = new System.Windows.Forms.TabPage();
            this.tabPageListeParticipant = new System.Windows.Forms.TabPage();
            this.lab_Choix_Liste = new System.Windows.Forms.Label();
            this.cbx_choix_liste_Participant = new System.Windows.Forms.ComboBox();
            this.DGV_ListeParticipant = new System.Windows.Forms.DataGridView();
            this.ID_Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Type_Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Nom_Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Prenom_Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Adresse_Participant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageAteliers.SuspendLayout();
            this.tabPageListeParticipant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ListeParticipant)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAteliers);
            this.tabControl1.Controls.Add(this.tabPageStand);
            this.tabControl1.Controls.Add(this.tabPageInscription);
            this.tabControl1.Controls.Add(this.tabPageListeParticipant);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(910, 498);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAteliers
            // 
            this.tabPageAteliers.Controls.Add(this.textBox3);
            this.tabPageAteliers.Controls.Add(this.label4);
            this.tabPageAteliers.Controls.Add(this.textBox2);
            this.tabPageAteliers.Controls.Add(this.label3);
            this.tabPageAteliers.Controls.Add(this.label2);
            this.tabPageAteliers.Controls.Add(this.textBox1);
            this.tabPageAteliers.Controls.Add(this.cbx_ChoixAteliers);
            this.tabPageAteliers.Controls.Add(this.label1);
            this.tabPageAteliers.Location = new System.Drawing.Point(4, 22);
            this.tabPageAteliers.Name = "tabPageAteliers";
            this.tabPageAteliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAteliers.Size = new System.Drawing.Size(902, 472);
            this.tabPageAteliers.TabIndex = 0;
            this.tabPageAteliers.Text = "Ateliers";
            this.tabPageAteliers.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(135, 195);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre de Places";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 159);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Thème";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // cbx_ChoixAteliers
            // 
            this.cbx_ChoixAteliers.FormattingEnabled = true;
            this.cbx_ChoixAteliers.Location = new System.Drawing.Point(135, 23);
            this.cbx_ChoixAteliers.Name = "cbx_ChoixAteliers";
            this.cbx_ChoixAteliers.Size = new System.Drawing.Size(121, 21);
            this.cbx_ChoixAteliers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choix Des Ateliers";
            // 
            // tabPageStand
            // 
            this.tabPageStand.Location = new System.Drawing.Point(4, 22);
            this.tabPageStand.Name = "tabPageStand";
            this.tabPageStand.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStand.Size = new System.Drawing.Size(902, 472);
            this.tabPageStand.TabIndex = 1;
            this.tabPageStand.Text = "Création de Stand";
            this.tabPageStand.UseVisualStyleBackColor = true;
            // 
            // tabPageInscription
            // 
            this.tabPageInscription.Location = new System.Drawing.Point(4, 22);
            this.tabPageInscription.Name = "tabPageInscription";
            this.tabPageInscription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInscription.Size = new System.Drawing.Size(902, 472);
            this.tabPageInscription.TabIndex = 2;
            this.tabPageInscription.Text = "Inscription";
            this.tabPageInscription.UseVisualStyleBackColor = true;
            // 
            // tabPageListeParticipant
            // 
            this.tabPageListeParticipant.Controls.Add(this.lab_Choix_Liste);
            this.tabPageListeParticipant.Controls.Add(this.cbx_choix_liste_Participant);
            this.tabPageListeParticipant.Controls.Add(this.DGV_ListeParticipant);
            this.tabPageListeParticipant.Location = new System.Drawing.Point(4, 22);
            this.tabPageListeParticipant.Name = "tabPageListeParticipant";
            this.tabPageListeParticipant.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageListeParticipant.Size = new System.Drawing.Size(902, 472);
            this.tabPageListeParticipant.TabIndex = 3;
            this.tabPageListeParticipant.Text = "Liste ";
            this.tabPageListeParticipant.UseVisualStyleBackColor = true;
            // 
            // lab_Choix_Liste
            // 
            this.lab_Choix_Liste.AutoSize = true;
            this.lab_Choix_Liste.Cursor = System.Windows.Forms.Cursors.Default;
            this.lab_Choix_Liste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lab_Choix_Liste.Location = new System.Drawing.Point(210, 95);
            this.lab_Choix_Liste.Name = "lab_Choix_Liste";
            this.lab_Choix_Liste.Size = new System.Drawing.Size(132, 20);
            this.lab_Choix_Liste.TabIndex = 2;
            this.lab_Choix_Liste.Text = "Choisir la Liste :";
            // 
            // cbx_choix_liste_Participant
            // 
            this.cbx_choix_liste_Participant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.cbx_choix_liste_Participant.FormattingEnabled = true;
            this.cbx_choix_liste_Participant.Location = new System.Drawing.Point(348, 87);
            this.cbx_choix_liste_Participant.Name = "cbx_choix_liste_Participant";
            this.cbx_choix_liste_Participant.Size = new System.Drawing.Size(206, 28);
            this.cbx_choix_liste_Participant.TabIndex = 1;
            // 
            // DGV_ListeParticipant
            // 
            this.DGV_ListeParticipant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ListeParticipant.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Participant,
            this.col_Type_Participant,
            this.col_Nom_Participant,
            this.Col_Prenom_Participant,
            this.Col_Adresse_Participant});
            this.DGV_ListeParticipant.Location = new System.Drawing.Point(149, 268);
            this.DGV_ListeParticipant.Name = "DGV_ListeParticipant";
            this.DGV_ListeParticipant.Size = new System.Drawing.Size(575, 150);
            this.DGV_ListeParticipant.TabIndex = 0;
            // 
            // ID_Participant
            // 
            this.ID_Participant.HeaderText = "N°";
            this.ID_Participant.Name = "ID_Participant";
            this.ID_Participant.Width = 50;
            // 
            // col_Type_Participant
            // 
            this.col_Type_Participant.HeaderText = "Type";
            this.col_Type_Participant.Name = "col_Type_Participant";
            this.col_Type_Participant.Width = 65;
            // 
            // col_Nom_Participant
            // 
            this.col_Nom_Participant.HeaderText = "Nom";
            this.col_Nom_Participant.Name = "col_Nom_Participant";
            // 
            // Col_Prenom_Participant
            // 
            this.Col_Prenom_Participant.HeaderText = "Prenom";
            this.Col_Prenom_Participant.Name = "Col_Prenom_Participant";
            // 
            // Col_Adresse_Participant
            // 
            this.Col_Adresse_Participant.HeaderText = "Adresse";
            this.Col_Adresse_Participant.Name = "Col_Adresse_Participant";
            // 
            // Maison_des_ligues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 495);
            this.Controls.Add(this.tabControl1);
            this.Name = "Maison_des_ligues";
            this.Text = "Maison des ligues";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAteliers.ResumeLayout(false);
            this.tabPageAteliers.PerformLayout();
            this.tabPageListeParticipant.ResumeLayout(false);
            this.tabPageListeParticipant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ListeParticipant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAteliers;
        private System.Windows.Forms.TabPage tabPageStand;
        private System.Windows.Forms.TabPage tabPageInscription;
        private System.Windows.Forms.ComboBox cbx_ChoixAteliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPageListeParticipant;
        private System.Windows.Forms.Label lab_Choix_Liste;
        private System.Windows.Forms.ComboBox cbx_choix_liste_Participant;
        private System.Windows.Forms.DataGridView DGV_ListeParticipant;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Type_Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Nom_Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Prenom_Participant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Adresse_Participant;
    }
}

