namespace fast_food
{
    internal class Program
    {
        static List<Articolo> articoloList = new List<Articolo>();
        
        static void Main(string[] args)
        {
            string? temp = "";
            Articolo a;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Benvenuto al CriFoodTruck!!!");
            Console.ResetColor();

            

            while ( temp != "0")
            {
                temp = Scelta();


                switch (temp)
                {
                    case "1":
                        a = new Menu();                        
                        //AggiungiMenu();
                        break;

                    case "2":
                        a = new Panino();
                        //AggiungiPanino();
                        break;

                    case "3":
                        a = new Bibita();
                        //AggiungiBibita();
                        break;

                    case "4":
                        a = new Patatine();
                        //AggiungiPatatine();
                        break;

                    case "5":
                        a = new Salsa();
                        //AggiungiSalsa();
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

        static void AggiungiMenu()
        {
            Menu menu;
            bool temp;

            do
            {
                menu = new Menu();
                menu.Ordina();
                articoloList.Add(menu);
                temp = menu.ChiediConferma("Vuoi ordinare un'altro menù?");
            } while (temp);
        }

        static void AggiungiPanino()
        {
            Panino panino;
            bool temp;

            do
            {
                panino = new Panino();
                panino.Ordina();
                articoloList.Add(panino);
                temp = panino.ChiediConferma("Vuoi ordinare un'altro panino?");
            } while (temp);

        }

        static void AggiungiBibita()
        {
            Bibita bibita;
            bool temp;

            do
            {
                bibita = new Bibita();
                bibita.Ordina();
                articoloList.Add(bibita);
                temp = bibita.ChiediConferma("Vuoi ordinare un'altra bibita?");
            } while (temp);
        }

        static void AggiungiPatatine()
        {
            Patatine patatine;
            bool temp;

            do
            {
                patatine = new Patatine();
                patatine.Ordina();
                articoloList.Add(patatine);
                temp = patatine.ChiediConferma("Vuoi ordinare un'altra porzione di patatine?");
            } while (temp);
        }

        static void AggiungiSalsa()
        {
            Salsa salsa;
            bool temp;

            do
            {
                salsa = new Salsa();
                salsa.Ordina();
                articoloList.Add(salsa);
                temp = salsa.ChiediConferma("Vuoi ordinare un'altra salsa?");
            } while (temp);
        }

        static void RiepilogoOrdini()
        {
            //foreground color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hai ordinato {articoloList.Count} prodotti ");
            Console.ResetColor();

            foreach ( Articolo a in articoloList)
            {
                Console.WriteLine($"\t{a.RiepilogoOrdine()}");
            }

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Hai ordinato {articoloList.Count} panini ");
            //Console.ResetColor();

            //foreach (Panino p in paninoList)
            //{
            //    Console.WriteLine($"\t{p.RiepilogoOrdine()}");
            //}

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Hai ordinato {bibitaList.Count} bibite ");
            //Console.ResetColor();

            //foreach (Bibita b in bibitaList)
            //{
            //    Console.WriteLine($"\t{b.RiepilogoOrdine()}");
            //}

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Hai ordinato {patatineList.Count} patatine ");
            //Console.ResetColor();

            //foreach (Patatine p in patatineList)
            //{
            //    Console.WriteLine($"\t{p.RiepilogoOrdine()}");
            //}

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Hai ordinato {salsaList.Count} salse ");
            //Console.ResetColor();

            //foreach (Salsa s in salsaList)
            //{
            //    Console.WriteLine($"\t{s.RiepilogoOrdine()}");
            //}
        }

    }
}