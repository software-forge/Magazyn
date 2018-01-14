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

        // Informacja o przeznaczeniu oleju przyjmuje wartości z różnych przedziałów dla olejów silnikowych 2t i 4t oraz przekładniowych
        protected int przeznaczenie;

        // Przykład właściwości abstrakcyjnej
        public abstract int Przeznaczenie
        {
            get;
            set;
        }

        // **** Przykłady właściwości wirtualnych: ****

        // Tylko olej4T implementuje tą właściwość (mineralny/półsyntetyczny/syntetyczny) (ew. przekładniowy manualny też może)
        public virtual int Typ
        {
            get;
            set;
        }

        // Dla olejów silnikowych i przekładniowych, klasy lepkości zimowych są różne (przyjmują wartości z różnych zbiorów)
        public virtual int Lepkosc_zimowa
        {
            get;
            set;
        }

        // Dla olejów silnikowych i przekładniowych, klasy lepkości letnich są różne (przyjmują wartości z różnych zbiorów)
        public virtual int Lepkosc_letnia
        {
            get;
            set;
        }

        // ********************************************

        // Przykład metody wirtualnej
        public virtual string Lepkosc()
        {
            return "";
        }

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

        // Przykład metody abstrakcyjnej, jeżeli zwróci true - usunąć olej z bazy
        public abstract bool Pokaz();
    }
}
