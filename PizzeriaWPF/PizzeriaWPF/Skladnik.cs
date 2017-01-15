using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaWPF
{
    class Skladnik: IComparable<Skladnik>
    {
        private string nazwaSkladnika;
        private double cenaSkladnika;

        public Skladnik(string nazwaSkladnika, double cenaSkladnika)
        {
            this.cenaSkladnika = cenaSkladnika;
            this.nazwaSkladnika = nazwaSkladnika;
        }
        public override string ToString()
        {
            return string.Format("Nazwa: {0}, cena: {1}", nazwaSkladnika, cenaSkladnika);
        }
        public double PobierzCene()
        {
            return cenaSkladnika;
        }

        public int CompareTo(Skladnik other)
        {
            return this.nazwaSkladnika.CompareTo(other.nazwaSkladnika);
        }
    }
}
