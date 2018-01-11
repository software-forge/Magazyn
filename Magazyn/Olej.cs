using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    abstract class Olej
    {
        // informacja o typie oleju dostępna przez GetType()
        
        // Informacje o produkcie
        string nazwa, producent, kod;   // nazwa produktu, nazwa producenta, kod produktu
        int regal, segment, polka;      // lokalizacja w magazynie

        // Informacje o stanie magazynowym i cenie
        int ilosc_jednost;              // ilość jednostek na magazynie
        decimal poje_jedn;              // pojemność (w litrach) jednej jednostki sprzedaży oleju (butelki, kanistra itp.)
        decimal cena_jedn;              // cena za jedną jednostkę

        // Informacja o przeznaczeniu oleju samochodowy/motocyklowy/inny lub do przekładni manualnej/automatycznej
        protected int przeznaczenie;

        public int Ilosc_jednost
        {
            get => ilosc_jednost;
            protected set => ilosc_jednost = value; // ???
        }

        public Olej()
        {

        }

        public virtual void Pokaz()
        {
            Console.Clear();
            Console.WriteLine("Nazwa: " + nazwa);
            Console.WriteLine("Producent: " + producent);
            Console.WriteLine("Kod produktu: " + kod);
            Console.WriteLine("Lokalizacja w magazynie: {0} regał, {1} segment, {2} półka", regal, segment, polka);
            Console.WriteLine("Dostępnych: {0} sztuk", Ilosc_jednost);
            Console.WriteLine("Cena: {0} PLN/szt.", cena_jedn);
            Console.WriteLine("Pojemność opakowania: {0} l", poje_jedn);
        }
    }
}
