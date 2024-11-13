using System;
using System.Windows.Forms;
using gtaFilesMoverLib;

namespace gtaFilesMoverGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void btnBrowseGtaPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtGtaPath.Text = folderDialog.SelectedPath;
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
                }
            }
        }
    }
}
