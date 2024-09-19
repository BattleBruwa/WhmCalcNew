using System.Globalization;
using System.Windows.Data;

namespace WhmCalcNew.Models
{
    [ValueConversion(typeof(string), typeof(byte)) ]
    public class StringToByteDataConverter : IValueConverter
    {
        // В стринг:
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString();
            }
            return "0";
        }

        // Стринг в байт:
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? val = value.ToString();
            byte result;
            if (byte.TryParse(val, out result))
            {
                return result;
            }
            return (byte)0;
        }
    }
}
