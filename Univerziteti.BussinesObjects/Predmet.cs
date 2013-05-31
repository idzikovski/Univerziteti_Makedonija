using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univerziteti.BussinesObjects
{
    public class Predmet
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        public string Fond { get; set; }
        public int Krediti { get; set; }
        public string Programa { get; set; }
    }
}
