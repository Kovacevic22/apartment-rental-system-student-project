namespace KorisnickiInterfejs.UgovorForme
{
    partial class FrmPretraziUgovore
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
            dgvPretragaUgovora = new DataGridView();
            groupBox1 = new GroupBox();
            txtStanodavacPretraga = new TextBox();
            label4 = new Label();
            cbPretragaPoVremenu = new CheckBox();
            btnPretraga = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbZakupacPretraga = new ComboBox();
            dtpDatumDoPretraga = new DateTimePicker();
            dtpDatumOdPretraga = new DateTimePicker();
            groupBox2 = new GroupBox();
            dtpDatumDo = new DateTimePicker();
            dtpDatumOd = new DateTimePicker();
            cmbZakupac = new ComboBox();
            txtUkupniIznos = new TextBox();
            txtStanodavac = new TextBox();
            txtIdUgovor = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            cbDozvoliIzmene = new CheckBox();
            groupBox3 = new GroupBox();
            dgvStanoviUgovor = new DataGridView();
            btnDetalji = new Button();
            groupBox4 = new GroupBox();
            btnDodajStan = new Button();
            label12 = new Label();
            label11 = new Label();
            txtIznosStan = new TextBox();
            cmbStan = new ComboBox();
            btnIzmeni = new Button();
            btnObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPretragaUgovora).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStanoviUgovor).BeginInit();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dgvPretragaUgovora
            // 
            dgvPretragaUgovora.AllowUserToAddRows = false;
            dgvPretragaUgovora.AllowUserToDeleteRows = false;
            dgvPretragaUgovora.AllowUserToResizeColumns = false;
            dgvPretragaUgovora.AllowUserToResizeRows = false;
            dgvPretragaUgovora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPretragaUgovora.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPretragaUgovora.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvPretragaUgovora.Location = new Point(12, 137);
            dgvPretragaUgovora.MultiSelect = false;
            dgvPretragaUgovora.Name = "dgvPretragaUgovora";
            dgvPretragaUgovora.ReadOnly = true;
            dgvPretragaUgovora.RowHeadersVisible = false;
            dgvPretragaUgovora.RowHeadersWidth = 51;
            dgvPretragaUgovora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPretragaUgovora.Size = new Size(1113, 267);
            dgvPretragaUgovora.TabIndex = 9;
            dgvPretragaUgovora.SelectionChanged += dgvPretragaUgovora_SelectionChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtStanodavacPretraga);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbPretragaPoVremenu);
            groupBox1.Controls.Add(btnPretraga);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbZakupacPretraga);
            groupBox1.Controls.Add(dtpDatumDoPretraga);
            groupBox1.Controls.Add(dtpDatumOdPretraga);
            groupBox1.Location = new Point(12, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1113, 125);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kriterijum pretrage";
            // 
            // txtStanodavacPretraga
            // 
            txtStanodavacPretraga.Location = new Point(532, 71);
            txtStanodavacPretraga.Name = "txtStanodavacPretraga";
            txtStanodavacPretraga.ReadOnly = true;
            txtStanodavacPretraga.Size = new Size(226, 27);
            txtStanodavacPretraga.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(437, 74);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 19;
            label4.Text = "Stanodavac:";
            // 
            // cbPretragaPoVremenu
            // 
            cbPretragaPoVremenu.AutoSize = true;
            cbPretragaPoVremenu.Location = new Point(795, 23);
            cbPretragaPoVremenu.Name = "cbPretragaPoVremenu";
            cbPretragaPoVremenu.Size = new Size(237, 24);
            cbPretragaPoVremenu.TabIndex = 18;
            cbPretragaPoVremenu.Text = "Dozvoli pretragu po datumima";
            cbPretragaPoVremenu.UseVisualStyleBackColor = true;
            // 
            // btnPretraga
            // 
            btnPretraga.Location = new Point(795, 74);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(259, 33);
            btnPretraga.TabIndex = 17;
            btnPretraga.Text = "Pretrazi";
            btnPretraga.UseVisualStyleBackColor = true;
            btnPretraga.Click += btnPretraga_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(458, 27);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 15;
            label3.Text = "Zakupac:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 75);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 14;
            label2.Text = "Datum do:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 25);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 13;
            label1.Text = "Datum od:";
            // 
            // cmbZakupacPretraga
            // 
            cmbZakupacPretraga.FormattingEnabled = true;
            cmbZakupacPretraga.Location = new Point(532, 27);
            cmbZakupacPretraga.Name = "cmbZakupacPretraga";
            cmbZakupacPretraga.Size = new Size(226, 28);
            cmbZakupacPretraga.TabIndex = 11;
            // 
            // dtpDatumDoPretraga
            // 
            dtpDatumDoPretraga.Location = new Point(187, 75);
            dtpDatumDoPretraga.Name = "dtpDatumDoPretraga";
            dtpDatumDoPretraga.Size = new Size(250, 27);
            dtpDatumDoPretraga.TabIndex = 10;
            // 
            // dtpDatumOdPretraga
            // 
            dtpDatumOdPretraga.Location = new Point(187, 26);
            dtpDatumOdPretraga.Name = "dtpDatumOdPretraga";
            dtpDatumOdPretraga.Size = new Size(250, 27);
            dtpDatumOdPretraga.TabIndex = 9;
            dtpDatumOdPretraga.ValueChanged += dtpDatumOdPretraga_ValueChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpDatumDo);
            groupBox2.Controls.Add(dtpDatumOd);
            groupBox2.Controls.Add(cmbZakupac);
            groupBox2.Controls.Add(txtUkupniIznos);
            groupBox2.Controls.Add(txtStanodavac);
            groupBox2.Controls.Add(txtIdUgovor);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(12, 439);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(398, 278);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Osnovni podaci";
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Enabled = false;
            dtpDatumDo.Location = new Point(102, 108);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 11;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Enabled = false;
            dtpDatumOd.Location = new Point(102, 71);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 10;
            // 
            // cmbZakupac
            // 
            cmbZakupac.Enabled = false;
            cmbZakupac.FormattingEnabled = true;
            cmbZakupac.Location = new Point(102, 141);
            cmbZakupac.Name = "cmbZakupac";
            cmbZakupac.Size = new Size(250, 28);
            cmbZakupac.TabIndex = 9;
            // 
            // txtUkupniIznos
            // 
            txtUkupniIznos.Location = new Point(102, 208);
            txtUkupniIznos.Name = "txtUkupniIznos";
            txtUkupniIznos.ReadOnly = true;
            txtUkupniIznos.Size = new Size(250, 27);
            txtUkupniIznos.TabIndex = 8;
            // 
            // txtStanodavac
            // 
            txtStanodavac.Location = new Point(102, 175);
            txtStanodavac.Name = "txtStanodavac";
            txtStanodavac.ReadOnly = true;
            txtStanodavac.Size = new Size(250, 27);
            txtStanodavac.TabIndex = 7;
            // 
            // txtIdUgovor
            // 
            txtIdUgovor.Location = new Point(102, 32);
            txtIdUgovor.Name = "txtIdUgovor";
            txtIdUgovor.ReadOnly = true;
            txtIdUgovor.Size = new Size(42, 27);
            txtIdUgovor.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(5, 208);
            label10.Name = "label10";
            label10.Size = new Size(96, 20);
            label10.TabIndex = 5;
            label10.Text = "Ukupni iznos:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 172);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 4;
            label9.Text = "Stanodavac:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 141);
            label8.Name = "label8";
            label8.Size = new Size(68, 20);
            label8.TabIndex = 3;
            label8.Text = "Zakupac:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 108);
            label7.Name = "label7";
            label7.Size = new Size(79, 20);
            label7.TabIndex = 2;
            label7.Text = "Datum do:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 71);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 1;
            label6.Text = "Datum od:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(74, 32);
            label5.Name = "label5";
            label5.Size = new Size(27, 20);
            label5.TabIndex = 0;
            label5.Text = "ID:";
            // 
            // cbDozvoliIzmene
            // 
            cbDozvoliIzmene.AutoSize = true;
            cbDozvoliIzmene.Location = new Point(17, 741);
            cbDozvoliIzmene.Name = "cbDozvoliIzmene";
            cbDozvoliIzmene.Size = new Size(134, 24);
            cbDozvoliIzmene.TabIndex = 14;
            cbDozvoliIzmene.Text = "Dozvoli izmene";
            cbDozvoliIzmene.UseVisualStyleBackColor = true;
            cbDozvoliIzmene.CheckedChanged += cbDozvoliIzmene_CheckedChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvStanoviUgovor);
            groupBox3.Location = new Point(416, 439);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(709, 278);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stanovi u ugovoru";
            // 
            // dgvStanoviUgovor
            // 
            dgvStanoviUgovor.AllowUserToAddRows = false;
            dgvStanoviUgovor.AllowUserToDeleteRows = false;
            dgvStanoviUgovor.AllowUserToResizeRows = false;
            dgvStanoviUgovor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStanoviUgovor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStanoviUgovor.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvStanoviUgovor.Location = new Point(15, 26);
            dgvStanoviUgovor.MultiSelect = false;
            dgvStanoviUgovor.Name = "dgvStanoviUgovor";
            dgvStanoviUgovor.ReadOnly = true;
            dgvStanoviUgovor.RowHeadersVisible = false;
            dgvStanoviUgovor.RowHeadersWidth = 51;
            dgvStanoviUgovor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStanoviUgovor.Size = new Size(688, 209);
            dgvStanoviUgovor.TabIndex = 0;
            dgvStanoviUgovor.CellDoubleClick += dgvStanoviUgovor_CellDoubleClick;
            // 
            // btnDetalji
            // 
            btnDetalji.Enabled = false;
            btnDetalji.Location = new Point(1025, 410);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 13;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnDodajStan);
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(txtIznosStan);
            groupBox4.Controls.Add(cmbStan);
            groupBox4.Location = new Point(830, 726);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(289, 186);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Dodaj stan:";
            // 
            // btnDodajStan
            // 
            btnDodajStan.Location = new Point(132, 151);
            btnDodajStan.Name = "btnDodajStan";
            btnDodajStan.Size = new Size(151, 29);
            btnDodajStan.TabIndex = 15;
            btnDodajStan.Text = "Dodaj stan";
            btnDodajStan.UseVisualStyleBackColor = true;
            btnDodajStan.Click += btnDodajStan_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(38, 81);
            label12.Name = "label12";
            label12.Size = new Size(86, 20);
            label12.TabIndex = 14;
            label12.Text = "Unesi iznos:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(38, 38);
            label11.Name = "label11";
            label11.Size = new Size(88, 20);
            label11.TabIndex = 13;
            label11.Text = "Izaberi stan:";
            // 
            // txtIznosStan
            // 
            txtIznosStan.Location = new Point(132, 81);
            txtIznosStan.Name = "txtIznosStan";
            txtIznosStan.ReadOnly = true;
            txtIznosStan.Size = new Size(151, 27);
            txtIznosStan.TabIndex = 12;
            // 
            // cmbStan
            // 
            cmbStan.Enabled = false;
            cmbStan.FormattingEnabled = true;
            cmbStan.Location = new Point(132, 38);
            cmbStan.Name = "cmbStan";
            cmbStan.Size = new Size(151, 28);
            cmbStan.TabIndex = 0;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(17, 779);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(151, 29);
            btnIzmeni.TabIndex = 16;
            btnIzmeni.Text = "Izmeni";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(17, 818);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(151, 29);
            btnObrisi.TabIndex = 17;
            btnObrisi.Text = "Obrisi";
            btnObrisi.UseVisualStyleBackColor = true;
            // 
            // FrmPretraziUgovore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1137, 924);
            Controls.Add(btnObrisi);
            Controls.Add(btnIzmeni);
            Controls.Add(groupBox4);
            Controls.Add(cbDozvoliIzmene);
            Controls.Add(btnDetalji);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(dgvPretragaUgovora);
            Name = "FrmPretraziUgovore";
            Text = "Pretrazi ugovore";
            ((System.ComponentModel.ISupportInitialize)dgvPretragaUgovora).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStanoviUgovor).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPretragaUgovora;
        private GroupBox groupBox1;
        private Button btnPretraga;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbZakupacPretraga;
        private DateTimePicker dtpDatumDoPretraga;
        private DateTimePicker dtpDatumOdPretraga;
        private GroupBox groupBox2;
        private Label label7;
        private Label label6;
        private Label label5;
        private GroupBox groupBox3;
        private DateTimePicker dtpDatumDo;
        private DateTimePicker dtpDatumOd;
        private ComboBox cmbZakupac;
        private TextBox txtUkupniIznos;
        private TextBox txtStanodavac;
        private TextBox txtIdUgovor;
        private Label label10;
        private Label label9;
        private Label label8;
        private DataGridView dgvStanoviUgovor;
        private Button btnDetalji;
        private CheckBox cbDozvoliIzmene;
        private GroupBox groupBox4;
        private Button btnDodajStan;
        private Label label12;
        private Label label11;
        private TextBox txtIznosStan;
        private ComboBox cmbStan;
        private Button btnIzmeni;
        private Button btnObrisi;
        private CheckBox cbPretragaPoVremenu;
        private Label label4;
        private TextBox txtStanodavacPretraga;
    }
}