using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_hrms.Commands;
using wpf_hrms.Services;


namespace wpf_hrms.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
     

        private String _username;
        public  String Username
        {
            get { return _username; }
            set { _username = value; 
                OnPropertyChanged(nameof(Username));
            }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand Login { get; set; }

        public MainWindowViewModel()
        {
            Login = new Retrieve(this);

        }
    }
}
