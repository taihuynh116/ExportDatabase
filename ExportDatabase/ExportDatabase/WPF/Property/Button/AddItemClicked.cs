using ExportDatabase.Database.Dao;
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
        public static readonly DependencyProperty AddItemClickedProperty = DependencyProperty.RegisterAttached(
            "AddItemClicked", typeof(string), typeof(BaseAttachedProperty), new PropertyMetadata(null, new PropertyChangedCallback(OnAddItemClickedPropertyChanged)));

        public static string GetAddItemClickedProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(AddItemClickedProperty);
        }
        public static void SetAddItemClickedProperty(DependencyObject obj, string value)
        {
            obj.SetValue(AddItemClickedProperty, value);
        }
        private static void OnAddItemClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= AddItemClicked;
            if ((string)e.NewValue != null)
            {
                btn.Click += AddItemClicked;
            }
        }

        private static void AddItemClicked(object sender, RoutedEventArgs e)
        {
            WPFDbContext.Instance.AddItemType = (ItemTypeEnum)Enum.Parse(typeof(ItemTypeEnum), (string)(sender as DependencyObject).GetValue(AddItemClickedProperty));

            WPFDbContext.Instance.AddItem.ShowDialog();
        }
    }
}
