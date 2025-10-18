namespace Server
{
    public partial class ServerFrm : Form
    {
        private Server server;
        private bool isRunning = false;
        public ServerFrm()
        {
            InitializeComponent();
            //
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //
            btnZaustaviSrv.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void DodajLog(string log)
        {
            if (lbLogs.InvokeRequired)
            {
                lbLogs.Invoke(new Action(() => DodajLog(log)));
                return;
            }
            string vreme = DateTime.Now.ToString("HH:mm:ss");
            lbLogs.Items.Add($"[{vreme}] {log}");
            lbLogs.TopIndex = lbLogs.Items.Count - 1;
        }
        private void btnPokreniSrv_Click(object sender, EventArgs e)
        {
            try
            {
                server = new Server();
                server.Start(this);
                lblServer.Text = "Server je pokrenut na portu 9999!";
                lblServer.ForeColor = Color.Green;
                DodajLog("Server je pokrenut! - ceka stanodavce...");
                btnPokreniSrv.Enabled = false;
                btnZaustaviSrv.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom pokretanja servera! ({ex.Message})", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnZaustaviSrv_Click(object sender, EventArgs e)
        {
            try
            {
                server?.Stop();
                lblServer.Text = "Server nije pokrenut!";
                lblServer.ForeColor = Color.Red;
                DodajLog("Server je zaustavljen!");
                btnPokreniSrv.Enabled = true;
                btnZaustaviSrv.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska prilikom zaustavljanja servera! ({ex.Message})", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbLogs.Items.Clear();
        }

        private void ServerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Stop();
        }
    }
}
