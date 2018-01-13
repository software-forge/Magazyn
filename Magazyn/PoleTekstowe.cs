using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    class PoleTekstowe
    {
        private string etykieta;

        public PoleTekstowe()
        {
            Etykieta = "";
        }

        public PoleTekstowe(string etykieta)
        {
            Etykieta = etykieta + ":";
        }

        public string Etykieta
        {
            get => etykieta;
            set
            {
                if (value.Length < 24)
                    etykieta = value + ":";
            }
        }

        // Wprowadza łańcuch znaków nie dłuższy niż 24 znaki
        public string WprowadzStringa()
        {
            string s;

            do
            {
                s = "";

                Console.ResetColor();
                Console.Clear();
                
                Console.SetCursorPosition((Console.WindowWidth / 2) - (Etykieta.Length + 12), Console.WindowHeight / 2);
               
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Etykieta);

                int etykieta_lewa = Console.CursorLeft;
                int etykieta_gora = Console.CursorTop;

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);
                Console.Write("".PadLeft(25));
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);

                s = Console.ReadLine();
            }
            while (s.Length > 24);

            Console.ResetColor();
            Console.Clear();

            return s;
        }

        // Wprowadza liczbę całkowitą (na potrzeby tego programu nieujemną i nie dłuższą niż 3 znaki, czyli od 0 do 999)
        public int WprowadzIntegera()
        {
            int liczba;
            bool prawidlowa = false;

            do
            {
                liczba = 0;

                Console.ResetColor();
                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth / 2) - (Etykieta.Length + 12), Console.WindowHeight / 2);

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Etykieta);

                int etykieta_lewa = Console.CursorLeft;
                int etykieta_gora = Console.CursorTop;

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);
                Console.Write("".PadLeft(25));
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);

                string wejscie = Console.ReadLine();
                prawidlowa = Int32.TryParse(wejscie, out liczba) && (wejscie.Length < 4);

                if (liczba < 0)
                    prawidlowa = false;
            }
            while (!prawidlowa);

            Console.ResetColor();
            Console.Clear();

            return liczba;
        }

        // Wprowadza liczbę stałoprzecinkową (na potrzeby tego programu nieujemną i nie dłuższą niż 7 znaków, czyli od 0 do 9999,99)
        public decimal WprowadzDecimala()
        {
            decimal liczba;
            bool prawidlowa = false;

            do
            {
                liczba = 0;

                Console.ResetColor();
                Console.Clear();

                Console.SetCursorPosition((Console.WindowWidth / 2) - (Etykieta.Length + 12), Console.WindowHeight / 2);

                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(Etykieta);

                int etykieta_lewa = Console.CursorLeft;
                int etykieta_gora = Console.CursorTop;

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);
                Console.Write("".PadLeft(25));
                Console.SetCursorPosition(etykieta_lewa, etykieta_gora);

                string wejscie = Console.ReadLine();
                prawidlowa = Decimal.TryParse(wejscie, out liczba) && (wejscie.Length < 8);

                if (liczba < 0)
                    prawidlowa = false;
            }
            while (!prawidlowa);

            Console.ResetColor();
            Console.Clear();

            return liczba;
        }
    }
}
