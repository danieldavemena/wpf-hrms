using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using wpf_hrms.Models;
using wpf_hrms.Services;
using wpf_hrms.Views;

namespace wpf_hrms.Commands
{
    internal class ModifyCredentials : CommandBase
    {

        MySqlCommand comm;
        DbConnect db;
        Employees _employees;
        CredentialsPage _credentialsPage;
        EditCredentials _editCredentials;
        GetCredentials getCredentials;

        public ModifyCredentials(Employees employees, CredentialsPage credentialsPage, EditCredentials editCredentials)
        {

            _editCredentials = editCredentials;
            _credentialsPage = credentialsPage;
            db = new DbConnect();
            _employees = employees;
            getCredentials = new GetCredentials(_credentialsPage);

        }

        public override void Execute(object? parameter)
        {            
            Update();
        }

        public void Update() {

            string query = "UPDATE `employee_info` SET `name`= '" + _employees.Name + "', `age`= " + _employees.Age + ", `address`= '" + _employees.Address + "', `phone`= '" + _employees.Phone + "', `email`= '" + _employees.Email + "'  WHERE  `id`= '" + _employees.ID + "'";
            comm = new MySqlCommand(query, db.conn);
            
            try
            {
                db.conn.Open();
                comm.ExecuteNonQuery();
                db.conn.Close();

                _credentialsPage.credsContainer.Children.Clear();
                getCredentials.AddField();
                
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            _editCredentials.Close();

        }
    }
}
