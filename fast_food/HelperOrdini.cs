using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace fast_food
{
    internal class HelperOrdini
    {       
        SQLiteConnection sqlite_conn;
        string connectionString = "Data Source = fast_food.db; Version = 3; New = True; Compress = True;";

        public bool CreateConnection()
        {            
            // Create a new database connection:
            this.sqlite_conn = new SQLiteConnection(connectionString);
            // Try to open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificata un'eccezione: {ex.Message}");
                return false;
            }
            return true;
        }

        public void CreateTable()
        {
            SQLiteCommand sqlite_cmd;
            string? createTable = @"CREATE TABLE if not exists Ordine (
                                    ID    INTEGER,
                                    DataOra    TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                    PRIMARY KEY(ID AUTOINCREMENT)
                                    );";
            
            sqlite_cmd = sqlite_conn.CreateCommand();            
            sqlite_cmd.CommandText = createTable;
            sqlite_cmd.ExecuteNonQuery();
                      
        }

        public void InserisciOrdine(string nameTable)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = $"INSERT INTO {nameTable} (Col1, Col2) VALUES('Test Text ', 1); ";
            sqlite_cmd.ExecuteNonQuery();
            
        }       
    }
}
