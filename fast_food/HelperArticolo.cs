using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class HelperArticolo : Helper
    {
        public virtual bool CreateTable()
        {
            string? createTable = @"CREATE TABLE if not exists Articolo (
                                        ID    INTEGER,
                                        ID_ORDER INTEGER,
                                        PRIMARY KEY(ID AUTOINCREMENT),
                                              FOREIGN KEY (ID_ORDER) REFERENCES Ordine (ID)
                                        );";

            return EseguiNonQuery(createTable);
        }

        public long InsertArticolo(long id_ordine)
        {
            long id;
            string? insert = $"INSERT INTO Articolo (ID_ORDER) VALUES ({id_ordine}) RETURNING *;";

            EseguiScalare(insert, out id);
            return id;
            
        }

        //public Ordine? Get(long id)
        //{
        //    string selectSql = $"SELECT * FROM Articolo WHERE id = {id};";

        //    SQLiteDataReader? reader;

        //    if (EseguiReader(selectSql, out reader))
        //    {
        //        if (EseguiReader(selectSql, out reader))
        //        {
        //            if (reader == null)
        //            {
        //                return null;
        //            }
        //            else
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        long id_Art = reader.GetInt64(0);
        //                        string type = reader.GetString(1);
        //                        string description = reader.GetString(2);
        //                        long id_order = reader.GetInt64(3);


        //                        if (id_Art != 0)
        //                        {
        //                            return new Articolo();
        //                        }
        //                        else
        //                        {
        //                            return null;
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    return null;
        //                }
        //            }
        //            return null;
        //        }
        //        else
        //        {
        //            return null;
        //        }


        //    }
        //    else { return null; }
        //}
    }
}
