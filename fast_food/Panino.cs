using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Panino : Articolo
    {
        public bool pane;
        public bool carne;
        public bool formaggio;
        public bool salsa;
        private int numero_morsi;

        public Panino(bool p = true, bool c = true, bool f = true, bool s = true, int n_m = 10)
        {
            this.pane = p;
            this.carne = c;
            this.formaggio = f;
            this.salsa = s;
            this.numero_morsi = n_m;
        }

        public override void Ordina()
        {
            string? pane;
            string? carne;
            string? form;
            string? salsa;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Cosa vuoi nel tuo panino?");
            Console.ResetColor();

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vuoi il pane?");
                Console.ResetColor();
                pane = Console.ReadLine();
            } while (int.TryParse(pane, out int v) || (pane != "y" && pane != "n"));

            if (pane == "y")
            {
                this.pane = true;
            }
            else if (pane == "n")
            {
                this.pane = false;
            }

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vuoi la carne?");
                Console.ResetColor();
                carne = Console.ReadLine();
            } while (int.TryParse(carne, out int v) || (carne != "y" && carne != "n"));

            if (carne == "y")
            {
                this.carne = true;
            }
            else if (carne == "n")
            {
                this.carne = false;
            }

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vuoi il formaggio?");
                Console.ResetColor();
                form = Console.ReadLine();
            } while (int.TryParse(form, out int v) || (form != "y" && form != "n"));

            if (form == "y")
            {
                this.formaggio = true;
            }
            else if (form == "n")
            {
                this.formaggio = false;
            }

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vuoi la salsa?");
                Console.ResetColor();
                salsa = Console.ReadLine();
            } while (int.TryParse(salsa, out int v) || (salsa != "y" && salsa != "n"));

            if (salsa == "y")
            {
                this.salsa = true;
            }
            else if (salsa == "n")
            {
                this.salsa = false;
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
            string[] panino = new string[4];

            if (this.pane == true)
            {
                panino[0] = "pane";
            }
            else { panino[0] = "no pane"; };

            if (this.carne == true)
            {
                panino[1] = "carne";
            }
            else { panino[1] = "no carne"; }

            if (this.formaggio == true)
            {
                panino[2] = "formaggio";
            }
            else { panino[2] = "no formaggio"; }

            if (this.salsa == true)
            {
                panino[3] = "salsa";
            }
            else { panino[3] = "no salsa"; }

            string? riepilogo = $"Hai ordinato un panino con: {String.Join(", ", panino)}";

            return riepilogo;
        }
    }
}
