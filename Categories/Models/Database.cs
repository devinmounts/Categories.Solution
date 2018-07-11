using System;
using MySql.Data.MySqlClient;
using Categories;

namespace Categories.Models
{
    public static class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
