using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal abstract class Articolo
    {
        public abstract void Ordina();

        public abstract string RiepilogoOrdine();

        public abstract bool ChiediConferma(string s); 
        
    }
}
