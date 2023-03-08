namespace fast_food
{
    internal class Program
    {
        static List<Articolo> articoloList = new List<Articolo>();

        static void Main(string[] args)
        {
            HelperSQL helper = new HelperSQL();
            long idIns;

            if (helper.CreateConnection())
            {
                string? comandosql;
                int ID;

                //helper.CreateTable();
                //Console.WriteLine("Tabella creata");

                comandosql = SceltaComandoSql();
                

                switch (comandosql)
                {
                    case "1":
                        if (helper.InserisciOrdine(DateTime.Now, out idIns))
                        { Console.WriteLine($"Ordine {idIns} Inserito"); }
                        else { Console.WriteLine($"Inserimento ordine {idIns} non riuscito"); };
                        break;

                    case "2":
                        ID = SceltaID();
                        if (helper.ModificaOrdine(DateTime.Now, ID))
                        { Console.WriteLine($"Ordine {ID} modificato"); }
                        else { Console.WriteLine($"Modifica ordine {ID} non riuscita"); };
                        break;

                    case "3":
                        ID = SceltaID();
                        if (helper.CancellaOrdine(ID))
                        { Console.WriteLine($"Ordine {ID} Cancellato"); }
                        else { Console.WriteLine($"Eliminazione ordine {ID} non riuscita"); };
                        break;

                    case "4":
                        long iD = SceltaID();
                        Ordine o = helper.GetOrdine(iD);                        
                        if (o != null) { Console.WriteLine($"L'ordine {o.ID} è stato creato in data {o.DataOra}"); }
                        else { Console.WriteLine("Ordine non trovato"); };
                        break;

                }
            }
            else
            {
                Console.WriteLine("Errore di connessione al db");
            }

        }

        static string SceltaComandoSql()
        {
            string? temp;

            do
            {
                Console.WriteLine("Vuoi inserire, modificare o cancellare un ordine?");
                Console.WriteLine("1) Per inserire un nuovo ordine");
                Console.WriteLine("2) Per modificare un ordine esistente");
                Console.WriteLine("3) Per eliminare un ordine esistente");
                Console.WriteLine("4) Per consultare un ordine esistente");
                temp = Console.ReadLine();

            } while (!int.TryParse(temp, out int v) || (temp == "1" && temp == "2" && temp == "3" && temp == "4"));

            return temp;
        }

        static int SceltaID()
        {
            int ID;
            do
            {
                Console.WriteLine("Inserire l'id dell'ordine interessato: ");

            } while (!int.TryParse(Console.ReadLine(), out ID));

            return ID;
        }

        static void OldMain(string[] args)
        {
            string? temp = "";
            Articolo a;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Benvenuto al CriFoodTruck!!!");
            Console.ResetColor();

            while (temp != "0")
            {
                temp = Scelta();


                switch (temp)
                {
                    case "1":
                        a = new Menu();
                        break;

                    case "2":
                        a = new Panino();
                        break;

                    case "3":
                        a = new Bibita();
                        break;

                    case "4":
                        a = new Patatine();
                        break;

                    case "5":
                        a = new Salsa();
                        break;

                    case "9":
                        RiepilogoOrdini();
                        continue;

                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Grazie per aver ordinato da noi! Arrivederci :D");
                        Console.ResetColor();
                        return;

                    default:
                        throw new Exception($"Valore {temp} inserito non corretto");
                }

                AggiungiArticolo(a);

            }
        }

        static string Scelta()
        {
            string? temp;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Cosa vuoi ordinar?");
                Console.WriteLine("Scegli 1 per ordinare un menù;");
                Console.WriteLine("Scegli 2 per ordinare un panino;");
                Console.WriteLine("Scegli 3 per ordinare una bibita;");
                Console.WriteLine("Scegli 4 per ordinare una porzione di patatine;");
                Console.WriteLine("Scegli 5 per ordinare una salsa;");
                Console.WriteLine("Scegli 9 per riepilogo ordine;");
                Console.WriteLine("Scegli 0 per uscire");
                Console.ResetColor();
                temp = Console.ReadLine();
            } while (temp != "1" && temp != "2" && temp != "3" && temp != "4" && temp != "5" && temp != "9" && temp != "0");

            return temp;
        }

        static void AggiungiArticolo(Articolo a)
        {
            bool temp;

            do
            {
                a.Ordina();
                articoloList.Add(a);
                temp = a.ChiediConferma("Vuoi ordinarne un'altro");
            } while (temp);

        }

        static void RiepilogoOrdini()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hai ordinato {articoloList.Count} prodotti ");
            Console.ResetColor();

            foreach (Articolo a in articoloList)
            {
                Console.WriteLine($"\t{a.RiepilogoOrdine()}");
            }
        }

    }
}