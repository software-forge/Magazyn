using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

            // Dodatkowe ustawienia odczytu
            XmlReaderSettings s = new XmlReaderSettings();

            XmlReader r = XmlReader.Create("oleje.xml", s);

            while(r.Read())
            {
                Olej olej;

                int lepkosc_z;
                int lepkosc_l;

                if(r.NodeType == XmlNodeType.Element)
                {
                    if (r.Name.Equals("olej_2t"))
                    {
                        olej = new Olej2T(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")));
                        olej.Producent = r.GetAttribute("producent");
                        olej.Nazwa = r.GetAttribute("nazwa");

                        if (r.GetAttribute("przeznaczenie").Equals("motocykle/motorowery"))
                            olej.Przeznaczenie = 0;
                        else
                            olej.Przeznaczenie = 1;

                        oleje.Add(olej);
                    }
                    if (r.Name.Equals("olej_4t"))
                    {
                        lepkosc_z = Convert.ToInt16(r.GetAttribute("lepkosc_zimowa"));
                        lepkosc_l = Convert.ToInt16(r.GetAttribute("lepkosc_letnia"));

                        if (lepkosc_z > -1 && lepkosc_l > -1)
                            olej = new Olej4T(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_z, lepkosc_l);
                        else
                        {
                            if (lepkosc_z > -1)
                                olej = new Olej4T(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_z, true);
                            else
                                olej = new Olej4T(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_l, false);
                        }

                        olej.Producent = r.GetAttribute("producent");
                        olej.Nazwa = r.GetAttribute("nazwa");

                        string przeznaczenie = r.GetAttribute("przeznaczenie");

                        if (przeznaczenie.Equals("samochody"))
                            olej.Przeznaczenie = 0;

                        if (przeznaczenie.Equals("motocykle"))
                            olej.Przeznaczenie = 1;

                        if(przeznaczenie.Equals("inne"))
                            olej.Przeznaczenie = 2;

                        string typ = r.GetAttribute("typ");

                        if (typ.Equals("mineralny"))
                            olej.Typ = 0;

                        if (typ.Equals("półsyntetyczny"))
                            olej.Typ = 1;

                        if (typ.Equals("syntetyczny"))
                            olej.Typ = 2;

                        oleje.Add(olej);
                    }
                    if (r.Name.Equals("olej_przekladniowy"))
                    {
                        lepkosc_z = Convert.ToInt16(r.GetAttribute("lepkosc_zimowa"));
                        lepkosc_l = Convert.ToInt16(r.GetAttribute("lepkosc_letnia"));

                        if (lepkosc_z > -1 && lepkosc_l > -1)
                            olej = new OlejPrzekladniowy(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_z, lepkosc_l);
                        else
                        {
                            if (lepkosc_z > -1)
                                olej = new OlejPrzekladniowy(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_z, true);
                            else
                                olej = new OlejPrzekladniowy(Convert.ToInt16(r.GetAttribute("pojemnosc")), Convert.ToDecimal(r.GetAttribute("cena")), lepkosc_l, false);
                        }

                        olej.Producent = r.GetAttribute("producent");
                        olej.Nazwa = r.GetAttribute("nazwa");

                        string przeznaczenie = r.GetAttribute("przeznaczenie");

                        if (przeznaczenie.Equals("przekładnie manualne"))
                            olej.Przeznaczenie = 0;

                        if (przeznaczenie.Equals("przekładnie automatyczne"))
                            olej.Przeznaczenie = 1;

                        oleje.Add(olej);
                    }
                }
            }

            r.Close();
        }

        // Zapisywanie do xml
        public static void Zapisz()
        {
            XmlWriterSettings s = new XmlWriterSettings();
            s.Indent = true;
            s.IndentChars = "\t";
            s.NewLineOnAttributes = true;

            XmlWriter w = XmlWriter.Create("oleje.xml", s);

            w.WriteStartDocument();
            w.WriteStartElement("oleje");

            foreach (Olej o in oleje)
            {
                if (o.GetType() == typeof(Olej2T))
                {
                    w.WriteStartElement("olej_2t");
                    w.WriteAttributeString("producent", o.Producent);
                    w.WriteAttributeString("nazwa", o.Nazwa);
                    w.WriteAttributeString("pojemnosc", Convert.ToString(o.Pojemnosc));
                    w.WriteAttributeString("cena", Convert.ToString(o.Cena));

                    if(o.Przeznaczenie == 0)
                        w.WriteAttributeString("przeznaczenie", "motocykle/motorowery");
                    else
                        w.WriteAttributeString("przeznaczenie", "inne");

                    w.WriteEndElement();
                }
                if (o.GetType() == typeof(Olej4T))
                {
                    w.WriteStartElement("olej_4t");
                    w.WriteAttributeString("producent", o.Producent);
                    w.WriteAttributeString("nazwa", o.Nazwa);
                    w.WriteAttributeString("pojemnosc", Convert.ToString(o.Pojemnosc));
                    w.WriteAttributeString("cena", Convert.ToString(o.Cena));

                    if (o.Przeznaczenie == 0)
                        w.WriteAttributeString("przeznaczenie", "samochody");
                    else if (o.Przeznaczenie == 1)
                        w.WriteAttributeString("przeznaczenie", "motocykle");
                    else
                        w.WriteAttributeString("przeznaczenie", "inne");

                    if(o.Typ == 0)
                        w.WriteAttributeString("typ", "mineralny");
                    else if(o.Typ == 1)
                        w.WriteAttributeString("typ", "półsyntetyczny");
                    else
                        w.WriteAttributeString("typ", "syntetyczny");

                    w.WriteAttributeString("lepkosc_zimowa", Convert.ToString(o.Lepkosc_zimowa));
                    w.WriteAttributeString("lepkosc_letnia", Convert.ToString(o.Lepkosc_letnia));

                    w.WriteEndElement();
                }
                if (o.GetType() == typeof(OlejPrzekladniowy))
                {
                    w.WriteStartElement("olej_przekladniowy");
                    w.WriteAttributeString("producent", o.Producent);
                    w.WriteAttributeString("nazwa", o.Nazwa);
                    w.WriteAttributeString("pojemnosc", Convert.ToString(o.Pojemnosc));
                    w.WriteAttributeString("cena", Convert.ToString(o.Cena));

                    if (o.Przeznaczenie == 0)
                    {
                        w.WriteAttributeString("przeznaczenie", "przekładnie manualne");
                        w.WriteAttributeString("lepkosc_zimowa", Convert.ToString(o.Lepkosc_zimowa));
                        w.WriteAttributeString("lepkosc_letnia", Convert.ToString(o.Lepkosc_letnia));
                    }
                    else
                        w.WriteAttributeString("przeznaczenie", "przekładnie automatyczne");

                    w.WriteEndElement();
                }
            }

            w.WriteEndElement();
            w.WriteEndDocument();

            w.Close();
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
                        if (oleje[wybor].Usunac())
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

        // Dobór oleju wg. podanego przeznaczenia, parametrów i maksymalnej ceny
        public static void Dobierz()
        {
            List<Olej> dobrane = new List<Olej>();

            Komunikat k = new Komunikat("DOBÓR OLEJU (anuluj - Esc)", "Wybierz rodzaj oleju");
            int odpowiedz = k.Wyswietl("SILNIKOWY", "PRZEKŁADNIOWY", true);

            PoleTekstowe p = new PoleTekstowe("Cena maksymalna");

            if (odpowiedz == -1)
                return;

            if(odpowiedz == 1)
            {
                // Dobór oleju silnikowego

                Menu m = new Menu();
                List<string> l = new List<string>();
                

                // 1. Przeznaczenie
                l.Add("Samochody");
                l.Add("Motocykle");
                l.Add("Inne");

                m.Tytul = "PRZEZNACZENIE (anuluj - Esc)";
                m.Elementy = l;

                int przeznaczenie = m.Wybor();

                l.Clear();

                if (przeznaczenie == -1)
                    return;

                if(przeznaczenie == 0)
                {
                    // Samochodowe, więc tylko 4T

                    // 2. minerał/półsyntetyk/syntetyk
                    l.Add("Mineralny");
                    l.Add("Półsyntetyczny");
                    l.Add("Syntetyczny");

                    m.Tytul = "TYP (anuluj - Esc)";
                    m.Elementy = l;

                    int typ = m.Wybor();

                    l.Clear();

                    if (typ == -1)
                        return;

                    // 3. cena maksymalna
                    decimal cena = p.WprowadzDecimala();

                    // przeszukanie listy
                    foreach (Olej o in oleje)
                        if ((o.GetType() == typeof(Olej4T)) && (o.Przeznaczenie == 0) && (o.Typ == typ) && (o.Cena <= cena))
                            dobrane.Add(o);
                }

                if(przeznaczenie == 1)
                {
                    // Motocyklowe, więc 4T i 2T

                    // 2. dwusuw/czterosuw
                    k.Tresc = "Wybierz typ silnika";
                    int silnik = k.Wyswietl("Czterosuw", "Dwusuw", true);

                    if (silnik == -1)
                        return;

                    // 3. cena maksymalna
                    decimal cena = p.WprowadzDecimala();

                    // przeszukanie listy
                    if(silnik == 1)
                    {
                        // Czterosuwy
                        foreach (Olej o in oleje)
                            if ((o.GetType() == typeof(Olej4T)) && (o.Przeznaczenie == 1) && (o.Cena <= cena))
                                dobrane.Add(o);
                    }

                    if(silnik == 0)
                    {
                        // Dwusuwy
                        foreach (Olej o in oleje)
                            if ((o.GetType() == typeof(Olej2T)) && (o.Przeznaczenie == 1) && (o.Cena <= cena))
                                dobrane.Add(o);
                    }
                }

                if (przeznaczenie == 2)
                {
                    // Inne (wszystkie 2T i 4T)

                    decimal cena = p.WprowadzDecimala();

                    // przeszukanie listy
                    foreach (Olej o in oleje)
                    {
                        if ((o.GetType() == typeof(Olej4T)) && (o.Przeznaczenie == 2) && (o.Cena <= cena))
                            dobrane.Add(o);
                        if ((o.GetType() == typeof(Olej2T)) && (o.Przeznaczenie == 1) && (o.Cena <= cena))
                            dobrane.Add(o);
                    }
                }
            }
            else
            {
                // Dobór oleju przekładniowego

                k.Tresc = "Wybierz typ przekładni";
                odpowiedz = k.Wyswietl("MANUALNA", "AUTOMATYCZNA", true);

                if (odpowiedz == -1)
                    return;

                decimal cena = p.WprowadzDecimala();

                if (odpowiedz == 1)
                {
                    // Dobór oleju do skrzyni manualnej

                    foreach (Olej o in oleje)
                        if ((o.GetType() == typeof(OlejPrzekladniowy)) && (o.Przeznaczenie == 0) && (o.Cena <= cena))
                            dobrane.Add(o);
                }
                else
                {
                    // Dobór oleju do skrzyni automatycznej

                    foreach (Olej o in oleje)
                        if ((o.GetType() == typeof(OlejPrzekladniowy)) && (o.Przeznaczenie == 1) && (o.Cena <= cena))
                            dobrane.Add(o);
                }
            }

            // Prezentacja wyników:
            List<string> nazwy_wynikow = new List<string>();
            foreach(Olej o in dobrane)
            {
                string nazwa = o.Producent + " " + o.Nazwa;
                nazwy_wynikow.Add(nazwa);
            }
            nazwy_wynikow.Add("Powrót");

            Menu wyniki = new Menu("WYNIKI (powrót - Esc)", nazwy_wynikow);

            // Komunikat, jeżeli nie znaleziono olejów o zadanych kryteriach
            if(dobrane.Count == 0)
            {
                k.Tytul = "DOBÓR OLEJU";
                k.Tresc = "Nie znaleziono olejów o podanych kryteriach";
                k.Wyswietl();
                return;
            }
            
            // Wyświetlenie wyszukanych olejów w Menu
            while(true)
            {
                int  wybrany = wyniki.Wybor();

                if (wybrany == -1 || wybrany == (nazwy_wynikow.Count - 1))
                    break;

                // Tą metodę trzeba przeciążyć
                dobrane[wybrany].Prezentuj();
            }
        }
    }
}
