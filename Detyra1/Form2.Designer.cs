﻿using System;

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
            this.kategoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shikoKategoriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mascaraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lipstickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blushToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porositeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.porositeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 49);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fornitoreToolStripMenuItem
            // 
            this.fornitoreToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.fornitoreToolStripMenuItem.Name = "fornitoreToolStripMenuItem";
            this.fornitoreToolStripMenuItem.Size = new System.Drawing.Size(162, 45);
            this.fornitoreToolStripMenuItem.Text = "Furnitore";
            this.fornitoreToolStripMenuItem.Click += new System.EventHandler(this.shihFurnitore);
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
            this.shikoKategoriToolStripMenuItem.Name = "shikoKategoriToolStripMenuItem";
            this.shikoKategoriToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.shikoKategoriToolStripMenuItem.Text = "Fondatine";
            this.shikoKategoriToolStripMenuItem.Click += new System.EventHandler(this.ShihFondatine);
            // 
            // mascaraToolStripMenuItem
            // 
            this.mascaraToolStripMenuItem.Name = "mascaraToolStripMenuItem";
            this.mascaraToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.mascaraToolStripMenuItem.Text = "Maskara";
            this.mascaraToolStripMenuItem.Click += new System.EventHandler(this.ShihMaskara);
            // 
            // lipstickToolStripMenuItem
            // 
            this.lipstickToolStripMenuItem.Name = "lipstickToolStripMenuItem";
            this.lipstickToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.lipstickToolStripMenuItem.Text = "Buzekuq";
            this.lipstickToolStripMenuItem.Click += new System.EventHandler(this.ShihBuzekuq);
            // 
            // blushToolStripMenuItem
            // 
            this.blushToolStripMenuItem.Name = "blushToolStripMenuItem";
            this.blushToolStripMenuItem.Size = new System.Drawing.Size(249, 46);
            this.blushToolStripMenuItem.Text = "Blush";
            this.blushToolStripMenuItem.Click += new System.EventHandler(this.ShihBlush);
            // 
            // porositeToolStripMenuItem
            // 
            this.porositeToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.porositeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.porositeToolStripMenuItem.Name = "porositeToolStripMenuItem";
            this.porositeToolStripMenuItem.Size = new System.Drawing.Size(144, 45);
            this.porositeToolStripMenuItem.Text = "Porosite";
            this.porositeToolStripMenuItem.Click += new System.EventHandler(this.ShihPorosite);
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
        private System.Windows.Forms.ToolStripMenuItem mascaraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lipstickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blushToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porositeToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem fornitoreToolStripMenuItem;
    }
}