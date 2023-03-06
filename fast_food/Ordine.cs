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
        private int iD;
        public List<Articolo> articoloList;

        public DateTime DataOra
        {
            get { return dataOra; }
            set { dataOra = value; }
        }

        public int ID 
        { 
            get { return iD; }
            set { iD = value; }
        }

        

        public Ordine(DateTime d, int id) 
        {
            this.dataOra = d;
            this.iD = id;
        }

    }
}
