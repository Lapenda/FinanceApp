using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using FinanceApp.Manager;
using FinanceApp.Properties;
using FinanceApp.Managers;

namespace FinanceApp.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly Dictionary<string, string> ThemeIdentifiers = new Dictionary<string, string>();

        private readonly Dictionary<string, string> ThemeDisplayNames = new Dictionary<string, string>
        {
            { "Light", Resources.LightTheme },
            { "Dark", Resources.DarkTheme }
        };

        public SettingsForm()
        {
            InitializeComponent();
            InitializeLanguageComboBox();
            InitializeThemeComboBox();
            InitializeCurrencyComboBox();
           
            SettingsManager.LanguageChanged += (s, e) => SettingsManager.UpdateFormLanguage(this);

            SettingsManager.ApplyTheme(this);
            SettingsManager.ThemeChanged += (s, e) => SettingsManager.ApplyTheme(this);
        }



        private void returnButton_Click(object sender, EventArgs e)
        {
            var storedToken = Settings.Default.JwtToken;
            var userManager = new UserManager();

            if(!string.IsNullOrEmpty(storedToken) && userManager.ValidateToken(storedToken, out var claimsPrincipal))
            {
                TransactionForm transactionForm = new TransactionForm();
                transactionForm.Show();
                this.Hide();
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void InitializeLanguageComboBox()
        {
            languageComboBox.Items.Clear();
            foreach(var culture in SettingsManager.GetSupportedCultures())
            {
                languageComboBox.Items.Add(culture.Key);
            }

            var currentCulture = Thread.CurrentThread.CurrentUICulture;
            var selectedLanguage = SettingsManager.GetSupportedCultures()
                .FirstOrDefault(c => c.Value.Name == currentCulture.Name)
                .Key;

            languageComboBox.SelectedItem = selectedLanguage ?? Resources.English;
        }



        private void applyLanguage_Click(object sender, EventArgs e)
         {
            bool settingsChanged = false;

            if (languageComboBox.SelectedItem != null)
            {
                if(SettingsManager.GetSettings().Language != languageComboBox.SelectedItem.ToString())
                {
                    SettingsManager.SetLanguage(languageComboBox.SelectedItem.ToString());
                    settingsChanged = true;
                }
            }

            if (themeComboBox.SelectedItem != null)
            {
                string selectedTheme = themeComboBox.SelectedItem.ToString();
                string themeIdentifier = ThemeIdentifiers.ContainsKey(selectedTheme) ? ThemeIdentifiers[selectedTheme] : "Light";
                
                if(SettingsManager.GetSettings().Theme != themeIdentifier) 
                {
                    SettingsManager.SetTheme(themeIdentifier);
                    settingsChanged = true;
                }
            }

            if (currencyComboBox.SelectedItem != null)
            {
                if(SettingsManager.GetSettings().DefaultCurrency != currencyComboBox.SelectedItem.ToString())
                {
                    SettingsManager.GetSettings().DefaultCurrency = currencyComboBox.SelectedItem.ToString();
                    settingsChanged = true;
                }
            }

            if (settingsChanged)
            {
                SettingsManager.GetSettings().Save();
            }
            
            SettingsManager.ApplyTheme(this);
            InitializeThemeComboBox();
            InitializeLanguageComboBox();
        }




        private void InitializeThemeComboBox()
        {
            themeComboBox.Items.Clear();
            ThemeDisplayNames.Clear();
            ThemeIdentifiers.Clear();

            ThemeDisplayNames["Light"] = Resources.LightTheme;
            ThemeDisplayNames["Dark"] = Resources.DarkTheme;

            foreach (var pair in ThemeDisplayNames)
            {
                ThemeIdentifiers[pair.Value] = pair.Key;
            }

            themeComboBox.Items.AddRange(new[] { ThemeDisplayNames["Light"], ThemeDisplayNames["Dark"] });

            var currentTheme = SettingsManager.GetSettings().Theme;

            themeComboBox.SelectedItem = ThemeDisplayNames.ContainsKey(currentTheme) ? ThemeDisplayNames[currentTheme] : ThemeDisplayNames["Light"];
        }
        


        private void InitializeCurrencyComboBox()
        {
            currencyComboBox.Items.Clear();
            currencyComboBox.Items.AddRange(new[] { "EUR", "USD", "HRK" });
            currencyComboBox.SelectedItem = SettingsManager.GetSettings().DefaultCurrency;
        }
    }
}
