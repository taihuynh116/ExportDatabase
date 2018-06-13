using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ExportDatabase.WPF
{
    public class GridHelpers
    {
        public static readonly DependencyProperty RowColumnCountProperty = DependencyProperty.RegisterAttached("RowColumnCount", typeof(string), typeof(GridHelpers), new PropertyMetadata("0 0", RowColumnCountChanged));
        public static string GetRowColumnCount(DependencyObject obj)
        {
            return (string)obj.GetValue(RowColumnCountProperty);
        }
        public static void SetRowColumnCount(DependencyObject obj, string value)
        {
            obj.SetValue(RowColumnCountProperty, value);
        }
        public static void RowColumnCountChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid)) return;
            string value = (string)e.NewValue;
            int rowCount = int.Parse(value[0].ToString());
            int columnCount = int.Parse(value[value.Length - 1].ToString());
            if (rowCount <= 0 || columnCount <= 0) return;
            Grid grid = obj as Grid;
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

        public static readonly DependencyProperty RowWidthsProperty = DependencyProperty.RegisterAttached("RowWidths", typeof(string), typeof(GridHelpers), new PropertyMetadata("*", RowWidthsChanged));
        public static string GetRowWidthsChanged(DependencyObject obj)
        {
            return (string)obj.GetValue(RowWidthsProperty);
        }
        public static void SetRowWidthsChanged(DependencyObject obj, string value)
        {
            obj.SetValue(RowWidthsProperty, value);
        }
        public static void RowWidthsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid)) return;
            string[] values = ((string)e.NewValue).Split(' ');
            Grid grid = obj as Grid;
            for (int i = 0; i < grid.RowDefinitions.Count; i++)
            {
                int j = i <= values.Length - 1 ? i : values.Length - 1;

                GridUnitType gut = GridUnitType.Auto;
                double val = 1;
                string value = values[j];
                if (value.Contains("*"))
                {
                    gut = GridUnitType.Star;
                    if (value[0] != '*')
                        val = double.Parse(value[0].ToString());
                }

                grid.RowDefinitions[i].Height = new GridLength(val, gut);
            }
        }

        public static readonly DependencyProperty ColumnWidthsProperty = DependencyProperty.RegisterAttached("ColumnWidths", typeof(string), typeof(GridHelpers), new PropertyMetadata("*", ColumnWidthsChanged));
        public static string GetCoilumnWidthsChanged(DependencyObject obj)
        {
            return (string)obj.GetValue(ColumnWidthsProperty);
        }
        public static void SetColumnWidthsChanged(DependencyObject obj, string value)
        {
            obj.SetValue(ColumnWidthsProperty, value);
        }
        public static void ColumnWidthsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is Grid)) return;
            string[] values = ((string)e.NewValue).Split(' ');
            Grid grid = obj as Grid;
            for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
            {
                int j = i <= values.Length - 1 ? i : values.Length - 1;

                GridUnitType gut = GridUnitType.Auto;
                double val = 1;
                string value = values[j];
                if (value.Contains("*"))
                {
                    gut = GridUnitType.Star;
                    if (value[0] != '*')
                        val = double.Parse(value[0].ToString());
                }

                grid.ColumnDefinitions[i].Width = new GridLength(val, gut);
            }
        }
    }
}
