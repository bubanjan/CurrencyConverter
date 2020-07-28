using StudentProjectNB.DataProvider;
using StudentProjectNB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentProjectNB
{
    

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        decimal rateFrom;
        decimal rateTo;

        Rootobject dataSum = new Rootobject();
        public MainPage()
        {
            this.InitializeComponent();
            APIHelper.InitilizeClient();
            getCurrencyData();
            getCurrencyList();
             
        }

        private async void getCurrencyData()
        {
            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetCurrencyDataO();
          
        }

        private async void getCurrencyList()
        {
            DataProviderC qdp = new DataProviderC();
            var currenciesListing = await qdp.GetCurrencyList();


            foreach (KeyValuePair<string, string> pair in currenciesListing)
            {
                CurrenciesFrom.Items.Add(pair.Key);
                CurrenciesTo.Items.Add(pair.Key);
            }
            CurrenciesFrom.SelectedIndex = 0;
            CurrenciesTo.SelectedIndex = 0;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CurrenciesFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Calculate(object sender, RoutedEventArgs e)
        {
            
            DataProviderC qdp = new DataProviderC();
            var currenciesL = await qdp.GetCurrencyDataO();

            foreach (KeyValuePair<string, decimal> pair in currenciesL.Rates)
            {
                if (CurrenciesFrom.SelectedItem.ToString() == pair.Key)
                {
                     rateFrom = pair.Value;

                }
                else if(CurrenciesFrom.SelectedItem.ToString() == "EUR")
                {
                    rateFrom = 1.0M;
                } //eur je izabran
            }

            foreach (KeyValuePair<string, decimal> pair in currenciesL.Rates)
            {
                if ( CurrenciesTo.SelectedItem.ToString() == pair.Key)
                {

                     rateTo = pair.Value;
                }
                else if (CurrenciesTo.SelectedItem.ToString() == "EUR")
                {
                    rateTo = 1.0M;
                } //eur je izabran
            }

            int amountN = Int32.Parse(amountInput.Text);

            decimal result = (1 / rateFrom * amountN) * rateTo;
            ResaultInfo.Text = result.ToString();
            
            
        }
    }
}
