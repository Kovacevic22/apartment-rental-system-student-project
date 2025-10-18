namespace KorisnickiInterfejs.ZakupacForme
{
    partial class FrmPretrazi
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
            dgvPrikazZakupaca = new DataGridView();
            txtEmailPretgraga = new TextBox();
            btnPretrazi = new Button();
            label1 = new Label();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtId = new TextBox();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            txtBrojTelefona = new TextBox();
            txtEmail = new TextBox();
            cmbMestoPretraga = new ComboBox();
            label8 = new Label();
            txtPassword = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtImePretraga = new TextBox();
            label11 = new Label();
            txtPrezimePretraga = new TextBox();
            label12 = new Label();
            cmbMesto = new ComboBox();
            btnDetalji = new Button();
            cbDozvoliIzmene = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazZakupaca).BeginInit();
            SuspendLayout();
            // 
            // dgvPrikazZakupaca
            // 
            dgvPrikazZakupaca.AllowUserToAddRows = false;
            dgvPrikazZakupaca.AllowUserToDeleteRows = false;
            dgvPrikazZakupaca.AllowUserToOrderColumns = true;
            dgvPrikazZakupaca.AllowUserToResizeColumns = false;
            dgvPrikazZakupaca.AllowUserToResizeRows = false;
            dgvPrikazZakupaca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrikazZakupaca.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPrikazZakupaca.Location = new Point(12, 58);
            dgvPrikazZakupaca.MultiSelect = false;
            dgvPrikazZakupaca.Name = "dgvPrikazZakupaca";
            dgvPrikazZakupaca.ReadOnly = true;
            dgvPrikazZakupaca.RowHeadersWidth = 51;
            dgvPrikazZakupaca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrikazZakupaca.Size = new Size(1016, 322);
            dgvPrikazZakupaca.TabIndex = 0;
            dgvPrikazZakupaca.SelectionChanged += dgvPrikazZakupaca_SelectionChanged;
            // 
            // txtEmailPretgraga
            // 
            txtEmailPretgraga.Location = new Point(65, 15);
            txtEmailPretgraga.Name = "txtEmailPretgraga";
            txtEmailPretgraga.Size = new Size(160, 27);
            txtEmailPretgraga.TabIndex = 1;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(915, 15);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(113, 29);
            btnPretrazi.TabIndex = 2;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 15);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "Email:";
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(320, 601);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(94, 29);
            btnIzmeni.TabIndex = 4;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(420, 601);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(94, 29);
            btnObrisi.TabIndex = 5;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 394);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 6;
            label2.Text = "id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(49, 432);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 7;
            label3.Text = "Ime:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 468);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 8;
            label4.Text = "Prezime:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 519);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-5, 499);
            label6.Name = "label6";
            label6.Size = new Size(98, 20);
            label6.TabIndex = 10;
            label6.Text = "Broj telefona:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 534);
            label7.Name = "label7";
            label7.Size = new Size(55, 20);
            label7.TabIndex = 11;
            label7.Text = "E-mail:";
            // 
            // txtId
            // 
            txtId.Location = new Point(100, 394);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(51, 27);
            txtId.TabIndex = 12;
            // 
            // txtIme
            // 
            txtIme.Location = new Point(100, 432);
            txtIme.Name = "txtIme";
            txtIme.ReadOnly = true;
            txtIme.Size = new Size(186, 27);
            txtIme.TabIndex = 13;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(100, 468);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.ReadOnly = true;
            txtPrezime.Size = new Size(186, 27);
            txtPrezime.TabIndex = 14;
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(100, 501);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.ReadOnly = true;
            txtBrojTelefona.Size = new Size(186, 27);
            txtBrojTelefona.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(100, 534);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(186, 27);
            txtEmail.TabIndex = 16;
            // 
            // cmbMestoPretraga
            // 
            cmbMestoPretraga.FormattingEnabled = true;
            cmbMestoPretraga.Location = new Point(734, 15);
            cmbMestoPretraga.Name = "cmbMestoPretraga";
            cmbMestoPretraga.Size = new Size(151, 28);
            cmbMestoPretraga.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(675, 15);
            label8.Name = "label8";
            label8.Size = new Size(53, 20);
            label8.TabIndex = 19;
            label8.Text = "Mesto:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(100, 567);
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(186, 27);
            txtPassword.TabIndex = 21;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 570);
            label9.Name = "label9";
            label9.Size = new Size(73, 20);
            label9.TabIndex = 20;
            label9.Text = "Password:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(231, 15);
            label10.Name = "label10";
            label10.Size = new Size(37, 20);
            label10.TabIndex = 23;
            label10.Text = "Ime:";
            // 
            // txtImePretraga
            // 
            txtImePretraga.Location = new Point(274, 15);
            txtImePretraga.Name = "txtImePretraga";
            txtImePretraga.Size = new Size(160, 27);
            txtImePretraga.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(438, 15);
            label11.Name = "label11";
            label11.Size = new Size(65, 20);
            label11.TabIndex = 25;
            label11.Text = "Prezime:";
            // 
            // txtPrezimePretraga
            // 
            txtPrezimePretraga.Location = new Point(509, 15);
            txtPrezimePretraga.Name = "txtPrezimePretraga";
            txtPrezimePretraga.Size = new Size(160, 27);
            txtPrezimePretraga.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(41, 601);
            label12.Name = "label12";
            label12.Size = new Size(53, 20);
            label12.TabIndex = 27;
            label12.Text = "Mesto:";
            // 
            // cmbMesto
            // 
            cmbMesto.Enabled = false;
            cmbMesto.FormattingEnabled = true;
            cmbMesto.Location = new Point(100, 601);
            cmbMesto.Name = "cmbMesto";
            cmbMesto.Size = new Size(186, 28);
            cmbMesto.TabIndex = 26;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(934, 385);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 29;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // cbDozvoliIzmene
            // 
            cbDozvoliIzmene.AutoSize = true;
            cbDozvoliIzmene.Location = new Point(320, 537);
            cbDozvoliIzmene.Name = "cbDozvoliIzmene";
            cbDozvoliIzmene.Size = new Size(134, 24);
            cbDozvoliIzmene.TabIndex = 30;
            cbDozvoliIzmene.Text = "Dozvoli izmene";
            cbDozvoliIzmene.UseVisualStyleBackColor = true;
            cbDozvoliIzmene.CheckedChanged += cbDozvoliIzmene_CheckedChanged;
            // 
            // FrmPretrazi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1040, 641);
            Controls.Add(cbDozvoliIzmene);
            Controls.Add(btnDetalji);
            Controls.Add(label12);
            Controls.Add(cmbMesto);
            Controls.Add(label11);
            Controls.Add(txtPrezimePretraga);
            Controls.Add(label10);
            Controls.Add(txtImePretraga);
            Controls.Add(txtPassword);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(cmbMestoPretraga);
            Controls.Add(txtEmail);
            Controls.Add(txtBrojTelefona);
            Controls.Add(txtPrezime);
            Controls.Add(txtIme);
            Controls.Add(txtId);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(label1);
            Controls.Add(btnPretrazi);
            Controls.Add(txtEmailPretgraga);
            Controls.Add(dgvPrikazZakupaca);
            Name = "FrmPretrazi";
            Text = "Zakupac";
            ((System.ComponentModel.ISupportInitialize)dgvPrikazZakupaca).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPrikazZakupaca;
        private TextBox txtEmailPretgraga;
        private Button btnPretrazi;
        private Label label1;
        private Button btnIzmeni;
        private Button btnObrisi;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtId;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtBrojTelefona;
        private TextBox txtEmail;
        private ComboBox cmbMestoPretraga;
        private Label label8;
        private TextBox txtPassword;
        private Label label9;
        private Label label10;
        private TextBox txtImePretraga;
        private Label label11;
        private TextBox txtPrezimePretraga;
        private Label label12;
        private ComboBox cmbMesto;
        private Button btnDetalji;
        private CheckBox cbDozvoliIzmene;
    }
}