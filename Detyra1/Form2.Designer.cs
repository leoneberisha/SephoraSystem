using System;

namespace Detyra1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fornitoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shihToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shikoKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shihToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mascaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtoToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.shihToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lipstickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtoBuzekuqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shihToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.blushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtoToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.shihToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.produktetToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.shtoprodukteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shihProdukteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shtoPorosiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shikoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri Light", 20F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fornitoreToolStripMenuItem,
            this.kategoriteToolStripMenuItem,
            this.produktetToolStripMenuItem1,
            this.porositeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 49);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fornitoreToolStripMenuItem
            // 
            this.fornitoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shihToolStripMenuItem1});
            this.fornitoreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.fornitoreToolStripMenuItem.Name = "fornitoreToolStripMenuItem";
            this.fornitoreToolStripMenuItem.Size = new System.Drawing.Size(162, 45);
            this.fornitoreToolStripMenuItem.Text = "Furnitore";
            // 
            // shihToolStripMenuItem1
            // 
            this.shihToolStripMenuItem1.Name = "shihToolStripMenuItem1";
            this.shihToolStripMenuItem1.Size = new System.Drawing.Size(224, 46);
            this.shihToolStripMenuItem1.Text = "Shih";
            this.shihToolStripMenuItem1.Click += new System.EventHandler(this.shihFurnitore);
            // 
            // kategoriteToolStripMenuItem
            // 
            this.kategoriteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shikoKategoriToolStripMenuItem,
            this.mascaraToolStripMenuItem,
            this.lipstickToolStripMenuItem,
            this.blushToolStripMenuItem});
            this.kategoriteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.kategoriteToolStripMenuItem.Name = "kategoriteToolStripMenuItem";
            this.kategoriteToolStripMenuItem.Size = new System.Drawing.Size(174, 45);
            this.kategoriteToolStripMenuItem.Text = "Kategorite";
            // 
            // shikoKategoriToolStripMenuItem
            // 
            this.shikoKategoriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shihToolStripMenuItem});
            this.shikoKategoriToolStripMenuItem.Name = "shikoKategoriToolStripMenuItem";
            this.shikoKategoriToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.shikoKategoriToolStripMenuItem.Text = "Fondatine";
            // 
            // shihToolStripMenuItem
            // 
            this.shihToolStripMenuItem.Name = "shihToolStripMenuItem";
            this.shihToolStripMenuItem.Size = new System.Drawing.Size(224, 46);
            this.shihToolStripMenuItem.Text = "Shih";
            this.shihToolStripMenuItem.Click += new System.EventHandler(this.ShihFondatine);
            // 
            // mascaraToolStripMenuItem
            // 
            this.mascaraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shtoToolStripMenuItem2,
            this.shihToolStripMenuItem2});
            this.mascaraToolStripMenuItem.Name = "mascaraToolStripMenuItem";
            this.mascaraToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.mascaraToolStripMenuItem.Text = "Maskara";
            // 
            // shtoToolStripMenuItem2
            // 
            this.shtoToolStripMenuItem2.Name = "shtoToolStripMenuItem2";
            this.shtoToolStripMenuItem2.Size = new System.Drawing.Size(172, 46);
            this.shtoToolStripMenuItem2.Text = "Shto";
            this.shtoToolStripMenuItem2.Click += new System.EventHandler(this.ShtoMaskara);
            // 
            // shihToolStripMenuItem2
            // 
            this.shihToolStripMenuItem2.Name = "shihToolStripMenuItem2";
            this.shihToolStripMenuItem2.Size = new System.Drawing.Size(172, 46);
            this.shihToolStripMenuItem2.Text = "Shih";
            this.shihToolStripMenuItem2.Click += new System.EventHandler(this.ShihMaskara);
            // 
            // lipstickToolStripMenuItem
            // 
            this.lipstickToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shtoBuzekuqToolStripMenuItem,
            this.shihToolStripMenuItem3});
            this.lipstickToolStripMenuItem.Name = "lipstickToolStripMenuItem";
            this.lipstickToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.lipstickToolStripMenuItem.Text = "Buzekuq";
            // 
            // shtoBuzekuqToolStripMenuItem
            // 
            this.shtoBuzekuqToolStripMenuItem.Name = "shtoBuzekuqToolStripMenuItem";
            this.shtoBuzekuqToolStripMenuItem.Size = new System.Drawing.Size(172, 46);
            this.shtoBuzekuqToolStripMenuItem.Text = "Shto";
            this.shtoBuzekuqToolStripMenuItem.Click += new System.EventHandler(this.ShtoBuzekuq);
            // 
            // shihToolStripMenuItem3
            // 
            this.shihToolStripMenuItem3.Name = "shihToolStripMenuItem3";
            this.shihToolStripMenuItem3.Size = new System.Drawing.Size(172, 46);
            this.shihToolStripMenuItem3.Text = "Shih";
            this.shihToolStripMenuItem3.Click += new System.EventHandler(this.ShihBuzekuq);
            // 
            // blushToolStripMenuItem
            // 
            this.blushToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shtoToolStripMenuItem3,
            this.shihToolStripMenuItem4});
            this.blushToolStripMenuItem.Name = "blushToolStripMenuItem";
            this.blushToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.blushToolStripMenuItem.Text = "Blush";
            // 
            // shtoToolStripMenuItem3
            // 
            this.shtoToolStripMenuItem3.Name = "shtoToolStripMenuItem3";
            this.shtoToolStripMenuItem3.Size = new System.Drawing.Size(172, 46);
            this.shtoToolStripMenuItem3.Text = "Shto";
            this.shtoToolStripMenuItem3.Click += new System.EventHandler(this.ShtoBlush);
            // 
            // shihToolStripMenuItem4
            // 
            this.shihToolStripMenuItem4.Name = "shihToolStripMenuItem4";
            this.shihToolStripMenuItem4.Size = new System.Drawing.Size(172, 46);
            this.shihToolStripMenuItem4.Text = "Shih";
            this.shihToolStripMenuItem4.Click += new System.EventHandler(this.ShihBlush);
            // 
            // produktetToolStripMenuItem1
            // 
            this.produktetToolStripMenuItem1.BackColor = System.Drawing.Color.Black;
            this.produktetToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shtoprodukteToolStripMenuItem,
            this.shihProdukteToolStripMenuItem});
            this.produktetToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.produktetToolStripMenuItem1.Name = "produktetToolStripMenuItem1";
            this.produktetToolStripMenuItem1.Size = new System.Drawing.Size(168, 45);
            this.produktetToolStripMenuItem1.Text = "Produktet";
            // 
            // shtoprodukteToolStripMenuItem
            // 
            this.shtoprodukteToolStripMenuItem.Name = "shtoprodukteToolStripMenuItem";
            this.shtoprodukteToolStripMenuItem.Size = new System.Drawing.Size(180, 46);
            this.shtoprodukteToolStripMenuItem.Text = "Shto ";
            this.shtoprodukteToolStripMenuItem.Click += new System.EventHandler(this.ShtoProdukt);
            // 
            // shihProdukteToolStripMenuItem
            // 
            this.shihProdukteToolStripMenuItem.Name = "shihProdukteToolStripMenuItem";
            this.shihProdukteToolStripMenuItem.Size = new System.Drawing.Size(180, 46);
            this.shihProdukteToolStripMenuItem.Text = "Shih";
            this.shihProdukteToolStripMenuItem.Click += new System.EventHandler(this.ShihProduktet);
            // 
            // porositeToolStripMenuItem
            // 
            this.porositeToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.porositeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shtoPorosiToolStripMenuItem,
            this.shikoToolStripMenuItem});
            this.porositeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.porositeToolStripMenuItem.Name = "porositeToolStripMenuItem";
            this.porositeToolStripMenuItem.Size = new System.Drawing.Size(144, 45);
            this.porositeToolStripMenuItem.Text = "Porosite";
            // 
            // shtoPorosiToolStripMenuItem
            // 
            this.shtoPorosiToolStripMenuItem.Name = "shtoPorosiToolStripMenuItem";
            this.shtoPorosiToolStripMenuItem.Size = new System.Drawing.Size(172, 46);
            this.shtoPorosiToolStripMenuItem.Text = "Shto";
            this.shtoPorosiToolStripMenuItem.Click += new System.EventHandler(this.ShtoPorosi);
            // 
            // shikoToolStripMenuItem
            // 
            this.shikoToolStripMenuItem.Name = "shikoToolStripMenuItem";
            this.shikoToolStripMenuItem.Size = new System.Drawing.Size(172, 46);
            this.shikoToolStripMenuItem.Text = "Shih";
            this.shikoToolStripMenuItem.Click += new System.EventHandler(this.ShihPorosite);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri Light", 46F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(197, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(436, 94);
            this.label5.TabIndex = 11;
            this.label5.Text = "S E P H O R A";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(869, 534);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Paneli Kryesor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void shihFurnitore(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kategoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shikoKategoriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shihToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mascaraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lipstickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produktetToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shtoprodukteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shihProdukteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porositeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shtoPorosiToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem fornitoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shihToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem shtoToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem shihToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem shtoBuzekuqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shihToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem shtoToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem shihToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem shikoToolStripMenuItem;
    }
}