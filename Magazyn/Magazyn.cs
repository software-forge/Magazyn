using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Magazyn
    {
        private static List <Olej> oleje;

        public static List <Olej> Oleje
        {
            get => oleje;
            private set => oleje = value;
        }

        // Wczytywanie z xml 
        public static void Wczytaj()
        {
            Oleje = new List <Olej>();

        }

        // Zapisywanie do xml
        public static void Zapisz()
        {

        }

        // Zrobić na klasie Menu - wybór oznacza pokazanie wybranego oleju
        public static void Przegladaj()
        {
            // TODO 2

            Console.Clear();
            Console.WriteLine("Przeglądanie olejów");
            Console.ReadKey();
            Console.Clear();

            // 1. Przeglądanie magazynu na klasie Menu

            // 2. Wyświetlenie wybranego produktu - metoda Wyswietl() klasy Olej

            // 3. Powrót do menu przeglądania
        }

        // Zrobić własny formularz dodawania
        public static void Dodaj()
        {
            // TODO 1

            Console.Clear();
            Console.WriteLine("Dodawanie nowego oleju");
            Console.ReadKey();
            Console.Clear();
        }

        // Zrobić własny formularz doboru oleju - wyniki w Menu (wartość zwracana przez metodę Wybor() klasy Menu oznacza pokazanie wybranego oleju)
        public static void Dobierz()
        {
            // TODO 3

            Console.Clear();
            Console.WriteLine("Dobieranie oleju wg. podanych wymagań");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
