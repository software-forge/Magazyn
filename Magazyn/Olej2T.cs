using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Olej2T:Olej
    {
        public Olej2T():base()
        {
            
        }

        public int Przeznaczenie
        {
            get => przeznaczenie;
            set
            {
                // Wartość musi być z przedziału 0-1
                if(value >= 0 && value <= 1)
                    przeznaczenie = value;
            }
        }

        public override void Pokaz()
        {
            base.Pokaz();

            Console.Write("Przeznaczenie: ");

            switch(przeznaczenie)
            {
                case 0:
                    Console.WriteLine("motocyklowy/motorowerowy");
                    break;
                case 1:
                    Console.WriteLine("inny");
                    break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
