using ExportDatabase.Database.Dao;
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
        public static readonly DependencyProperty UnusedParameterKeyBoardFocusWithinChangedProperty = DependencyProperty.RegisterAttached(
            "UnusedParameterKeyBoardFocusWithinChanged", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnUnusedParameterKeyBoardFocusWithinChanged)));

        public static bool GetUnusedParameterKeyBoardFocusWithinChangedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(UnusedParameterKeyBoardFocusWithinChangedProperty);
        }
        public static void SetUnusedParameterKeyBoardFocusWithinChangedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(UnusedParameterKeyBoardFocusWithinChangedProperty, value);
        }
        private static void OnUnusedParameterKeyBoardFocusWithinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listbox = d as ListBox;
            if (listbox == null) return;

            listbox.IsKeyboardFocusWithinChanged -= UnusedParameterKeyBoardFocusWithinChanged;
            if ((bool)e.NewValue)
            {
                listbox.IsKeyboardFocusWithinChanged += UnusedParameterKeyBoardFocusWithinChanged;
            }
        }

        private static void UnusedParameterKeyBoardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue && !(bool)e.NewValue)
            {
                
            }
            else
            {
                WPFDbContext.Instance.TaskComboBoxVisibility = Visibility.Visible;
                WPFDbContext.Instance.TaskLabelVisibility = Visibility.Collapsed;
            }
        }
    }
}
