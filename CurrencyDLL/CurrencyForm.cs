using CurrencyDLL.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace CurrencyDLL
{
    public partial class CurrencyForm : Form
    {
        public CurrencyForm(CultureInfo cultureName)
        {
            InitializeComponent();

            CultureInfo culture = cultureName;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show(Resources.ISOMessage);
                return;
            }

            try
            {
                var client = new CountryInfoServiceReference.CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");
                string isoCode;

                if (input.Length == 2 || input.Length == 3)
                {
                    isoCode = input.ToUpper();
                }
                else
                {
                    string normalizedInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
                    isoCode = client.CountryISOCode(normalizedInput);
                    if (string.IsNullOrEmpty(isoCode))
                    {
                        MessageBox.Show(Resources.CountryFound);
                        return;
                    }
                }

                var currency = client.CountryCurrency(isoCode);

                if (currency != null && !string.IsNullOrEmpty(currency.sISOCode))
                {
                    resultLabel.Text = $"{client.CountryName(isoCode)} -> {Resources.CurrencyInCountry} -> {currency.sName} ({currency.sISOCode})";
                }
                else
                {
                    resultLabel.Text = $"{Resources.CountryFound}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
