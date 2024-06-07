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
            SaveNotification.Visibility = Visibility.Collapsed;
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
            var page = PageService.Instance.GetPage<HomePage>();
            page.RegList.SelectedIndex = -1;
            MainFrame.Navigate(page);
            ViewModel.CalcDocVisibility = Visibility.Hidden;
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveNotification.Visibility = Visibility.Visible;

            PageService.Instance.GetPage<CalculatorPage>().ViewModel.SaveCargoCommand.Execute(null);
          
            SaveNotification.Visibility = Visibility.Collapsed;
            var uiMessageBox = new Wpf.Ui.Controls.MessageBox
            {
                Title = "Изменения сохранены"
            };

            _ = await uiMessageBox.ShowDialogAsync();
        }
    }
}