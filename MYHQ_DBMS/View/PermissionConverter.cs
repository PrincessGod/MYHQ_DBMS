using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MYHQ_DBMS.View
{
    public class Permission1ToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = (string)value;
            if (temp == "仅浏览")
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool temp = (bool)value;
            if (temp == false)
                return "全操作";
            else
                return "仅浏览";

        }
    }

    public class Permission2ToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string temp = (string)value;
            if (temp == "全操作")
                return true;
            else
                return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool temp = (bool)value;
            if (temp == false)
                return "仅浏览";
            else
                return "全操作";

        }
    }
}
