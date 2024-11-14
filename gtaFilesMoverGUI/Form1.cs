using System;
using System.IO;
using System.Threading.Tasks;
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
            lblFileCounter.Text = "Postêp przenoszenia plików";

            FileMover.FileMoved += UpdateProgress;

            UpdateFileLocations();
        }

        private void UpdateFileLocations()
        {
            listViewFileLocations.Items.Clear();

            foreach (string file in FileMover.filesToMove)
            {
                string gtaPath = Path.Combine(FileMover.gtaFolder, file);
                string backupPath = Path.Combine(FileMover.backupFolder, file);
                string reshadePath = Path.Combine(FileMover.backupFolder, "reshade", file);

                string location = "Not found";
                if (File.Exists(gtaPath) || Directory.Exists(gtaPath))
                    location = "GTA V";
                else if (File.Exists(backupPath) || Directory.Exists(backupPath))
                    location = "Backup";
                else if (File.Exists(reshadePath) || Directory.Exists(reshadePath))
                    location = "Backup/Reshade";

                var item = new ListViewItem(file);
                item.SubItems.Add(location);
                listViewFileLocations.Items.Add(item);
            }
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
            lblFileCounter.Text = $"Przenoszenie plików: {filesMoved}/{totalFiles} ({(filesMoved * 100) / totalFiles}%)";
        }

        private async void btnMoveAllToBackup_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie wszystkich plików do folderu backup...", addSeparator: true);
            try
            {
                await Task.Run(() => FileMover.MoveAllFilesToBackup());
                Log("Sukces: Przeniesiono wszystkie pliki do backup.", addSeparator: true);
                ShowNotification("Przeniesiono wszystkie pliki do backup.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
            finally
            {
                UpdateFileLocations();
                progressBar.Value = 0;
            }
        }

        private async void btnMoveAllToGTA_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie wszystkich plików do GTA...", addSeparator: true);
            try
            {
                await Task.Run(() => FileMover.MoveAllFilesToGTA());
                Log("Sukces: Przeniesiono wszystkie pliki do GTA.", addSeparator: true);
                ShowNotification("Przeniesiono wszystkie pliki do GTA.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
            finally
            {
                UpdateFileLocations();
                progressBar.Value = 0;
            }
        }

        private async void btnMoveReshadeToBackup_Click(object sender, EventArgs e)
        {
            FileMover.gtaFolder = txtGtaPath.Text;
            FileMover.backupFolder = txtBackupPath.Text;

            Log("Przenoszenie plików reshade do backup...", addSeparator: true);
            try
            {
                await Task.Run(() => FileMover.MoveOnlyReshadeFilesToBackup());
                Log("Sukces: Przeniesiono pliki reshade do backup.", addSeparator: true);
                ShowNotification("Przeniesiono pliki reshade do backup.");
                SystemSounds.Exclamation.Play();
            }
            catch (Exception ex)
            {
                Log($"B³¹d: {ex.Message}", addSeparator: true);
            }
            finally
            {
                UpdateFileLocations();
                progressBar.Value = 0;
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
            SystemSounds.Exclamation.Play();
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
