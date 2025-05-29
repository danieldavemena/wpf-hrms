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
    /// Interaction logic for EditCredentials.xaml
    /// </summary>
    public partial class EditCredentials : Window
    {
        Employees employees = new Employees();
        CredentialsPage credentialPage = new CredentialsPage();

        public EditCredentials()
        {
            InitializeComponent();
            DataContext = new EditCredentialViewModel(employees, credentialPage, this);
        }
    }
}
