using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Ordine
    {
        public DateTime dataOra;
        public int iD;
        public List<Articolo> articoloList;

        public Ordine(DateTime d, int id) 
        {
            this.dataOra = d;
            this.iD = id;
        }

    }
}
