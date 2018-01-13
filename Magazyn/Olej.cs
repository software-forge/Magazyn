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
        private string nazwa, producent; // nazwa produktu, nazwa producenta

        // Informacje o stanie magazynowym i cenie
        private int pojemnosc;             // pojemność jednej jednostki w litrach
        private decimal cena;        // cena za jedną jednostkę

        // Informacja o przeznaczeniu oleju samochodowy/motocyklowy/inny (silnikowy) lub do przekładni manualnej/automatycznej (przekładniowy)
        protected int przeznaczenie;

        public string Nazwa
        {
            get => nazwa;
            set
            {
                if (value.Length < 25)
                    nazwa = value;
                else
                    nazwa = "";
            }

        }

        public string Producent
        {
            get => producent;
            set
            {
                if (value.Length < 25)
                    producent = value;
                else
                    producent = "";
            }
        }

        public int Pojemnosc
        {
            get => pojemnosc;
            private set => pojemnosc = value;
        }
        public decimal Cena
        {
            get => cena;
            private set => cena = value;
        }

        public Olej(int pojemnosc, decimal cena)
        {
            Pojemnosc = pojemnosc;
            Cena = cena;
        }

        // Jeżeli nadpisana metoda Pokaz() zwróci true, tzn., że ten olej należy usunąć z bazy
        public abstract bool Pokaz();
    }
}
