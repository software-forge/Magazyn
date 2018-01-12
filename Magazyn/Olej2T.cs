using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Olej2T:Olej
    {

        // TODO ??
        public Olej2T():base()
        {
            
        }

        public new int Przeznaczenie
        {
            get => base.Przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-1
                if(value >= 0 && value <= 1)
                    base.Przeznaczenie = value;
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
                        Console.WriteLine("motocykle/motorowery");
                        break;
                    case 1:
                        Console.WriteLine("inne");
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
