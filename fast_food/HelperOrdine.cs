using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.VisualBasic;
using System.Reflection.PortableExecutable;

namespace fast_food
{
    internal class HelperOrdine : Helper
    {
        public bool CreateTable()
        {
            string? createTableOrdini = @"CREATE TABLE if not exists Ordine (
                                        ID    INTEGER,
                                        DataOra    TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                                        PRIMARY KEY(ID AUTOINCREMENT)
                                        );";

            return EseguiNonQuery(createTableOrdini);
        }

        public bool Insert(DateTime dataOra, out long id)
        {
            string dataStr = dataOra.ToString("yyy-MM-dd HH:mm:ss");
            string? insertSQL = $"INSERT INTO Ordine (DataOra) VALUES ('{dataStr}') RETURNING *; ";

            return EseguiScalare(insertSQL, out id);
        }

        public bool Delete(int id)
        {
            string? deleteOneSQL = $"DELETE FROM Ordine WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public bool Update(DateTime dataOra, int id)
        {
            string dataStr = dataOra.ToString("yyy-MM-dd HH:mm:ss");
            string? updateSQL = $"UPDATE Ordine SET DataOra = '{dataStr}' WHERE ID = {id}";

            return EseguiNonQuery(updateSQL);
        }

        public Ordine? Get(long id)
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

        public List<Ordine> GetAll()
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
