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
	public sealed partial class MortgageCalculator : Page
	{

		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double annualInterestRate;
			double durationYears;
			double durationMonths;
			double monthlyInterestRate;
			double monthlyInterestRateDecimal;
			double principalAmount;
			double totalMonths;
			double monthlyRepayments;

			annualInterestRate = double.Parse(annualInterestTextBox.Text);
			monthlyInterestRate = annualInterestRate / 12;
			monthlyInterestTextBox.Text = monthlyInterestRate.ToString("0.0000") + "%";
			monthlyInterestRateDecimal = monthlyInterestRate / 100;

			durationYears = double.Parse(durationYearsTextBox.Text);
			durationMonths = double.Parse(durationMonthsTextBox.Text);
			principalAmount = double.Parse(principalAmountTextBox.Text);

			totalMonths = durationYears * 12 + durationMonths;

			monthlyRepayments = principalAmount * (monthlyInterestRateDecimal * Math.Pow(1 + monthlyInterestRateDecimal, totalMonths)) / (Math.Pow(1 + monthlyInterestRateDecimal, totalMonths)-1);


			monthlyRepaymentTextBox.Text = monthlyRepayments.ToString("C");
		}

		private void menuButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(main_menu));
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(main_menu));
		}
	}
}
