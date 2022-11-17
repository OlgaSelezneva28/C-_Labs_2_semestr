using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    abstract class Obj
    {

        public abstract Obj copy();
        public abstract bool equal(Obj Dr);
        public abstract int cmp(Obj Dr);
        public abstract string ToString();
        public abstract String GetType(); 
        
    }
}
