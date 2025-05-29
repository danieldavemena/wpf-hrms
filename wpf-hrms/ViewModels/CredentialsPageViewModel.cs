using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_hrms.Commands;
using wpf_hrms.Views;

namespace wpf_hrms.ViewModels
{
    internal class CredentialsPageViewModel : ViewModelBase
    {
        public CredentialsPage _credentialsPage;


        public ICommand DisplayEmployees { get; set; }

        public CredentialsPageViewModel(CredentialsPage credentialsPage) {

            _credentialsPage = credentialsPage;

            DisplayEmployees = new GetCredentials(_credentialsPage);
        }

    }
}
