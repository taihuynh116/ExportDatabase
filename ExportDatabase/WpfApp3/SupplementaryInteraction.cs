using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace WpfApp3
{
    public class Behaviors:List<Behavior>
    {

    }
    public class Triggers : List<System.Windows.Interactivity.TriggerBase>
    {

    }
    public static class SupplementaryInteraction
    {
        private static void OnPropertyBehaviorsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var behaviors = Interaction.GetBehaviors(obj);
            foreach (var behavior in e.NewValue as Behaviors)
            {
                behaviors.Add(behavior);
            }
        }
        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.RegisterAttached(
            "Behaviors", typeof(Behaviors), typeof(SupplementaryInteraction),
            new UIPropertyMetadata(null, OnPropertyBehaviorsChanged));
        public static Behaviors GetBehaviors(DependencyObject obj)
        {
            return (Behaviors)obj.GetValue(BehaviorsProperty);
        }
        private static void OnPropertyTriggersChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var triggers = Interaction.GetTriggers(obj);
            foreach (var trigger in e.NewValue as Triggers)
            {
                triggers.Add(trigger);
            }
        }
        public static readonly DependencyProperty TriggersProperty = DependencyProperty.RegisterAttached(
            "Triggers", typeof(Triggers), typeof(SupplementaryInteraction),
            new UIPropertyMetadata(null, OnPropertyTriggersChanged));
        public static Triggers GetTriggers(DependencyObject obj)
        {
            return (Triggers)obj.GetValue(TriggersProperty);
        }
    }
}
