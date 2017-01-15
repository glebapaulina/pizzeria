using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWPF
{
    class NaWynos: Zamowienie
    {
        public override bool PoprawnyCzas()
        {

            return czasDostawy.AddHours(3) > DateTime.Now;
        }
    }
}
