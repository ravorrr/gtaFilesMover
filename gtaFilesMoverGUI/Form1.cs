using System;
using System.Windows.Forms;
using gtaFilesMoverLib;
using System.Media;

namespace gtaFilesMoverGUI
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;

        public Form1()
        {
            InitializeComponent();

            txtGtaPath.Text = Properties.Settings.Default.LastGtaPath;
            txtBackupPath.Text = Properties.Settings.Default.LastBackupPath;

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
        }

        private void btnMoveAllToBackup_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie wszystkich plików do folderu backup...", addSeparator: true);
            try
            {
                FileMover.MoveAllFilesToBackup();
                Log("Sukces: Przeniesiono wszystkie pliki do backup.", addSeparator: true);
                ShowNotification("Przeniesiono wszystkie pliki do backup.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
        }

        private void btnMoveAllToGTA_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie wszystkich plików do GTA...", addSeparator: true);
            try
            {
                FileMover.MoveAllFilesToGTA();
                Log("Sukces: Przeniesiono wszystkie pliki do GTA.", addSeparator: true);
                ShowNotification("Przeniesiono wszystkie pliki do GTA.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
        }

        private void btnMoveReshadeToBackup_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie plików reshade do backup...", addSeparator: true);
            try
            {
                FileMover.MoveOnlyReshadeFilesToBackup();
                Log("Sukces: Przeniesiono pliki reshade do backup.", addSeparator: true);
                ShowNotification("Przeniesiono pliki reshade do backup.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
        }

        private void Log(string message, bool addTimestamp = true, bool addSeparator = false)
        {
            if (addTimestamp)
            {
                message = $"[{DateTime.Now:HH:mm:ss}] {message}";
            }

            listBoxLog.Items.Add(message);

            if (addSeparator)
            {
                listBoxLog.Items.Add(new string('-', 73));
            }

            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
        }

        private void ShowNotification(string message)
        {
            notifyIcon.BalloonTipTitle = "Operacja zakoñczona";
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(3000);
        }

        private void btnBrowseGtaPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtGtaPath.Text = folderDialog.SelectedPath;
                    Properties.Settings.Default.LastGtaPath = folderDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnBrowseBackupPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = folderDialog.SelectedPath;
                    Properties.Settings.Default.LastBackupPath = folderDialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
