using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class TerminIznajmljivanja
    {
        public int IdTerminIz {  get; set; }
        public DateTime DatumOd {  get; set; }
        public DateTime DatumDo {  get; set; }
        public Status Status { get; set; }
    }
}
