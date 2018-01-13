using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Olej2T:Olej
    {
        public Olej2T(int pojemnosc, decimal cena) : base(pojemnosc, cena) {}

        public int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-1
                if(value == 0 || value == 1)
                    przeznaczenie = value;
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
                        Console.WriteLine("motocykle/motorowery");
                        break;
                    case 1:
                        Console.WriteLine("inne");
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

                        if(i == 0 || i == -1)
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
