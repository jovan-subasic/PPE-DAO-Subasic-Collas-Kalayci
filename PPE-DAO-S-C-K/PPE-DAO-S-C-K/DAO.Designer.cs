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
            this.tabPageStand = new System.Windows.Forms.TabPage();
            this.tabPageInscription = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAteliers);
            this.tabControl1.Controls.Add(this.tabPageStand);
            this.tabControl1.Controls.Add(this.tabPageInscription);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(395, 325);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageAteliers
            // 
            this.tabPageAteliers.Location = new System.Drawing.Point(4, 22);
            this.tabPageAteliers.Name = "tabPageAteliers";
            this.tabPageAteliers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAteliers.Size = new System.Drawing.Size(387, 299);
            this.tabPageAteliers.TabIndex = 0;
            this.tabPageAteliers.Text = "Ateliers";
            this.tabPageAteliers.UseVisualStyleBackColor = true;
            // 
            // tabPageStand
            // 
            this.tabPageStand.Location = new System.Drawing.Point(4, 22);
            this.tabPageStand.Name = "tabPageStand";
            this.tabPageStand.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStand.Size = new System.Drawing.Size(387, 299);
            this.tabPageStand.TabIndex = 1;
            this.tabPageStand.Text = "Création de Stand";
            this.tabPageStand.UseVisualStyleBackColor = true;
            // 
            // tabPageInscription
            // 
            this.tabPageInscription.Location = new System.Drawing.Point(4, 22);
            this.tabPageInscription.Name = "tabPageInscription";
            this.tabPageInscription.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInscription.Size = new System.Drawing.Size(387, 299);
            this.tabPageInscription.TabIndex = 2;
            this.tabPageInscription.Text = "Inscription";
            this.tabPageInscription.UseVisualStyleBackColor = true;
            // 
            // Maison_des_ligues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 328);
            this.Controls.Add(this.tabControl1);
            this.Name = "Maison_des_ligues";
            this.Text = "Maison des ligues";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAteliers;
        private System.Windows.Forms.TabPage tabPageStand;
        private System.Windows.Forms.TabPage tabPageInscription;
    }
}

