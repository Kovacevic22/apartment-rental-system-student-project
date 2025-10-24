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
    public partial class FrmPretraziUgovore : Form
    {
        private Stanodavac prijavljeni;
        public FrmPretraziUgovore(Stanodavac prijavljeni)
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

                btnDetalji.Enabled = false;
                btnIzmeni.Enabled = false;
                btnObrisi.Enabled = false;
                cbDozvoliIzmene.Enabled = false;
                btnDodajStan.Enabled = false;
                cmbZakupac.Enabled = false;
                dgvPretragaUgovora.DataSource = Kontroler.Instance.VratiSveUgovore();

                List<Zakupac> zakupacPretraga = Kontroler.Instance.VratiSveZakupce();
                zakupacPretraga.Insert(0, new Zakupac { IdZakupac = 0, Email = "", Ime = "", Prezime = "" });
                cmbZakupacPretraga.DataSource = zakupacPretraga;
                cmbZakupacPretraga.SelectedIndex = -1;
                cmbZakupacPretraga.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbZakupacPretraga.ValueMember = "IdZakupac";
                cmbZakupacPretraga.DisplayMember = "ImePrezime";

                cmbZakupac.DataSource = Kontroler.Instance.VratiSveZakupce();
                cmbZakupac.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbZakupac.ValueMember = "IdZakupac";
                cmbZakupac.DisplayMember = "ImePrezime";

                txtStanodavacPretraga.Text = $"{prijavljeni.Ime} {prijavljeni.Prezime}";

                dtpDatumDoPretraga.MinDate = dtpDatumOdPretraga.Value.AddDays(1);

                cmbStan.DataSource = Kontroler.Instance.VratiSveStanove();
                cmbStan.DisplayMember = "Adresa";
                cmbStan.ValueMember = "IdStan";
                cmbStan.DropDownStyle = ComboBoxStyle.DropDownList;


                dgvStanoviUgovor.DataSource = new BindingList<StavkaUgovora>();
                //Stilizovanje datagrid-a

                dgvPretragaUgovora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStanoviUgovor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvPretragaUgovora.Columns["IdUgovor"].Visible = false;
                dgvPretragaUgovora.Columns["IdStanodavac"].Visible = false;
                dgvPretragaUgovora.Columns["IdZakupac"].Visible = false;
                dgvPretragaUgovora.Columns["Iznos"].Visible = false;
                dgvPretragaUgovora.Columns["IdUgovor"].Visible = false;
                dgvPretragaUgovora.Columns["IdStanodavac"].Visible = false;
                dgvPretragaUgovora.Columns["IdZakupac"].Visible = false;
                dgvPretragaUgovora.Columns["TableName"].Visible = false;
                dgvPretragaUgovora.Columns["InsertColumns"].Visible = false;
                dgvPretragaUgovora.Columns["InsertValues"].Visible = false;
                dgvPretragaUgovora.Columns["UpdateSetClause"].Visible = false;
                dgvPretragaUgovora.Columns["WhereClause"].Visible = false;

                dgvStanoviUgovor.Columns["TableName"].Visible = false;
                dgvStanoviUgovor.Columns["InsertColumns"].Visible = false;
                dgvStanoviUgovor.Columns["InsertValues"].Visible = false;
                dgvStanoviUgovor.Columns["UpdateSetClause"].Visible = false;
                dgvStanoviUgovor.Columns["WhereClause"].Visible = false;
                dgvStanoviUgovor.Columns["Idstan"].Visible=false;


                dgvPretragaUgovora.Columns["DatumOd"].HeaderText = "Datum od";
                dgvPretragaUgovora.Columns["DatumDo"].HeaderText = "Datum do";
                dgvPretragaUgovora.Columns["StanodavacImePrezime"].HeaderText = "Stanodavac";
                dgvPretragaUgovora.Columns["ZakupacImePrezime"].HeaderText = "Zakupac";
                dgvPretragaUgovora.Columns["UkupanIznos"].HeaderText = "Ukupan iznos";

                dgvStanoviUgovor.Columns["Stan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvStanoviUgovor.Columns["Iznos"].HeaderText = "Iznos";
                dgvStanoviUgovor.Columns["Stan"].HeaderText = "Stan";

            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show($"Sistem ne moze da ucita formu za pretragu ugovora.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dtpDatumOdPretraga_ValueChanged(object sender, EventArgs e)
        {
            dtpDatumDoPretraga.MinDate = dtpDatumOdPretraga.Value.AddDays(1);
        }

        private void dgvPretragaUgovora_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPretragaUgovora.SelectedRows.Count > 0)
            {
                btnDetalji.Enabled = true;
            }
            else
            {
                btnDetalji.Enabled = false;
            }
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? datumOd = cbPretragaPoVremenu.Checked ? dtpDatumOdPretraga.Value.Date : null;
                DateTime? datumDo = cbPretragaPoVremenu.Checked ? dtpDatumDoPretraga.Value.Date : null;
                int? zakupacId = (cmbZakupacPretraga.SelectedValue != null && (int)cmbZakupacPretraga.SelectedValue != 0) ? (int)cmbZakupacPretraga.SelectedValue : null;
                int? stanodavacId = prijavljeni.IdStanodavac;
                List<Ugovor> ugovori = Kontroler.Instance.PretraziUgovor(datumOd, datumDo, zakupacId, stanodavacId);
                if (ugovori.Count == 0)
                {
                    MessageBox.Show("Sistem ne moze da nadje ugovore po zadatim kriterijumima.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvPretragaUgovora.DataSource = Kontroler.Instance.VratiSveUgovore();
                    OsveziTxtBoxeve();
                    return;
                }
                else if (ugovori.Count == 1)
                {
                    MessageBox.Show("Sistem je nasao ugovor po zadatim kriterijumima.", "Infomracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sistem je nasao ugovore po zadatim kriterijumima.", "Infomracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dgvPretragaUgovora.DataSource = ugovori;
                OsveziTxtBoxeve();
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Sistem ne moze da nadje ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OsveziTxtBoxeve()
        {
            txtIdUgovor.Clear();
            dtpDatumOd.Value = DateTime.Now;
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            txtStanodavac.Clear();
            cmbZakupac.SelectedIndex = -1;
            txtUkupniIznos.Clear();
            txtIznosStan.Clear();
            dgvStanoviUgovor.ClearSelection();
            dgvStanoviUgovor.DataSource = new BindingList<StavkaUgovora>();
        }

        private void btnDetalji_Click(object sender, EventArgs e)
        {
            Ugovor selektovanUgovor = (Ugovor)dgvPretragaUgovora.SelectedRows[0].DataBoundItem;
            Ugovor ugovorSaStavkama = Kontroler.Instance.VratiUgovorSaStavkama(selektovanUgovor.IdUgovor);
            txtIdUgovor.Text = ugovorSaStavkama.IdUgovor.ToString();
            dtpDatumOd.Value = ugovorSaStavkama.DatumOd;
            dtpDatumDo.Value = ugovorSaStavkama.DatumDo;
            cmbZakupac.SelectedValue = ugovorSaStavkama.IdZakupac;
            txtStanodavac.Text = $"{prijavljeni.Ime} {prijavljeni.Prezime}";
            txtUkupniIznos.Text = ugovorSaStavkama.Iznos.ToString();
            cbDozvoliIzmene.Enabled = true;
            dgvStanoviUgovor.DataSource = new BindingList<StavkaUgovora>(ugovorSaStavkama.StavkeUgovora);
            MessageBox.Show("Sistem je nasao ugovor.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbDozvoliIzmene_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDozvoliIzmene.Checked)
            {
                btnIzmeni.Enabled = true;
                btnObrisi.Enabled = true;
                btnDodajStan.Enabled = true;
                cmbZakupac.Enabled = true;
                dtpDatumDo.Enabled = true;
                dtpDatumOd.Enabled = true;
                cmbStan.Enabled = true;
                txtIznosStan.Enabled = true;
                txtIznosStan.ReadOnly = false;
            }
            else
            {
                btnIzmeni.Enabled = false;
                btnObrisi.Enabled = false;
                btnDodajStan.Enabled = false;
            }
        }

        private void dgvStanoviUgovor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (cbDozvoliIzmene.Checked == false)
            {
                MessageBox.Show("Morate dozvoliti izmene!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rezultat = MessageBox.Show("Da li zelite da obrisete stavku iz ugovora?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                BindingList<StavkaUgovora> stavke = (BindingList<StavkaUgovora>)dgvStanoviUgovor.DataSource;
                stavke.RemoveAt(e.RowIndex);
                dgvStanoviUgovor.DataSource = stavke;
                txtUkupniIznos.Text = stavke.Sum(s => s.Iznos).ToString();
            }
        }

        private void btnDodajStan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIznosStan.Text) || Convert.ToDecimal(txtIznosStan.Text) <= 0)
                {
                    MessageBox.Show("Morate uneti validan iznos za stan.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIznosStan.Focus();
                    return;
                }
                Stan izabraniStan = (Stan)cmbStan.SelectedItem;
                BindingList<StavkaUgovora> stavke = (BindingList<StavkaUgovora>)dgvStanoviUgovor.DataSource;
                if (stavke.Any(s => s.IdStan == izabraniStan.IdStan))
                {
                    MessageBox.Show("Ovaj stan je vec dodat u ugovor.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                StavkaUgovora novaStavka = new StavkaUgovora
                {
                    IdStan = izabraniStan.IdStan,
                    Iznos = Convert.ToDecimal(txtIznosStan.Text),
                    IdUgovora = Convert.ToInt32(txtIdUgovor.Text),
                    Stan = izabraniStan,
                    Rb = stavke.Count + 1
                };
                stavke.Add(novaStavka);
                AzurirajIznos();
                txtIznosStan.Clear();
                MessageBox.Show("Sistem je uspesno dodao stan.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Doslo je do greske prilikom dodavanja stana!");
            }
        }

        private void AzurirajIznos()
        {
            if (dgvStanoviUgovor.DataSource != null)
            {
                BindingList<StavkaUgovora> stavke = (BindingList<StavkaUgovora>)dgvStanoviUgovor.DataSource;
                txtUkupniIznos.Text = stavke.Sum(s => s.Iznos).ToString();
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDatumDo.Value <= dtpDatumOd.Value)
                {
                    MessageBox.Show("Datum do mora biti veci od datuma od.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbZakupac.SelectedItem == null)
                {
                    MessageBox.Show("Morate izabrati zakupca.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BindingList<StavkaUgovora> stavke = (BindingList<StavkaUgovora>)dgvStanoviUgovor.DataSource;
                if (stavke == null || stavke.Count == 0)
                {
                    MessageBox.Show("Ugovor mora imati bar jedan stan.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Ugovor ugovor = new Ugovor
                {
                    IdUgovor = int.Parse(txtIdUgovor.Text),
                    IdStanodavac = prijavljeni.IdStanodavac,
                    IdZakupac = (int)cmbZakupac.SelectedValue,
                    DatumDo = dtpDatumDo.Value.Date,
                    DatumOd = dtpDatumOd.Value.Date,
                };
                int rb = 1;
                foreach (StavkaUgovora stavka in stavke)
                {
                    stavka.Rb = rb++;
                    stavka.IdUgovora = ugovor.IdUgovor;
                    ugovor.StavkeUgovora.Add(stavka);
                }
                Kontroler.Instance.PromeniUgovor(ugovor);
                MessageBox.Show("Sistem je zapamtio ugovor.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvPretragaUgovora.DataSource = Kontroler.Instance.VratiSveUgovore();
                OcistiFormu();
            }
            catch (Exception ex)
            {
                Helper.ProveraServerGreske(ex);
                MessageBox.Show("Sistem ne moze da zapamti ugovor.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcistiFormu()
        {
            txtIdUgovor.Clear();
            dtpDatumOd.Value = DateTime.Now;
            dtpDatumDo.Value = dtpDatumOd.Value.AddDays(1);
            dtpDatumDo.Enabled = false;
            dtpDatumOd.Enabled = false;
            cmbZakupac.Enabled = false;
            cbDozvoliIzmene.Enabled = false;
            btnDetalji.Enabled = false;
            btnDodajStan.Enabled = false;
            btnIzmeni.Enabled = false;
            btnObrisi.Enabled = false;
            cmbStan.Enabled = false;
            txtIznosStan.Enabled = false;
            txtIznosStan.ReadOnly = true;
            dgvStanoviUgovor.DataSource = new BindingList<StavkaUgovora>();
            cbDozvoliIzmene.Checked = false;
        }
    }
}
