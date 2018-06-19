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
        public static readonly DependencyProperty MessageBoxClickedProperty = DependencyProperty.RegisterAttached(
            "MessageBoxClicked", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnMessageBoxClickedPropertyChanged)));

        public static bool GetMessageBoxClickedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(MessageBoxClickedProperty);
        }
        public static void SetMessageBoxClickedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(MessageBoxClickedProperty, value);
        }
        private static void OnMessageBoxClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= Click_Command;
            if ((bool)e.NewValue)
            {
                btn.Click += Click_Command;
            }
        }

        private static void Click_Command(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked me :(");
        }
    }
}
