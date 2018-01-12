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
            // Zapełnienie listy obiektów z xml
            Magazyn.Wczytaj();

            // Elementy menu głównego
            List <string> elementyMenu = new List <string>();
            elementyMenu.Add("Przeglądaj oleje w bazie");
            elementyMenu.Add("Dodaj olej do bazy");
            elementyMenu.Add("Dobierz olej");
            elementyMenu.Add("O programie");
            elementyMenu.Add("Wyjście");

            Menu menuGlowne = new Menu("OLEJARKA v. 1.0 (wyjście - Esc)", elementyMenu);

            while (true)
            {
                int wybor = menuGlowne.Wybor();

                switch(wybor)
                {
                    case -1:
                        Magazyn.Zapisz();
                        return;
                    case 0:
                        Magazyn.Przegladaj();
                        break;
                    case 1:
                        Magazyn.Dodaj();
                        break;
                    case 2:
                        Magazyn.Dobierz();
                        break;
                    case 3:
                        Komunikat k = new Komunikat("OLEJARKA v. 1.0 by Rafał Miller", "Program zaliczeniowy przedmiotu JiPP w WWSI");
                        k.Wyswietl();
                        break;
                    case 4:
                        Magazyn.Zapisz();
                        return;
                }
            }
        }
    }
}
