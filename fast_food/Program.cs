using System.Text;

namespace fast_food
{
    internal class Program
    {
        static List<Articolo> articoloList = new List<Articolo>();

        static void Main(string[] args)
        {
            Helper helper = new Helper();
            HelperPatatine helperPata = new HelperPatatine();
            HelperOrdine helperOrdine = new HelperOrdine();
            long idIns;

            helper.CreateConnection();

            Ordina();



            //if (helper.CreateConnection())
            //{
            //    string? comandosql;
            //    int ID;                

            //helper.CreateTable();
            //Console.WriteLine("Tabella creata");

            //comandosql = SceltaComandoOrdine();

            //switch (comandosql)
            //{
            //    case "1":
            //        if (helperOrdine.Insert(DateTime.Now, out idIns))
            //        { Console.WriteLine($"Ordine {idIns} Inserito"); }
            //        else { Console.WriteLine($"Inserimento ordine {idIns} non riuscito"); };
            //        break;

            //    case "2":
            //        ID = SceltaID();
            //        if (helperOrdine.Update(DateTime.Now, ID))
            //        { Console.WriteLine($"Ordine {ID} modificato"); }
            //        else { Console.WriteLine($"Modifica ordine {ID} non riuscita"); };
            //        break;

            //    case "3":
            //        ID = SceltaID();
            //        if (helperOrdine.Delete(ID))
            //        { Console.WriteLine($"Ordine {ID} Cancellato"); }
            //        else { Console.WriteLine($"Eliminazione ordine {ID} non riuscita"); };
            //        break;

            //    case "4":
            //        long id = SceltaID();
            //        Ordine? o = helperOrdine.Get(id);
            //        if (o != null) { Console.WriteLine(o); }
            //        else { Console.WriteLine($"Ordine {id} non trovato"); };
            //        break;

            //    case "5":
            //        List<Ordine> listaOrdini = helperOrdine.GetAll();
            //        foreach (Ordine ordine in listaOrdini)
            //        {
            //            Console.WriteLine(ordine);
            //        }
            //        break;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Errore di connessione al db");
            //}



        }

        static string SceltaComandoPatatine()
        {
            string? temp;

            do
            {
                Console.WriteLine("Vuoi inserire, modificare o cancellare una patatina?");
                Console.WriteLine("1) Per inserire un nuova patatina");
                Console.WriteLine("2) Per modificare una patatina esistente");
                Console.WriteLine("3) Per eliminare una patatina esistente");
                Console.WriteLine("4) Per consultare una patatina esistente");
                Console.WriteLine("5) Per consultare tutti le patatine esistenti");
                temp = Console.ReadLine();

            } while (!int.TryParse(temp, out int v) || (temp == "1" && temp == "2" && temp == "3" && temp == "4" && temp == "5"));

            return temp;
        }

        static string SceltaComandoOrdine()
        {
            string? temp;

            do
            {
                Console.WriteLine("Vuoi inserire, modificare o cancellare un ordine?");
                Console.WriteLine("1) Per inserire un nuovo ordine");
                Console.WriteLine("2) Per modificare un ordine esistente");
                Console.WriteLine("3) Per eliminare un ordine esistente");
                Console.WriteLine("4) Per consultare un ordine esistente");
                Console.WriteLine("5) Per consultare tutti gli ordini esistenti");
                temp = Console.ReadLine();

            } while (!int.TryParse(temp, out int v) || (temp == "1" && temp == "2" && temp == "3" && temp == "4" && temp == "5"));

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

        static Ordine Ordina()
        {
            string? temp = "";
            bool temp1;
            Articolo a;
            Ordine ordine = new Ordine();

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
                        ordine.RiepilogoOrdini();
                        continue;

                    case "0":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Grazie per aver ordinato da noi! Arrivederci :D");
                        Console.ResetColor();
                        return ordine;

                    default:
                        throw new Exception($"Valore {temp} inserito non corretto");
                }


                do
                {
                    ordine.AggiungiArticolo(a);
                    temp1 = a.ChiediConferma("Vuoi ordinarne un'altro");
                } while (temp1);




            } return ordine;
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

        

        

    }
}