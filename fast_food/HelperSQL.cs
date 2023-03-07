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
        string? connectionString = "Data Source = fast_food.db; Version = 3; New = True; Compress = True;";

        public string? ConectionString
        {
            get { return connectionString; } 
            private set { connectionString = value;}
        }
        private bool EseguiNonQuery(string istruzioni)
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
                    lastID = (long)sqlite_cmd.ExecuteScalar();                    
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

        public bool CreateTable()
        {
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

            if (EseguiNonQuery(createTableOrdini))
            {
                return EseguiNonQuery(createTableArticoli);
                
            } else { return false; }
                      
        }

        public bool InserisciOrdine(out long id)
        {            
            //RETURNING * = INSERISCE LA RIGA E RESTITUISCE IL VALORE NELLA PRIMA COLONNA
            string? insertSQL = @"INSERT INTO Ordine (DataOra) 
                                  VALUES (CURRENT_TIMESTAMP)
                                  RETURNING *; ";

            return EseguiScalare(insertSQL, out id);
            
            
            
        }  
        
        public bool CancellaOrdine(int id)
        {
            string? deleteAllSQL = "DELETE * FROM Ordine";
            string? deleteOneSQL = $"DELETE FROM Ordine WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public bool ModificaOrdine(int id)
        {
            
            string? updateSQL = $"UPDATE Ordine SET DataOra = CURRENT_TIMESTAMP WHERE ID = {id}";

            return EseguiNonQuery(updateSQL);
        }
    }
}
