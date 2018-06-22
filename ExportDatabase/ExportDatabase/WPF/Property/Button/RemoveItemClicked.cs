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
        public static readonly DependencyProperty RemoveItemClickedProperty = DependencyProperty.RegisterAttached(
            "RemoveItemClicked", typeof(string), typeof(BaseAttachedProperty), new PropertyMetadata(null, new PropertyChangedCallback(OnRemoveItemClickedPropertyChanged)));

        public static string GetRemoveItemClickedProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(RemoveItemClickedProperty);
        }
        public static void SetRemoveItemClickedProperty(DependencyObject obj, string value)
        {
            obj.SetValue(RemoveItemClickedProperty, value);
        }
        private static void OnRemoveItemClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= RemoveItemClicked;
            if ((string)e.NewValue != null)
            {
                btn.Click += RemoveItemClicked;
            }
        }

        private static void RemoveItemClicked(object sender, RoutedEventArgs e)
        {
            WPFDbContext.Instance.RemoveItemType = (ItemTypeEnum)Enum.Parse(typeof(ItemTypeEnum), (string)(sender as DependencyObject).GetValue(RemoveItemClickedProperty));
            switch (WPFDbContext.Instance.RemoveItemType)
            {
                case ItemTypeEnum.Category:
                    WPFCategoryDao.SaveTempSelectedIndex();
                    CategoryDao.Remove(WPFDbContext.Instance.SelectedCategory.ID);
                    WPFCategoryDao.GetCategories();
                    WPFCategoryDao.GetCategoryFromTempSelectedIndex();
                    break;
                case ItemTypeEnum.ParameterName:
                    break;
                case ItemTypeEnum.Task:
                    break;
            }
        }
    }
}
