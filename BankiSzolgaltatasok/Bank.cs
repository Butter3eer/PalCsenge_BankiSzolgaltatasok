using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class Bank
    {
        private List<Szamla> szamlaLista;

        public Bank()
        {
            szamlaLista = new List<Szamla>();
        }

        public long OsszHitelkeret
        {
            get
            {
                return szamlaLista.FindAll(x => x is HitelSzamla).Sum(x => (x as HitelSzamla).HitelKeret);
            }
        }

        public Szamla SzamlaNyitas(Tulajdonos tulajdonos, int hitelKeret)
        {
            if (hitelKeret < 0)
            {
                throw new ArgumentException("A hitelkeret nemlehet negatív.");
            }
            else if (hitelKeret == 0)
            {
                Szamla szamla = new MegtakaritasiSzamla(tulajdonos);
                szamlaLista.Add(szamla);
                return szamla;
            }
            else
            {
                Szamla szamla = new HitelSzamla(tulajdonos, hitelKeret);
                szamlaLista.Add(szamla);
                return szamla;
            }
        }

        public long GetOsszEgyenleg(Tulajdonos tulajdonos)
        {
            return szamlaLista.FindAll(x => x.Tulajdonos == tulajdonos).Sum(y => y.AktualisEgyenleg);
        }

        public Szamla GetLegnagyobbEgyenleguSzamla(Tulajdonos tulajdonos)
        {
            return szamlaLista.FindAll(x => x.Tulajdonos == tulajdonos).Find(x => x.AktualisEgyenleg == szamlaLista.FindAll(x => x.Tulajdonos == tulajdonos).Max(x => x.AktualisEgyenleg))!;
        }
    }
}
