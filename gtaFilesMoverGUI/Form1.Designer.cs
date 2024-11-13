namespace gtaFilesMoverGUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnMoveAllToBackup = new Button();
            btnMoveAllToGTA = new Button();
            btnMoveReshadeToBackup = new Button();
            listBoxLog = new ListBox();
            txtGtaPath = new TextBox();
            txtBackupPath = new TextBox();
            btnBrowseGtaPath = new Button();
            btnBrowseBackupPath = new Button();
            progressBar = new ProgressBar();
            lblFileCounter = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listViewFileLocations = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            SuspendLayout();
            // 
            // btnMoveAllToBackup
            // 
            btnMoveAllToBackup.Location = new Point(300, 395);
            btnMoveAllToBackup.Name = "btnMoveAllToBackup";
            btnMoveAllToBackup.Size = new Size(206, 43);
            btnMoveAllToBackup.TabIndex = 0;
            btnMoveAllToBackup.Text = "Przenieś wszystkie do backup";
            btnMoveAllToBackup.UseVisualStyleBackColor = true;
            btnMoveAllToBackup.Click += btnMoveAllToBackup_Click;
            // 
            // btnMoveAllToGTA
            // 
            btnMoveAllToGTA.Location = new Point(12, 395);
            btnMoveAllToGTA.Name = "btnMoveAllToGTA";
            btnMoveAllToGTA.Size = new Size(206, 43);
            btnMoveAllToGTA.TabIndex = 1;
            btnMoveAllToGTA.Text = "Przenieś wszystkie do GTA";
            btnMoveAllToGTA.UseVisualStyleBackColor = true;
            btnMoveAllToGTA.Click += btnMoveAllToGTA_Click;
            // 
            // btnMoveReshadeToBackup
            // 
            btnMoveReshadeToBackup.Location = new Point(582, 395);
            btnMoveReshadeToBackup.Name = "btnMoveReshadeToBackup";
            btnMoveReshadeToBackup.Size = new Size(206, 43);
            btnMoveReshadeToBackup.TabIndex = 2;
            btnMoveReshadeToBackup.Text = "Przenieś Reshade do backup";
            btnMoveReshadeToBackup.UseVisualStyleBackColor = true;
            btnMoveReshadeToBackup.Click += btnMoveReshadeToBackup_Click;
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 15;
            listBoxLog.Location = new Point(12, 30);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(445, 154);
            listBoxLog.TabIndex = 3;
            // 
            // txtGtaPath
            // 
            txtGtaPath.Location = new Point(12, 237);
            txtGtaPath.Name = "txtGtaPath";
            txtGtaPath.Size = new Size(538, 23);
            txtGtaPath.TabIndex = 4;
            // 
            // txtBackupPath
            // 
            txtBackupPath.Location = new Point(12, 266);
            txtBackupPath.Name = "txtBackupPath";
            txtBackupPath.Size = new Size(538, 23);
            txtBackupPath.TabIndex = 5;
            // 
            // btnBrowseGtaPath
            // 
            btnBrowseGtaPath.Location = new Point(556, 236);
            btnBrowseGtaPath.Name = "btnBrowseGtaPath";
            btnBrowseGtaPath.Size = new Size(232, 23);
            btnBrowseGtaPath.TabIndex = 6;
            btnBrowseGtaPath.Text = "Wybierz folder GTA V";
            btnBrowseGtaPath.UseVisualStyleBackColor = true;
            btnBrowseGtaPath.Click += btnBrowseGtaPath_Click;
            // 
            // btnBrowseBackupPath
            // 
            btnBrowseBackupPath.Location = new Point(556, 265);
            btnBrowseBackupPath.Name = "btnBrowseBackupPath";
            btnBrowseBackupPath.Size = new Size(232, 23);
            btnBrowseBackupPath.TabIndex = 7;
            btnBrowseBackupPath.Text = "Wybierz folder backup";
            btnBrowseBackupPath.UseVisualStyleBackColor = true;
            btnBrowseBackupPath.Click += btnBrowseBackupPath_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 343);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(776, 23);
            progressBar.TabIndex = 8;
            // 
            // lblFileCounter
            // 
            lblFileCounter.AutoSize = true;
            lblFileCounter.Location = new Point(12, 325);
            lblFileCounter.Name = "lblFileCounter";
            lblFileCounter.Size = new Size(152, 15);
            lblFileCounter.TabIndex = 9;
            lblFileCounter.Text = "Postęp przenoszenia plików";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 10;
            label1.Text = "Log operacji";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 219);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 11;
            label2.Text = "Ścieżki folderów";
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(12, 203);
            label3.Name = "label3";
            label3.Size = new Size(776, 2);
            label3.TabIndex = 12;
            // 
            // label4
            // 
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(12, 306);
            label4.Name = "label4";
            label4.Size = new Size(776, 2);
            label4.TabIndex = 13;
            // 
            // listViewFileLocations
            // 
            listViewFileLocations.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3 });
            listViewFileLocations.FullRowSelect = true;
            listViewFileLocations.Location = new Point(463, 30);
            listViewFileLocations.Name = "listViewFileLocations";
            listViewFileLocations.Size = new Size(325, 154);
            listViewFileLocations.TabIndex = 14;
            listViewFileLocations.UseCompatibleStateImageBehavior = false;
            listViewFileLocations.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "File/Folder";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Location";
            columnHeader3.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewFileLocations);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblFileCounter);
            Controls.Add(progressBar);
            Controls.Add(btnBrowseBackupPath);
            Controls.Add(btnBrowseGtaPath);
            Controls.Add(txtBackupPath);
            Controls.Add(txtGtaPath);
            Controls.Add(listBoxLog);
            Controls.Add(btnMoveReshadeToBackup);
            Controls.Add(btnMoveAllToGTA);
            Controls.Add(btnMoveAllToBackup);
            Name = "Form1";
            Text = "Narzędzie do przenoszenia plików GTA V";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnMoveAllToBackup;
        private Button btnMoveAllToGTA;
        private Button btnMoveReshadeToBackup;
        private ListBox listBoxLog;
        private TextBox txtGtaPath;
        private TextBox txtBackupPath;
        private Button btnBrowseGtaPath;
        private Button btnBrowseBackupPath;
        private ProgressBar progressBar;
        private Label lblFileCounter;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListView listViewFileLocations;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
