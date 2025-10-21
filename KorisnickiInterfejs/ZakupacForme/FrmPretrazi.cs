using Domen;
using KorisnickiInterfejs.UIKontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace KorisnickiInterfejs.ZakupacForme
{
    public partial class FrmPretrazi : Form
    {
        public FrmPretrazi()
        {
            InitializeComponent();
            try
            {
                //
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                //
                btnDetalji.Enabled = false;
                btnIzmeni.Enabled = false;
                btnObrisi.Enabled = false;
                cbDozvoliIzmene.Enabled = false;
                dgvPrikazZakupaca.DataSource = Kontroler.Instance.VratiSveZakupce();

                List<Mesto> mestaPretraga = Kontroler.Instance.VratiSvaMesta();
                mestaPretraga.Insert(0, new Mesto { IdMesto = 0, Naziv = "" });
                cmbMestoPretraga.DataSource = mestaPretraga;
                cmbMestoPretraga.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMestoPretraga.DisplayMember = "Naziv";
                cmbMestoPretraga.ValueMember = "IdMesto";
                cmbMestoPretraga.SelectedIndex = -1;

                cmbMesto.DataSource = Kontroler.Instance.VratiSvaMesta();
                cmbMesto.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbMesto.DisplayMember = "Naziv";
                cmbMesto.ValueMember = "IdMesto";


                //Dizajn DGV-ova
                dgvPrikazZakupaca.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPrikazZakupaca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPrikazZakupaca.MultiSelect = false;

                dgvPrikazZakupaca.Columns["IdZakupac"].Visible = false;
                dgvPrikazZakupaca.Columns["Password"].Visible = false;
                dgvPrikazZakupaca.Columns["ImePrezime"].Visible = false;
                dgvPrikazZakupaca.RowHeadersVisible = false;

            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da ucita formu za pretragu.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmailPretgraga.Text.Trim();
                string ime = txtImePretraga.Text.Trim();
                string prezime = txtPrezimePretraga.Text.Trim();
                int? mestoId = cmbMestoPretraga.SelectedItem != null ? ((Mesto)cmbMestoPretraga.SelectedItem).IdMesto : (int?)null;
                List<Zakupac> zakupci = Kontroler.Instance.PretraziZakupac(email, ime, prezime, mestoId);
                if (zakupci.Count == 0)
                {
                    MessageBox.Show("Sistem ne moze da nadje zakupce po zadatim kriterijumima.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPrikazZakupaca.DataSource = Kontroler.Instance.VratiSveZakupce();
                    return;
                }
                else if (zakupci.Count == 1)
                {
                    MessageBox.Show("Sistem je nasao zakupca po zadatim kriterijumima.", "Infomracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sistem je nasao zakupce po zadatim kriterijumima", "Infomracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvPrikazZakupaca.DataSource = zakupci;

            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Sistem ne moze da nadje zakupca(Server pao)", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrikazZakupaca_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrikazZakupaca.SelectedRows.Count > 0)
            {
                btnDetalji.Enabled = true;
            }
            else
            {
                btnDetalji.Enabled = false;
            }
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            Zakupac zakupac = (Zakupac)dgvPrikazZakupaca.SelectedRows[0].DataBoundItem;
            txtId.Text = zakupac.IdZakupac.ToString();
            txtIme.Text = zakupac.Ime;
            txtPrezime.Text = zakupac.Prezime;
            txtEmail.Text = zakupac.Email;
            txtBrojTelefona.Text = zakupac.BrojTelefona;
            cmbMesto.SelectedValue = zakupac.IdMesto;
            txtPassword.Text = zakupac.Password;
            btnObrisi.Enabled = true;
            btnIzmeni.Enabled = true;
            cbDozvoliIzmene.Enabled = true;
            MessageBox.Show("Sistem je nasao zakupca.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbDozvoliIzmene_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDozvoliIzmene.Checked)
            {
                txtBrojTelefona.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtIme.ReadOnly = false;
                txtPassword.ReadOnly = false;
                txtPrezime.ReadOnly = false;
                cmbMesto.Enabled = true;
            }
            else
            {
                txtBrojTelefona.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtIme.ReadOnly = true;
                txtPassword.ReadOnly = true;
                txtPrezime.ReadOnly = true;
                cmbMesto.Enabled = false;
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = txtIme.Text.Trim();
                string prezime = txtPrezime.Text.Trim();
                string email = txtEmail.Text.Trim();
                string brojTelefona = txtBrojTelefona.Text.Trim();
                string password = txtPassword.Text;
                int idZakupac = int.Parse(txtId.Text);
                int idMesto = ((Mesto)cmbMesto.SelectedItem).IdMesto;
                if (string.IsNullOrEmpty(ime) || Regex.IsMatch(ime, @"^[\p{L}]+$") == false)
                {
                    MessageBox.Show("Ime nije validno.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(prezime) || Regex.IsMatch(prezime, @"^[\p{L}]+$") == false)
                {
                    MessageBox.Show("Prezime nije validno.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(email) || Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") == false)
                {
                    MessageBox.Show("Email nije validan.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(brojTelefona) || (brojTelefona.All(char.IsDigit) == false) || (brojTelefona.Length < 6 || brojTelefona.Length > 15))
                {
                    MessageBox.Show("Broj telefona nije validan.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Password ne sme biti prazan.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show($"Da li ste sigurni da zelite da izmenite zakupca?", "Potvrda izmene", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                Zakupac zakupac = new Zakupac()
                {
                    IdZakupac = idZakupac,
                    Ime = ime,
                    Prezime = prezime,
                    Email = email,
                    BrojTelefona = brojTelefona,
                    Password = password,
                    IdMesto = idMesto
                };
                Kontroler.Instance.PromeniZakupac(zakupac);
                MessageBox.Show("Sistem je zapamtio zakupca.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPrikazZakupaca.DataSource = Kontroler.Instance.VratiSveZakupce();
                OcistiPolja();
                cbDozvoliIzmene.Enabled = false;
                cbDozvoliIzmene.Checked = false;
                btnIzmeni.Enabled = false;
                btnObrisi.Enabled = false;
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        ///Pomocne metode///
        private void OcistiPolja()
        {
            txtId.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtBrojTelefona.Clear();
            txtPassword.Clear();
            cmbMesto.SelectedItem = null;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            try
            {
                Zakupac zakupac = (Zakupac)dgvPrikazZakupaca.SelectedRows[0].DataBoundItem;
                DialogResult result = MessageBox.Show($"Da li ste sigurni da zelite da obrisete zakupca {zakupac.Ime} {zakupac.Prezime}?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                Kontroler.Instance.ObrisiZakupac(zakupac.IdZakupac);
                MessageBox.Show("Sistem je obrisao zakupca.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPrikazZakupaca.DataSource = Kontroler.Instance.VratiSveZakupce();
                OcistiPolja();
                cbDozvoliIzmene.Enabled = false;
                cbDozvoliIzmene.Checked = false;
                btnIzmeni.Enabled = false;
                btnObrisi.Enabled = false;
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
