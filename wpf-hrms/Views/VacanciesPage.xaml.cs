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
    /// Interaction logic for VacanciesPage.xaml
    /// </summary>
    public partial class VacanciesPage : UserControl
    {
        VacanciesPageViewModel vm;


        public VacanciesPage()
        {
            InitializeComponent();
            vm = new VacanciesPageViewModel(this);
            DataContext = vm;
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm.FetchVacancies.Execute(null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddVacancies addVac = new AddVacancies(this, vm);
            addVac.Show();
        }
    }
}
