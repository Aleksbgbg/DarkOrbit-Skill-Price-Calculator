namespace DarkOrbitSkillPriceCalculator.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    [ValueConversion(typeof(int), typeof(BitmapImage))]
    internal class ImageLocatorConverter : IMultiValueConverter
    {
        public static ImageLocatorConverter Instance { get; } = new ImageLocatorConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return Application.Current.FindResource(((Func<int, string>)values[1])((int)values[0]));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("ConvertBack is not supported.");
        }
    }
}