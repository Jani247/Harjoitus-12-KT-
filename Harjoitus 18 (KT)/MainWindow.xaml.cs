// Tiedosto: MainWindow.xaml.cs

using System;
using System.Windows;

namespace WpfLaskin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SumButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = GetInputNumber(FirstNumberTextBox.Text);
                double b = GetInputNumber(SecondNumberTextBox.Text);
                double result = Laskin.Summa(a, b);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        //erroria
        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = GetInputNumber(FirstNumberTextBox.Text);
                double b = GetInputNumber(SecondNumberTextBox.Text);
                double result = Laskin.Erotus(a, b);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = GetInputNumber(FirstNumberTextBox.Text);
                double b = GetInputNumber(SecondNumberTextBox.Text);
                double result = Laskin.Kertolasku(a, b);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = GetInputNumber(FirstNumberTextBox.Text);
                double b = GetInputNumber(SecondNumberTextBox.Text);
                double result = Laskin.Jakolasku(a, b);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private double GetInputNumber(string input)
        {
            if (!double.TryParse(input, out double number))
                throw new Exception("Syöte ei ole kelvollinen luku.");
            return number;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ResultTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
