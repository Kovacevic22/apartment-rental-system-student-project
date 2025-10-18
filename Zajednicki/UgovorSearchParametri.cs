using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class UgovorSearchParametri
    {
        public DateTime? datumOd { get; set; }
        public DateTime? datumDo { get; set; }
        public int? idZakupac { get; set; }
        public int? idStanodavac { get; set; }
    }
}
