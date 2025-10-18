using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class StavkaUgovora
    {
        public int IdUgovora { get; set; }
        public int Rb {  get; set; }
        public int IdStan {  get; set; }
        public decimal Iznos { get; set; }
        public Stan Stan { get; set; }
    }
}
