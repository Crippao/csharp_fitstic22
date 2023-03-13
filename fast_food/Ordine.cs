using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Ordine
    {
        private DateTime dataOra;
        private long id;
        private List<Articolo> _articoloList;

        public void AddArticolo(Articolo articolo)
        {
            _articoloList.Add(articolo);
        }

        public List<Articolo> Articoli { get => _articoloList; }

        public DateTime DataOra
        {
            get { return dataOra; }
            set { dataOra = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public Ordine(long id = 0, DateTime? d = null)
        {
            this.dataOra = d ?? DateTime.Now;
            this.id = id;
            _articoloList = new List<Articolo>();
        }

        public override string ToString()
        {
            string? ordine = $"L'ordine {id} è stato creato in data {dataOra}";
            return ordine;
        }

        public void RiepilogoOrdini()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Hai ordinato {_articoloList.Count} prodotti ");
            Console.ResetColor();

            foreach (Articolo a in _articoloList)
            {
                Console.WriteLine($"\t{a.RiepilogoOrdine()}");
            }
        }

        public Ordine AggiungiArticolo(Articolo a)
        {
            
            a.Ordina();
            this.AddArticolo(a);

            return this;
        }

    }
}
