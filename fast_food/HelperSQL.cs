using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;

namespace fast_food
{
    public class HelperSQL
    {
        SQLiteConnection sqlite_conn;
        string? connectionString = "Data Source = fast_food.db; Version = 3; New = True; Compress = True;";

        public string? ConectionString
        {
            get { return connectionString; }
            private set { connectionString = value; }
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


        protected IEnumerable<T>? ExecuteQuery<T>(string table, Func<IDataReader, T> projection /* Magia nera lascia perdere per ora*/)
        {
            //FIXME: We're vulnerable to SQLInjections
            if (sqlite_conn.State != ConnectionState.Open)
            {
                yield break;
            }

            SQLiteCommand cmd = sqlite_conn.CreateCommand();
            cmd.CommandText = @$"select * from ${table}";

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                // altra magia nera lascia stare
                yield return projection(dr);
            }

        }


        public List<Ordine> GetAllOrders()
        {

            var l = new List<Ordine>();
            if (sqlite_conn.State != ConnectionState.Open)
            {
                return l;
            }

            SQLiteCommand cmd = sqlite_conn.CreateCommand();
            cmd.CommandText = @$"select * from Ordine";

            SQLiteDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //l.Add(new Ordine(dr.GetDateTime("DataOra"), dr.GetInt32("ID")));
            }

            return l;

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

            string? createTableMenu = @"CREATE TABLE IF NOT EXISTS Menu (
                                        ID INTEGER,
                                        PRIMARY KEY (ID AUTOINCREMENT)
                                        );";


            return EseguiNonQuery(createTableMenu);


        }

        public bool InserisciOrdine(DateTime dataOra, out long id)
        {
            string dataStr = dataOra.ToString("yyy-MM-dd HH:mm:ss");
            string? insertSQL = $"INSERT INTO Ordine (DataOra) VALUES ('{dataStr}') RETURNING *; ";

            return EseguiScalare(insertSQL, out id);
        }

        public bool CancellaOrdine(int id)
        {
            string? deleteOneSQL = $"DELETE FROM Ordine WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public bool ModificaOrdine(DateTime dataOra, int id)
        {
            string dataStr = dataOra.ToString("yyy-MM-dd HH:mm:ss");
            string? updateSQL = $"UPDATE Ordine SET DataOra = '{dataStr}' WHERE ID = {id}";

            return EseguiNonQuery(updateSQL);
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

        public Ordine? GetOrdine(long id)
        {
            string selectSql = $"SELECT * FROM Ordine WHERE id = {id};";

            SQLiteDataReader? reader;

            if (EseguiReader(selectSql, out reader))
            {
                if (EseguiReader(selectSql, out reader))
                {
                    if (reader == null)
                    {
                        return null;
                    }
                    else
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                long idQUERY = reader.GetInt64(0);

                                DateTime dt;
                                if (DateTime.TryParse(reader.GetString(1), out dt))
                                {
                                    return new Ordine(idQUERY, dt);
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    return null;
                }
                else
                {
                    return null;
                }


            }
            else { return null; }
        }

        public List<Ordine> ListOrdini()
        {
            List<Ordine> listaOrdini = new List<Ordine>();

            string selectSql = $"SELECT * FROM Ordine;";

            SQLiteDataReader? reader;

            if (EseguiReader(selectSql, out reader))
            {
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            long idQUERY = reader.GetInt64(0);

                            DateTime dt;
                            if (DateTime.TryParse(reader.GetString(1), out dt))
                            {
                                listaOrdini.Add(new Ordine(idQUERY, dt));
                            }
                        }
                    }

                }

            }
            return listaOrdini;
        }
    }
}
