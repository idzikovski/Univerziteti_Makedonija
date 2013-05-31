using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univerziteti.BussinesObjects
{
    public class Vraboten
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public int KontaktId { get; set; }
    }
}
