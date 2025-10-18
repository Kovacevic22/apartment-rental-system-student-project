namespace Server
{
    partial class ServerFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPokreniSrv = new Button();
            btnZaustaviSrv = new Button();
            lblServer = new Label();
            lbLogs = new ListBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnPokreniSrv
            // 
            btnPokreniSrv.Location = new Point(100, 35);
            btnPokreniSrv.Name = "btnPokreniSrv";
            btnPokreniSrv.Size = new Size(131, 29);
            btnPokreniSrv.TabIndex = 0;
            btnPokreniSrv.Text = "Pokreni server";
            btnPokreniSrv.UseVisualStyleBackColor = true;
            btnPokreniSrv.Click += btnPokreniSrv_Click;
            // 
            // btnZaustaviSrv
            // 
            btnZaustaviSrv.Location = new Point(622, 35);
            btnZaustaviSrv.Name = "btnZaustaviSrv";
            btnZaustaviSrv.Size = new Size(131, 29);
            btnZaustaviSrv.TabIndex = 1;
            btnZaustaviSrv.Text = "Zaustavi server";
            btnZaustaviSrv.UseVisualStyleBackColor = true;
            btnZaustaviSrv.Click += btnZaustaviSrv_Click;
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.ForeColor = Color.Red;
            lblServer.Location = new Point(311, 421);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(143, 20);
            lblServer.TabIndex = 2;
            lblServer.Text = "Server je zaustavljen";
            // 
            // lbLogs
            // 
            lbLogs.FormattingEnabled = true;
            lbLogs.Location = new Point(12, 85);
            lbLogs.Name = "lbLogs";
            lbLogs.Size = new Size(776, 244);
            lbLogs.TabIndex = 3;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 335);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear logs";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // ServerFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(lbLogs);
            Controls.Add(lblServer);
            Controls.Add(btnZaustaviSrv);
            Controls.Add(btnPokreniSrv);
            Name = "ServerFrm";
            Text = "Server";
            FormClosing += ServerFrm_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPokreniSrv;
        private Button btnZaustaviSrv;
        private Label lblServer;
        private ListBox lbLogs;
        private Button btnClear;
    }
}
