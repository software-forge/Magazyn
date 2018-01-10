using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazyn
{
    abstract class Produkt
    {
        // Wybrany do usunięcia
        public bool zaznaczony;

        // Wyświetla informacje dot. produktu
        public abstract void Pokaz();
    }
}
