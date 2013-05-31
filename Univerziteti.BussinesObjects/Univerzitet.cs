using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Univerziteti.BussinesObjects
{
    public class Univerzitet
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        public string Slika { get; set; }
        public int Rektor { get; set; }
        public int KontaktId { get; set; }
        public List<Fakultet> Fakulteti { get; set; }
    }
}
