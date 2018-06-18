using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace WpfApp4
{
    public class Behaviors : List<Behavior>
    {
    }
    public class Triggers : List<System.Windows.Interactivity.TriggerBase>
    {
    }
    public static class SupplementaryInteraction
    {
        private static void OnBehaviorsPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {

        }
        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.RegisterAttached("Behaviors", typeof(Behaviors), typeof(SupplementaryInteraction), new UIPropertyMetadata(null, OnBehaviorsPropertyChanged));
        public static Behaviors GetBehaviors(DependencyObject obj)
        {

        }
    }
}
