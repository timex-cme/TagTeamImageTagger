using System;
using System.IO;
using System.Text.Json;
using static ImageProcessingService;

namespace ImageTagger
{
    /// <summary>
    /// Manages application settings persistence.
    /// Settings are stored in a JSON file in the application data directory.
    /// </summary>
    public class ApplicationSettings
    {
        private readonly string settingsFilePath;
        private const string SettingsFileName = "ImageTaggerSettings.json";

        public string SelectedFolderPath { get; set; } = "";
        public LanguageEnum TaggingLanguage { get; set; } = LanguageEnum.German;
        public ProcessingModeEnum ProcessingMode { get; set; } = ProcessingModeEnum.SkipTagged;
        public bool MarkClassificationErrors { get; set; } = true;

        public ApplicationSettings()
        {
            // Store settings in the application data directory
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appFolder = Path.Combine(appDataPath, "ImageTagger");
            
            // Create folder if it doesn't exist
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            settingsFilePath = Path.Combine(appFolder, SettingsFileName);
        }

        /// <summary>
        /// Loads settings from the JSON file if it exists.
        /// If the file doesn't exist, uses default values.
        /// </summary>
        public void Load()
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    string json = File.ReadAllText(settingsFilePath);
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var settings = JsonSerializer.Deserialize<SettingsData>(json, options);

                    if (settings != null)
                    {
                        SelectedFolderPath = settings.SelectedFolderPath ?? "";
                        TaggingLanguage = settings.TaggingLanguage ?? LanguageEnum.English;
                        ProcessingMode = settings.ProcessingMode ?? ProcessingModeEnum.SkipTagged;
                        MarkClassificationErrors = settings.MarkClassificationErrors;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading settings: {ex.Message}");
                // Use default values if loading fails
            }
        }

        /// <summary>
        /// Saves the current settings to a JSON file.
        /// </summary>
        public void Save()
        {
            try
            {
                var settingsData = new SettingsData
                {
                    SelectedFolderPath = SelectedFolderPath,
                    TaggingLanguage = TaggingLanguage,
                    ProcessingMode = ProcessingMode,
                    MarkClassificationErrors = MarkClassificationErrors
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(settingsData, options);
                File.WriteAllText(settingsFilePath, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving settings: {ex.Message}");
                // Silently fail if saving doesn't work
            }
        }

        /// <summary>
        /// Resets all settings to their default values and deletes the settings file.
        /// </summary>
        public void ResetToDefaults()
        {
            SelectedFolderPath = "";
            TaggingLanguage = LanguageEnum.English;
            ProcessingMode = ProcessingModeEnum.SkipTagged;
            MarkClassificationErrors = true;

            try
            {
                if (File.Exists(settingsFilePath))
                {
                    File.Delete(settingsFilePath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error resetting settings: {ex.Message}");
            }
        }

        /// <summary>
        /// Internal class for JSON serialization/deserialization.
        /// </summary>
        private class SettingsData
        {
            public string? SelectedFolderPath { get; set; }
            public LanguageEnum? TaggingLanguage { get; set; }
            public ProcessingModeEnum? ProcessingMode { get; set; }
            public bool MarkClassificationErrors { get; set; }
        }
    }
}
