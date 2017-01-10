using System;
using System.Globalization;
using System.Windows.Data;

namespace MYHQ_DBMS.View
{
    public class Permission1ToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (string) value;
            if (temp == "仅浏览")
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (bool) value;
            if (temp == false)
                return "全操作";
            return "仅浏览";
        }
    }

    public class Permission2ToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (string) value;
            if (temp == "全操作")
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temp = (bool) value;
            if (temp == false)
                return "仅浏览";
            return "全操作";
        }
    }
}