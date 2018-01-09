using System;

namespace Magazyn
{
    class Komunikat
    {
        private string tytul;
        private string tresc;
        private bool odpowiedz;

        public string Tytul
        {
            get => tytul;
            set => tytul = value;
        }
        public string Tresc
        {
            get => tresc;
            set => tresc = value;
        }
        public bool Odpowiedz
        {
            get => odpowiedz;
            set => odpowiedz = value;
        }

        public Komunikat(string tytul, string tresc)
        {
            Tytul = tytul;
            Tresc = tresc;
            Odpowiedz = true;
        }

        public Komunikat(string tytul, string tresc, bool odp_domyslna)
        {
            Tytul = tytul;
            Tresc = tresc;
            Odpowiedz = odp_domyslna;
        }

        // Wyświetla treść komunikatu i czeka na naciśnięcie dowolnego klawisza
        public void Wyswietl()
        {
            Console.Clear();
            Console.CursorVisible = false;

            // Wypisanie tytułu
            Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) - 2);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(tytul.PadRight(50));

            // Wypisanie treści
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            int margines = (50 - tresc.Length) / 2;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) + (-1 + i));

                if (i == 1)
                    Console.WriteLine((tresc.PadLeft(margines + tresc.Length)).PadRight(50));
                else
                    Console.WriteLine("".PadRight(50));
            }

            // Wypisanie instrukcji powrotu
            Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) + 2);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Aby powrócić, naciśnij dowolny klawisz...".PadRight(50));

            Console.ReadKey();

            Console.Clear();
            Console.CursorVisible = true;
            Console.ResetColor();
        }
        
        // Wyswietla treść komunikatu (pytania w formule tak/nie) i zwraca odpowiedź
        public bool Wyswietl(string t, string n)
        {
            Console.Clear();
            Console.CursorVisible = false;
            
            // Wypisanie tytułu
            Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) - 2);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(tytul.PadRight(50));

            // Wypisanie treści
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Cyan;
            int margines = (50 - tresc.Length) / 2;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) + (-1 + i));

                if (i == 1)
                    Console.WriteLine((tresc.PadLeft(margines + tresc.Length)).PadRight(50));
                else
                    Console.WriteLine("".PadRight(50));
            }

            // Wypisanie możliwych odpowiedzi i reakcja na wciśnięcie klawisza
            while (true)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) + 2);

                if(Odpowiedz)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(n.PadRight(25));

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(t.PadRight(25));
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(n.PadRight(25));

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(t.PadRight(25));
                }
                
                ConsoleKeyInfo info = Console.ReadKey();

                switch(info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Odpowiedz = false;
                        break;
                    case ConsoleKey.RightArrow:
                        Odpowiedz = true;
                        break;
                    case ConsoleKey.Enter:
                        Console.CursorVisible = true;
                        Console.ResetColor();
                        Console.Clear();
                        return Odpowiedz;
                }
            }
        }
    }
}
