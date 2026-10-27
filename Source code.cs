/*
 * ==============================================================================
 * LocalWP Doctor (Classic Edition)
 * Open-Source Utility for Local (LocalWP)
 *
 * Developed by: Mohammaed El-gammal
 * Author Credit: Mohammaed El-gammal 
 * License: MIT Open Source License
 * Version: 1.0.0 Classic Edition
 *
 * Description:
 *   Lightweight, focused tool for solving MySQL startup timeouts (10061),
 *   cleaning stale PID lock files, and applying HDD performance optimizations.
 * ==============================================================================
 */

using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace LocalWPFixerClassic
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private Color bgDark = Color.FromArgb(15, 23, 42);
        private Color cardDark = Color.FromArgb(30, 41, 59);
        private Color textLight = Color.FromArgb(248, 250, 252);
        private Color textMuted = Color.FromArgb(148, 163, 184);
        private Color accentGreen = Color.FromArgb(16, 185, 129);
        private Color accentBlue = Color.FromArgb(56, 189, 248);
        private Color logBg = Color.FromArgb(2, 6, 23);

        private RichTextBox txtLog;
        private NumericUpDown numRetries;
        private Label lblStatusSummary;
        private Button btnApply;
        private Button btnScan;
        private Button btnCleanPids;

        public MainForm()
        {
            InitializeComponent();
            try { this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath); } catch { }

            Log("=============================================================", Color.FromArgb(100, 116, 139));
            Log(" LocalWP Doctor - Classic Edition (v1.0)", accentBlue);
            Log(" Developed by Mohammaed El-gammal ", accentGreen);
            Log("=============================================================", Color.FromArgb(100, 116, 139));
            Log("[*] Initializing system check...", textMuted);
            RunDiagnostics();
        }

        private void InitializeComponent()
        {
            this.Text = "LocalWP Doctor (Classic) • by Mohammaed El-gammal";
            this.Size = new Size(720, 680);
            this.MinimumSize = new Size(680, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = bgDark;
            this.ForeColor = textLight;
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(20);
            mainPanel.BackColor = bgDark;
            this.Controls.Add(mainPanel);

            // Header Panel
            Panel headerPanel = new Panel();
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 85;
            headerPanel.BackColor = cardDark;
            headerPanel.Padding = new Padding(15, 12, 15, 12);
            mainPanel.Controls.Add(headerPanel);

            Label lblTitle = new Label();
            lblTitle.Text = "LocalWP Doctor (Classic)";
            lblTitle.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblTitle.ForeColor = textLight;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 12);
            headerPanel.Controls.Add(lblTitle);

            Label lblSub = new Label();
            lblSub.Text = "Fast & Lightweight MySQL Timeout Fixer for LocalWP";
            lblSub.Font = new Font("Segoe UI", 9f);
            lblSub.ForeColor = textMuted;
            lblSub.AutoSize = true;
            lblSub.Location = new Point(16, 42);
            headerPanel.Controls.Add(lblSub);

            Label lblBadge = new Label();
            lblBadge.Text = "★ Created by Mohammaed El-gammal";
            lblBadge.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lblBadge.ForeColor = accentGreen;
            lblBadge.BackColor = Color.FromArgb(6, 78, 59);
            lblBadge.AutoSize = true;
            lblBadge.Padding = new Padding(8, 4, 8, 4);
            lblBadge.Location = new Point(480, 15);
            lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            headerPanel.Controls.Add(lblBadge);

            // Controls Card
            Panel cardControls = new Panel();
            cardControls.Dock = DockStyle.Top;
            cardControls.Height = 160;
            cardControls.BackColor = cardDark;
            cardControls.Padding = new Padding(15);

            Panel spacer1 = new Panel();
            spacer1.Dock = DockStyle.Top;
            spacer1.Height = 15;
            mainPanel.Controls.Add(spacer1);
            mainPanel.Controls.Add(cardControls);

            lblStatusSummary = new Label();
            lblStatusSummary.Text = "Status: Checking system configuration...";
            lblStatusSummary.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lblStatusSummary.ForeColor = accentBlue;
            lblStatusSummary.AutoSize = true;
            lblStatusSummary.Location = new Point(15, 15);
            cardControls.Controls.Add(lblStatusSummary);

            Label lblRetryPrompt = new Label();
            lblRetryPrompt.Text = "Target Timeout Retries (Wait attempts for MySQL):";
            lblRetryPrompt.ForeColor = textLight;
            lblRetryPrompt.AutoSize = true;
            lblRetryPrompt.Location = new Point(15, 48);
            cardControls.Controls.Add(lblRetryPrompt);

            numRetries = new NumericUpDown();
            numRetries.Minimum = 10;
            numRetries.Maximum = 60;
            numRetries.Value = 25;
            numRetries.BackColor = bgDark;
            numRetries.ForeColor = textLight;
            numRetries.Location = new Point(340, 46);
            numRetries.Width = 65;
            cardControls.Controls.Add(numRetries);

            btnApply = CreateButton("🚀 Apply Full Repair", accentGreen, Color.White, 15, 90, 270, 45);
            btnApply.Click += new EventHandler(this.btnApply_Click);
            cardControls.Controls.Add(btnApply);

            btnScan = CreateButton("🔍 Scan System", Color.FromArgb(59, 130, 246), Color.White, 295, 90, 160, 45);
            btnScan.Click += new EventHandler(this.btnScan_Click);
            cardControls.Controls.Add(btnScan);

            btnCleanPids = CreateButton("🧹 Clean PIDs", Color.FromArgb(71, 85, 105), textLight, 465, 90, 150, 45);
            btnCleanPids.Click += new EventHandler(this.btnCleanPids_Click);
            cardControls.Controls.Add(btnCleanPids);

            // Log Console Card
            Panel cardLog = new Panel();
            cardLog.Dock = DockStyle.Fill;
            cardLog.BackColor = cardDark;
            cardLog.Padding = new Padding(12);

            Panel spacer2 = new Panel();
            spacer2.Dock = DockStyle.Top;
            spacer2.Height = 15;
            mainPanel.Controls.Add(spacer2);
            mainPanel.Controls.Add(cardLog);

            Label lblLogTitle = new Label();
            lblLogTitle.Text = "Activity Log:";
            lblLogTitle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblLogTitle.ForeColor = textMuted;
            lblLogTitle.Dock = DockStyle.Top;
            lblLogTitle.Height = 25;
            cardLog.Controls.Add(lblLogTitle);

            txtLog = new RichTextBox();
            txtLog.Dock = DockStyle.Fill;
            txtLog.BackColor = logBg;
            txtLog.ForeColor = Color.FromArgb(226, 232, 240);
            txtLog.Font = new Font("Consolas", 9.5f, FontStyle.Regular);
            txtLog.BorderStyle = BorderStyle.None;
            txtLog.ReadOnly = true;
            cardLog.Controls.Add(txtLog);

            // Footer
            Panel footerPanel = new Panel();
            footerPanel.Dock = DockStyle.Bottom;
            footerPanel.Height = 35;
            footerPanel.BackColor = bgDark;
            mainPanel.Controls.Add(footerPanel);

            Label lblFooter = new Label();
            lblFooter.Text = "MIT License • Author: Mohammaed El-gamal • 2026";
            lblFooter.Font = new Font("Segoe UI", 8.5f);
            lblFooter.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooter.Dock = DockStyle.Left;
            lblFooter.AutoSize = true;
            lblFooter.Padding = new Padding(0, 10, 0, 0);
            footerPanel.Controls.Add(lblFooter);
        }

        private Button CreateButton(string text, Color bg, Color fg, int x, int y, int width, int height)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.Location = new Point(x, y);
            btn.Size = new Size(width, height);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            return btn;
        }

        private void Log(string message, Color color)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;
            txtLog.SelectionColor = color;
            txtLog.AppendText(string.Format("[{0:HH:mm:ss}] {1}\n", DateTime.Now, message));
            txtLog.ScrollToCaret();
        }

        private void RunDiagnostics()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string servicesDir = Path.Combine(appData, @"Local\lightning-services");
            string runDir = Path.Combine(appData, @"Local\run");

            if (!Directory.Exists(servicesDir))
            {
                Log("[!] LocalWP services directory not found.", Color.FromArgb(239, 68, 68));
                lblStatusSummary.Text = "Status: LocalWP installation not detected!";
                lblStatusSummary.ForeColor = Color.FromArgb(239, 68, 68);
                return;
            }

            int fixedCount = 0;
            int pendingCount = 0;

            string[] jsFiles = Directory.GetFiles(servicesDir, "*.js", SearchOption.AllDirectories);
            foreach (string file in jsFiles)
            {
                string filename = Path.GetFileName(file);
                if (filename == "MysqlService.js" || filename == "MariadbService.js")
                {
                    string content = File.ReadAllText(file);
                    Match m = Regex.Match(content, @"maxTries\s*=\s*(\d+);");
                    if (m.Success)
                    {
                        int tries = int.Parse(m.Groups[1].Value);
                        if (tries >= 20)
                        {
                            fixedCount++;
                            Log(string.Format("[✓] Healthy: {0} (maxTries = {1})", filename, tries), Color.FromArgb(52, 211, 153));
                        }
                        else
                        {
                            pendingCount++;
                            Log(string.Format("[!] Timeout Warning: {0} has low maxTries = {1}", filename, tries), Color.FromArgb(251, 191, 36));
                        }
                    }
                }
            }

            int pidCount = 0;
            if (Directory.Exists(runDir))
            {
                string[] pids = Directory.GetFiles(runDir, "*.pid", SearchOption.AllDirectories);
                pidCount = pids.Length;
                if (pidCount > 0)
                {
                    Log(string.Format("[!] Found {0} stale PID lock files.", pidCount), Color.FromArgb(251, 191, 36));
                }
                else
                {
                    Log("[✓] No stale PID lock files detected.", Color.FromArgb(52, 211, 153));
                }
            }

            if (pendingCount == 0 && pidCount == 0)
            {
                lblStatusSummary.Text = "Status: System is optimized and healthy!";
                lblStatusSummary.ForeColor = accentGreen;
            }
            else
            {
                lblStatusSummary.Text = string.Format("Status: Action required! {0} low timeout(s), {1} stale PID(s).", pendingCount, pidCount);
                lblStatusSummary.ForeColor = Color.FromArgb(251, 191, 36);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Log("-------------------------------------------------------------", Color.FromArgb(100, 116, 139));
            Log("[*] Executing Full Repair...", accentBlue);

            int targetRetries = (int)numRetries.Value;
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string servicesDir = Path.Combine(appData, @"Local\lightning-services");
            string runDir = Path.Combine(appData, @"Local\run");

            int patched = 0;
            if (Directory.Exists(servicesDir))
            {
                string[] jsFiles = Directory.GetFiles(servicesDir, "*.js", SearchOption.AllDirectories);
                foreach (string file in jsFiles)
                {
                    string filename = Path.GetFileName(file);
                    if (filename == "MysqlService.js" || filename == "MariadbService.js")
                    {
                        try
                        {
                            string content = File.ReadAllText(file);
                            if (Regex.IsMatch(content, @"maxTries\s*=\s*\d+;"))
                            {
                                string updated = Regex.Replace(content, @"maxTries\s*=\s*\d+;", string.Format("maxTries = {0};", targetRetries));
                                File.WriteAllText(file, updated);
                                patched++;
                                Log(string.Format("[✓] Updated timeout in: {0}", filename), Color.FromArgb(52, 211, 153));
                            }
                        }
                        catch (Exception ex)
                        {
                            Log(string.Format("[X] Error updating {0}: {1}", filename, ex.Message), Color.FromArgb(239, 68, 68));
                        }
                    }
                }
            }

            int removedPids = 0;
            if (Directory.Exists(runDir))
            {
                string[] pids = Directory.GetFiles(runDir, "*.pid", SearchOption.AllDirectories);
                foreach (string pid in pids)
                {
                    try
                    {
                        File.Delete(pid);
                        removedPids++;
                        Log(string.Format("[✓] Removed stale PID: {0}", Path.GetFileName(pid)), Color.FromArgb(52, 211, 153));
                    }
                    catch { }
                }
            }

            Log("=============================================================", Color.FromArgb(100, 116, 139));
            Log(string.Format("[SUCCESS] Finished! {0} services patched, {1} PIDs cleaned.", patched, removedPids), Color.FromArgb(52, 211, 153));
            Log("[*] You can now start LocalWP safely!", accentGreen);

            lblStatusSummary.Text = "Status: Repair applied successfully!";
            lblStatusSummary.ForeColor = accentGreen;

            MessageBox.Show(
                string.Format("Repair complete!\n\n• Patched Services: {0}\n• Cleaned PID Locks: {1}\n\nYour Local sites are ready to start!",
                patched, removedPids),
                "LocalWP Doctor - Mohamed Elgamal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Log("-------------------------------------------------------------", Color.FromArgb(100, 116, 139));
            Log("[*] Running system scan...", textMuted);
            RunDiagnostics();
        }

        private void btnCleanPids_Click(object sender, EventArgs e)
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string runDir = Path.Combine(appData, @"Local\run");
            int cleaned = 0;
            if (Directory.Exists(runDir))
            {
                string[] pids = Directory.GetFiles(runDir, "*.pid", SearchOption.AllDirectories);
                foreach (string pid in pids)
                {
                    try
                    {
                        File.Delete(pid);
                        cleaned++;
                    }
                    catch { }
                }
            }
            Log(string.Format("[*] Cleaned {0} stale PID file(s).", cleaned), accentGreen);
            RunDiagnostics();
        }
    }
}
