using RegistryManagerClient.Services;
using RegistryManagerClient.View.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace RegistryManagerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModels.MainWindowViewModel ViewModel { get; }
        public MainWindow()
        {
            ViewModel = new ViewModels.MainWindowViewModel();
            DataContext = this;
            InitializeComponent();
            MainFrame.Navigate(PageService.Instance.GetPage<HomePage>());
        }

        private void CalculationsNav_Click(object sender, RoutedEventArgs e)
        {
            CalcAndDocParentPage page = PageService.Instance.GetPage<CalcAndDocParentPage>();
            page.WorkAreaFrame.Navigate(PageService.Instance.GetPage<CalculatorPage>());
        }

        private void DocumentsNav_Click(object sender, RoutedEventArgs e)
        {
            CalcAndDocParentPage page = PageService.Instance.GetPage<CalcAndDocParentPage>();
            page.WorkAreaFrame.Navigate(PageService.Instance.GetPage<DocumentsGenPage>());
        }

        private void HomeNav_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(PageService.Instance.GetPage<HomePage>());
            ViewModel.CalcDocVisibility = Visibility.Hidden;
        }
    }
}