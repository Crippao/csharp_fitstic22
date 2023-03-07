using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Menu : Articolo
    {
        private Panino panino;
        private Bibita bibita;
        private Patatine patatine;
        private Salsa salsa;

        public Panino Panino 
        {
            get { return panino; }
            set { panino = value; }
        }
        public Bibita Bibita 
        {
            get { return bibita; }
            set { bibita = value; }
        }
        public Patatine Patatine 
        {
            get { return patatine; }
            set { patatine = value; }
        }
        public Salsa Salsa 
        {
            get { return salsa; }
            set { salsa = value; }
        }


        public Menu() 
        {
            this.panino = new Panino(inMenu :this);
            this.bibita = new Bibita(inMenu:true);
            this.patatine = new Patatine(inMenu: true);
            this.salsa= new Salsa(inMenu: true);
           
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
            } while (int.TryParse(temp, out int v) );

            if (temp == "y")
            {
                choice = true;
            } else
            {
                choice = false;
            }
            return choice;
        }

        public override void Ordina()
        {
            bool c1;

            c1 = ChiediConferma("Nel menù vuoi il panino?");
            if (c1 == true)
            {
                panino.Ordina();
            }
            c1 = ChiediConferma("Nel menù vuoi la bibita?");
            if (c1 == true)
            {
                bibita.Ordina();
            }
            c1 = ChiediConferma("Nel menù vuoi le patatine?");
            if (c1 == true)
            {
                patatine.Ordina();
            }
            c1 = ChiediConferma("Nel menù vuoi una salsa?");
            if (c1 == true)
            {
                salsa.Ordina();
            }
            
        }

        public override string RiepilogoOrdine()
        {
            string? riepilogo = "Hai ordinato un menù con: ";
            riepilogo += $"\n\t\t{panino.RiepilogoOrdine()}";
            riepilogo += $"\n\t\t{bibita.RiepilogoOrdine()}";
            riepilogo += $"\n\t\t{patatine.RiepilogoOrdine()}";
            riepilogo += $"\n\t\t{salsa.RiepilogoOrdine()}";


            return riepilogo;
        }
    }

}
