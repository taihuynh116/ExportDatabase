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
        public static readonly DependencyProperty GridRowColumnCountProperty = DependencyProperty.RegisterAttached(
            "GridRowColumnCount", typeof(string), typeof(BaseAttachedProperty), 
            new PropertyMetadata("0 0", new PropertyChangedCallback(OnGridRowColumnCountChanged)));

        public static string GetGridRowColumnCountProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowColumnCountProperty);
        }
        public static void SetGridRowColumnCountProperty(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowColumnCountProperty, value);
        }
        private static void OnGridRowColumnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = d as Grid;
            if (grid == null) return;

            string value = (string)e.NewValue;
            int rowCount = int.Parse(value[0].ToString());
            int columnCount = int.Parse(value[value.Length - 1].ToString());
            if (rowCount <= 0 || columnCount <= 0) return;
            
            grid.RowDefinitions.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < columnCount; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
        }
    }
}
