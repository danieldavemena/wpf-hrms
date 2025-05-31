using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpf_hrms.Models;
using wpf_hrms.Services;
using wpf_hrms.ViewModels;

namespace wpf_hrms.Commands
{
    internal class SetVacancies : CommandBase
    {

        private DbConnect db;
        private MySqlCommand comm; 
        private Vacancies _vacancies;
        private VacanciesPageViewModel _vacanciesPageViewModel;

        public SetVacancies(Vacancies vacancies, VacanciesPageViewModel vacanciesPageViewModel) {
            db = new DbConnect();
            _vacanciesPageViewModel = vacanciesPageViewModel;
            _vacancies = vacancies;
        }

        public override void Execute(object? parameter)
        {

            AddRole();
        }

        private void AddRole()
        {
            if (_vacancies.RoleName == null) {
            } else
            {
                string query = "Select * from roles where role='" + _vacancies.RoleName + "'";
                string insert = "insert into `roles` (`role`, `vacancies`) values ('" + _vacancies.RoleName + "', '" + _vacancies.Vacant + "')";  
                comm = new MySqlCommand(query, db.conn);
                MySqlDataReader reader;

                try
                {
                    db.conn.Open();
                    reader = comm.ExecuteReader();


                    if (reader.HasRows)
                    {
                        db.conn.Close();
                        throw new Exception();
                    }
                    db.conn.Close();

                    db.conn.Open();
                    comm = new MySqlCommand(insert, db.conn);
                    comm.ExecuteNonQuery();
                    db.conn.Close();

                    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                _vacanciesPageViewModel.FetchVacancies.Execute(null);
            }
        }
    }
}
