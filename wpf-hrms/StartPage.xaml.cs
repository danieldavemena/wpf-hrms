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
using System.Windows.Shapes;
using wpf_hrms.ViewModels;
using wpf_hrms.Views;

namespace wpf_hrms
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        CredentialsPage credsPage = new CredentialsPage();
        VacanciesPage vacanciesPage = new VacanciesPage();

        public StartPage()
        {

            InitializeComponent();
            Page.Content = new CredentialsPageViewModel(credsPage);
        }

        private void DockPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Page.Content = new Dashboard();
        }

        private void DockPanel_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Page.Content = new CredentialsPageViewModel(credsPage);
        }

        private void DockPanel_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            Page.Content = new VacanciesPageViewModel(vacanciesPage);
        }
    }
}
