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

        public OlejPrzekladniowy():base()
        {

        }

        public int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                if (value >= 0 && value <= 1)
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
                if (przeznaczenie == 0)
                {
                    // Jeżeli przekazywana wartość jest poprawną lepkością letnią oleju przekładniowego
                    if (PoprLepkoscLetnia(value))
                        lepkosc_letnia = value;
                    else
                        lepkosc_letnia = 0;
                }
            }
        }

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

        public override void Pokaz()
        {
            base.Pokaz();

            Console.Write("Przeznaczenie: ");

            switch (przeznaczenie)
            {
                case 0:
                    Console.WriteLine("przekładnie manualne");
                    Console.WriteLine("Klasa lepkości: " + Lepkosc());
                    break;
                case 1:
                    Console.WriteLine("przekładnie automatyczne");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
