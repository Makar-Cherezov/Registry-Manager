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
    /// Логика взаимодействия для LabelledInfoLine.xaml
    /// </summary>
    public partial class LabelledInfoLine : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty =
           DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(LabelledInfoLine), new PropertyMetadata(default(string)));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty ContentTextProperty =
            DependencyProperty.Register("ContentText", typeof(string), typeof(LabelledInfoLine), new PropertyMetadata(default(string)));

        public string ContentText
        {
            get { return (string)GetValue(ContentTextProperty); }
            set { SetValue(ContentTextProperty, value); }
        }

        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(LabelledInfoLine), new PropertyMetadata(default(string)));

        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        public LabelledInfoLine()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
