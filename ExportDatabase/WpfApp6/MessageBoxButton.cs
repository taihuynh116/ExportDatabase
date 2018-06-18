using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp6
{
    public class MessageBoxButton : BaseAttachedProperty<MessageBoxButton, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            button.Click -= Button_Clicked;
            if ((bool)e.NewValue)
            {
                button.Click += Button_Clicked;
            }
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");
        }
    }
}
