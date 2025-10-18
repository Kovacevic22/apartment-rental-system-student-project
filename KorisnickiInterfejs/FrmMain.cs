using Domen;
using KorisnickiInterfejs.StanodavacForme;
using KorisnickiInterfejs.UgovorForme;
using KorisnickiInterfejs.UIKontroler;
using KorisnickiInterfejs.ZakupacForme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorisnickiInterfejs
{
    public partial class FrmMain : Form
    {
        private Stanodavac prijavljeni;
        public FrmMain(Stanodavac prijavljeni)
        {
            InitializeComponent();
            //
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            this.prijavljeni = prijavljeni;
            this.Text = $"Zdravo {prijavljeni.Ime} {prijavljeni.Prezime}";
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Kontroler.Instance?.Disconnect();
                LoginFrm loginFrm = new LoginFrm();
                loginFrm.Show();
            }
            catch { }
        }

        private void kreirajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKreirajZakupca frmKreirajZakupca = new FrmKreirajZakupca();
            frmKreirajZakupca.ShowDialog();
        }

        private void pretraziToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmPretrazi frmPretrazi = new FrmPretrazi();
            frmPretrazi.ShowDialog();
        }

        private void pretraziToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKreirajUgovor frmKreirajUgovor = new FrmKreirajUgovor(prijavljeni);
            frmKreirajUgovor.ShowDialog();
        }

        private void promeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPretraziUgovore frmPretraziUgovore = new FrmPretraziUgovore(prijavljeni);
            frmPretraziUgovore.ShowDialog();
        }

        private void ubaciTerminIznajmljivanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUbaciTerminIznajmljivanja frmUbaciTerminIznajmljivanja = new FrmUbaciTerminIznajmljivanja(prijavljeni);
            frmUbaciTerminIznajmljivanja.ShowDialog();
        }
    }
}
