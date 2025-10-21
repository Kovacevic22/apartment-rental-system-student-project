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

namespace KorisnickiInterfejs.UgovorForme
{
    public partial class FrmKreirajUgovor : Form
    {
        private Stanodavac prijavljeni;
        private List<StavkaUgovora> dodateStavke = new List<StavkaUgovora>();
        public FrmKreirajUgovor(Stanodavac prijavljeni)
        {
            InitializeComponent();
            try
            {

                this.prijavljeni = prijavljeni;
                //
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                //
                txtStanodavac.Text = $"{prijavljeni.Ime} {prijavljeni.Prezime}";
                txtStanodavac.Enabled = false;
                cmbStan.DataSource = Kontroler.Instance.VratiSveStanove();
                cmbStan.DisplayMember = "Adresa";
                cmbStan.ValueMember = "IdStan";
                cmbStan.DropDownStyle = ComboBoxStyle.DropDownList;

                cmbZakupac.DataSource = Kontroler.Instance.VratiSveZakupce();
                cmbZakupac.DisplayMember = "ImePrezime";
                cmbZakupac.ValueMember = "IdZakupac";
                cmbZakupac.DropDownStyle = ComboBoxStyle.DropDownList;

                dtpDatumOd.MinDate = DateTime.Today;
                dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(1);
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da kreira ugovor.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnDodajStan_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbStan.SelectedItem == null)
                {
                    MessageBox.Show("Morate izabrati stan.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStan.Focus();
                    return;
                }
                if (txtIznos.Text.Trim().Length == 0 || Convert.ToDecimal(txtIznos.Text) <= 0)
                {
                    MessageBox.Show("Morate uneti ispravan iznos. Iznos mora biti veci od 0.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIznos.Focus();
                    return;
                }
                if (!txtIznos.Text.All(char.IsDigit))
                {
                    MessageBox.Show("Ukupni iznos ne sme sadrzati slova.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIznos.Focus();
                    return;
                }
                Stan izabraniStan = (Stan)cmbStan.SelectedItem;
                if (dodateStavke.Any(s => s.IdStan == izabraniStan.IdStan))
                {
                    MessageBox.Show("Ovaj stan je vec dodat u ugovor.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStan.Focus();
                    return;
                }
                StavkaUgovora stavka = new StavkaUgovora()
                {
                    IdStan = izabraniStan.IdStan,
                    Iznos = Convert.ToDecimal(txtIznos.Text),
                    Stan = izabraniStan,
                    Rb = dodateStavke.Count + 1
                };
                dodateStavke.Add(stavka);
                OsveziDgv();
                txtIznos.Clear();
                MessageBox.Show("Sistem je dodao stan u ugovor.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sistem ne moze da doda stan. ({ex.Message})", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OsveziDgv()
        {
            var prikaz = dodateStavke.Select(s => new
            {
                s.Rb,
                s.Stan.Adresa,
                s.Stan.Povrsina,
                s.Stan.TipStana,
                s.Stan.BrojSoba,
                s.Iznos
            }).ToList();
            dgvPrikazStanova.DataSource = prikaz;
            dgvPrikazStanova.Columns["TipStana"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvPrikazStanova.Columns["Rb"].HeaderText = "Rb";
            dgvPrikazStanova.Columns["Adresa"].HeaderText = "Adresa";
            dgvPrikazStanova.Columns["Povrsina"].HeaderText = "Površina (m²)";
            dgvPrikazStanova.Columns["TipStana"].HeaderText = "Tip stana";
            dgvPrikazStanova.Columns["BrojSoba"].HeaderText = "Broj soba";
            dgvPrikazStanova.Columns["Iznos"].HeaderText = "Iznos (RSD)";

            dgvPrikazStanova.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrikazStanova.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrikazStanova.MultiSelect = false;
            dgvPrikazStanova.Columns["Adresa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            dgvPrikazStanova.RowHeadersVisible = false;
            AzurirajLabele();
        }

        private void AzurirajLabele()
        {
            txtUkupnoStanova.Text = dodateStavke.Count.ToString();
            txtUkupniIznos.Text = dodateStavke.Sum(s => s.Iznos).ToString("N2");
        }



        private void dtpDatumOd_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumDo.MinDate = dtpDatumOd.Value.AddDays(1);
        }

        private void dgvPrikazStanova_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            int rb = (int)dgvPrikazStanova.Rows[e.RowIndex].Cells["Rb"].Value;
            var rezultat = MessageBox.Show("Da li ste sigurni da zelite da uklonite stavku iz ugovora?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                var stavka = dodateStavke.FirstOrDefault(s => s.Rb == rb);
                if (stavka != null)
                {
                    dodateStavke.Remove(stavka);
                    for (int i = 0; i < dodateStavke.Count; i++)
                    {
                        dodateStavke[i].Rb = i + 1;
                    }
                    OsveziDgv();
                    MessageBox.Show("Sistem je uklonio stavku iz ugovora.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnKreirajUgovor_Click(object sender, EventArgs e)
        {
            try
            {
                if(cmbZakupac.SelectedItem == null)
                {
                    MessageBox.Show("Morate izabrati zakupca.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbZakupac.Focus();
                    return;
                }
                if(dodateStavke.Count == 0)
                {
                    MessageBox.Show("Morate dodati bar jedan stan u ugovor.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStan.Focus();
                    return;
                }
                DateTime datumOd = dtpDatumOd.Value.Date;
                DateTime datumDo = dtpDatumDo.Value.Date;
                Zakupac izabraniZakupac = (Zakupac)cmbZakupac.SelectedItem;
                Ugovor ugovor = new Ugovor()
                {
                    DatumOd = datumOd,
                    DatumDo = datumDo,
                    IdStanodavac = prijavljeni.IdStanodavac,
                    IdZakupac = izabraniZakupac.IdZakupac,
                    StavkeUgovora = dodateStavke
                };
                var result = MessageBox.Show($"Da li ste sigurni da zelite da kreirate ugovor za {izabraniZakupac.ImePrezime}?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    return;
                }
                Kontroler.Instance.KreirajUgovor(ugovor);
                MessageBox.Show("Sistem je kreirao ugovor.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetujFormu();
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da kreira ugovor. {ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetujFormu()
        {
            dtpDatumOd.Value = DateTime.Today;
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            cmbZakupac.SelectedIndex = -1;
            cmbStan.SelectedIndex = -1;
            dodateStavke.Clear();
            txtIznos.Clear();
            txtUkupniIznos.Clear();
            OsveziDgv();
        }
    }
}
