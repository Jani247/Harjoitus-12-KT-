// Tiedosto: MainWindow.xaml.cs

using System.Windows;
using System.Windows.Controls;

namespace OstosApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Tapahtumankäsittelijä CheckBox-kontrolleille kun tuote lisätään windowiin
        private void ProductCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Tarkistetaan että onko lähettäjä CheckBox ja onko se valittu
            if (sender is CheckBox checkBox && checkBox.IsChecked == true)
            {
                // Lisätään tuotteen nimi ostoskoriin tää (CartTextBox)
                CartTextBox.Text += $"{checkBox.Content}\n";
            }
        }

        // Tapahtumankäsittelijä CheckBox kontrolleille, kun tuote poistetaan
        private void ProductCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Tarkistetaan, onko lähettäjä CheckBox ja onko se valitsematon
            if (sender is CheckBox checkBox && checkBox.IsChecked == false)
            {
                // Muodostetaan poistettava tekstijono
                string product = $"{checkBox.Content}\n";
                // Poistetaan tekstijono ostoskorista
                CartTextBox.Text = CartTextBox.Text.Replace(product, string.Empty);
            }
        }

        // Tapahtumankäsittelijä "Osta"-painikkeelle
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            // Tyhjennetään ostoskori
            CartTextBox.Text = string.Empty;

            // palautetaan kaikki CheckBox kontrollit valitsemattomiksi
            CheckBoxApple.IsChecked = false;
            CheckBoxBanana.IsChecked = false;
            CheckBoxOrange.IsChecked = false;
            CheckBoxGrapes.IsChecked = false;
            CheckBoxMango.IsChecked = false;

            // viimeiseksi näytetään viesti ostoksen suorittamisesta
            MessageBox.Show("Ostos on suoritettu!", "Osto", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
