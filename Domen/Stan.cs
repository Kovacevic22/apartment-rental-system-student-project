using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Stan
    {
        public int IdStan {  get; set; }
        public string Adresa { get; set; }
        public int Povrsina { get; set; }
        public TipStana TipStana { get; set; }
        public double BrojSoba { get; set; }

        public override string ToString()
        {
            return Adresa;
        }

    }
}
