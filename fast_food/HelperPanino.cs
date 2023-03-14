using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class HelperPanino : HelperArticolo
    {
        public override bool CreateTable()
        {
            base.CreateTable();
            string? createTable = @"CREATE TABLE if not exists Panini (
                                        ID    INTEGER,
                                        PANE INTEGER,
                                        CARNE INTEGER,
                                        FORMAGGIO INTEGER,
                                        SALSA INTEGER,
                                        ID_ORDER INTEGER,
                                        PRIMARY KEY(ID)
                                            FOREIGN KEY (ID) REFERENCES Articoli (ID),
                                            FOREIGN KEY (ID_ORDER) REFERENCES Ordini (ID)
                                        );";

            return EseguiNonQuery(createTable);
        }

        public bool Insert(Panino p, long id_ordine)
        {
            long pk = InsertArticolo(id_ordine);
            long id_panino;
            string? insert = $"INSERT INTO Panini (ID, PANE, CARNE, FORMAGGIO, SALSA) VALUES ({pk},'{p.Pane}', {p.Carne}, {p.Formaggio}, {p.Salsa}, {id_ordine}) RETURNING *; ";

            return EseguiScalare(insert, out id_panino);
        }

        public bool Delete(int id)
        {
            string? deleteOneSQL = $"DELETE FROM Panini WHERE ID = {id}";

            return EseguiNonQuery(deleteOneSQL);
        }

        public bool Update(Panino p, int id)
        {            
            string? updateSQL = $"UPDATE Panini SET PANE = '{p.Pane}', CARNE = {p.Carne}, FORMAGGIO = {p.Formaggio}, SALSA = {p.Salsa} WHERE ID = {id}";

            return EseguiNonQuery(updateSQL);
        }

        public Panino? Get(long id)
        {
            string selectSql = $"SELECT * FROM Panini WHERE id = {id};";

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
                                long idPanino = reader.GetInt64(0);
                                bool pane = reader.GetBoolean(1);
                                bool carne = reader.GetBoolean(2);
                                bool formaggio = reader.GetBoolean(3);
                                bool salsa = reader.GetBoolean(4);

                                if (idPanino != 0)
                                {
                                    return new Panino(pane, carne, formaggio, salsa);
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

        public List<Panino> GetAll()
        {
            List<Panino> listaPanini = new List<Panino>();

            string selectSql = $"SELECT * FROM Panini;";

            SQLiteDataReader? reader;

            if (EseguiReader(selectSql, out reader))
            {
                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            long idPanino = reader.GetInt64(0);
                            bool pane = reader.GetBoolean(1);
                            bool carne = reader.GetBoolean(2);
                            bool formaggio = reader.GetBoolean(3);
                            bool salsa = reader.GetBoolean(4);

                            if (idPanino != 0)
                            {
                                listaPanini.Add(new Panino(idPanino, pane, carne, formaggio, salsa));
                            }
                        }
                    }

                }

            }
            return listaPanini;
        }
    }
}
