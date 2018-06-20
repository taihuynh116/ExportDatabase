using ExportDatabase.Database.Dao;
using ExportDatabase.Database.EF;
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
        public static readonly DependencyProperty UsedParameterSelectoinChangedProperty = DependencyProperty.RegisterAttached(
            "UsedParameterSelectionChanged", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnUsedParameterSelectionChanged)));

        public static bool GetUsedParameterSelectoinChangedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(CategorySelectionChangedProperty);
        }
        public static void SetUsedParameterSelectoinChangedProperty(DependencyObject obj, bool value)
        {
            ListBox listbox = obj as ListBox;
            if (listbox == null) return;
            listbox.SelectionChanged -= UsedParameterSelectionChanged;
            if (value)
            {
                listbox.SelectionChanged += UsedParameterSelectionChanged;
            }

            obj.SetValue(CategorySelectionChangedProperty, value);
        }
        private static void OnUsedParameterSelectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        private static void UsedParameterSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category selectedCate = WPFDbContext.Instance.SelectedCategory;

            ListBox listbox = sender as ListBox;
            if (listbox == null) return;
            if (listbox.SelectedIndex == -1)
            {
                WPFDbContext.Instance.SelectedLabelTask = null;
            }
            else
            {
                WPFDbContext.Instance.SelectedLabelTask = TaskDao.GetTask(TaskDao.GetId(selectedCate.ID, (int)listbox.SelectedValue));
            }
        }
    }
}
