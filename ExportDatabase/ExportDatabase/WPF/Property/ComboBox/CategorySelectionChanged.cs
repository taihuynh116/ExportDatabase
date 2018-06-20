using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using ExportDatabase.WPF.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExportDatabase.WPF
{
    public partial class BaseAttachedProperty
    {
        public static readonly DependencyProperty CategorySelectionChangedProperty = DependencyProperty.RegisterAttached(
            "CategorySelectionChanged", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnCategorySelectionChanged)));

        public static bool GetCategorySelectionChangedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(CategorySelectionChangedProperty);
        }
        public static void SetCategorySelectionChangedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(CategorySelectionChangedProperty, value);
        }
        private static void OnCategorySelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ComboBox comboBox = d as ComboBox;
            if (comboBox == null) return;
            comboBox.SelectionChanged -= CategorySelectionChanged;
            if ((bool)e.NewValue)
            {
                comboBox.SelectionChanged += CategorySelectionChanged;
            }
        }

        private static void CategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == -1) return;
            Category cate = (sender as ComboBox).SelectedItem as Category;

            WPFParameterNameDao.Update();
        }
    }
}
