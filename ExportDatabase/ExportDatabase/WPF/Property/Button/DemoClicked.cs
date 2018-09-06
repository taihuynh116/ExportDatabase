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
        public static readonly DependencyProperty DemoClickedProperty = DependencyProperty.RegisterAttached(
            "DemoClicked", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnDemoClickedPropertyChanged)));

        public static bool GetDemoClickedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(DemoClickedProperty);
        }
        public static void SetDemoClickedProperty(DependencyObject obj, bool value)
        {
            //Button btn = d as Button;
            //if (btn == null) return;

            //btn.Click -= DemoClicked;
            //if (value)
            //{
            //    btn.Click += DemoClicked;
            //}

            obj.SetValue(DemoClickedProperty, value);
        }
        private static void OnDemoClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= DemoClicked;
            if ((bool)e.NewValue)
            {
                btn.Click += DemoClicked;
            }
        }

        private static void DemoClicked(object sender, RoutedEventArgs e)
        {
            WPFDbContext.Instance.TempSelectedCategoryIndex++;
            WPFDbContext.Instance.SelectedCategory = WPFDbContext.Instance.Categories[WPFDbContext.Instance.TempSelectedCategoryIndex];
        }
    }
}
