using System.Globalization;
using System.Windows.Data;

namespace SupplyWinApp.Presentation.Converters;

public class PercentageConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is double actual &&
            parameter is string pct &&
            double.TryParse(pct, CultureInfo.InvariantCulture, out var factor))
        {
            return actual * factor;
        }

        return value!;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
