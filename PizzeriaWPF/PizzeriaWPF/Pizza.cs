using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWPF
{
    class Pizza
    {
        private string nazwa;
        private decimal suma = 15;
        private List<Skladnik> skladniki = new List<Skladnik>();
        private string sos;

        public void DodajSkladnik(string nazwaSkladnika, double cenaSkladnika)
        {
            skladniki.Add(new Skladnik(nazwaSkladnika, cenaSkladnika));
            suma += (decimal)cenaSkladnika;
        }
        public void DodajSos(string sos)
        {
            this.sos = sos;
        }
        public void UstawNazwe(string nazwa)
        {
            this.nazwa = nazwa;
        }
        public override string ToString()
        {
            string result = "";
            if (skladniki != null)
            {
                result += "Pizza: " + nazwa + Environment.NewLine;
                skladniki.Sort();
                foreach (var element in skladniki)
                {
                    result += element.ToString() + Environment.NewLine;
                }
                result += "Sos: " + sos + Environment.NewLine;
                result += "Suma: " + suma + Environment.NewLine;
            }
            return result;
        }
        public bool CzyNazwa()
        {
            return nazwa.Length != 0;
        }
        public bool CzyPoprawnaPizza()
        {
            return skladniki.Count > 2 && sos != "";
        }
    }
}
