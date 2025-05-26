using FinanceApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinanceApp.Manager
{
    internal class SettingsManager
    {
        public static event EventHandler LanguageChanged;
        public static event EventHandler ThemeChanged;

        private static readonly AppSettings Settings = new AppSettings();

        private static readonly Dictionary<string, CultureInfo> SupportedCultures = new Dictionary<string, CultureInfo>
        {
            { Resources.English, new CultureInfo("en-US") },
            { Resources.Croatian, new CultureInfo("hr-HR") },
        };

        public static IReadOnlyDictionary<string, CultureInfo> GetSupportedCultures() => SupportedCultures;


        public static void SetLanguage(string cultureName)
        {
            try
            {
                if(!SupportedCultures.ContainsKey(cultureName))
                {
                    throw new ArgumentException($"Culture '{cultureName}' is not supported.");
                }

                CultureInfo culture = SupportedCultures[cultureName];
                Thread.CurrentThread.CurrentUICulture = culture;
                //Thread.CurrentThread.CurrentCulture = culture;
                LanguageChanged?.Invoke(null, EventArgs.Empty);

                if(Settings.Language != cultureName)
                {
                    Settings.Language = cultureName;
                    Settings.Save();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    $"Failed to set language: {ex.Message}",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error
                );
            }
        }

        public static void LoadLanguageFromIni()
        {
            try
            {
                Settings.Load();
                string savedLanguage = Settings.Language;
                SetLanguage(savedLanguage);
            }
            catch (Exception ex)
            {
                SetLanguage(Resources.English);
                MessageBox.Show($"Failed to load language from INI: {ex.Message}. Using default language");
            }
        }

        public static void UpdateFormLanguage(Form form)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(form.GetType());

                resources.ApplyResources(form, "$this");

                ApplyResourcesToControls(form.Controls, resources);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to update form language: {ex.Message}", 
                    "Error", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void ApplyResourcesToControls(Control.ControlCollection controls, ComponentResourceManager resources)
        {
            foreach (Control control in controls) 
            { 
                resources.ApplyResources(control, control.Name);

                if(control.Controls.Count > 0)
                {
                    ApplyResourcesToControls(controls, resources);
                }
            }
        }

        public static void SetTheme(string theme)
        {
            if (Settings.Theme != theme)
            {
                Settings.Theme = theme;
                Settings.Save();
                ThemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void ApplyTheme(Form form)
        {
            Settings.Load();

            if (Settings.Theme == "Dark")
            {
                form.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                foreach (Control control in form.Controls)
                {
                    if (control is Button)
                    {
                        control.ForeColor = System.Drawing.Color.Black;
                    }

                    if (control is Label)
                    {
                        control.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            else
            {
                form.BackColor = System.Drawing.SystemColors.Control;
                foreach (Control control in form.Controls)
                {
                    if (control is Label || control is Button)
                    {
                        control.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        public static AppSettings GetSettings() => Settings;
    }
}
