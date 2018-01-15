using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Olej2T:Olej
    {
        // Wywołanie konstruktora bazowego (czy trzeba w ten sposób?)
        public Olej2T(int pojemnosc, decimal cena) : base(pojemnosc, cena) {}

        // Nadpisanie abstrakcyjnej właściwości Przeznaczenie
        public override int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-1
                if(value == 0 || value == 1)
                    przeznaczenie = value;
            }
        }

        // Nadpisanie abstrakcyjnej metody Pokaz()
        public override void Pokaz()
        {
                Console.Clear();

                Console.WriteLine((Producent + " " + Nazwa).PadRight(50));

                Console.Write("Przeznaczenie: ");
                switch (Przeznaczenie)
                {
                    case 0:
                        Console.WriteLine("motocykle/motorowery");
                        break;
                    case 1:
                        Console.WriteLine("inne");
                        break;
                }
                
                Console.WriteLine("Pojemność opakowania: {0} L", Convert.ToString(Pojemnosc));
                Console.WriteLine("Cena: {0} PLN/szt.", Convert.ToString(Cena));
        }
    }
}
