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
                                        PRIMARY KEY(ID)
                                            FOREIGN KEY (ID) REFERENCES Ordini (ID)
                                        );";

            return EseguiNonQuery(createTable);
        }

        public bool Insert(Panino p, long id_ordine)
        {
            long pk = InsertArticolo(id_ordine);
            long id;
            string? insert = $"INSERT INTO Panini (ID, PANE, CARNE, FORMAGGIO, SALSA) VALUES ({pk},'{p.Pane}', {p.Carne}, {p.Formaggio}, {p.Salsa}) RETURNING *; ";

            return EseguiScalare(insert, out id);
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

        public Ordine? Get(long id)
        {
            string selectSql = $"SELECT * FROM Panino WHERE id = {id};";

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


                               
                                //if (DateTime.TryParse(reader.GetString(1), out dt))
                                //{
                                //    //return new Panino(idPanino, dt);
                                //}
                                //else
                                //{
                                //    return null;
                                //}
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
    }
}
