using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace WpfApp3
{
    public class Action : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            "Message", typeof(string), typeof(Action), new UIPropertyMetadata(""));
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        public static readonly DependencyProperty MessageParameterProperty = DependencyProperty.Register(
            "MessageParameter", typeof(object), typeof(Action), new UIPropertyMetadata(null));
        public object MessageParameter
        {
            get { return GetValue(MessageParameterProperty); }
            set { SetValue(MessageParameterProperty, value); }
        }
        protected override void Invoke(object parameter)
        {
            //Debug.WriteLine(Message, MessageParameter, AssociatedObject, parameter);

            MessageBox.Show($"{Message} - {MessageParameter} - {AssociatedObject} - {parameter}");
        }
    }
}
