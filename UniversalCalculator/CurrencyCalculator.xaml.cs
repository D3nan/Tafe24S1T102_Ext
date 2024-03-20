using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyCalculator : Page
	{
		private double amount;
		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				amount = double.Parse(txtAmount.Text);
			}
			catch (FormatException)
			{
				var msg = new MessageDialog("Error. Please enter a valid amount.");
				await msg.ShowAsync();
				txtAmount.Focus(FocusState.Programmatic);
				txtAmount.SelectAll();
				return;
			}


			if (cmbFromCurrency.SelectedIndex == cmbToCurrency.SelectedIndex)
			{
				var dialogMessage = new MessageDialog("Error From and To currency choices are the same!");
				await dialogMessage.ShowAsync();
				return;
			}
			else
			{
				string fromCurrency = ((ComboBoxItem)cmbFromCurrency.SelectedItem).Content.ToString();
				string toCurrency = ((ComboBoxItem)cmbToCurrency.SelectedItem).Content.ToString();

				double conversionRate = 0.0;


				if (fromCurrency == "USD")
				{
					if (toCurrency == "EUR")
						conversionRate = 0.85189982;
					else if (toCurrency == "GBP")
						conversionRate = 0.72872436;
					else if (toCurrency == "INR")
						conversionRate = 74.257327;
				}
				else if (fromCurrency == "EUR")
				{
					if (toCurrency == "USD")
						conversionRate = 1.1739732;
					else if (toCurrency == "GBP")
						conversionRate = 0.8556672;
					else if (toCurrency == "INR")
						conversionRate = 87.00755;
				}
				else if (fromCurrency == "GBP")
				{
					if (toCurrency == "USD")
						conversionRate = 1.371907;
					else if (toCurrency == "EUR")
						conversionRate = 1.1686692;
					else if (toCurrency == "INR")
						conversionRate = 101.68635;
				}
				else if (fromCurrency == "INR")
				{
					if (toCurrency == "USD")
						conversionRate = 0.011492628;
					else if (toCurrency == "EUR")
						conversionRate = 0.013492774;
					else if (toCurrency == "GBP")
						conversionRate = 0.0098339397;
				}

				//if (conversionRate == 0.0)
				//{
				//    var msg = new MessageDialog("Error: Invalid currency combination.");
				//    //await msg.ShowAsync();
				//    return;
				//}

				double reverseRate = 0.0;

				if (fromCurrency == "USD")
				{
					if (toCurrency == "EUR")
						reverseRate = 1.1739732;
					if (toCurrency == "GBP")
						reverseRate = 1.371907;
					if (toCurrency == "INR")
						reverseRate = 0.011492628;
				}


				if (fromCurrency == "EUR")
				{
					if (toCurrency == "USD")
						reverseRate = 0.85189982;
					if (toCurrency == "GBP")
						reverseRate = 1.1686692;
					if (toCurrency == "INR")
						reverseRate = 0.013492774;
				}


				if (fromCurrency == "GBP")
				{
					if (toCurrency == "USD")
						reverseRate = 0.72872436;
					if (toCurrency == "EUR")
						reverseRate = 0.8556672;
					if (toCurrency == "INR")
						reverseRate = 0.0098339397;
				}

				if (fromCurrency == "INR")
				{
					if (toCurrency == "USD")
						reverseRate = 74.257327;
					if (toCurrency == "EUR")
						reverseRate = 87.00755;
					if (toCurrency == "GBP")
						reverseRate = 101.68635;
				}

				double result = amount * conversionRate;

				Result.Text = amount.ToString() + "  " + fromCurrency + " = " + result + "  " + toCurrency;
				txtResult.Text = "1" + "  " + fromCurrency + " = " + conversionRate + "  " + toCurrency;
				txtReverse.Text = "1" + "  " + toCurrency + " = " + reverseRate + "  " + fromCurrency;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
	}
}
