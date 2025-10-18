namespace KorisnickiInterfejs.StanodavacForme
{
    partial class FrmUbaciTerminIznajmljivanja
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
            txtStanodavac = new TextBox();
            dtpDatumOd = new DateTimePicker();
            dtpDatumDo = new DateTimePicker();
            cmbOpisStatusa = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnUbaci = new Button();
            SuspendLayout();
            // 
            // txtStanodavac
            // 
            txtStanodavac.Location = new Point(165, 39);
            txtStanodavac.Name = "txtStanodavac";
            txtStanodavac.ReadOnly = true;
            txtStanodavac.Size = new Size(259, 27);
            txtStanodavac.TabIndex = 0;
            // 
            // dtpDatumOd
            // 
            dtpDatumOd.Location = new Point(165, 97);
            dtpDatumOd.Name = "dtpDatumOd";
            dtpDatumOd.Size = new Size(259, 27);
            dtpDatumOd.TabIndex = 1;
            // 
            // dtpDatumDo
            // 
            dtpDatumDo.Location = new Point(165, 160);
            dtpDatumDo.Name = "dtpDatumDo";
            dtpDatumDo.Size = new Size(259, 27);
            dtpDatumDo.TabIndex = 2;
            // 
            // cmbOpisStatusa
            // 
            cmbOpisStatusa.FormattingEnabled = true;
            cmbOpisStatusa.Location = new Point(165, 220);
            cmbOpisStatusa.Name = "cmbOpisStatusa";
            cmbOpisStatusa.Size = new Size(259, 28);
            cmbOpisStatusa.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 39);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 4;
            label1.Text = "Stanodavac:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 97);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 5;
            label2.Text = "Datum od:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 160);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 6;
            label3.Text = "Datum do:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 220);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 7;
            label4.Text = "Opis statusa:";
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(165, 275);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(259, 29);
            btnUbaci.TabIndex = 8;
            btnUbaci.Text = "Ubaci termin iznajmljivanja";
            btnUbaci.UseVisualStyleBackColor = true;
            btnUbaci.Click += btnUbaci_Click;
            // 
            // FrmUbaciTerminIznajmljivanja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(523, 362);
            Controls.Add(btnUbaci);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbOpisStatusa);
            Controls.Add(dtpDatumDo);
            Controls.Add(dtpDatumOd);
            Controls.Add(txtStanodavac);
            Name = "FrmUbaciTerminIznajmljivanja";
            Text = "Ubacivanje termina iznajmljivanja";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtStanodavac;
        private DateTimePicker dtpDatumOd;
        private DateTimePicker dtpDatumDo;
        private ComboBox cmbOpisStatusa;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnUbaci;
    }
}