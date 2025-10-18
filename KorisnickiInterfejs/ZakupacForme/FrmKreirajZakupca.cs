using Domen;
using KorisnickiInterfejs.UIKontroler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace KorisnickiInterfejs.ZakupacForme
{
    public partial class FrmKreirajZakupca : Form
    {
        public FrmKreirajZakupca()
        {
            InitializeComponent();
            this.Text = "Kreiraj zakupca";
            //
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            try
            {
                cmbMesto.DataSource = Kontroler.Instance.VratiSvaMesta();
                cmbMesto.DropDownStyle = ComboBoxStyle.DropDownList;
                MessageBox.Show("Sistem je kreirao zakupca.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da kreira zakupca.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            ResetGreske();
            string ime = txtIme.Text.Trim();
            string prezime = txtPrezime.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string brojTelefona = txtBrojTelefona.Text.Trim();
            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(brojTelefona) || cmbMesto.SelectedItem == null)
            {
                MessageBox.Show("Sva polja su obavezna!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidirajIme(ime))
            {
                lblGreskaIme.Text = "Ime nije validno!";
                lblGreskaIme.BackColor = Color.Salmon;
                return;
            }
            if (!ValidirajPrezime(prezime))
            {
                lblGreskaPrezime.Text = "Prezime nije validno!";
                lblGreskaPrezime.BackColor = Color.Salmon;
                return;
            }
            if (!ValidirajEmail(email))
            {
                lblGreskaEmail.Text = "Email nije validan!";
                lblGreskaEmail.BackColor = Color.Salmon;
                return;
            }
            if (!ValidirajBrojTelefona(brojTelefona))
            {
                lblGreskaBrojTelefona.Text = "Broj telefona nije validan!";
                lblGreskaBrojTelefona.BackColor = Color.Salmon;
                return;
            }
            try
            {
                int idMesto = ((Mesto)cmbMesto.SelectedItem).IdMesto;
                Zakupac zakupac = new Zakupac
                {
                    Ime = ime,
                    Prezime = prezime,
                    Email = email,
                    Password = password,
                    BrojTelefona = brojTelefona,
                    IdMesto = idMesto,
                };
                Kontroler.Instance.KreirajZakupac(zakupac);
                MessageBox.Show("Sistem je zapamtio zakupca.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BrisanjeTextBoxova();
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da zapamti zakupca.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cbShowHide.Checked ? '\0' : '*';
        }
        //Pomocne metode//
        private bool ValidirajIme(string ime)
        {
            return Regex.IsMatch(ime, @"^[\p{L}]+$");
        }
        private bool ValidirajPrezime(string prezime)
        {
            return Regex.IsMatch(prezime, @"^[\p{L}]+$");
        }
        private bool ValidirajEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        private bool ValidirajBrojTelefona(string brojTelefona)
        {
            return brojTelefona.All(char.IsDigit) && (brojTelefona.Length>=6 && brojTelefona.Length<=15);
        }
        private void ResetGreske()
        {
            lblGreskaIme.Text = lblGreskaPrezime.Text = lblGreskaEmail.Text = lblGreskaBrojTelefona.Text = "";
            lblGreskaIme.BackColor = lblGreskaPrezime.BackColor = lblGreskaEmail.BackColor = lblGreskaBrojTelefona.BackColor = SystemColors.Control;
        }
        private void BrisanjeTextBoxova()
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtBrojTelefona.Clear();
            cmbMesto.SelectedItem = null;
            ResetGreske();
        }
    }
}
