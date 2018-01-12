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
        // TODO
        public static void Wczytaj()
        {
            Oleje = new List <Olej>();

        }

        // Zapisywanie do xml
        // TODO
        public static void Zapisz()
        {

        }

        // Przeglądanie olejów wprowadzonych do bazy (jeżeli są)
        public static void Przegladaj()
        {
            // Pętla przeglądania olejów w bazie
            while (true)
            {
                if(oleje.Count > 0)
                {
                    // Są wczytane oleje

                    // Zbudowanie listy pełnych nazw olejów do wyświetlenia w menu
                    List<string> nazwy = new List<string>();
                    foreach (Olej o in oleje)
                        nazwy.Add(o.Producent + " " + o.Nazwa);
                    nazwy.Add("Powrót");

                    // Stworzenie obiektu menu
                    Menu przegladarka = new Menu("DOSTĘPNE OLEJE (powrót - Esc)", nazwy, 0);

                    // Wyświetlenie menu i zwrócenie wyniku
                    int wybor = przegladarka.Wybor();

                    if (wybor == -1 || wybor == (nazwy.Count - 1))
                        break;
                    else
                    {
                        if (oleje[wybor].Pokaz())
                            oleje.RemoveAt(wybor);
                    }
                }
                else
                {
                    // Brak wczytanych olejów

                    Komunikat brak_olejow = new Komunikat("BRAK OLEJÓW", "Brak dostępnych olejów w bazie.");
                    brak_olejow.Wyswietl();
                    break;
                }
            }   
        }

        // Procedura dodawania nowego oleju do bazy
        // TODO
        public static void Dodaj()
        {
            Komunikat k = new Komunikat("Dodawanie nowego oleju", "");

            k.Tresc = "Olej silnikowy czy przekładniowy?";
            if(k.Wyswietl("Silnikowy", "Przekładniowy"))
            {
                // Dodawanie oleju silnikowego
                k.Tresc = "Wybierz typ silnika";
                if(k.Wyswietl("Czterosuwowy", "Dwusuwowy"))
                {
                    // Dodawanie oleju do silnika 4T
                    Olej4T olej = new Olej4T();

                    Console.Write("Producent: ");
                    olej.Producent = Console.ReadLine();

                    Console.Write("Nazwa oleju: ");
                    olej.Nazwa = Console.ReadLine();

                    Menu m = new Menu();
                    List<string> l = new List<string>(3);

                    m.Tytul = "PRZEZNACZENIE OLEJU";
                    l.Add("Samochody");
                    l.Add("Motocykle");
                    l.Add("Inne");
                    m.Elementy = l;
                    
                    olej.Przeznaczenie = m.Wybor();
                    l.Clear();

                    m.Tytul = "TYP OLEJU";
                    l.Add("Mineralny");
                    l.Add("Półsyntetyczny");
                    l.Add("Syntetyczny");
                    m.Elementy = l;
                    

                    olej.Typ = m.Wybor();
                    l.Clear();

                    m.Tytul = "SEZON UŻYTKOWANIA";
                    l.Add("Całoroczny");
                    l.Add("Zimowy");
                    l.Add("Letni");
                    m.Elementy = l;
                    
                    int sezon = m.Wybor();
                    int lepkosc;
                    if (sezon > -1)
                    {
                        switch (sezon)
                        {
                            case 0:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość zimowa: ");
                                }
                                while(!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_zimowa = lepkosc;

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość letnia: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_letnia = lepkosc;

                                break;
                            case 1:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość zimowa: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_zimowa = lepkosc;
                                olej.Lepkosc_letnia = 0;

                                break;
                            case 2:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość letnia: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_letnia = lepkosc;
                                olej.Lepkosc_zimowa = -1;

                                break;
                        }
                    }

                    l.Clear();
                    
                    oleje.Add(olej);
                }
                else
                {
                    // Dodawanie oleju do silnika 2T
                    Olej2T olej = new Olej2T();

                    Console.Write("Producent: ");
                    olej.Producent = Console.ReadLine();

                    Console.Write("Nazwa oleju: ");
                    olej.Nazwa = Console.ReadLine();

                    k.Tresc = "Wybierz przeznaczenie oleju";
                    if (k.Wyswietl("Motocyklowy", "Inny"))
                        olej.Przeznaczenie = 0;
                    else
                        olej.Przeznaczenie = 1;

                    oleje.Add(olej);
                }
            }
            else
            {
                // Dodawanie oleju przekładniowego
                OlejPrzekladniowy olej = new OlejPrzekladniowy();

                Console.Write("Producent: ");
                olej.Producent = Console.ReadLine();

                Console.Write("Nazwa oleju: ");
                olej.Nazwa = Console.ReadLine();

                k.Tresc = "Wybierz rodzaj przekładni";
                if (k.Wyswietl("Manualna", "Automatyczna"))
                {
                    // Dodawanie oleju do przekładni manualnych

                    olej.Przeznaczenie = 0;

                    Menu m = new Menu();
                    List <string> l = new List <string>(3);

                    m.Tytul = "SEZON UŻYTKOWANIA";
                    l.Add("Całoroczny");
                    l.Add("Zimowy");
                    l.Add("Letni");
                    m.Elementy = l;

                    int sezon = m.Wybor();
                    int lepkosc;
                    if (sezon > -1)
                    {
                        switch (sezon)
                        {
                            case 0:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość zimowa: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_zimowa = lepkosc;

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość letnia: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_letnia = lepkosc;

                                break;
                            case 1:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość zimowa: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_zimowa = lepkosc;
                                olej.Lepkosc_letnia = 0;

                                break;
                            case 2:

                                do
                                {
                                    Console.Clear();
                                    Console.Write("Lepkość letnia: ");
                                }
                                while (!Int32.TryParse(Console.ReadLine(), out lepkosc));

                                olej.Lepkosc_letnia = lepkosc;
                                olej.Lepkosc_zimowa = -1;

                                break;
                        }
                    }

                    l.Clear();
                }
                else
                {
                    // Dodawanie oleju do przekładni automatycznych

                    olej.Przeznaczenie = 1;
                }

                oleje.Add(olej);
            }
        }

        // Zrobić własny formularz doboru oleju - wyniki w Menu (wartość zwracana przez metodę Wybor() klasy Menu oznacza pokazanie wybranego oleju)
        // TODO
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
