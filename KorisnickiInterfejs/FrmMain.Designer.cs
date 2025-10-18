namespace KorisnickiInterfejs
{
    partial class FrmMain
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
            ugovorToolStripMenuItem = new ToolStripMenuItem();
            pretraziToolStripMenuItem = new ToolStripMenuItem();
            promeniToolStripMenuItem = new ToolStripMenuItem();
            kreirajUgovorToolStripMenuItem = new ToolStripDropDownMenu();
            zakupacToolStripMenuItem = new ToolStripMenuItem();
            kreirajToolStripMenuItem = new ToolStripMenuItem();
            pretraziToolStripMenuItem1 = new ToolStripMenuItem();
            stanodavacToolStripMenuItem = new ToolStripMenuItem();
            ubaciTerminIznajmljivanjaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ugovorToolStripMenuItem
            // 
            ugovorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pretraziToolStripMenuItem, promeniToolStripMenuItem });
            ugovorToolStripMenuItem.Name = "ugovorToolStripMenuItem";
            ugovorToolStripMenuItem.Size = new Size(72, 24);
            ugovorToolStripMenuItem.Text = "Ugovor";
            // 
            // pretraziToolStripMenuItem
            // 
            pretraziToolStripMenuItem.Name = "pretraziToolStripMenuItem";
            pretraziToolStripMenuItem.Size = new Size(142, 26);
            pretraziToolStripMenuItem.Text = "Kreiraj";
            pretraziToolStripMenuItem.Click += pretraziToolStripMenuItem_Click;
            // 
            // promeniToolStripMenuItem
            // 
            promeniToolStripMenuItem.Name = "promeniToolStripMenuItem";
            promeniToolStripMenuItem.Size = new Size(142, 26);
            promeniToolStripMenuItem.Text = "Pretrazi";
            promeniToolStripMenuItem.Click += promeniToolStripMenuItem_Click;
            // 
            // kreirajUgovorToolStripMenuItem
            // 
            kreirajUgovorToolStripMenuItem.AutoClose = false;
            kreirajUgovorToolStripMenuItem.ImageScalingSize = new Size(20, 20);
            kreirajUgovorToolStripMenuItem.Name = "kreirajUgovorToolStripMenuItem";
            kreirajUgovorToolStripMenuItem.OwnerItem = ugovorToolStripMenuItem;
            kreirajUgovorToolStripMenuItem.Size = new Size(61, 4);
            // 
            // zakupacToolStripMenuItem
            // 
            zakupacToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajToolStripMenuItem, pretraziToolStripMenuItem1 });
            zakupacToolStripMenuItem.Name = "zakupacToolStripMenuItem";
            zakupacToolStripMenuItem.Size = new Size(79, 24);
            zakupacToolStripMenuItem.Text = "Zakupac";
            // 
            // kreirajToolStripMenuItem
            // 
            kreirajToolStripMenuItem.Name = "kreirajToolStripMenuItem";
            kreirajToolStripMenuItem.Size = new Size(142, 26);
            kreirajToolStripMenuItem.Text = "Kreiraj";
            kreirajToolStripMenuItem.Click += kreirajToolStripMenuItem_Click;
            // 
            // pretraziToolStripMenuItem1
            // 
            pretraziToolStripMenuItem1.Name = "pretraziToolStripMenuItem1";
            pretraziToolStripMenuItem1.Size = new Size(142, 26);
            pretraziToolStripMenuItem1.Text = "Pretrazi";
            pretraziToolStripMenuItem1.Click += pretraziToolStripMenuItem1_Click;
            // 
            // stanodavacToolStripMenuItem
            // 
            stanodavacToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciTerminIznajmljivanjaToolStripMenuItem });
            stanodavacToolStripMenuItem.Name = "stanodavacToolStripMenuItem";
            stanodavacToolStripMenuItem.Size = new Size(100, 24);
            stanodavacToolStripMenuItem.Text = "Stanodavac";
            // 
            // ubaciTerminIznajmljivanjaToolStripMenuItem
            // 
            ubaciTerminIznajmljivanjaToolStripMenuItem.Name = "ubaciTerminIznajmljivanjaToolStripMenuItem";
            ubaciTerminIznajmljivanjaToolStripMenuItem.Size = new Size(272, 26);
            ubaciTerminIznajmljivanjaToolStripMenuItem.Text = "Ubaci termin iznajmljivanja";
            ubaciTerminIznajmljivanjaToolStripMenuItem.Click += ubaciTerminIznajmljivanjaToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ugovorToolStripMenuItem, zakupacToolStripMenuItem, stanodavacToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMain";
            Text = "Evidencija";
            FormClosing += FrmMain_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem ugovorToolStripMenuItem;
        private ToolStripMenuItem pretraziToolStripMenuItem;
        private ToolStripMenuItem promeniToolStripMenuItem;
        private ToolStripDropDownMenu kreirajUgovorToolStripMenuItem;
        private ToolStripMenuItem zakupacToolStripMenuItem;
        private ToolStripMenuItem kreirajToolStripMenuItem;
        private ToolStripMenuItem pretraziToolStripMenuItem1;
        private ToolStripMenuItem stanodavacToolStripMenuItem;
        private ToolStripMenuItem ubaciTerminIznajmljivanjaToolStripMenuItem;
        private MenuStrip menuStrip1;
    }
}