using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent:BaseAttachedProperty<Parent, Property>, new ()
    {
        public static Parent Instance { get; private set; } = new Parent();
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Instance.OnValueChanged(sender, e);

            Instance.ValueChanged(sender, e);
        }
        public static Property GetValue(DependencyObject obj) => (Property)obj.GetValue(ValueProperty);
        public static void SetValue(DependencyObject obj, Property value) => obj.SetValue(ValueProperty, value);
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
