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
	public sealed partial class FuelCalculator : Page
	{
		const double MPG_CONV_0 = 2.8248;
		const double MPG_CONV_1 = 282.48;

		public FuelCalculator()
		{
			this.InitializeComponent();
		}

		private async void calcButton_Click(object sender, RoutedEventArgs e)
		{
			double fromAmount;

			// Validate input (1st method throws error warning for null entry, 2nd method ensures decimal number input)
			if (string.IsNullOrWhiteSpace(fromTextBox.Text))
			{
				var dialogMessage = new MessageDialog("Error! Please enter an input number");
				await dialogMessage.ShowAsync();
				fromTextBox.Focus(FocusState.Programmatic);
				fromTextBox.SelectAll();
				return;
			}

			try
			{
				fromAmount = double.Parse(fromTextBox.Text);
			}
			catch (Exception)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a input (decimal number)");
				await dialogMessage.ShowAsync();
				fromTextBox.Focus(FocusState.Programmatic);
				fromTextBox.SelectAll();
				return;
			}

			converterSelector(fromAmount);
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(main_menu));
		}

		private void converterSelector(double fromAmount)
		{
			double toAmount;
			if (fromComboBox.SelectedIndex == 0)
			{
				toAmount = kiloPerLitCalc(fromAmount);
			}
			else if (fromComboBox.SelectedIndex == 1)
			{
				toAmount = litPerKiloCalc(fromAmount);
			}
			else
			{
				toAmount = milPerGallCalc(fromAmount);
			}
			toTextBox.Text = toAmount.ToString("f3");
			return;
		}

		private double kiloPerLitCalc(double fromAmount)
		{
			double toAmount;
			if (toComboBox.SelectedIndex == 0)
			{
				toAmount = fromAmount;
			}
			else if (toComboBox.SelectedIndex == 1)
			{
				toAmount = 100 / fromAmount;
			}
			else
			{
				toAmount = fromAmount * MPG_CONV_0;
			}
			return toAmount;
		}

		private double litPerKiloCalc(double fromAmount)
		{
			double toAmount;
			if (toComboBox.SelectedIndex == 0)
			{
				toAmount = 100 / fromAmount;
			}
			else if (toComboBox.SelectedIndex == 1)
			{
				toAmount = fromAmount;
			}
			else
			{
				toAmount = MPG_CONV_1 / fromAmount;
			}
			return toAmount;
		}

		private double milPerGallCalc(double fromAmount)
		{
			double toAmount;
			if (toComboBox.SelectedIndex == 0)
			{
				toAmount = fromAmount / MPG_CONV_0;
			}
			else if (toComboBox.SelectedIndex == 1)
			{
				toAmount = MPG_CONV_1 / fromAmount;
			}
			else
			{
				toAmount = fromAmount;
			}

			return toAmount;
		}
	}
}