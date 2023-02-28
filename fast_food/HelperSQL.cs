using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace fast_food
{
    internal class HelperSQL
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

        public bool EseguiComando(string istruzioni) 
        {
            SQLiteCommand sqlite_cmd;

            if (sqlite_conn.State == System.Data.ConnectionState.Open)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = istruzioni;

                try
                {
                    sqlite_cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    return false;
                }

                return true;
            }
            else { return false; }
        }

        public bool CreateTable()
        {
            SQLiteCommand sqlite_cmd;
            string? createTableOrdini = @"CREATE TABLE if not exists Ordine (
                                        ID    INTEGER,
                                        DataOra    TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                        PRIMARY KEY(ID AUTOINCREMENT)
                                        );";
            
            string? createTableArticoli = @"CREATE TABLE if not exists Articoli (
                                        ID    INTEGER,
                                        IdOrdine INTEGER,
                                        IdMenu INTEGER,                                        
                                        PRIMARY KEY(ID AUTOINCREMENT),
                                        FOREIGN KEY (IdOrdine)
                                            REFERENCES Ordine (ID)
                                        );";

           return EseguiComando(createTableArticoli);           
        }

        public bool InserisciOrdine(string nameTable)
        {
            SQLiteCommand sqlite_cmd;
            string? insert = $"INSERT INTO {nameTable} (Col1, Col2) VALUES('Test Text ', 1); ";

            return EseguiComando(insert);
            
        }       
    }
}
