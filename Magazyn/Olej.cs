using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    abstract class Olej
    {
        // Informacje o produkcie
        string nazwa, producent; // nazwa produktu, nazwa producenta

        // Informacje o stanie magazynowym i cenie
        public int poj_jedn;              // ilość jednostek na magazynie
        public decimal cena_jedn;              // cena za jedną jednostkę

        // Informacja o przeznaczeniu oleju samochodowy/motocyklowy/inny (silnikowy) lub do przekładni manualnej/automatycznej (przekładniowy)
        private int przeznaczenie;

        // Czy ta hermetyzacja ma sens?
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public string Producent { get => producent; set => producent = value; }

        public int Przeznaczenie
        {
            get => przeznaczenie;
            set => przeznaczenie = value;
        }

        // TODO ??
        public Olej()
        {

        }

        // Jeżeli nadpisana metoda Pokaz() zwróci true, tzn., że ten olej należy usunąć z bazy
        public virtual bool Pokaz()
        {
            Console.Clear();
            Console.WriteLine(Producent + " " + Nazwa);

            return false;
        }
    }
}
