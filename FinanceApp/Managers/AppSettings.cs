using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace FinanceApp.Manager
{
    internal class AppSettings
    {

        private static readonly IniFileManager ini = new IniFileManager("settings.ini");
        private const string RegistryPath = @"Software\FinanceApp";

        public string Language { get; set; } = Properties.Resources.Croatian;
        public string Theme { get; set; } = "Light";
        public string DefaultCurrency { get; set; } = "HRK";
        public string LastTransactionCategory { get; set; } = "Food";

        public void Save()
        {
            ini.Write("Settings", "Language", Language);
            ini.Write("Settings", "Theme", Theme);
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath))
                {
                    if (key != null)
                    {
                        key.SetValue("DefaultCurrency", DefaultCurrency, RegistryValueKind.String);
                        key.SetValue("LastTransactionCategory", LastTransactionCategory, RegistryValueKind.String);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving to Registry: {ex.Message}");
            }
        
        }


        public void Load()
        {
            Language = ini.Read("Settings", "Language", Language);
            Theme = ini.Read("Settings", "Theme", Theme);

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath))
                {
                    if (key != null)
                    {
                        DefaultCurrency = key.GetValue("DefaultCurrency", "HRK").ToString();
                        LastTransactionCategory = key.GetValue("LastTransactionCategory", "Food").ToString();
                    }
                    else
                    {
                        DefaultCurrency = "HRK";
                        LastTransactionCategory = "Food";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading from Registry: {ex.Message}");
                DefaultCurrency = "HRK";
                LastTransactionCategory = "Food";
            }
        }
    }
}
