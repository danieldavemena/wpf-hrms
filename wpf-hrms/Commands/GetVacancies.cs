using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using wpf_hrms.Models;
using wpf_hrms.Services;
using wpf_hrms.Views;

namespace wpf_hrms.Commands
{
    class GetVacancies : CommandBase
    {

        DbConnect db;
        MySqlCommand comm;

        Roles _rolemodel;
        VacanciesPage _vacanciesPage;

        public GetVacancies(Roles rolemodel, VacanciesPage vacanciesPage) {
            _rolemodel = rolemodel;
            _vacanciesPage = vacanciesPage;
            db = new DbConnect();
        }

        public override void Execute(object? parameter)
        {
            FetchRoles();
        }

        public void FetchRoles()
        {
            _vacanciesPage.rolesDisplay.Children.Clear();

            string query = "Select * from roles where 1";
            comm = new MySqlCommand(query, db.conn);
            MySqlDataReader reader;


            Color bdColor = (Color)ColorConverter.ConvertFromString("#f7ecfc");
            Color headingColor = (Color)ColorConverter.ConvertFromString("#5955B3");


            DropShadowEffect shadow = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = 270,
                BlurRadius = 20,
                ShadowDepth = 2,
                Opacity = 0.2
            };

            try
            {
                db.conn.Open();
                reader = comm.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                       

                        string _role = reader.GetString(reader.GetOrdinal("role"));
                        int _vacancies = reader.GetInt32(reader.GetOrdinal("vacancies"));
                        int _occupied = reader.GetInt32(reader.GetOrdinal("occupied"));

                        Border bd = new Border
                        {
                            Background = new SolidColorBrush(bdColor),
                            Effect = shadow,
                            Height = 290,
                            Width = 290,
                            Margin = new Thickness(0, 0, 20, 20),
                            Padding = new Thickness(20),    
                            CornerRadius = new CornerRadius(20)
                        };

                        StackPanel sp = new StackPanel();

                        TextBlock txRole = new TextBlock
                        {
                            FontSize = 24,
                            Foreground = new SolidColorBrush(headingColor),
                            FontWeight = FontWeights.Bold,
                            Text = _role
                        };

                        TextBlock txVacancies = new TextBlock
                        {
                            FontSize = 20,
                            Foreground = new SolidColorBrush(headingColor),
                            FontWeight = FontWeights.SemiBold,
                            Text = "Vacancies: " + _vacancies.ToString(),
                            Opacity = 0.8
                        };
                        TextBlock txOccupied = new TextBlock
                        {
                            FontSize = 20,
                            Foreground = new SolidColorBrush(headingColor),
                            FontWeight = FontWeights.SemiBold,
                            Text = "Occupied: " + _occupied.ToString(),
                            Opacity = 0.8
                        };

                        sp.Children.Add(txRole);
                        sp.Children.Add(txVacancies);
                        sp.Children.Add(txOccupied);
                        bd.Child = sp; 
                        _vacanciesPage.rolesDisplay.Children.Add(bd);
                    }
                }

                db.conn.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
