using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Salsa : Articolo
    {
        public string? tipo;

        private int numero_intingoli;

        public Salsa(string t = "mayo", int n_i = 15)
        {
            this.tipo = t;
            this.numero_intingoli = n_i;
        }

        public int ChiediQuantità()
        {
            int num;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quante salse vuoi ordinare?");
                Console.ResetColor();
            } while (!int.TryParse(Console.ReadLine(), out num));

            return num;
        }

        public override void Ordina()
        {
            string? t;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quale salsa vuoi??");
                Console.WriteLine("Scegli tra:");
                Console.WriteLine("m per Maionese");
                Console.WriteLine("k per Ketchup");
                Console.WriteLine("b per Bbq");
                Console.WriteLine("a per Agrodolce");
                Console.WriteLine("s per Senape");
                Console.ResetColor();
                t = Console.ReadLine();
            } while (int.TryParse(t, out int v) || (t != "m" && t != "k" && t != "b" && t != "a" && t != "s"));

            switch (t)
            {
                case "m":
                    this.tipo = "maionese";
                    this.numero_intingoli = 10;
                    break;

                case "k":
                    this.tipo = "ketchup";
                    this.numero_intingoli = 10;
                    break;

                case "b":
                    this.tipo = "bbq";
                    this.numero_intingoli = 10;
                    break;

                case "a":
                    this.tipo = "agrodolce";
                    this.numero_intingoli = 10;
                    break;

                case "s":
                    this.tipo = "senape";
                    this.numero_intingoli = 10;
                    break;
            }
        }
        public override bool ChiediConferma(string? ogg)
        {
            bool choice;
            string? temp;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ogg);
                Console.ResetColor();
                temp = Console.ReadLine();
            } while (int.TryParse(temp, out int v));

            if (temp == "y")
            {
                choice = true;
            }
            else
            {
                choice = false;
            }
            return choice;
        }

        public override string RiepilogoOrdine()
        {
            string? riepilogo = "Hai ordinato una salsa ";

            if (this.tipo == "maionese")
            {
                riepilogo += "Maionese";
            }
            else if (this.tipo == "ketchup")
            {
                riepilogo += "Ketchup";
            }
            else if (this.tipo == "bbq")
            {
                riepilogo += "Bbq";
            }
            else if (this.tipo == "agrodolce")
            {
                riepilogo += "Agrodolce";
            }
            else if (this.tipo == "senape")
            {
                riepilogo += "Senape";
            }

            return riepilogo;
        }
    }
}
