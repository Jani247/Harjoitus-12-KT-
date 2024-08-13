// EmptyTextToVisibilityConverter.cs tarjoaa konvertoijan, joka muuntaa TextBox-kentän tekstin tyhjyyden (Visibility) näkyväksi niin, että se voi hallita, milloin tietty elementti, kuten paikkamerkki (placeholder) teksti, on näkyvissä tai piilossa käyttöliittymässä.. elikkäs antaa tavan muokata käyttöliittymän elementtien ulkoasua ja käyttäytymistä dynaamisesti.

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TaskApp
{
    // Konvertoija, joka muuttaa tyhjän tekstikentän näkyväksi
    public class EmptyTextToVisibilityConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // // Tarkistaa, onko annettu teksti tyhjä (null tai tyhjä merkkijono) ja jos tekstikenttä on tyhjä, näytä TextBlock, muuten piilotetaan se
            return string.IsNullOrEmpty(value as string) ? Visibility.Visible : Visibility.Collapsed;
        }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
