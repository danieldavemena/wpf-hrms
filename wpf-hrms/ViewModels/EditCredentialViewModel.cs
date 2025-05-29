using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_hrms.Commands;
using wpf_hrms.Models;
using wpf_hrms.Views;

namespace wpf_hrms.ViewModels
{
    internal class EditCredentialViewModel : ViewModelBase
    {

        CredentialsPage _credentialsPage;
        EditCredentials _editCredentials;
        private Employees _employees;
        public Employees Employees
        {
            get { return _employees; }
            set { _employees = value; 
                OnPropertyChanged(nameof(Employees));
            } 
        }

        public ICommand SaveEdit { get; set; }

        public EditCredentialViewModel(Employees employees, CredentialsPage credentialsPage, EditCredentials editCredentials)
        {

            _editCredentials = editCredentials;
            _credentialsPage = credentialsPage;

            _employees = employees;
            SaveEdit = new ModifyCredentials(_employees, _credentialsPage, _editCredentials);

        }


    }
}
