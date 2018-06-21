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
        public static readonly DependencyProperty AddParametersClickedProperty = DependencyProperty.RegisterAttached(
            "AddParametersClicked", typeof(bool), typeof(BaseAttachedProperty), new PropertyMetadata(false, new PropertyChangedCallback(OnAddParametersClickedPropertyChanged)));

        public static bool GetAddParametersClickedProperty(DependencyObject obj)
        {
            return (bool)obj.GetValue(AddParametersClickedProperty);
        }
        public static void SetAddParametersClickedProperty(DependencyObject obj, bool value)
        {
            obj.SetValue(AddParametersClickedProperty, value);
        }
        private static void OnAddParametersClickedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button btn = d as Button;
            if (btn == null) return;

            btn.Click -= AddParameterClicked;
            if ((bool)e.NewValue)
            {
                btn.Click += AddParameterClicked;
            }
        }

        private static void AddParameterClicked(object sender, RoutedEventArgs e)
        {
            if (WPFDbContext.Instance.UnusedTaskVisibility == Visibility.Collapsed) return;
            ParameterBindingDao.Insert(WPFDbContext.Instance.SelectedUnusedTask.ID, WPFDbContext.Instance.SelectedCategory.ID, WPFDbContext.Instance.SelectedUnusedParameter.ID);

            WPFParameterNameDao.Update();
        }
    }
}
