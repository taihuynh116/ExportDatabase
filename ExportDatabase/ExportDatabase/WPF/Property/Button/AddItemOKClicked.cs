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
        public static readonly DependencyProperty AddItemOKClickedProperty = DependencyProperty.RegisterAttached(
            "AddItemOKClicked", typeof(string), typeof(BaseAttachedProperty), new PropertyMetadata(null, new PropertyChangedCallback(OnAddItemOKClickedPropertyChanged)));

        public static string GetAddItemOKClickedProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(AddItemOKClickedProperty);
        }
        public static void SetAddItemOKClickedProperty(DependencyObject obj, string value)
        {
            obj.SetValue(AddItemOKClickedProperty, value);
        }
        private static void OnAddItemOKClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= AddItemOKClicked;
            if ((string)e.NewValue != null)
            {
                btn.Click += AddItemOKClicked;
            }
        }

        private static void AddItemOKClicked(object sender, RoutedEventArgs e)
        {
            WPFDbContext.Instance.AddItem.Hide();
            switch (WPFDbContext.Instance.AddItemType)
            {
                case ItemTypeEnum.Category:
                    WPFCategoryDao.SaveTempSelectedIndex();
                    CategoryDao.Insert(WPFDbContext.Instance.ItemName);
                    WPFCategoryDao.GetCategories();
                    WPFCategoryDao.GetCategoryFromTempSelectedIndex();
                    break;
                case ItemTypeEnum.ParameterName:
                    break;
                case ItemTypeEnum.Task:
                    break;
            }
            WPFDbContext.Instance.ItemName = "";
        }
    }
}
