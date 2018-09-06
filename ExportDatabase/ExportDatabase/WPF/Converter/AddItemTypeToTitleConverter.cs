using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ExportDatabase.WPF
{
    public class AddItemTypeToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((ItemTypeEnum)value)
            {
                case ItemTypeEnum.Category:
                    return "Add Category";
                case ItemTypeEnum.ParameterName:
                    return "Add ParameterName";
                case ItemTypeEnum.Task:
                    return "Add Task";
            }
            throw new Exception();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
