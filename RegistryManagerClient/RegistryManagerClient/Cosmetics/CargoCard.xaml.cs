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

namespace RegistryManagerClient.Cosmetics
{
    /// <summary>
    /// Логика взаимодействия для CargoCard.xaml
    /// </summary>
    public partial class CargoCard : UserControl
    {
        public static readonly DependencyProperty CategoryItemsProperty =
            DependencyProperty.Register("CategoryItems", typeof(List), typeof(CargoCard), new PropertyMetadata(default(List)));

        public List CategoryItems
        {
            get { return (List)GetValue(CategoryItemsProperty); }
            set { SetValue(CategoryItemsProperty, value); }
        }

        public static readonly DependencyProperty PlacesCountProperty =
            DependencyProperty.Register("PlacesCount", typeof(int), typeof(CargoCard), new PropertyMetadata(default(int)));

        public int PlacesCount
        {
            get { return (int)GetValue(PlacesCountProperty); }
            set { SetValue(PlacesCountProperty, value); }
        }

        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(float), typeof(CargoCard), new PropertyMetadata(default(float)));

        public float Weight
        {
            get { return (float)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }

        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(float), typeof(CargoCard), new PropertyMetadata(default(float)));

        public float Volume
        {
            get { return (float)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        public static readonly DependencyProperty PackageItemsProperty =
            DependencyProperty.Register("PackageItems", typeof(List), typeof(CargoCard), new PropertyMetadata(default(List)));

        public List PackageItems
        {
            get { return (List)GetValue(PackageItemsProperty); }
            set { SetValue(PackageItemsProperty, value); }
        }

        public static readonly DependencyProperty ConditionDescriptionProperty =
            DependencyProperty.Register("ConditionDescription", typeof(string), typeof(CargoCard), new PropertyMetadata(default(string)));

        public string ConditionDescription
        {
            get { return (string)GetValue(ConditionDescriptionProperty); }
            set { SetValue(ConditionDescriptionProperty, value); }
        }
        public CargoCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        
    }
}
