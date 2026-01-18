namespace ImageTagger
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainContainer = new TableLayoutPanel();
            lblComment = new Label();
            lstTags = new ListBox();
            lblTags = new Label();
            lblFolderPath = new Label();
            txtFolderPath = new TextBox();
            btnSelectFolder = new Button();
            pictureBox = new PictureBox();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            lblStatus = new Label();
            lstLog = new ListBox();
            buttonPanel = new Panel();
            lblLanguage = new Label();
            btnAbort = new Button();
            btnStart = new Button();
            groupProcessingMode = new GroupBox();
            optClassificationErrorsOnly = new RadioButton();
            optSkipTaggedFiles = new RadioButton();
            optAllFiles = new RadioButton();
            chkMarkClassificationErrors = new CheckBox();
            cboTaggingLanguage = new ComboBox();
            lblCurrentFile = new Label();
            mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            buttonPanel.SuspendLayout();
            groupProcessingMode.SuspendLayout();
            SuspendLayout();
            // 
            // mainContainer
            // 
            mainContainer.ColumnCount = 3;
            mainContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            mainContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.0000038F));
            mainContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300F));
            mainContainer.Controls.Add(lblComment, 0, 4);
            mainContainer.Controls.Add(lstTags, 2, 3);
            mainContainer.Controls.Add(lblTags, 2, 2);
            mainContainer.Controls.Add(lblFolderPath, 0, 0);
            mainContainer.Controls.Add(txtFolderPath, 0, 1);
            mainContainer.Controls.Add(btnSelectFolder, 1, 1);
            mainContainer.Controls.Add(pictureBox, 0, 3);
            mainContainer.Controls.Add(progressBar, 0, 6);
            mainContainer.Controls.Add(lblProgress, 0, 7);
            mainContainer.Controls.Add(lblStatus, 0, 9);
            mainContainer.Controls.Add(lstLog, 0, 5);
            mainContainer.Controls.Add(buttonPanel, 0, 10);
            mainContainer.Controls.Add(lblCurrentFile, 2, 4);
            mainContainer.Dock = DockStyle.Fill;
            mainContainer.Location = new Point(0, 0);
            mainContainer.Name = "mainContainer";
            mainContainer.Padding = new Padding(10);
            mainContainer.RowCount = 8;
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainContainer.RowStyles.Add(new RowStyle());
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            mainContainer.RowStyles.Add(new RowStyle());
            mainContainer.RowStyles.Add(new RowStyle());
            mainContainer.RowStyles.Add(new RowStyle());
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 180F));
            mainContainer.Size = new Size(1095, 811);
            mainContainer.TabIndex = 0;
            // 
            // lblComment
            // 
            mainContainer.SetColumnSpan(lblComment, 2);
            lblComment.Dock = DockStyle.Fill;
            lblComment.Location = new Point(10, 396);
            lblComment.Margin = new Padding(0, 5, 0, 5);
            lblComment.Name = "lblComment";
            lblComment.Size = new Size(775, 50);
            lblComment.TabIndex = 18;
            // 
            // lstTags
            // 
            lstTags.Dock = DockStyle.Fill;
            lstTags.FormattingEnabled = true;
            lstTags.Location = new Point(785, 80);
            lstTags.Margin = new Padding(0, 5, 0, 5);
            lstTags.Name = "lstTags";
            lstTags.Size = new Size(300, 306);
            lstTags.TabIndex = 17;
            // 
            // lblTags
            // 
            lblTags.AutoSize = true;
            lblTags.Dock = DockStyle.Top;
            lblTags.Location = new Point(788, 60);
            lblTags.Name = "lblTags";
            lblTags.Size = new Size(294, 15);
            lblTags.TabIndex = 15;
            lblTags.Text = "Tags";
            // 
            // lblFolderPath
            // 
            lblFolderPath.AutoSize = true;
            lblFolderPath.Dock = DockStyle.Left;
            lblFolderPath.Location = new Point(13, 10);
            lblFolderPath.Name = "lblFolderPath";
            lblFolderPath.Size = new Size(43, 20);
            lblFolderPath.TabIndex = 0;
            lblFolderPath.Text = "Folder:";
            lblFolderPath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFolderPath
            // 
            txtFolderPath.Dock = DockStyle.Fill;
            txtFolderPath.Location = new Point(15, 34);
            txtFolderPath.Margin = new Padding(5, 4, 5, 0);
            txtFolderPath.Name = "txtFolderPath";
            txtFolderPath.ReadOnly = true;
            txtFolderPath.Size = new Size(455, 23);
            txtFolderPath.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Dock = DockStyle.Left;
            btnSelectFolder.Location = new Point(480, 30);
            btnSelectFolder.Margin = new Padding(5, 0, 0, 0);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(85, 30);
            btnSelectFolder.TabIndex = 2;
            btnSelectFolder.Text = "Browse";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // pictureBox
            // 
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            mainContainer.SetColumnSpan(pictureBox, 2);
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Location = new Point(10, 80);
            pictureBox.Margin = new Padding(0, 5, 5, 0);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(770, 311);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // progressBar
            // 
            mainContainer.SetColumnSpan(progressBar, 3);
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(10, 556);
            progressBar.Margin = new Padding(0, 5, 0, 5);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1075, 25);
            progressBar.TabIndex = 8;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Dock = DockStyle.Fill;
            lblProgress.Location = new Point(13, 586);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(459, 15);
            lblProgress.TabIndex = 9;
            lblProgress.Text = "0 / 0";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            mainContainer.SetColumnSpan(lblStatus, 3);
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(10, 606);
            lblStatus.Margin = new Padding(0, 5, 0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(1075, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status: Ready";
            // 
            // lstLog
            // 
            mainContainer.SetColumnSpan(lstLog, 3);
            lstLog.Dock = DockStyle.Fill;
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(10, 456);
            lstLog.Margin = new Padding(0, 5, 0, 0);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(1075, 95);
            lstLog.TabIndex = 12;
            // 
            // buttonPanel
            // 
            buttonPanel.AutoSize = true;
            mainContainer.SetColumnSpan(buttonPanel, 3);
            buttonPanel.Controls.Add(lblLanguage);
            buttonPanel.Controls.Add(btnAbort);
            buttonPanel.Controls.Add(btnStart);
            buttonPanel.Controls.Add(groupProcessingMode);
            buttonPanel.Controls.Add(chkMarkClassificationErrors);
            buttonPanel.Controls.Add(cboTaggingLanguage);
            buttonPanel.Dock = DockStyle.Right;
            buttonPanel.Location = new Point(427, 626);
            buttonPanel.Margin = new Padding(0, 5, 0, 0);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(658, 175);
            buttonPanel.TabIndex = 13;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new Point(3, 15);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(104, 15);
            lblLanguage.TabIndex = 10;
            lblLanguage.Text = "Tagging language:";
            // 
            // btnAbort
            // 
            btnAbort.Enabled = false;
            btnAbort.Location = new Point(573, 7);
            btnAbort.Margin = new Padding(5, 0, 0, 0);
            btnAbort.Name = "btnAbort";
            btnAbort.Size = new Size(85, 40);
            btnAbort.TabIndex = 5;
            btnAbort.Text = "Abort";
            btnAbort.UseVisualStyleBackColor = true;
            btnAbort.Click += btnAbort_Click;
            // 
            // btnStart
            // 
            btnStart.Enabled = false;
            btnStart.Location = new Point(483, 7);
            btnStart.Margin = new Padding(5, 0, 0, 0);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(85, 40);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // groupProcessingMode
            // 
            groupProcessingMode.Controls.Add(optClassificationErrorsOnly);
            groupProcessingMode.Controls.Add(optSkipTaggedFiles);
            groupProcessingMode.Controls.Add(optAllFiles);
            groupProcessingMode.Location = new Point(284, 7);
            groupProcessingMode.Name = "groupProcessingMode";
            groupProcessingMode.Size = new Size(191, 101);
            groupProcessingMode.TabIndex = 7;
            groupProcessingMode.TabStop = false;
            groupProcessingMode.Text = "Processing mode";
            // 
            // optClassificationErrorsOnly
            // 
            optClassificationErrorsOnly.AutoSize = true;
            optClassificationErrorsOnly.Location = new Point(6, 72);
            optClassificationErrorsOnly.Name = "optClassificationErrorsOnly";
            optClassificationErrorsOnly.Size = new Size(154, 19);
            optClassificationErrorsOnly.TabIndex = 2;
            optClassificationErrorsOnly.Text = "Only classification errors";
            optClassificationErrorsOnly.UseVisualStyleBackColor = true;
            // 
            // optSkipTaggedFiles
            // 
            optSkipTaggedFiles.AutoSize = true;
            optSkipTaggedFiles.Checked = true;
            optSkipTaggedFiles.Location = new Point(6, 47);
            optSkipTaggedFiles.Name = "optSkipTaggedFiles";
            optSkipTaggedFiles.Size = new Size(111, 19);
            optSkipTaggedFiles.TabIndex = 1;
            optSkipTaggedFiles.TabStop = true;
            optSkipTaggedFiles.Text = "Skip tagged files";
            optSkipTaggedFiles.UseVisualStyleBackColor = true;
            // 
            // optAllFiles
            // 
            optAllFiles.AutoSize = true;
            optAllFiles.Location = new Point(6, 22);
            optAllFiles.Name = "optAllFiles";
            optAllFiles.Size = new Size(63, 19);
            optAllFiles.TabIndex = 0;
            optAllFiles.Text = "All files";
            optAllFiles.UseVisualStyleBackColor = true;
            // 
            // chkMarkClassificationErrors
            // 
            chkMarkClassificationErrors.AutoSize = true;
            chkMarkClassificationErrors.Checked = true;
            chkMarkClassificationErrors.CheckState = CheckState.Checked;
            chkMarkClassificationErrors.Location = new Point(290, 114);
            chkMarkClassificationErrors.Name = "chkMarkClassificationErrors";
            chkMarkClassificationErrors.Size = new Size(157, 19);
            chkMarkClassificationErrors.TabIndex = 8;
            chkMarkClassificationErrors.Text = "Mark classification errors";
            chkMarkClassificationErrors.UseVisualStyleBackColor = true;
            // 
            // cboTaggingLanguage
            // 
            cboTaggingLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTaggingLanguage.FormattingEnabled = true;
            cboTaggingLanguage.Location = new Point(110, 12);
            cboTaggingLanguage.Name = "cboTaggingLanguage";
            cboTaggingLanguage.Size = new Size(155, 23);
            cboTaggingLanguage.TabIndex = 9;
            // 
            // lblCurrentFile
            // 
            lblCurrentFile.AutoSize = true;
            lblCurrentFile.Dock = DockStyle.Fill;
            lblCurrentFile.Location = new Point(788, 391);
            lblCurrentFile.Name = "lblCurrentFile";
            lblCurrentFile.Size = new Size(294, 60);
            lblCurrentFile.TabIndex = 19;
            lblCurrentFile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 811);
            Controls.Add(mainContainer);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tag Team AI Image Tagger";
            mainContainer.ResumeLayout(false);
            mainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            buttonPanel.ResumeLayout(false);
            buttonPanel.PerformLayout();
            groupProcessingMode.ResumeLayout(false);
            groupProcessingMode.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainContainer;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListBox lstLog;
        private ListBox lstTags;
        private Label lblTags;
        private Label lblComment;
        private Label lblCurrentFile;
        private Panel buttonPanel;
        private Label lblLanguage;
        private Button btnAbort;
        private Button btnStart;
        private GroupBox groupProcessingMode;
        private RadioButton optClassificationErrorsOnly;
        private RadioButton optSkipTaggedFiles;
        private RadioButton optAllFiles;
        private CheckBox chkMarkClassificationErrors;
        private ComboBox cboTaggingLanguage;
    }
}
