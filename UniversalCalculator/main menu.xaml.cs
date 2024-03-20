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
	public sealed partial class main_menu : Page
	{
		public main_menu()
		{
			this.InitializeComponent();
		}

		
		

		private void exit_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void cur_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(currencyCalculatorxaml));
		}

		private void fuel_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(FuelCalculator));
		}

		private void morg_CalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MortgageCalculator));
		}
	}
}
