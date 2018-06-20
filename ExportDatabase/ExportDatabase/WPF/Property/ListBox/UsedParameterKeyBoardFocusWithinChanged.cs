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
        public static readonly DependencyProperty UsedParameterKeyBoardFocusWithinChangedProperty = DependencyProperty.RegisterAttached(
            "UsedParameterKeyBoardFocusWithinChanged", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnUsedParameterKeyBoardFocusWithinChanged)));

        public static bool GetUsedParameterKeyBoardFocusWithinChangedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(UsedParameterKeyBoardFocusWithinChangedProperty);
        }
        public static void SetUsedParameterKeyBoardFocusWithinChangedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(UsedParameterKeyBoardFocusWithinChangedProperty, value);
        }
        private static void OnUsedParameterKeyBoardFocusWithinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ListBox listbox = d as ListBox;
            if (listbox == null) return;

            listbox.IsKeyboardFocusWithinChanged -= UsedParameterKeyBoardFocusWithinChanged;
            if ((bool)e.NewValue)
            {
                listbox.IsKeyboardFocusWithinChanged += UsedParameterKeyBoardFocusWithinChanged;
            }
        }

        private static void UsedParameterKeyBoardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue && !(bool)e.NewValue)
            {
            }
            else
            {
                WPFDbContext.Instance.TaskComboBoxVisibility = Visibility.Collapsed;
                WPFDbContext.Instance.TaskLabelVisibility = Visibility.Visible;
            }
        }
    }
}
