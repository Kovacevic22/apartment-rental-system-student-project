using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Mesto
    {
        public int IdMesto {  get; set; }
        public string Naziv {  get; set; }
        override public string ToString()
        {
            return Naziv;
        }
    }
}
