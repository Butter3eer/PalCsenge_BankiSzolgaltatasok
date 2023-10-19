﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankiSzolgaltatasok
{
    public class HitelSzamla : Szamla
    {
        private int hitelKeret;

        public HitelSzamla(Tulajdonos tulajdonos, int hitelKeret) : base(tulajdonos)
        {
            this.hitelKeret = hitelKeret;
        }

        public int HitelKeret { get => hitelKeret; }

        public override bool Kivesz(int osszeg)
        {
            if (this.AktualisEgyenleg + hitelKeret >= osszeg)
            {
                aktualisEgyenleg -= osszeg;
                return true;
            }
            return false;
        }
    }
}
