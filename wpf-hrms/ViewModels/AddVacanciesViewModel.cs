using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_hrms.Commands;
using wpf_hrms.Models;
using wpf_hrms.Views;

namespace wpf_hrms.ViewModels
{
    public class AddVacanciesViewModel : ViewModelBase
    {
        private Vacancies _vacanciesModel;
        public Vacancies VacanciesModel
        {
            get { return _vacanciesModel; }
            set
            {
                _vacanciesModel = value;
                OnPropertyChanged(nameof(VacanciesModel));
            }
        }

        VacanciesPage _vacanciesPage;
        AddVacancies _addVacancies;
        VacanciesPageViewModel _vacanciesPageViewModel;

        public ICommand Add { get; set; }

        public AddVacanciesViewModel(AddVacancies addVacancies, VacanciesPage vacanciesPage, Vacancies vacanciesModel, VacanciesPageViewModel vacanciesPageViewModel) {
        
            _addVacancies = addVacancies;
            _vacanciesPage = vacanciesPage;
            _vacanciesPageViewModel = vacanciesPageViewModel;
            _vacanciesModel = vacanciesModel;

            Add = new SetVacancies(_vacanciesModel, _vacanciesPageViewModel);
        }
    }
}
