﻿namespace gtaFilesMoverGUI
{
    partial class Form1
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
            SuspendLayout();
            // 
            // btnMoveAllToBackup
            // 
            btnMoveAllToBackup.Location = new Point(132, 93);
            btnMoveAllToBackup.Name = "btnMoveAllToBackup";
            btnMoveAllToBackup.Size = new Size(174, 23);
            btnMoveAllToBackup.TabIndex = 0;
            btnMoveAllToBackup.Text = "Przenieś wszystkie do backup";
            btnMoveAllToBackup.UseVisualStyleBackColor = true;
            btnMoveAllToBackup.Click += btnMoveAllToBackup_Click;
            // 
            // btnMoveAllToGTA
            // 
            btnMoveAllToGTA.Location = new Point(132, 122);
            btnMoveAllToGTA.Name = "btnMoveAllToGTA";
            btnMoveAllToGTA.Size = new Size(174, 23);
            btnMoveAllToGTA.TabIndex = 1;
            btnMoveAllToGTA.Text = "Przenieś wszystkie do GTA";
            btnMoveAllToGTA.UseVisualStyleBackColor = true;
            btnMoveAllToGTA.Click += btnMoveAllToGTA_Click;
            // 
            // btnMoveReshadeToBackup
            // 
            btnMoveReshadeToBackup.Location = new Point(132, 151);
            btnMoveReshadeToBackup.Name = "btnMoveReshadeToBackup";
            btnMoveReshadeToBackup.Size = new Size(174, 23);
            btnMoveReshadeToBackup.TabIndex = 2;
            btnMoveReshadeToBackup.Text = "Przenieś Reshade do backup";
            btnMoveReshadeToBackup.UseVisualStyleBackColor = true;
            btnMoveReshadeToBackup.Click += btnMoveReshadeToBackup_Click;
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 15;
            listBoxLog.Location = new Point(411, 12);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(377, 244);
            listBoxLog.TabIndex = 3;
            // 
            // txtGtaPath
            // 
            txtGtaPath.Location = new Point(250, 296);
            txtGtaPath.Name = "txtGtaPath";
            txtGtaPath.Size = new Size(538, 23);
            txtGtaPath.TabIndex = 4;
            // 
            // txtBackupPath
            // 
            txtBackupPath.Location = new Point(250, 325);
            txtBackupPath.Name = "txtBackupPath";
            txtBackupPath.Size = new Size(538, 23);
            txtBackupPath.TabIndex = 5;
            // 
            // btnBrowseGtaPath
            // 
            btnBrowseGtaPath.Location = new Point(12, 296);
            btnBrowseGtaPath.Name = "btnBrowseGtaPath";
            btnBrowseGtaPath.Size = new Size(232, 23);
            btnBrowseGtaPath.TabIndex = 6;
            btnBrowseGtaPath.Text = "Wybierz folder GTA V";
            btnBrowseGtaPath.UseVisualStyleBackColor = true;
            btnBrowseGtaPath.Click += btnBrowseGtaPath_Click;
            // 
            // btnBrowseBackupPath
            // 
            btnBrowseBackupPath.Location = new Point(12, 324);
            btnBrowseBackupPath.Name = "btnBrowseBackupPath";
            btnBrowseBackupPath.Size = new Size(232, 23);
            btnBrowseBackupPath.TabIndex = 7;
            btnBrowseBackupPath.Text = "Wybierz folder backup";
            btnBrowseBackupPath.UseVisualStyleBackColor = true;
            btnBrowseBackupPath.Click += btnBrowseBackupPath_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 415);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(776, 23);
            progressBar.TabIndex = 8;
            // 
            // lblFileCounter
            // 
            lblFileCounter.AutoSize = true;
            lblFileCounter.Location = new Point(12, 397);
            lblFileCounter.Name = "lblFileCounter";
            lblFileCounter.Size = new Size(152, 15);
            lblFileCounter.TabIndex = 9;
            lblFileCounter.Text = "Postęp przenoszenia plików";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            Text = "Form1";
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
    }
}
