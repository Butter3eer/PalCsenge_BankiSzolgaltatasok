using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class MegtakaritasiSzamla : Szamla
    {
        public static double alapKamat;
        private double kamat;

        public MegtakaritasiSzamla(Tulajdonos tulajdonos) : base(tulajdonos)
        {
            alapKamat = 1.1;
            this.kamat = alapKamat;
        }

        public double Kamat { get => kamat; set => kamat = value; }

        public void KamatJovairas()
        {
            this.aktualisEgyenleg = Convert.ToInt32(aktualisEgyenleg * kamat);
        }

        public override bool Kivesz(int osszeg)
        {
            if (aktualisEgyenleg >= osszeg)
            {
                aktualisEgyenleg -= osszeg;
                return true;
            }
            return false;
        }
    }
}
