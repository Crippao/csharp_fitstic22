using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    public class Ordine
    {
        private DateTime dataOra;
        private long id;
        public List<Articolo> articoloList;

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

        public Ordine(long id, DateTime d) 
        {
            this.dataOra = d;
            this.id = id;
        }

        public override string ToString()
        {
            string? ordine = $"L'ordine {id} è stato creato in data {dataOra}";
            return ordine;
        }

    }
}
