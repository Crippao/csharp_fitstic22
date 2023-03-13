using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Helper
    {
        SQLiteConnection sqlite_conn;
        string? connectionString = "Data Source = fast_food.db; Version = 3; New = True; Compress = True;";

        public string? ConectionString
        {
            get { return connectionString; }
            private set { connectionString = value; }
        }

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

        protected bool EseguiReader(string istruzioni, out SQLiteDataReader? dbReader)
        {
            SQLiteCommand sqlite_cmd;
            dbReader = null;
            if (sqlite_conn.State == System.Data.ConnectionState.Open)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = istruzioni;

                try
                {
                    dbReader = sqlite_cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Connessione al db non riuscita");
                return false;
            }
        }

        protected bool EseguiNonQuery(string istruzioni)
        {
            SQLiteCommand sqlite_cmd;

            if (sqlite_conn.State == System.Data.ConnectionState.Open)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = istruzioni;

                try
                {
                    if (sqlite_cmd.ExecuteNonQuery() == 0)
                    {
                        Console.WriteLine("Sono state modificate/eliminate 0 righe");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Connessione al db non riuscita");
                return false;
            }
        }

        protected bool EseguiScalare(string istruzioni, out long lastID)
        {
            SQLiteCommand sqlite_cmd;
            lastID = -1;

            if (sqlite_conn.State == System.Data.ConnectionState.Open)
            {
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = istruzioni;

                try
                {
                    object r = sqlite_cmd.ExecuteScalar();
                    lastID = (long)r;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore: {ex.Message}");
                    return false;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Connessione al db non riuscita");
                return false;
            }
        }
    }
}
