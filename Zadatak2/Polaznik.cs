using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    internal class Polaznik
    {
        private string ime, prezime, oib;
        private DateTime datumUpisa;
        private double dug;

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Ime mora biti zadano");
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Prezime mora biti zadano");
                prezime = value;
            }
        }

        public string Oib
        {
            get
            {
                return oib;
            }
            set
            {
                if (value.Length != 11)
                    throw new ArgumentException("Oib mora imati točno 11 znakova");
                oib = value;
            }
        }

        public DateTime DatumUpisa
        {
            get
            {
                return datumUpisa;
            }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("datum ne smije biti u budućnosti");
                datumUpisa = value;
            }
        }

        public double Dug
        {
            get
            {
                return dug;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Dug ne smije biti negativan");
                dug = value;
            }
        }
    }
}
