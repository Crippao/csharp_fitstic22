using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class HelperPatatine : Helper
    {
        public bool CreateTable()
        {
            string? create = @"CREATE TABLE if not exists Patatine (
                                        ID    INTEGER,
                                        DIMENSIONE STRING,
                                        NUM_PATATINE INTEGER,
                                        ID_ORDINE INTEGER,                                                                                
                                        PRIMARY KEY(ID AUTOINCREMENT),
                                            FOREIGN KEY (ID_ORDINE) REFERENCES ORDINE (ID)                                            
                                        );";

            return EseguiNonQuery(create);
        }

        public Patatine? Get(long id)
        {
            string selectSql = $"SELECT * FROM Patatine WHERE id = {id};";

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
                                long id_pata = reader.GetInt64(0);
                                string dim_pata = reader.GetString(1);
                                int num_pata = reader.GetInt32(2);
                                long id_ordine = reader.GetInt64(3);

                                if (id_pata != 0)
                                {
                                    return new Patatine(id_pata, dim_pata, num_pata, id_ordine);
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

        public bool Insert(Patatine p, long id_ordine)
        {
            long id;
            string? insert = $"INSERT INTO Patatine (DIMENSIONE, NUM_PATATINE, ID_ORDINE) VALUES ('{p.Dimensione}', {p.Numero_Patatine}, {id_ordine} ); ";

            return EseguiScalare(insert, out id);
        }

        public bool Update(Patatine p, long id_ordine, long id)
        {
            
            string? update = @$"UPDATE Patatine SET Dimensione = '{p.Dimensione}',
                                                SET NUM_PATATINE = {p.Numero_Patatine},
                                                SET ID_ORDINE = {id_ordine}
                                                WHERE ID = {id}";

            return EseguiNonQuery(update);
        }

        public bool Delete(int id)
        {
            string? deleteOneSQL = $"DELETE FROM Patatine WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public List<Patatine> GetAll()
        {
            List<Patatine> listaPatatine = new List<Patatine>();

            string selectSql = $"SELECT * FROM Patatine;";

            SQLiteDataReader? reader;

            if (EseguiReader(selectSql, out reader))
            {
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            long id_pata = reader.GetInt64(0);
                            string dim_pata = reader.GetString(1);
                            int num_pata = reader.GetInt32(2);
                            long id_ordine = reader.GetInt64(3);

                            if (id_pata != 0)
                            {
                                listaPatatine.Add(new Patatine(id_pata, dim_pata, num_pata, id_ordine));
                            }
                        }
                    }

                }

            }
            return listaPatatine;
        }
    }
}
