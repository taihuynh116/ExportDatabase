using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExportDatabase.WPF
{
    public partial class BaseAttachedProperty
    {
        public static readonly DependencyProperty AddItemWindowClosingProperty = DependencyProperty.RegisterAttached(
            "AddItemWindowClosing", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnAddItemWindowClosingPropertyChanged)));

        public static bool GetAddItemWindowClosingProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(AddItemWindowClosingProperty);
        }
        public static void SetAddItemWindowClosingProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(AddItemWindowClosingProperty, value);
        }
        private static void OnAddItemWindowClosingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = d as Window;
            if (window == null) return;

            window.Closing += AddItemWindowClosing;
            if ((bool)e.NewValue)
            {
                window.Closing += AddItemWindowClosing;
            }
        }

        private static void AddItemWindowClosing(object sender, CancelEventArgs e)
        {
            ((Window)sender).Hide();
            e.Cancel = true;
        }
    }
}
