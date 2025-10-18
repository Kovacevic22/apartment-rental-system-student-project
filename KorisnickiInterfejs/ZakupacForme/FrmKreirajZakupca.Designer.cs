

namespace KorisnickiInterfejs.ZakupacForme
{
    partial class FrmKreirajZakupca
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
            label1 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtBrojTelefona = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cmbMesto = new ComboBox();
            btnKreiraj = new Button();
            cbShowHide = new CheckBox();
            lblGreskaIme = new Label();
            lblGreskaPrezime = new Label();
            lblGreskaEmail = new Label();
            lblGreskaBrojTelefona = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(109, 50);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(161, 43);
            txtIme.Name = "txtIme";
            txtIme.PlaceholderText = "Pero";
            txtIme.Size = new Size(207, 27);
            txtIme.TabIndex = 1;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(161, 96);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.PlaceholderText = "Peric";
            txtPrezime.Size = new Size(207, 27);
            txtPrezime.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(161, 148);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "primer@gmail.com";
            txtEmail.Size = new Size(207, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(161, 206);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(207, 27);
            txtPassword.TabIndex = 4;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(161, 265);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.PlaceholderText = "065223327";
            txtBrojTelefona.Size = new Size(207, 27);
            txtBrojTelefona.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(81, 103);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 6;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 272);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 7;
            label3.Text = "Broj telefona:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 213);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 8;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 155);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 9;
            label5.Text = "E-mail:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(93, 327);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 10;
            label6.Text = "Mesto:";
            // 
            // cmbMesto
            // 
            cmbMesto.FormattingEnabled = true;
            cmbMesto.Location = new Point(161, 319);
            cmbMesto.Name = "cmbMesto";
            cmbMesto.Size = new Size(207, 28);
            cmbMesto.TabIndex = 11;
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(161, 379);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(207, 29);
            btnKreiraj.TabIndex = 12;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // cbShowHide
            // 
            cbShowHide.AutoSize = true;
            cbShowHide.Location = new Point(374, 212);
            cbShowHide.Name = "cbShowHide";
            cbShowHide.Size = new Size(67, 24);
            cbShowHide.TabIndex = 13;
            cbShowHide.Text = "Show";
            cbShowHide.UseVisualStyleBackColor = true;
            cbShowHide.CheckedChanged += cbShowHide_CheckedChanged;
            // 
            // lblGreskaIme
            // 
            lblGreskaIme.AutoSize = true;
            lblGreskaIme.Location = new Point(374, 50);
            lblGreskaIme.Name = "lblGreskaIme";
            lblGreskaIme.Size = new Size(0, 20);
            lblGreskaIme.TabIndex = 14;
            // 
            // lblGreskaPrezime
            // 
            lblGreskaPrezime.AutoSize = true;
            lblGreskaPrezime.Location = new Point(374, 103);
            lblGreskaPrezime.Name = "lblGreskaPrezime";
            lblGreskaPrezime.Size = new Size(0, 20);
            lblGreskaPrezime.TabIndex = 15;
            // 
            // lblGreskaEmail
            // 
            lblGreskaEmail.AutoSize = true;
            lblGreskaEmail.Location = new Point(374, 155);
            lblGreskaEmail.Name = "lblGreskaEmail";
            lblGreskaEmail.Size = new Size(0, 20);
            lblGreskaEmail.TabIndex = 16;
            // 
            // lblGreskaBrojTelefona
            // 
            lblGreskaBrojTelefona.AutoSize = true;
            lblGreskaBrojTelefona.Location = new Point(374, 272);
            lblGreskaBrojTelefona.Name = "lblGreskaBrojTelefona";
            lblGreskaBrojTelefona.Size = new Size(0, 20);
            lblGreskaBrojTelefona.TabIndex = 17;
            // 
            // FrmKreirajZakupca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 450);
            Controls.Add(lblGreskaBrojTelefona);
            Controls.Add(lblGreskaEmail);
            Controls.Add(lblGreskaPrezime);
            Controls.Add(lblGreskaIme);
            Controls.Add(cbShowHide);
            Controls.Add(btnKreiraj);
            Controls.Add(cmbMesto);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmKreirajZakupca";
            Text = "Zakupac";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtBrojTelefona;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cmbMesto;
        private Button btnKreiraj;
        private CheckBox cbShowHide;
        private Label lblGreskaIme;
        private Label lblGreskaPrezime;
        private Label lblGreskaEmail;
        private Label lblGreskaBrojTelefona;
    }
}