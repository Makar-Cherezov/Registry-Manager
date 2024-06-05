using RegistryManagerClient.Services;
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

namespace RegistryManagerClient.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public ViewModels.HomePageViewModel ViewModel { get; }
        public HomePage()
        {
            ViewModel = new ViewModels.HomePageViewModel();
            DataContext = this;
            InitializeComponent();
        }

        //private void OpenRegistryButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var mainWindow = Application.Current.MainWindow as MainWindow;
        //    if (mainWindow != null)
        //    {
        //        mainWindow.MainFrame.Navigate(PageService.Instance.GetPage<CalcAndDocParentPage>());
        //        mainWindow.ViewModel.CalcDocVisibility = Visibility.Visible;
        //    }
        //}
    }
}
