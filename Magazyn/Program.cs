using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Program
    {
        // Pokazanie produktu - metoda w klasie Produkt()

        // Zrobić na klasie Menu() - wybór oznacza pokazanie produktu
        private static void Przegladaj()
        {
            
        }

        // Zrobić własny formularz wyszukiwania - wyniki w Menu() (wybór Menu() oznacza pokazanie produktu)
        private static void Szukaj()
        {

        }

        // Zrobić własny formularz dodawania
        private static void Dodaj()
        {

        }

        static void Main(string[] args)
        {
            // Elementy menu głównego
            List <string> elementyMenu = new List <string>();
            elementyMenu.Add("Przeglądaj magazyn");
            elementyMenu.Add("Szukaj w magazynie");
            elementyMenu.Add("Dodaj do magazynu");
            elementyMenu.Add("O programie");
            elementyMenu.Add("Wyjście");

            Menu menuGlowne = new Menu("MAGAZYN v.1.0", elementyMenu);

            // Zapełnienie listy obiektów z xml

            while (true)
            {
                int wybor = menuGlowne.Wybor();

                switch(wybor)
                {
                    case 0:
                        Przegladaj();
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        // Zapisanie listy obiektów do xml
                        return;
                }
            }
        }
    }
}
