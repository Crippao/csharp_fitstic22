using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Bibita : Articolo
    {
        private string? dimensione;
        private bool inMenu;
        private int numero_sorsi;

        public string? Dimensione
        {
            get { return dimensione; }
            set { dimensione = value; }
        }

        public Bibita(bool inMenu)
        {
            this.inMenu = inMenu;
        }

        public Bibita(string? dim = "medium", int n_s = 15)
        {
            this.dimensione = dim;
            this.numero_sorsi = n_s;
            this.inMenu = false;
        }

        public override void Ordina()
        {
            string? dim;

            do
            {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Che bibita vuoi??");
                Console.WriteLine("Scegli tra:");
                Console.WriteLine("s per Piccola");
                Console.WriteLine("m per Media");
                Console.WriteLine("l per Grande");
                Console.ResetColor();
                dim = Console.ReadLine();
            } while (int.TryParse(dim, out int v) || (dim != "s" && dim != "m" && dim != "l"));

            switch (dim)
            {
                case "s":
                    this.dimensione = "small";
                    this.numero_sorsi = 10;
                    break;

                case "m":
                    this.dimensione = "medium";
                    this.numero_sorsi = 15;
                    break;

                case "l":
                    this.dimensione = "large";
                    this.numero_sorsi = 20;
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
            string? riepilogo;

            if (this.inMenu == true)
            {
                riepilogo = "";
            } else
            {
                riepilogo = "Hai ordinato una ";                
            }

            if (this.dimensione == "small")
            {
                riepilogo += "bibita piccola";
            }
            else if (this.dimensione == "medium")
            {
                riepilogo += "bibita media";
            }
            else if (this.dimensione == "large")
            {
                riepilogo += "bibita grande";
            }

            return riepilogo;
        }
    }
}
