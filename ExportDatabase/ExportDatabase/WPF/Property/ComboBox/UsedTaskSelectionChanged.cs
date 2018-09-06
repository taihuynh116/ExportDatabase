using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
using ExportDatabase.WPF.Data.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ExportDatabase.WPF
{
    public partial class BaseAttachedProperty
    {
        public static readonly DependencyProperty UsedTaskSelectionChangedProperty = DependencyProperty.RegisterAttached(
            "UsedTaskSelectionChanged", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnUsedTaskSelectionChanged)));

        public static bool GetUsedTaskSelectionChangedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(UsedTaskSelectionChangedProperty);
        }
        public static void SetUsedTaskSelectionChangedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(UsedTaskSelectionChangedProperty, value);
        }
        private static void OnUsedTaskSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ComboBox comboBox = d as ComboBox;
            if (comboBox == null) return;
            comboBox.SelectionChanged -= UsedTaskSelectionChanged;
            if ((bool)e.NewValue)
            {
                comboBox.SelectionChanged += UsedTaskSelectionChanged;
            }
        }

        private static void UsedTaskSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null) return;
            if (comboBox.SelectedIndex == -1) return;
            if (WPFDbContext.Instance.SelectedCategory == null) return;

            ParameterBindingDao.UpdateNewTask((e.AddedItems[0] as Task).ID, WPFDbContext.Instance.SelectedCategory.ID, WPFDbContext.Instance.SelectedUsedParameter.ID);
        }
    }
}
