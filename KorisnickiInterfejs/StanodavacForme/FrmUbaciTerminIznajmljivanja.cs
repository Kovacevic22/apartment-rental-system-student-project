using Domen;
using KorisnickiInterfejs.UIKontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs.StanodavacForme
{
    public partial class FrmUbaciTerminIznajmljivanja : Form
    {
        private Stanodavac prijavljeni;
        public FrmUbaciTerminIznajmljivanja(Stanodavac prijavljeni)
        {
            InitializeComponent();
            try
            {
                //
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                //
                this.prijavljeni = prijavljeni;
                txtStanodavac.Text = $"{prijavljeni.Ime} {prijavljeni.Prezime}";
                dtpDatumOd.MinDate = DateTime.Now;
                dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(1);
                txtStanodavac.Enabled = false;
                cmbOpisStatusa.DataSource = Enum.GetValues(typeof(OpisStatusa));
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Sistem ne moze da ucita formu za ubacivanje termina iznajmljivanja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUbaci_Click(object sender, EventArgs e)
        {
            try
            {
                TerminIznajmljivanja termin = new TerminIznajmljivanja
                {
                    DatumDo = dtpDatumDo.Value.Date,
                    DatumOd = dtpDatumOd.Value.Date,
                };
                int idStanodavac = prijavljeni.IdStanodavac;
                string opisStatusa = cmbOpisStatusa.SelectedItem.ToString();
                var result = MessageBox.Show("Da li ste sigurni da zelite da zapamtite termin iznajmljivanja?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                Kontroler.Instance.UbaciTerminIznajmljivanja(termin,idStanodavac,opisStatusa);
                MessageBox.Show("Sistem je zapamtio termin iznajmljivanja.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpDatumOd.Value = DateTime.Now;
                dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Sistem ne moze da zapamti termin iznajmljivanja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
