using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace wpf_hrms.Services
{
    internal class DbConnect
    {

        private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=hrms;";
        public MySqlConnection conn;

        public DbConnect()
        {
            conn = new MySqlConnection(connectionString);
        }
    }
}
