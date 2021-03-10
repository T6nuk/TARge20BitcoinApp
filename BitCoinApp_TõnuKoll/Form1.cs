using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinApp_TõnuKoll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetRates_Click(object sender, EventArgs e)
        {
            if (currencyCombo.SelectedItem.ToString()=="EUR") //kui valib euro
            {
                if (AmountOfTextBox.Text == string.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(AmountOfTextBox.Text), "Amount of bitcoins not entered!");
                }
                resultLabel.Visible = true;
                ResultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(AmountOfTextBox.Text) * bitcoin.bpi.EUR.rate_float;
                ResultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.EUR.code}";
            }

            if (currencyCombo.SelectedItem.ToString() == "USD") //kui valib USD
            {
                if (AmountOfTextBox.Text == string.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(AmountOfTextBox.Text), "Amount of bitcoins not entered!");
                }
                resultLabel.Visible = true;
                ResultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(AmountOfTextBox.Text) * bitcoin.bpi.USD.rate_float;
                ResultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.USD.code}";
            }

            if (currencyCombo.SelectedItem.ToString() == "GBP") //kui valib GBP
            {
                if (AmountOfTextBox.Text == string.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(AmountOfTextBox.Text), "Amount of bitcoins not entered!");
                }
                resultLabel.Visible = true;
                ResultTextBox.Visible = true;
                BitcoinRates bitcoin = GetRates();
                float result = Int32.Parse(AmountOfTextBox.Text) * bitcoin.bpi.GBP.rate_float;
                ResultTextBox.Text = $"{result.ToString()} {bitcoin.bpi.GBP.code}";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ResultTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public static BitcoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitcoinRates bitcoin;
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitcoinRates>(response);
            }

            return bitcoin;
        }

        private void AmountOfTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
