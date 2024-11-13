using System;
using System.Windows.Forms;
using gtaFilesMoverLib;
using System.Media;

namespace gtaFilesMoverGUI
{
    public partial class Form1 : Form
    {
        private readonly NotifyIcon notifyIcon;

        public Form1()
        {
            InitializeComponent();

            txtGtaPath.Text = Properties.Settings.Default.LastGtaPath;
            txtBackupPath.Text = Properties.Settings.Default.LastBackupPath;

            notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
            lblFileCounter.Text = "Postêp przenoszenia plików";

            FileMover.FileMoved += UpdateProgress;
        }

        private void UpdateProgress(int filesMoved, int totalFiles)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, int>(UpdateProgress), filesMoved, totalFiles);
                return;
            }

            progressBar.Maximum = totalFiles;
            progressBar.Value = filesMoved;
        }

        private void PerformFileMove(Action moveAction, string successMessage)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log(successMessage, addSeparator: true);
            try
            {
                moveAction();
                Log($"Sukces: {successMessage}", addSeparator: true);
                ShowNotification(successMessage);
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
            finally
            {
                progressBar.Value = 0;
            }
        }

        private void btnMoveAllToBackup_Click(object sender, EventArgs e) =>
            PerformFileMove(FileMover.MoveAllFilesToBackup, "Przenoszenie wszystkich plików do folderu backup...");

        private void btnMoveAllToGTA_Click(object sender, EventArgs e) =>
            PerformFileMove(FileMover.MoveAllFilesToGTA, "Przenoszenie wszystkich plików do GTA...");

        private void btnMoveReshadeToBackup_Click(object sender, EventArgs e) =>
            PerformFileMove(FileMover.MoveOnlyReshadeFilesToBackup, "Przenoszenie plików reshade do backup...");

        private void Log(string message, bool addTimestamp = true, bool addSeparator = false)
        {
            if (addTimestamp)
            {
                message = $"[{DateTime.Now:HH:mm:ss}] {message}";
            }

            listBoxLog.Items.Add(message);

            if (addSeparator)
            {
                listBoxLog.Items.Add(new string('-', 75));
            }

            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
        }

        private void ShowNotification(string message)
        {
            notifyIcon.BalloonTipTitle = "Operacja zakoñczona";
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(3000);
        }

        private void btnBrowseGtaPath_Click(object sender, EventArgs e) => BrowsePath(txtGtaPath, "LastGtaPath");

        private void btnBrowseBackupPath_Click(object sender, EventArgs e) => BrowsePath(txtBackupPath, "LastBackupPath");

        private void BrowsePath(TextBox textBox, string settingKey)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderDialog.SelectedPath;
                    Properties.Settings.Default[settingKey] = folderDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
