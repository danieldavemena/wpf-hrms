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
using wpf_hrms.Models;
using wpf_hrms.ViewModels;

namespace wpf_hrms.Views
{
    /// <summary>
    /// Interaction logic for AddVacancies.xaml
    /// </summary>
    public partial class AddVacancies : Window
    {
        AddVacanciesViewModel vm;
        VacanciesPage _vacanciesPage;
        Vacancies vacanciesModel = new Vacancies();
        VacanciesPageViewModel _vacanciesPageViewModel;

        public AddVacancies(VacanciesPage vacanciesPage, VacanciesPageViewModel vacanciesPageViewModel)
        {
            InitializeComponent();
            _vacanciesPage = vacanciesPage;
            _vacanciesPageViewModel = vacanciesPageViewModel;
            vm = new AddVacanciesViewModel(this, _vacanciesPage, vacanciesModel, _vacanciesPageViewModel);
            DataContext = vm;
            _vacanciesPageViewModel = vacanciesPageViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
