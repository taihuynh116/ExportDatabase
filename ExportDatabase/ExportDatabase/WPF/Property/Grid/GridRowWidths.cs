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
        public static readonly DependencyProperty GridRowWidthsProperty = DependencyProperty.RegisterAttached(
            "GridRowWidths", typeof(string), typeof(BaseAttachedProperty), 
            new PropertyMetadata("0 0", new PropertyChangedCallback(OnGridRowWidthsChanged)));

        public static string GetGridRowWidthsProperty(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowWidthsProperty);
        }
        public static void SetGridRowWidthsProperty(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowWidthsProperty, value);
        }
        private static void OnGridRowWidthsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = d as Grid;
            if (grid == null) return;

            string[] values = ((string)e.NewValue).Split(' ');
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
    }
}
