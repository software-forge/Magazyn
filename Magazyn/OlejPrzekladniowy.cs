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

        // TODO ??
        public OlejPrzekladniowy():base()
        {

        }

        public new int Przeznaczenie
        {
            get => base.Przeznaczenie;
            set
            {
                if (value >= 0 && value <= 1)
                    base.Przeznaczenie = value;
            }
        }

        private int lepkosc_zimowa, lepkosc_letnia;

        public int Lepkosc_zimowa
        {
            get => lepkosc_zimowa;
            set
            {
                // Tylko jeśli przeznaczenie = manual (dla olejów do automatów nie rozpatrujemy lepkości)
                if(base.Przeznaczenie == 0)
                {
                    // Jeżeli przekazywana wartość jest poprawną lepkością zimową oleju przekładniowego
                    if (PoprLepkoscZimowa(value))
                        lepkosc_zimowa = value;
                    else
                        lepkosc_zimowa = 0;
                }
            }
        }

        public int Lepkosc_letnia
        {
            get => lepkosc_letnia;
            set
            {
                // Tylko jeśli przeznaczenie = manual (dla olejów do automatów nie rozpatrujemy lepkości)
                if (base.Przeznaczenie == 0)
                {
                    // Jeżeli przekazywana wartość jest poprawną lepkością letnią oleju przekładniowego
                    if (PoprLepkoscLetnia(value))
                        lepkosc_letnia = value;
                    else
                        lepkosc_letnia = 0;
                }
            }
        }

        // TODO - sensowna obsługa błędnych wartości
        public string Lepkosc()
        {
            bool wielosezonowy = false;
            if (Lepkosc_zimowa >= 70 && Lepkosc_letnia >= 80)
                wielosezonowy = true;

            if (wielosezonowy)
                return Lepkosc_zimowa + "W-" + Lepkosc_letnia;
            else
            {
                if (Lepkosc_zimowa >= 0)
                    return Lepkosc_zimowa + "W";
                else
                    return Convert.ToString(Lepkosc_letnia);
            }
        }

        public override bool Pokaz()
        {
            while(true)
            {
                base.Pokaz();

                Console.Write("Przeznaczenie: ");
                switch (base.Przeznaczenie)
                {
                    case 0:
                        Console.WriteLine("przekładnie manualne");
                        Console.WriteLine("Klasa lepkości: " + Lepkosc());
                        break;
                    case 1:
                        Console.WriteLine("przekładnie automatyczne");
                        break;
                }

                Console.WriteLine("Cena: {0} PLN/szt.", cena_jedn);

                Console.WriteLine("Esc - powrót, Spacja - usuń olej z bazy");

                ConsoleKeyInfo usunac = Console.ReadKey();
                switch (usunac.Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return false;
                    case ConsoleKey.Spacebar:
                        Komunikat k = new Komunikat("CZY NA PEWNO?", "Czy na pewno chcesz usunąć ten olej z bazy?", false);
                        if (k.Wyswietl("USUŃ", "ANULUJ"))
                        {
                            Console.Clear();
                            return true;
                        }
                        break;
                }
            }
        }
    }
}
