using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp5
{
    /// <summary>
    /// A base attached property to replace the vanilla WPF attached property
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent: BaseAttachedProperty<Parent, Property>, new()
    {
        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// A singleton instance of our parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// The callback event when the ValueProperty is changed
        /// </summary>
        /// <param name="d">The UI Element that had it's property changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call event listeners
            Instance.ValueChanged(d, e);
        }
        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="obj">The element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject obj) => (Property)obj.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="obj">The element to get the property from</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject obj, Property value) => obj.SetValue(ValueProperty, value);

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="obj">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {

        }
    }
    
}
