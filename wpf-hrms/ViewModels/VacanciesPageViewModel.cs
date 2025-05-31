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
   public class VacanciesPageViewModel : ViewModelBase
    {
        VacanciesPage _vacanciesPage;

        private Roles _roleModel;
        private Roles RoleModel
        {
            get { return _roleModel; }
            set
            {
                _roleModel = value;

                OnPropertyChanged(nameof(RoleModel));
            }
        }

        public ICommand FetchVacancies { get; set; }

        public VacanciesPageViewModel(VacanciesPage vacanciesPage)
        {

            _vacanciesPage = vacanciesPage;
            FetchVacancies = new GetVacancies(_roleModel, _vacanciesPage);
        }
    }
}
