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
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton bt = sender as RadioButton;
            if (bt.Name == "Combined")
                ViewModel.IsCombined = true;
            else ViewModel.IsCombined = false;
        }
    }
}
