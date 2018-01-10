using System;

namespace Magazyn
{
    class Komunikat
    {
        private string tytul;
        private string tresc;
        
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

        private bool odpowiedz;

        public Komunikat()
        {
            Tytul = "";
            Tresc = "";
            odpowiedz = true;
        }

        public Komunikat(string tytul, string tresc)
        {
            Tytul = tytul;
            Tresc = tresc;
            odpowiedz = true;
        }

        public Komunikat(string tytul, string tresc, bool odp_domyslna)
        {
            Tytul = tytul;
            Tresc = tresc;
            odpowiedz = odp_domyslna;
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
        public bool Wyswietl(string tak, string nie)
        {
            Console.CursorVisible = false;

            // Wypisanie możliwych odpowiedzi i reakcja na wciśnięcie klawisza
            while (true)
            {
                Console.Clear();

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

                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) + 2);

                if(odpowiedz)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(nie.PadRight(25));

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(tak.PadRight(25));
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(nie.PadRight(25));

                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(tak.PadRight(25));
                }
                
                ConsoleKeyInfo info = Console.ReadKey();
                Console.ResetColor();

                switch(info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        odpowiedz = false;
                        break;
                    case ConsoleKey.RightArrow:
                        odpowiedz = true;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 0);
                        Console.CursorVisible = true;
                        return odpowiedz;
                }
            }
        }
    }
}
