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
            ComboBox cbbCate = ProjectData.EF.Singleton.Instance.DataForm.cbbCategory;
            ListBox listbox = sender as ListBox;
            if (listbox == null) return;
            if (listbox.SelectedIndex == -1)
            {
                WPFDbContext.Instance.CurrentTask = null;
            }
            else
            {
                WPFDbContext.Instance.CurrentTask = TaskDao.GetTask(TaskDao.GetId((int)cbbCate.SelectedValue, (int)listbox.SelectedValue));
            }
        }
    }
}
