using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class Program
    {
        static void Main(string[] args)
        {
            // Elementy menu głównego
            List <string> elementyMenu = new List <string>();
            elementyMenu.Add("Test powiadomienia");
            elementyMenu.Add("Test zapytania");
            elementyMenu.Add("Test wprowadzania tekstu");
            elementyMenu.Add("Ustawienia");
            elementyMenu.Add("O programie");
            elementyMenu.Add("Pomoc");
            elementyMenu.Add("Wyjście");

            Menu menuGlowne = new Menu("MENU GŁÓWNE", elementyMenu);

            // Zapełnienie listy obiektów z xml

            while(true)
            {
                int wybor = menuGlowne.Wybor();

                Komunikat k;

                switch(wybor)
                {
                    case 0:
                        k = new Komunikat("Komunikat", "Tak wygląda komunikat");
                        k.Wyswietl();
                        break;
                    case 1:
                        k = new Komunikat("Pytanie", "Kontynuować?", true);
                        bool odpowiedz = k.Wyswietl("OK", "Anuluj");
                        Console.WriteLine(odpowiedz);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Tutaj będzie test wprowadzania danych tekstowych");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Tutaj będą ustawienia");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("O programie");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Pomoc");
                        Console.ReadKey();
                        break;
                    case 6:
                        return;
                }
            }

            // Zapisanie listy obiektów do xml
        }
    }
}
