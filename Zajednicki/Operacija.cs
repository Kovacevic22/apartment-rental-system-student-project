using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Operacija
    {
        //SK-ovi
        PrijaviStanodavac,
        KreirajZakupac,
        PretraziZakupac,
        PromeniZakupac,
        ObrisiZakupac,
        KreirajUgovor,
        PretraziUgovor,
        PromeniUgovor,
        UbaciTerminIznajmljivanja,
        //Dodatne operacije
        VratiSvaMesta,
        VratiSveZakupce,
        VratiSveStanove,
        VratiSveUgovore,
        VratiUgovorSaStavkama,
       
    }
}
