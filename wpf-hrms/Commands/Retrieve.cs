using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using wpf_hrms.Services;
using MySql.Data;

using wpf_hrms.ViewModels;

namespace wpf_hrms.Commands
{
    internal class Retrieve : CommandBase
    {
        DbConnect db;
        MySqlCommand comm;

        MainWindowViewModel _mainView;

        public Retrieve(MainWindowViewModel MainView)
        {
            _mainView = MainView;
            db = new DbConnect();
        }

        public override void Execute(object? parameter)
        {
            string query = "Select * from admin where `username`='" + _mainView.Username + "' AND `password`='" + _mainView.Password + "'";
            comm = new MySqlCommand(query, db.conn);
            MySqlDataReader reader;

            try {
                db.conn.Open();
                reader = comm.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //MessageBox.Show(reader.GetString("password"));



                        StartPage startPage = new StartPage();
                        startPage.Show();

                        App.Current.Windows[0].Close();
                    }
                }
                else
                {
                    MessageBox.Show("No such user. Check if credentials are correct.");
                }

                db.conn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
