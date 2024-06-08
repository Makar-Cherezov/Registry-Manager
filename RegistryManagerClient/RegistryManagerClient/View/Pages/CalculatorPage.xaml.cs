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
            this.KeyDown += Page_Reload;
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton bt = sender as RadioButton;
            if (bt.Name == "Combined")
                ViewModel.IsCombined = true;
            else ViewModel.IsCombined = false;
        }
        private void LoseFocus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ((UIElement)e.OriginalSource).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
        private void Page_Reload(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.R && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                UpdatePage();
        }
        private void UpdatePage()
        {
            
                if (ViewModel.CtrlRPressedCommand.CanExecute(null))
                {
                    ViewModel.CtrlRPressedCommand.Execute(null);
                }
            
        }
        private void Page_Reload(object sender, RoutedEventArgs e)
        {
            //if (sender is NumberBox box)
            //{
            //    (sender as NumberBox).GetBindingExpression(NumberBox.ValueProperty).UpdateSource();
            //}
            //UpdatePage();
        }

        private void AddCargoButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteCP(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteCargoPlaceCommand.Execute((sender as CargoPlaceVM));
        }
    }
}
