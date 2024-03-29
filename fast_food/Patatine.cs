﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Patatine : Articolo
    {
        private long id;
        private long id_ordine;
        private string? dimensione;
        private bool inMenu;
        private int numero_patatine;

        public long Id { get; set; }

        public long Id_ordine { get; set; }

        public string? Dimensione
        {
            get { return dimensione; }
            set { dimensione = value; }
        }

        public int Numero_Patatine
        {
            get { return numero_patatine; }
        }
        public bool InMenu
        {
            get { return inMenu; }
            set { inMenu = value; }
        }
        
        public Patatine(long id = 0, string? dim = "medium", int n_p = 15, long id_ordine = 0, bool inMenu = false)
        {
            this.id = id;         
            this.dimensione = dim;
            this.numero_patatine = n_p;
            this.id_ordine = id_ordine;
            this.inMenu = inMenu;
        }

        public override void Ordina()
        {
            string? dim;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Quante patatine vuoi??");
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
                    //this.id++;
                    this.dimensione = "small";
                    this.numero_patatine = 10;                    
                    break;

                case "m":
                    //this.id++;
                    this.dimensione = "medium";
                    this.numero_patatine = 15;
                    break;

                case "l":
                    //this.id++;
                    this.dimensione = "large";
                    this.numero_patatine = 20;
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
            if (inMenu == true)
            {
                riepilogo = "";
            }
            else
            {
                riepilogo = "Hai ordinato una ";
            }
            
            if (this.dimensione == "small") 
            {
                riepilogo += "patatina piccola";
            } else if (this.dimensione == "medium") 
            {
                riepilogo += "patatina media";
            } else if (this.dimensione == "large")
            {
                riepilogo += "patatina grande";
            }

            return riepilogo;
        }
    }
}
