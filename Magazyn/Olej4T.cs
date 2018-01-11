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

        public Olej4T():base()
        {

        }

        public int Przeznaczenie
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

        public int Lepkosc_zimowa
        {
            get => lepkosc_zimowa;
            set
            {
                // Jeżeli przekazywana wartość jest poprawną lepkością zimową oleju dla silnika 4T
                if (PoprLepkoscZimowa(value))
                    lepkosc_zimowa = value;
                else
                    lepkosc_zimowa = -1;
            }
        }

        public int Lepkosc_letnia
        {
            get => lepkosc_letnia;
            set
            {
                // Jeżeli przekazywana wartość jest poprawną lepkością letnią oleju dla silnika 4T
                if (PoprLepkoscLetnia(value))
                    lepkosc_letnia = value;
                else
                    lepkosc_letnia = 0;
            }
        }

        public int Typ
        {
            get => typ;
            set
            {
                if (value >= 0 && value <= 2)
                    typ = value;
            }
        }

        public string Lepkosc()
        {
            bool wielosezonowy = false;
            if (Lepkosc_zimowa >= 0 && Lepkosc_letnia >= 8)
                wielosezonowy = true;

            if(wielosezonowy)
                return Lepkosc_zimowa + "W-" + Lepkosc_letnia;
            else
            {
                if(Lepkosc_zimowa >= 0)
                    return Lepkosc_zimowa + "W";
                else
                    return Convert.ToString(Lepkosc_letnia);
            }
            
        }

        public override void Pokaz()
        {
            base.Pokaz();

            Console.Write("Przeznaczenie: ");
            switch (Przeznaczenie)
            {
                case 0:
                    Console.WriteLine("motocyklowy/motorowerowy");
                    break;
                case 1:
                    Console.WriteLine("inny");
                    break;
                case 2:
                    Console.WriteLine("samochodowy");
                    break;
            }

            Console.WriteLine("Klasa lepkości: " + Lepkosc());

            Console.Write("Typ: ");
            switch(Typ)
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

            Console.ReadKey();
            Console.Clear();
        }
    }
}
