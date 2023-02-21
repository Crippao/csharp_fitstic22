﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Menu : Articolo
    {
        public Panino panino;
        public Bibita bibita;
        public Patatine patatine;
        public Salsa salsa;
        

        public Menu() 
        {
            this.panino = new Panino();
            this.bibita = new Bibita(true);
            this.patatine = new Patatine();
            this.salsa= new Salsa();
           
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
            string? riepilogo = "";
            riepilogo += $"{panino.RiepilogoOrdine()}";
            riepilogo += $"\n\t{bibita.RiepilogoOrdine()}";
            riepilogo += $"\n\t{patatine.RiepilogoOrdine()}";
            riepilogo += $"\n\t{salsa.RiepilogoOrdine()}";


            return riepilogo;
        }
    }

}