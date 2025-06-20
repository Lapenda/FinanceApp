using System;
using System.Globalization;
using System.Windows.Forms;

namespace FinanceApp.Forms
{
    public partial class CurrencyForm : Form
    {
        public CurrencyForm()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show(Properties.Resources.ISOMessage);
                return;
            }

            try
            {
                var client = new CountryInfoServiceReference.CountryInfoServiceSoapTypeClient();
                string isoCode;

                if(input.Length == 2 || input.Length == 3)
                {
                    isoCode = input.ToUpper();
                }
                else
                {
                    string normalizedInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
                    isoCode = client.CountryISOCode(normalizedInput);
                    if (string.IsNullOrEmpty(isoCode))
                    {
                        MessageBox.Show(Properties.Resources.CountryFound);
                        return;
                    }
                }

                var currency = client.CountryCurrency(isoCode);

                if (currency != null && !string.IsNullOrEmpty(currency.sISOCode))
                {
                    resultLabel.Text = $"{client.CountryName(isoCode)} -> {Properties.Resources.CurrencyInCountry} -> {currency.sName} ({currency.sISOCode})";
                }
                else
                {
                    resultLabel.Text = $"{Properties.Resources.CountryFound}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
