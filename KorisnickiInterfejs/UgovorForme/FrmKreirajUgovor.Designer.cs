namespace KorisnickiInterfejs.UgovorForme
{
    partial class FrmKreirajUgovor
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
            dtpDatumOd = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dtpDatumDo = new DateTimePicker();
            groupBox1 = new GroupBox();
            txtStanodavac = new TextBox();
            cmbZakupac = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            txtUkupniIznos = new TextBox();
            txtUkupnoStanova = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dgvPrikazStanova = new DataGridView();
            btnDodajStan = new Button();
            label6 = new Label();
            txtIznos = new TextBox();
            cmbStan = new ComboBox();
            label5 = new Label();
            btnKreirajUgovor = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazStanova).BeginInit();
            SuspendLayout();
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(99, 40);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(250, 27);
            dtpDatumOd.TabIndex = 0;
            dtpDatumOd.ValueChanged += dtpDatumOd_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 40);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Datum od:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 92);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "Datum do:";
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(99, 92);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(250, 27);
            dtpDatumDo.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtStanodavac);
            groupBox1.Controls.Add(cmbZakupac);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpDatumOd);
            groupBox1.Controls.Add(dtpDatumDo);
            groupBox1.Location = new Point(12, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(509, 258);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Osnovni podaci ugovora";
            // 
            // txtStanodavac
            // 
            txtStanodavac.Location = new Point(99, 184);
            txtStanodavac.Name = "txtStanodavac";
            txtStanodavac.ReadOnly = true;
            txtStanodavac.Size = new Size(248, 27);
            txtStanodavac.TabIndex = 7;
            // 
            // cmbZakupac
            // 
            cmbZakupac.FormattingEnabled = true;
            cmbZakupac.Location = new Point(99, 139);
            cmbZakupac.Name = "cmbZakupac";
            cmbZakupac.Size = new Size(248, 28);
            cmbZakupac.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 184);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 5;
            label4.Text = "Stanodavac:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 139);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 4;
            label3.Text = "Zakupac:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtUkupniIznos);
            groupBox2.Controls.Add(txtUkupnoStanova);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(dgvPrikazStanova);
            groupBox2.Controls.Add(btnDodajStan);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(txtIznos);
            groupBox2.Controls.Add(cmbStan);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(536, 30);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(573, 417);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stavke ugovora";
            // 
            // txtUkupniIznos
            // 
            txtUkupniIznos.Location = new Point(130, 382);
            txtUkupniIznos.Name = "txtUkupniIznos";
            txtUkupniIznos.ReadOnly = true;
            txtUkupniIznos.Size = new Size(145, 27);
            txtUkupniIznos.TabIndex = 17;
            // 
            // txtUkupnoStanova
            // 
            txtUkupnoStanova.Location = new Point(130, 352);
            txtUkupnoStanova.Name = "txtUkupnoStanova";
            txtUkupnoStanova.ReadOnly = true;
            txtUkupnoStanova.Size = new Size(145, 27);
            txtUkupnoStanova.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 385);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 15;
            label8.Text = "Ukupni iznos:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 355);
            label7.Name = "label7";
            label7.Size = new Size(118, 20);
            label7.TabIndex = 14;
            label7.Text = "Ukupno stanova:";
            // 
            // dgvPrikazStanova
            // 
            dgvPrikazStanova.AllowUserToAddRows = false;
            dgvPrikazStanova.AllowUserToDeleteRows = false;
            dgvPrikazStanova.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrikazStanova.Location = new Point(6, 134);
            dgvPrikazStanova.MultiSelect = false;
            dgvPrikazStanova.Name = "dgvPrikazStanova";
            dgvPrikazStanova.ReadOnly = true;
            dgvPrikazStanova.RowHeadersWidth = 51;
            dgvPrikazStanova.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrikazStanova.Size = new Size(561, 188);
            dgvPrikazStanova.TabIndex = 13;
            dgvPrikazStanova.CellDoubleClick += dgvPrikazStanova_CellDoubleClick;
            // 
            // btnDodajStan
            // 
            btnDodajStan.Location = new Point(330, 79);
            btnDodajStan.Name = "btnDodajStan";
            btnDodajStan.Size = new Size(113, 29);
            btnDodajStan.TabIndex = 12;
            btnDodajStan.Text = "Dodaj stan";
            btnDodajStan.UseVisualStyleBackColor = true;
            btnDodajStan.Click += btnDodajStan_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(61, 80);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 11;
            label6.Text = "Iznos:";
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(113, 80);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(202, 27);
            txtIznos.TabIndex = 10;
            // 
            // cmbStan
            // 
            cmbStan.FormattingEnabled = true;
            cmbStan.Location = new Point(113, 37);
            cmbStan.Name = "cmbStan";
            cmbStan.Size = new Size(202, 28);
            cmbStan.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 35);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 8;
            label5.Text = "Izaberite stan:";
            // 
            // btnKreirajUgovor
            // 
            btnKreirajUgovor.Location = new Point(536, 453);
            btnKreirajUgovor.Name = "btnKreirajUgovor";
            btnKreirajUgovor.Size = new Size(573, 42);
            btnKreirajUgovor.TabIndex = 6;
            btnKreirajUgovor.Text = "Kreiraj ugovor";
            btnKreirajUgovor.UseVisualStyleBackColor = true;
            btnKreirajUgovor.Click += btnKreirajUgovor_Click;
            // 
            // FrmKreirajUgovor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1121, 507);
            Controls.Add(btnKreirajUgovor);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmKreirajUgovor";
            Text = "Kreiranje ugovora";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrikazStanova).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpDatumOd;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpDatumDo;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox txtStanodavac;
        private ComboBox cmbZakupac;
        private Label label4;
        private GroupBox groupBox2;
        private Label label6;
        private TextBox txtIznos;
        private ComboBox cmbStan;
        private Label label5;
        private Label label8;
        private Label label7;
        private DataGridView dgvPrikazStanova;
        private Button btnDodajStan;
        private TextBox txtUkupniIznos;
        private TextBox txtUkupnoStanova;
        private Button btnKreirajUgovor;
    }
}