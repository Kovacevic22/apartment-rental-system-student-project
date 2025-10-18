using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Zakupac
    {
        public int IdZakupac {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdMesto { get; set; }
        
        public string ImePrezime => $"{Ime} {Prezime}";
        public override string ToString()
        {
            return ImePrezime;
        }
    }
}
