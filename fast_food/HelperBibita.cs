using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class HelperBibita : HelperArticolo
    {
        public override bool CreateTable()
        {
            base.CreateTable();


            string? create = @"CREATE TABLE if not exists Bibite (
                                        ID    INTEGER,
                                        DIMENSIONE STRING,
                                        NUM_SORSI INTEGER,
                                        ID_ORDER INTEGER,
                                        PRIMARY KEY(ID),
                                            FOREIGN KEY (ID) REFERENCES Articoli (ID),
                                            FOREIGN KEY (ID_ORDER) REFERENCES Ordini (ID)                                            
                                        );";

            return EseguiNonQuery(create);
        }

        public Bibita? Get(long id)
        {
            string selectSql = $"SELECT * FROM Bibite WHERE id = {id};";

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
                                long id_bibita = reader.GetInt64(0);
                                string dim_bibita = reader.GetString(1);
                                int num_sorsi = reader.GetInt32(2);
                                long id_ordine = reader.GetInt64(3);

                                if (id_bibita != 0)
                                {
                                    return new Bibita(dim_bibita, num_sorsi);
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

        public bool Insert(Bibita b, long id_ordine)
        {
            long id_articolo;
            long id_bibita;
            long pk = InsertArticolo(id_ordine, out id_articolo);

            string? insert = $"INSERT INTO Patatine (ID, DIMENSIONE, NUM_PATATINE, ID_ORDER) VALUES ({id_articolo},'{b.Dimensione}', {b.Numero_Sorsi}, {pk}) RETURNING *; ";

            return EseguiScalare(insert, out id_bibita);
        }

        public bool Update(Bibita b, long id_ordine, long id)
        {

            string? update = @$"UPDATE Bibite SET Dimensione = '{b.Dimensione}',
                                                SET NUM_PATATINE = {b.Numero_Sorsi},
                                                SET ID_ORDINE = {id_ordine}
                                                WHERE ID = {id}";

            return EseguiNonQuery(update);
        }

        public bool Delete(int id)
        {
            string? deleteOneSQL = $"DELETE FROM Bibite WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public List<Bibita> GetAll()
        {
            List<Bibita> listaBibite = new List<Bibita>();

            string selectSql = $"SELECT * FROM Bibite;";

            SQLiteDataReader? reader;

            if (EseguiReader(selectSql, out reader))
            {
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            long id_bibita = reader.GetInt64(0);
                            string dim_bibita = reader.GetString(1);
                            int num_sorsi = reader.GetInt32(2);
                            long id_ordine = reader.GetInt64(3);

                            if (id_bibita != 0)
                            {
                                listaBibite.Add(new Bibita(dim_bibita, num_sorsi));
                            }
                        }
                    }

                }

            }
            return listaBibite;
        }
    }
}
