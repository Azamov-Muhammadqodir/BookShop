using BookShop.Domain.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Repositories
{
    public class BaseRepository
    {
        static string _path = @"..\..\..\..\BookShop.Infrastructure\Repositories\Files\createTable.txt";
        public BaseRepository()
        {
            if (!(File.ReadAllText(_path) == ""))
            {
                CreateDB();
            }
        }
        public static string conString()
        {
            string _path = @"..\..\..\..\BookShop.Infrastructure\Repositories\Files\appsetting.json";
            string cString = File.ReadAllText(_path);
            var str = JsonConvert.DeserializeObject<Logging>(cString);
            return str.logging!;
        }
        private static void CreateDB()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(conString()))
                {
                    conn.Open();
                    Console.WriteLine("SuccesFull");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string msg = conString().Replace("bookshop", "postgres");
                if (ex.Message.Contains("does not exist"))
                {
                    using (NpgsqlConnection conn = new NpgsqlConnection(msg))
                    {
                        conn.Open();
                        string cmdQuery = "create database bookshop";
                        NpgsqlCommand cmd = new(cmdQuery, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    CreateTable();
                }
            }
        }
        private static void CreateTable()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(conString()))
                {
                    connection.Open();
                    string cmdTable = File.ReadAllText(_path);
                    File.WriteAllText(_path, "");
                    NpgsqlCommand command = new NpgsqlCommand(cmdTable, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    public class Logging
    {
        public string logging { get; set; }
    }

}


