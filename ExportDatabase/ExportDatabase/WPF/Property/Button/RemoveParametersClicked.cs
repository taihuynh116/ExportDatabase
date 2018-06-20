using ExportDatabase.Database.Dao;
using ExportDatabase.WPF.Data.Dao;
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
        public static readonly DependencyProperty RemoveParametersClickedProperty = DependencyProperty.RegisterAttached(
            "RemoveParametersClicked", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnRemoveParametersClickedPropertyChanged)));

        public static bool GetRemoveParametersClickedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(RemoveParametersClickedProperty);
        }
        public static void SetRemoveParametersClickedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(RemoveParametersClickedProperty, value);
        }
        private static void OnRemoveParametersClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= RemoveParameterClicked;
            if ((bool)e.NewValue)
            {
                btn.Click += RemoveParameterClicked;
            }
        }

        private static void RemoveParameterClicked(object sender, RoutedEventArgs e)
        {
            if (WPFDbContext.Instance.TaskLabelVisibility == Visibility.Collapsed) return;
            ParameterBindingDao.Remove(WPFDbContext.Instance.SelectedLabelTask.ID, WPFDbContext.Instance.SelectedCategory.ID, WPFDbContext.Instance.SelectedUsedParameter.ID);

            WPFParameterNameDao.Update();
        }
    }
}
