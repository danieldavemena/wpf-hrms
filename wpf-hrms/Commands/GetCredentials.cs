using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using wpf_hrms.Models;
using wpf_hrms.Services;
using wpf_hrms.ViewModels;
using wpf_hrms.Views;

namespace wpf_hrms.Commands
{
    internal class GetCredentials : CommandBase
    {
        MySqlCommand comm;
        DbConnect db;
        private readonly CredentialsPage _credentialsPage;
   

        public GetCredentials(CredentialsPage credentialsPage)
        {
            _credentialsPage = credentialsPage;

            db = new DbConnect();
        }

        public override void Execute(object? parameter)
        {
            //MessageBox.Show("Test");


            AddField();

        }

        public void AddField()
        {


            Color bdColor = (Color)ColorConverter.ConvertFromString("#f7ecfc");


            DropShadowEffect shadow = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = 270,
                BlurRadius = 20,
                ShadowDepth = 2,
                Opacity = 0.2
            };

           

            string query = "Select * from employee_info where 1";
            comm = new MySqlCommand(query, db.conn);
            MySqlDataReader reader;

            try
            {
                db.conn.Open();
                reader = comm.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string _id = reader.GetString(reader.GetOrdinal("id"));
                        string _employeeName = reader.GetString(reader.GetOrdinal("name"));
                        int _age = reader.GetInt32(reader.GetOrdinal("age"));
                        string _address = reader.GetString(reader.GetOrdinal("address"));
                        string _email = reader.GetString(reader.GetOrdinal("email"));
                        string _phone = reader.GetString(reader.GetOrdinal("phone"));

                        Border bd = new Border
                        {
                            Background = new SolidColorBrush(bdColor),
                            Effect = shadow,
                            Height = 60,
                            Margin = new Thickness(0,0,0,15),
                            CornerRadius = new CornerRadius(20)
                        };

                        Grid gd = new Grid();

                        gd.ColumnDefinitions.Add(new ColumnDefinition());
                        gd.ColumnDefinitions.Add(new ColumnDefinition());
                        gd.ColumnDefinitions.Add(new ColumnDefinition());
                        gd.ColumnDefinitions.Add(new ColumnDefinition());
                        gd.ColumnDefinitions.Add(new ColumnDefinition());
                        gd.ColumnDefinitions.Add(new ColumnDefinition());

                        bd.Child = gd;

                        Label id = new Label
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 15,
                            Content = reader.GetString("id")
                        };
                        Grid.SetColumn(id, 0);
                        gd.Children.Add(id);

                        Label name = new Label
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 15,
                            Content = reader.GetString("name")
                        };
                        Grid.SetColumn(name, 1);
                        gd.Children.Add(name);

                        Label age = new Label
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 15,
                            Content = reader.GetInt32("age")
                        };
                        Grid.SetColumn(age, 2);
                        gd.Children.Add(age);

                        Label phone = new Label
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 15,
                            Content = reader.GetString("phone")
                        };
                        Grid.SetColumn(phone, 3);
                        gd.Children.Add(phone);

                        Label email = new Label
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            FontSize = 15,
                            Content = reader.GetString("email")
                        };
                        Grid.SetColumn(email, 4);
                        gd.Children.Add(email);


                        DockPanel dp = new DockPanel
                        {
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center
                        };

                        Button edit = new Button
                        {
                            Background = new SolidColorBrush(Colors.Blue),
                            Content = "Edit",
                            Height = 50,
                            Width = 50
                        };

                        Button delete = new Button
                        {
                            Background = new SolidColorBrush(Colors.Blue),
                            Content = "Delete",
                            Height = 50,
                            Width = 50
                        };


                        edit.Click += (object sender, RoutedEventArgs e) =>
                        {

                            var editCredsWindow = new EditCredentials();
                            Employees employees = new Employees
                            {
                                ID = _id,
                                Name = _employeeName,
                                Age = _age,
                                Address = _address,
                                Email = _email,
                                Phone = _phone
                            };


                            var editCredentialViewModel = new EditCredentialViewModel(employees, _credentialsPage, editCredsWindow);
                            editCredentialViewModel.Employees = employees;

                            editCredsWindow.DataContext = editCredentialViewModel;

                            editCredsWindow.ShowDialog();

                        };
                        //delete.Click += _dashboardModel.delete_Click;

                        dp.Children.Add(edit);
                        dp.Children.Add(delete);

                        Grid.SetColumn(dp, 5);
                        gd.Children.Add(dp);
                        _credentialsPage.credsContainer.Children.Add(bd);


                    }
                }
                else
                {
                    MessageBox.Show("No employee");
                }

                db.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
