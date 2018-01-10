using System;
using System.Collections.Generic;

namespace Magazyn
{
    class Menu
    {
        private string tytul;
        private List <string> elementy;

        public string Tytul
        {
            get => tytul;
            set => tytul = value;
        }
        public List <string> Elementy
        {
            get => elementy;
            set => elementy = value;
        }

        private int zaznaczony;

        public Menu(string tytul, List <string> elementy)
        {
            Tytul = tytul;
            Elementy = elementy;
        }

        public Menu(string tytul, List <string> elementy, int domyslny)
        {
            Tytul = tytul;
            Elementy = elementy;
            zaznaczony = domyslny;
        }

        // Wyświetla menu, oczekuje na wybór i zwraca wybraną wartość
        public int Wybor()
        {
            Console.CursorVisible = false;

            while(true)
            {
                Console.Clear();
                
                Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) - (Elementy.Count / 2) - 1);
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Tytul.PadRight(50));

                for (int i = 0; i < Elementy.Count; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 25, (Console.WindowHeight / 2) - ((Elementy.Count / 2) - i));

                    if (i == zaznaczony)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine(Elementy[i].PadRight(50));
                }

                ConsoleKeyInfo info = Console.ReadKey();
                Console.ResetColor();

                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (zaznaczony > 0)
                            zaznaczony--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (zaznaczony < Elementy.Count - 1)
                            zaznaczony++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.ResetColor();
                        Console.SetCursorPosition(0, 0);
                        Console.CursorVisible = true;
                        return zaznaczony;
                }
            }
        }
    }
}
