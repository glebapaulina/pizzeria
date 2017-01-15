using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWPF
{
    abstract class Zamowienie
    {
        protected DateTime czasDostawy;

        public virtual bool PoprawnyCzas()
        {
            return czasDostawy > DateTime.Now;
        }
        
        public void UstawCzasDostawy(DateTime czasDostawy)
        {
            this.czasDostawy = czasDostawy;
        }


    }
}
