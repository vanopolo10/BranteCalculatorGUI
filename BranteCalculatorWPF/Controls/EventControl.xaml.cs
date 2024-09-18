using BranteCalculator.Entities.Events;
using BranteCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BranteCalculatorWPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для EventUserControl.xaml
    /// </summary>
    public partial class EventControl : UserControl
    {
        public EventControl()
        {
            InitializeComponent();

        }

        /*private void Decision_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox radioButton && radioButton.DataContext is Decision decision)
            {
                // Выполняем все последствия (Consequences)
                foreach (var consequence in decision.Consequances)
                {
                    var compiledAction = consequence.Compile();
                    compiledAction();
                }

                // Добавляем следующее событие (если нужно)
                var mainWindow = Application.Current.MainWindow as MainWindow;
                var events = (mainWindow.DataContext as MainViewModel).Events;
                var gameEvent = events.FirstOrDefault(e => e.Decisions.Contains(decision));

                if (gameEvent != null && gameEvent.Equals(events.Last()))
                {
                    gameEvent.HasPassed = true;
                    mainWindow.AddNextEvent();
                }

                // Сбросить состояние других решений в этом событии
                foreach (var eventDecision in gameEvent.Decisions)
                {
                    if (decision.Name == eventDecision.Name)
                    {
                        eventDecision.IsChecked = false;
                        break;
                    }
                }
            }
        }*/

        private void Decision_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            var selectedDecision = radioButton?.DataContext as Decision;

            if (selectedDecision == null)
                return;

            // Get the parent ItemsControl
            var itemsControl = FindAncestor<ItemsControl>(radioButton);
            if (itemsControl == null)
                return;

            // Uncheck all other checkboxes
            foreach (var decision in itemsControl.Items.OfType<Decision>())
            {
                if (decision != selectedDecision && decision.IsChecked)
                {
                    decision.IsChecked = false;
                }
            }

            selectedDecision.Select();

            var mainWindow = Application.Current.MainWindow as MainWindow;
            var events = (mainWindow.DataContext as MainViewModel).Events;
            var gameEvent = events.FirstOrDefault(e => e.Decisions.Contains(selectedDecision));
            if (gameEvent != null && gameEvent.Equals(events.Last()))
            {
                mainWindow.AddNextEvent();
            }
            else 
            {
                mainWindow.Recalculate(gameEvent, selectedDecision);
            }
        }

        private RadioButton FindRadioButton(Decision decision)
        {
            var itemsControl = FindAncestor<ItemsControl>(this);
            if (itemsControl == null)
                return null;

            var container = itemsControl.ItemContainerGenerator.ContainerFromItem(decision) as FrameworkElement;
            return container?.FindName("DecisionRadioButton") as RadioButton;
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T ancestor)
                {
                    return ancestor;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }


    }
}