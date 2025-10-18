using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Ugovor
    {
        public int IdUgovor {  get; set; }
        public DateTime DatumOd {  get; set; }
        public DateTime DatumDo { get; set; }
        public int IdStanodavac {  get; set; }
        public int IdZakupac { get; set; }
        public List<StavkaUgovora> StavkeUgovora { get; set; } = new List<StavkaUgovora>();

        //Za prikaz
        public string StanodavacImePrezime { get; set; }
        public string ZakupacImePrezime { get; set; }
        public decimal UkupanIznos { get; set; }    
        public decimal Iznos => (StavkeUgovora?.Count>0)?StavkeUgovora.Sum(s=>s.Iznos):(UkupanIznos>0?UkupanIznos:0);

    }
}
