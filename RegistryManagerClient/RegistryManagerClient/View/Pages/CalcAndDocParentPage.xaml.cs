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

    public partial class CalcAndDocParentPage : Page
    {
        public ViewModels.CalcAndDocParentViewModel ViewModel { get; }
        public CalcAndDocParentPage()
        {
            long regID = PageService.Instance.GetPage<HomePage>().ViewModel.SelectedRegistry!.RegistryId;
            ViewModel = new ViewModels.CalcAndDocParentViewModel(regID);
            DataContext = this;
            InitializeComponent();
            WorkAreaFrame.Navigate(PageService.Instance.GetPage<CalculatorPage>());
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
