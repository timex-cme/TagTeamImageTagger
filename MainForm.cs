using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagTeam
{
    public partial class MainForm : Form
    {
        private readonly ImageProcessingService processingService = new();
        private CancellationTokenSource? cancellationTokenSource;
        private readonly ApplicationSettings appSettings = new();

        public MainForm()
        {
            InitializeComponent();
            ConfigureEventHandlers();
            InitializeControls();
            RestoreSettings();
        }

        private class LanguageEntry
        {
            public string DisplayName { get; }
            public ImageProcessingService.LanguageEnum Language { get; }
            public LanguageEntry(string displayName, ImageProcessingService.LanguageEnum language)
            {
                DisplayName = displayName;
                Language = language;
            }
            public override string ToString()
            {
                return DisplayName;
            }
        }

        private void InitializeControls()
        {
            SetupLanguages();
            cboTaggingLanguage.SelectedIndex = 0; // Default to first language
        }

        private void SetupLanguages()
        {
            cboTaggingLanguage.Items.Clear();
            cboTaggingLanguage.Items.Add(new LanguageEntry("German", ImageProcessingService.LanguageEnum.German));
            cboTaggingLanguage.Items.Add(new LanguageEntry("English", ImageProcessingService.LanguageEnum.English));
        }

        private void ConfigureEventHandlers()
        {
            processingService.ProgressChanged += ProcessingService_ProgressChanged;
            processingService.ProcessingComplete += ProcessingService_ProcessingComplete;
            this.FormClosing += MainForm_FormClosing;
        }

        private void ProcessingService_ProgressChanged(object? sender, ProcessingProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() => ProcessingService_ProgressChanged(sender, e));
                return;
            }

            // Update progress
            lblStatus.Text = e.Status;
            if (e.TotalFiles > 0)
            {
                progressBar.Visible = true;
                progressBar.Maximum = e.TotalFiles;
                progressBar.Value = Math.Min(e.ProcessedFiles, e.TotalFiles);
                lblProgress.Text = $"{e.ProcessedFiles} / {e.TotalFiles}";
            }
            else
            {
                progressBar.Visible = false;
                lblProgress.Text = $"{e.ProcessedFiles}";
            }

            // Update status color
            if (e.IsError)
            {
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.ForeColor = Color.Green;
            }

            // Update image preview
            if (!string.IsNullOrEmpty(e.ImagePath) && File.Exists(e.ImagePath))
            {
                try
                {
                    if (pictureBox.Image != null)
                    {
                        var image = pictureBox.Image;
                        pictureBox.Image = null;

                        image.Dispose();
                    }

                    pictureBox.Image = new Bitmap(e.ImagePath);
                }
                catch
                {
                    // Image couldn't be loaded, continue
                }
            }

            // Update tags display
            if (e.Tags != null && e.Tags.Length > 0)
            {
                lstTags.Items.Clear();
                foreach (var tag in e.Tags)
                {
                    lstTags.Items.Add(tag);
                }
            }

            // Update comment
            if (!string.IsNullOrEmpty(e.Comment))
            {
                lblComment.Text = $"{e.Comment}\r\n\r\n({e.CurrentFile})";
            }

            lblCurrentFile.Visible = true;
            lblCurrentFile.Text = $"Current File:\r\n{e.CurrentFile}";

            // Log to list box
            if (!string.IsNullOrEmpty(e.Status))
            {
                LogEntry(e.CurrentFile, e.Status, e.Comment);
            }
        }

        private void ProcessingService_ProcessingComplete(object? sender, ProcessingCompleteEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() => ProcessingService_ProcessingComplete(sender, e));
                return;
            }

            btnSelectFolder.Enabled = true;
            btnAbort.Enabled = false;
            btnStart.Enabled = true;
            groupProcessingMode.Enabled = true;
            chkMarkClassificationErrors.Enabled = true;
            lblProgress.Text = $"Complete: {e.ProcessedFiles} / {e.TotalFiles}";
            progressBar.Visible = false;
            lblCurrentFile.Visible = false;
            MessageBox.Show($"Processing complete!\nProcessed: {e.ProcessedFiles} / {e.TotalFiles}");
        }

        private void LogEntry(string fileName, string status, string comment)
        {
            string commentStr = !string.IsNullOrEmpty(comment) ? $" - {comment}" : "";
            lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {fileName}: {status} {commentStr}");
            lstLog.TopIndex = Math.Max(0, lstLog.Items.Count - 1);
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select the folder containing images to process";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = dialog.SelectedPath;
                    btnStart.Enabled = !string.IsNullOrWhiteSpace(dialog.SelectedPath);
                }
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFolderPath.Text))
                {
                    MessageBox.Show("Please select a folder first.");
                    return;
                }

                if (!Directory.Exists(txtFolderPath.Text))
                {
                    MessageBox.Show("The selected folder does not exist.");
                    return;
                }

                btnSelectFolder.Enabled = false;
                btnStart.Enabled = false;
                btnAbort.Enabled = true;
                lstLog.Items.Clear();
                progressBar.Value = 0;
                lblProgress.Text = "0 / 0";
                lblStatus.Text = "Processing...";
                lblStatus.ForeColor = Color.Black;
                groupProcessingMode.Enabled = false;
                chkMarkClassificationErrors.Enabled = false;

                cancellationTokenSource = new CancellationTokenSource();

                ImageProcessingService.ProcessingModeEnum processingMode;

                if (optAllFiles.Checked)
                {
                    processingMode = ImageProcessingService.ProcessingModeEnum.ProcessAll;
                }
                else if (optSkipTaggedFiles.Checked)
                {
                    processingMode = ImageProcessingService.ProcessingModeEnum.SkipTagged;
                }
                else
                {
                    processingMode = ImageProcessingService.ProcessingModeEnum.ProcessClassificationErrorsOnly;
                }

                await processingService.StartProcessing(txtFolderPath.Text, processingMode, chkMarkClassificationErrors.Checked, cancellationTokenSource, GetSelectedLanguage());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while starting processing: {ex.Message}", "Processing error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelectFolder.Enabled = true;
                btnStart.Enabled = true;
                btnAbort.Enabled = false;
                groupProcessingMode.Enabled = true;
                chkMarkClassificationErrors.Enabled = true;
                lblStatus.Text = "Error starting processing.";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            btnAbort.Enabled = false;
            lblStatus.Text = "Aborting...";
            lblStatus.ForeColor = Color.Orange;
        }

        private ImageProcessingService.LanguageEnum GetSelectedLanguage()
        {
            if (cboTaggingLanguage.SelectedItem is LanguageEntry entry)
            {
                return entry.Language;
            }
            return ImageProcessingService.LanguageEnum.English; // Default to English
        }

        private void RestoreSettings()
        {
            appSettings.Load();

            // Restore folder path
            if (!string.IsNullOrEmpty(appSettings.SelectedFolderPath) && Directory.Exists(appSettings.SelectedFolderPath))
            {
                txtFolderPath.Text = appSettings.SelectedFolderPath;
                btnStart.Enabled = true;
            }

            // Restore tagging language
            foreach(var item in cboTaggingLanguage.Items)
            {
                if (item is LanguageEntry entry && entry.Language == appSettings.TaggingLanguage)
                {
                    cboTaggingLanguage.SelectedItem = item;
                    break;
                }
            }

            // Restore processing mode
            switch (appSettings.ProcessingMode)
            {
                case ImageProcessingService.ProcessingModeEnum.ProcessAll:
                    optAllFiles.Checked = true;
                    break;
                case ImageProcessingService.ProcessingModeEnum.ProcessClassificationErrorsOnly:
                    optClassificationErrorsOnly.Checked = true;
                    break;
                case ImageProcessingService.ProcessingModeEnum.SkipTagged:
                default:
                    optSkipTaggedFiles.Checked = true;
                    break;
            }

            // Restore mark classification errors
            chkMarkClassificationErrors.Checked = appSettings.MarkClassificationErrors;
        }

        private void SaveSettings()
        {
            appSettings.SelectedFolderPath = txtFolderPath.Text;

            if (cboTaggingLanguage.SelectedItem is LanguageEntry selectedLanguage)
            {
                appSettings.TaggingLanguage = selectedLanguage.Language;
            }
            else
            {
                appSettings.TaggingLanguage = ImageProcessingService.LanguageEnum.English;
            }

            if (optAllFiles.Checked)
                appSettings.ProcessingMode = ImageProcessingService.ProcessingModeEnum.ProcessAll;
            else if (optClassificationErrorsOnly.Checked)
                appSettings.ProcessingMode = ImageProcessingService.ProcessingModeEnum.ProcessClassificationErrorsOnly;
            else
                appSettings.ProcessingMode = ImageProcessingService.ProcessingModeEnum.SkipTagged;

            appSettings.MarkClassificationErrors = chkMarkClassificationErrors.Checked;
            
            appSettings.Save();
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
