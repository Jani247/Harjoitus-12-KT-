// Tiedosto: MainWindow.xaml.cs

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PintaAlaLaskuri
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Tapahtumankäsittelijä "Laske" painikkeelle
        private void LaskeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Luetaan käyttäjän syöttämät arvot
                double leveysMm = GetInputNumber(LeveysTextBox.Text);
                double korkeusMm = GetInputNumber(KorkeusTextBox.Text);
                double karmiMm = GetInputNumber(KarmiTextBox.Text);

                // Muutetaan mitat neliösenttimetreiksi
                double leveysCm = leveysMm / 10;
                double korkeusCm = korkeusMm / 10;
                double karmiCm = karmiMm / 10;

                // Lasketaan sitten ikkunan pinta ala, lasin pinta ala ja karmin piiri
                double ikkunaPintaAla = leveysCm * korkeusCm;
                double lasiPintaAla = (leveysCm - 2 * karmiCm) * (korkeusCm - 2 * karmiCm);
                double karminPiiri = 2 * (leveysCm + korkeusCm);

                // Näytetään siiten laskutulokset
                IkkunaPintaAlaTextBlock.Text = $"Ikkunan pinta-ala: {ikkunaPintaAla:F2} cm²";
                LasiPintaAlaTextBlock.Text = $"Lasin pinta-ala: {lasiPintaAla:F2} cm²";
                KarminPiiriTextBlock.Text = $"Karmin piiri: {karminPiiri:F2} cm";

                // Piirretään sitten ikkuna
                PiirraIkkuna(leveysMm, korkeusMm, karmiMm);
            }
            catch (Exception ex)
            {
                // Näytetään virheilmoitus, jos syöte on virheellinen he
                MessageBox.Show(ex.Message, "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Funktio syötteiden lukemiseen ja tarkistamiseen
        private double GetInputNumber(string input)
        {
            if (!double.TryParse(input, out double number))
                throw new Exception("Syöte ei ole kelvollinen luku.");
            return number;
        }

        // Funktio ikkunan piirtämiseen Canvas kontrollii
        private void PiirraIkkuna(double leveys, double korkeus, double karmi)
        {
            // Tyhjennetään aiempi piirros
            IkkunaCanvas.Children.Clear();

            // Lasketaan suhteelliset mitat Canvas alueel
            double canvasWidth = IkkunaCanvas.Width;
            double canvasHeight = IkkunaCanvas.Height;

            // Lasketaan mittasuhde, jotta ikkuna mahtuu Canvas-alueelle
            double scaleFactor = Math.Min(canvasWidth / leveys, canvasHeight / korkeus);

            // Piirretään karmin ulkoreunaa
            Rectangle karmiReuna = new Rectangle
            {
                Width = leveys * scaleFactor,
                Height = korkeus * scaleFactor,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Canvas.SetLeft(karmiReuna, (canvasWidth - karmiReuna.Width) / 2);
            Canvas.SetTop(karmiReuna, (canvasHeight - karmiReuna.Height) / 2);
            IkkunaCanvas.Children.Add(karmiReuna);

            // Piirretään lasin alue karmin sisällä
            Rectangle lasiReuna = new Rectangle
            {
                Width = (leveys - 2 * karmi) * scaleFactor,
                Height = (korkeus - 2 * karmi) * scaleFactor,
                Stroke = Brushes.Blue,
                StrokeThickness = 2
            };
            Canvas.SetLeft(lasiReuna, (canvasWidth - lasiReuna.Width) / 2);
            Canvas.SetTop(lasiReuna, (canvasHeight - lasiReuna.Height) / 2);
            IkkunaCanvas.Children.Add(lasiReuna);
        }
    }
}
