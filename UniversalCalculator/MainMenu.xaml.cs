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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}
		
		private void math_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(SimpleCalculator));
		}
		private void morg_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}

		private void cur_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyCalculator));
		}

		private void fuel_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(FuelCalculator));
		}

		private void exit_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void trip_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			// Trip calculator C# code will be developed later
        }
    }
}
