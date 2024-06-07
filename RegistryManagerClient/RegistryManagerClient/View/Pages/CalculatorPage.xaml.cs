using CommunityToolkit.Mvvm.ComponentModel;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using Wpf.Ui.Controls;

namespace RegistryManagerClient.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculatorPage.xaml
    /// </summary>
    public partial class CalculatorPage : Page
    {
        public CalculatorViewModel ViewModel { get; }
        public CalculatorPage()
        {
            ViewModel = new CalculatorViewModel();
            DataContext = this;
            this.KeyDown += Page_KeyDown;
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton bt = sender as RadioButton;
            if (bt.Name == "Combined")
                ViewModel.IsCombined = true;
            else ViewModel.IsCombined = false;
        }
        private void CountBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is NumberBox box)
                {
                    var bindingExpression = box.GetBindingExpression(NumberBox.ValueProperty);
                    bindingExpression?.UpdateSource();
                    ((UIElement)e.OriginalSource).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }
        }
        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                if (ViewModel.CtrlRPressedCommand.CanExecute(null))
                {
                    ViewModel.CtrlRPressedCommand.Execute(null);
                }
            }
        }
    }
}
