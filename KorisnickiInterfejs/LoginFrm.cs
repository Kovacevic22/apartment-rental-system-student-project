using Domen;
using KorisnickiInterfejs.UIKontroler;

namespace KorisnickiInterfejs
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
            //
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Sva polja su obavezna!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Kontroler kontroler = Kontroler.Instance;
                kontroler.Connect();
                Stanodavac prijavljeni = kontroler.Login(txtEmail.Text, txtPassword.Text);
                if (prijavljeni != null)
                {
                    MessageBox.Show("Uspesno ste se prijavili!", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMain frmMain = new FrmMain(prijavljeni);
                    frmMain.Show();
                    this.Hide();
                    txtEmail.Clear();
                    txtPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Clear();
                txtPassword.Clear();
            }
        }

        private void LoginFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch
            {
                
            }
        }
    }
}
