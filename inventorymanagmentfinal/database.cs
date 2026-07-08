using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

public static class DatabaseHelper
{
    private static string connectionString = "Server=127.0.0.1; Port=3306; Password=12345678; Database=da_perfumes; User=dante;";


    public static MySqlConnection GetConnection()
    {
        MySqlConnection conn = new MySqlConnection(connectionString);
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Database Connection Error: " + ex.Message);
        }
        return conn;
    }
}
