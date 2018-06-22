using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ExportDatabase.WPF
{
    public class CategoryToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return -1;
            return CategoryDao.GetIndex((Category)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)value;
            if (index == -1) return null;
            return CategoryDao.GetCategoryFromIndex(index);
        }
    }
}
