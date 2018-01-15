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

        // Konstruktor bazowy
        public Olej(int pojemnosc, decimal cena)
        {
            Pojemnosc = pojemnosc;
            Cena = cena;
        }

        // Przykład metody abstrakcyjnej
        public abstract void Pokaz();

        // Wyświetla dane wybranego oleju i czeka na wciśnięcie dowolnego klawisza
        public void Prezentuj()
        {
            Pokaz();
            Console.WriteLine("Aby powrócić, naciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        // Wyświetla dane wybranego oleju i czeka na wybór usunąć/powrót
        public bool Usunac()
        {
            Pokaz();

            Console.WriteLine("Esc - powrót, Spacja - usuń olej z bazy");

            while (true)
            {
                ConsoleKeyInfo usunac = Console.ReadKey();
                switch (usunac.Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return false;
                    case ConsoleKey.Spacebar:

                        Komunikat k = new Komunikat("CZY NA PEWNO? (anuluj - Esc)", "Czy na pewno chcesz usunąć ten olej z bazy?", false);
                        int i = k.Wyswietl("USUŃ", "ANULUJ", true);

                        if (i == 0 || i == -1)
                        {
                            Console.Clear();
                            return false;
                        }

                        Console.Clear();
                        return true;
                }
            }
        }
    }
}
