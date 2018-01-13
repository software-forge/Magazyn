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
        public static void Dodaj()
        {
            Komunikat k = new Komunikat("Dodawanie nowego oleju (anuluj - Esc)", "");
            k.Tresc = "Kontynuować?";

            int dalej = k.Wyswietl("Dalej", "Anuluj", true);

            if (dalej == 0 || dalej == -1)
                return;

            PoleTekstowe p = new PoleTekstowe();

            int pojemnosc;
            decimal cena;

            p.Etykieta = "Pojemność opakowania";
            pojemnosc = p.WprowadzIntegera();

            p.Etykieta = "Cena opakowania";
            cena = p.WprowadzDecimala();

            k.Tresc = "Olej silnikowy czy przekładniowy?";
            int wybor = k.Wyswietl("Silnikowy", "Przekładniowy", true);

            if (wybor == -1)
                return;

            if (wybor == 1)
            {
                // Dodawanie oleju silnikowego

                k.Tresc = "Wybierz typ silnika";
                wybor = k.Wyswietl("Czterosuwowy", "Dwusuwowy", true);

                if (wybor == -1)
                    return;

                if (wybor == 1)
                {
                    // Dodawanie oleju do silnika 4T
                    Olej4T olej;

                    Menu m = new Menu();
                    List<string> l = new List<string>(3);

                    m.Tytul = "SEZON UŻYTKOWANIA (anuluj - Esc)";
                    l.Add("Całoroczny");
                    l.Add("Zimowy");
                    l.Add("Letni");
                    m.Elementy = l;

                    int lepkosc_z = -1;
                    int lepkosc_l = -1;

                    int sezon = m.Wybor();
                    if (sezon > -1)
                    {
                        switch (sezon)
                        {
                            case 0:
                                p.Etykieta = "Lepkość zimowa";
                                lepkosc_z = p.WprowadzIntegera();
                                p.Etykieta = "Lepkość letnia";
                                lepkosc_l = p.WprowadzIntegera();
                                break;
                            case 1:
                                p.Etykieta = "Lepkość zimowa";
                                lepkosc_z = p.WprowadzIntegera();
                                break;
                            case 2:
                                p.Etykieta = "Lepkość letnia";
                                lepkosc_l = p.WprowadzIntegera();
                                break;
                        }
                    }
                    else
                        return;

                    if(lepkosc_z > -1 && lepkosc_l > -1)
                        olej = new Olej4T(pojemnosc, cena, lepkosc_z, lepkosc_l);
                    else
                    {
                        if(lepkosc_z > -1)
                            olej = new Olej4T(pojemnosc, cena, lepkosc_z, true);
                        else
                            olej = new Olej4T(pojemnosc, cena, lepkosc_l, false);
                    }

                    l.Clear();

                    p.Etykieta = "Producent";
                    olej.Producent = p.WprowadzStringa();

                    p.Etykieta = "Nazwa oleju";
                    olej.Nazwa = p.WprowadzStringa();

                    m.Tytul = "PRZEZNACZENIE OLEJU (anuluj - Esc)";
                    l.Add("Samochody");
                    l.Add("Motocykle");
                    l.Add("Inne");
                    m.Elementy = l;

                    int przeznaczenie = m.Wybor();
                    if (przeznaczenie > -1)
                        olej.Przeznaczenie = przeznaczenie;
                    else
                        return;

                    l.Clear();

                    m.Tytul = "TYP OLEJU (anuluj - Esc)";
                    l.Add("Mineralny");
                    l.Add("Półsyntetyczny");
                    l.Add("Syntetyczny");
                    m.Elementy = l;

                    int typ = m.Wybor();
                    if (typ > -1)
                        olej.Typ = typ;
                    else
                        return;

                    l.Clear();

                    oleje.Add(olej);
                }
                else
                {
                    // Dodawanie oleju do silnika 2T

                    Olej2T olej = new Olej2T(pojemnosc, cena);
                    
                    p.Etykieta = "Producent";
                    olej.Producent = p.WprowadzStringa();

                    p.Etykieta = "Nazwa oleju";
                    olej.Nazwa = p.WprowadzStringa();

                    k.Tresc = "Wybierz przeznaczenie oleju (anuluj - Esc)";
                    wybor = k.Wyswietl("Motocyklowy", "Inny", true);

                    if (wybor == -1)
                        return;

                    if (wybor == 1)
                        olej.Przeznaczenie = 0;
                    else
                        olej.Przeznaczenie = 1;

                    oleje.Add(olej);
                }
            }
            else
            {
                // Dodawanie oleju przekładniowego

                OlejPrzekladniowy olej;

                k.Tresc = "Wybierz rodzaj przekładni";
                wybor = k.Wyswietl("Manualna", "Automatyczna", true);

                if (wybor == -1)
                    return;

                if (wybor == 1) 
                {
                    // Dodawanie oleju do przekładni manualnych

                    Menu m = new Menu();
                    List<string> l = new List<string>(3);

                    m.Tytul = "SEZON UŻYTKOWANIA (anuluj - Esc)";
                    l.Add("Całoroczny");
                    l.Add("Zimowy");
                    l.Add("Letni");
                    m.Elementy = l;

                    int lepkosc_z = -1;
                    int lepkosc_l = -1;

                    int sezon = m.Wybor();
                    if (sezon > -1)
                    {
                        switch (sezon)
                        {
                            case 0:

                                p.Etykieta = "Lepkość zimowa";
                                lepkosc_z = p.WprowadzIntegera();

                                p.Etykieta = "Lepkość letnia";
                                lepkosc_l = p.WprowadzIntegera();

                                break;
                            case 1:

                                p.Etykieta = "Lepkość zimowa";
                                lepkosc_z = p.WprowadzIntegera();

                                break;
                            case 2:

                                p.Etykieta = "Lepkość letnia";
                                lepkosc_l = p.WprowadzIntegera();

                                break;
                        }

                        if (lepkosc_z > -1 && lepkosc_l > -1)
                            olej = new OlejPrzekladniowy(pojemnosc, cena, lepkosc_z, lepkosc_l);
                        else
                        {
                            if (lepkosc_z > -1)
                                olej = new OlejPrzekladniowy(pojemnosc, cena, lepkosc_z, true);
                            else
                                olej = new OlejPrzekladniowy(pojemnosc, cena, lepkosc_l, false);
                        }
                    }
                    else
                        return;

                    l.Clear();
                }
                else
                {
                    // Dodawanie oleju do przekładni automatycznych

                    olej = new OlejPrzekladniowy(pojemnosc, cena);
                }

                p.Etykieta = "Producent";
                olej.Producent = p.WprowadzStringa();

                p.Etykieta = "Nazwa oleju";
                olej.Nazwa = p.WprowadzStringa();

                oleje.Add(olej);
            }
        }

        // Zrobić własny formularz doboru oleju - wyniki w Menu (wartość zwracana przez metodę Wybor() klasy Menu oznacza pokazanie wybranego oleju)
        // TODO - pod koniec, jak starczy czasu
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
