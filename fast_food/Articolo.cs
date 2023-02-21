using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fast_food
{
    internal class Articolo
    {
        public virtual void Ordina() 
        { 
        
        }

        public virtual string RiepilogoOrdine() 
        {
            return "";
        }

        public virtual bool ChiediConferma(string s) 
        {
            return true;
        }
    }
}
