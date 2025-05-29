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
using wpf_hrms.ViewModels;

namespace wpf_hrms.Views
{
    /// <summary>
    /// Interaction logic for CredentialsPage.xaml
    /// </summary>
    public partial class CredentialsPage : UserControl
    {

        CredentialsPageViewModel dm;

        public CredentialsPage()
        {

            dm = new CredentialsPageViewModel(this);

            InitializeComponent();

            DataContext = new CredentialsPageViewModel(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dm.DisplayEmployees.Execute(null);
        }
    }
}
