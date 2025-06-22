using CurrencyDLL.Properties;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        private async void calcBtn_Click(object sender, EventArgs e)
        {
            string currFrom = currFromTextBox.Text.ToUpper();
            string currTo = currToTextBox.Text.ToUpper();
            var isNumber = float.TryParse(amountTextBox.Text, out var result);

            if(!isNumber)
            {
                MessageBox.Show("Please enter a number!");
                return;
            }

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync($"https://api.getgeoapi.com/v2/currency/convert?api_key=5c4dce8197b2131b693ec665a7306fb11d63284b&from={currFrom}&to={currTo}&amount={result}&format=json");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var convertedAmount = JsonConvert.DeserializeObject<Currency>(jsonString);
                        
                        if(convertedAmount.Status == "success" && convertedAmount.Rates.TryGetValue(currTo, out var rateDetail))
                        {
                            resultTextBox.Text = $"{rateDetail.RateForAmount} {currTo}";
                            dateLabel.Text = "Last time rate was updated: " + convertedAmount.UpdatedDate;
                        }
                        else
                        {
                            MessageBox.Show("Currency not found or API request failed.");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            
        }
    }
}
