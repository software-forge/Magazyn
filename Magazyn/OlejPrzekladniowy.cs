using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class OlejPrzekladniowy:Olej
    {
        private readonly int[] lepkosci_letnie = {80, 85, 90, 110, 140, 190, 250};

        private bool PoprLepkoscLetnia(int lepkosc)
        {
            foreach (int l in lepkosci_letnie)
                if (l == lepkosc)
                    return true;
            return false;
        }

        private readonly int[] lepkosci_zimowe = {70, 75, 80, 85};

        private bool PoprLepkoscZimowa(int lepkosc)
        {
            foreach (int l in lepkosci_zimowe)
                if (l == lepkosc)
                    return true;
            return false;
        }

        public OlejPrzekladniowy(int pojemnosc, decimal cena) : base(pojemnosc, cena)
        {
            Przeznaczenie = 1;
        }

        public OlejPrzekladniowy(int pojemnosc, decimal cena, int lepkosc_z, int lepkosc_l) : base(pojemnosc, cena)
        {
            Przeznaczenie = 0;

            Lepkosc_zimowa = lepkosc_z;
            Lepkosc_letnia = lepkosc_l;
        }

        public OlejPrzekladniowy(int pojemnosc, decimal cena, int lepkosc, bool zimowy) : base(pojemnosc, cena)
        {
            Przeznaczenie = 0;

            if(zimowy)
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

        public int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-1
                if (value == 0 || value == 1)
                    przeznaczenie = value;
            }
        }

        private int lepkosc_zimowa, lepkosc_letnia;

        public int Lepkosc_zimowa
        {
            get => lepkosc_zimowa;
            set
            {
                // Tylko jeśli przeznaczenie = manual (dla olejów do automatów nie rozpatrujemy lepkości)
                if(przeznaczenie == 0)
                {
                    // Jeżeli przekazywana wartość jest poprawną lepkością zimową oleju przekładniowego
                    if (PoprLepkoscZimowa(value))
                        lepkosc_zimowa = value;
                    else
                        lepkosc_zimowa = -1;
                }
                else
                    lepkosc_zimowa = -1;
            }
        }

        public int Lepkosc_letnia
        {
            get => lepkosc_letnia;
            set
            {
                // Tylko jeśli przeznaczenie = manual (dla olejów do automatów nie rozpatrujemy lepkości)
                if (przeznaczenie == 0)
                {
                    // Jeżeli przekazywana wartość jest poprawną lepkością letnią oleju przekładniowego
                    if (PoprLepkoscLetnia(value))
                        lepkosc_letnia = value;
                    else
                        lepkosc_letnia = -1;
                }
                else
                    lepkosc_letnia = -1;
            }
        }

        public string Lepkosc()
        {
            if (Lepkosc_letnia == -1 && Lepkosc_zimowa == -1)
                return "brak danych";
            
            if (Lepkosc_zimowa > -1 && Lepkosc_letnia > -1)
                return Lepkosc_zimowa + "W-" + Lepkosc_letnia;
            else
            {
                if (Lepkosc_zimowa > -1)
                    return Lepkosc_zimowa + "W";
                else
                    return Convert.ToString(Lepkosc_letnia);
            }
        }

        public override bool Pokaz()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(Producent + " " + Nazwa);

                Console.Write("Przeznaczenie: ");
                switch (Przeznaczenie)
                {
                    case 0:
                        Console.WriteLine("przekładnie manualne");
                        Console.WriteLine("Klasa lepkości: " + Lepkosc());
                        break;
                    case 1:
                        Console.WriteLine("przekładnie automatyczne");
                        break;
                }

                Console.WriteLine("Pojemność opakowania: {0} l", Pojemnosc);
                Console.WriteLine("Cena: {0} PLN/szt.", Cena);

                Console.WriteLine("Esc - powrót, Spacja - usuń olej z bazy");

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
