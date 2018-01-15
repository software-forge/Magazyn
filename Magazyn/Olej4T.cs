using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Olej4T:Olej
    {
        private readonly int[] lepkosci_letnie = {8, 12, 16, 20, 30, 40, 50, 60};

        private bool PoprLepkoscLetnia(int lepkosc)
        {
            foreach (int l in lepkosci_letnie)
                if (l == lepkosc)
                    return true;
            return false;
        }

        private readonly int[] lepkosci_zimowe = {0, 5, 10, 15, 20, 25};

        private bool PoprLepkoscZimowa(int lepkosc)
        {
            foreach (int l in lepkosci_zimowe)
                if (l == lepkosc)
                    return true;
            return false;
        }

        // ***** Przeciążone konstruktory, każdy wywołuje konstruktor bazowy *****
        
        public Olej4T(int pojemnosc, decimal cena, int lepkosc_z, int lepkosc_l):base(pojemnosc, cena)
        {
            Lepkosc_zimowa = lepkosc_z;
            Lepkosc_letnia = lepkosc_l;
        }


        public Olej4T(int pojemnosc, decimal cena, int lepkosc, bool zimowy):base(pojemnosc, cena)
        {
            if (zimowy)
            {
                Lepkosc_zimowa = lepkosc;
                Lepkosc_letnia = -1;
            }
            else
            {
                Lepkosc_letnia = lepkosc;
                Lepkosc_zimowa = -1;
            }
        }

        // ************************************************************************

        // Nadpisanie abstrakcyjnej właściwości Przeznaczenie
        public override int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-2
                if (value >= 0 && value <= 2)
                    przeznaczenie = value;
            }
        }

        private int lepkosc_zimowa, lepkosc_letnia, typ;

        public override int Lepkosc_zimowa
        {
            get => lepkosc_zimowa;
            set
            {
                // Przekazywana wartość musi być poprawną lepkością zimową oleju do silnika 4T
                if (PoprLepkoscZimowa(value))
                    lepkosc_zimowa = value;
                else
                    lepkosc_zimowa = -1;
            }
        }

        public override int Lepkosc_letnia
        {
            get => lepkosc_letnia;
            set
            {
                // Przekazywana wartość musi być poprawną lepkością letnią oleju do silnika 4T
                if (PoprLepkoscLetnia(value))
                    lepkosc_letnia = value;
                else
                    lepkosc_letnia = -1;
            }
        }

        public override int Typ
        {
            get => typ;
            set
            {
                // Wartość musi być z przedziału 0-2
                if (value >= 0 && value <= 2)
                    typ = value;
            }
        }

        // Nadpisanie wirtualnej metody Lepkosc()
        public override string Lepkosc()
        {
            if (Lepkosc_letnia == -1 && Lepkosc_zimowa == -1)
                return "brak danych";

            if(Lepkosc_zimowa > -1 && Lepkosc_letnia > -1)
                return Lepkosc_zimowa + "W-" + Lepkosc_letnia;
            else
            {
                if(Lepkosc_zimowa > -1)
                    return Lepkosc_zimowa + "W";
                else
                    return Convert.ToString(Lepkosc_letnia);
            }
        }

        // Nadpisanie abstrakcyjnej metody Pokaz()
        public override void Pokaz()
        {
                Console.Clear();
                Console.WriteLine(Producent + " " + Nazwa);

                Console.Write("Przeznaczenie: ");
                switch (Przeznaczenie)
                {
                    case 0:
                        Console.WriteLine("samochody");
                        break;
                    case 1:
                        Console.WriteLine("motocykle");
                        break;
                    case 2:
                        Console.WriteLine("inne");
                        break;
                }

                Console.WriteLine("Klasa lepkości: " + Lepkosc());

                Console.Write("Typ: ");
                switch (Typ)
                {
                    case 0:
                        Console.WriteLine("mineralny");
                        break;
                    case 1:
                        Console.WriteLine("półsyntetyczny");
                        break;
                    case 2:
                        Console.WriteLine("syntetyczny");
                        break;
                }

                Console.WriteLine("Pojemność opakowania: {0} l", Pojemnosc);
                Console.WriteLine("Cena: {0} PLN/szt.", Cena);
        }
    }
}
