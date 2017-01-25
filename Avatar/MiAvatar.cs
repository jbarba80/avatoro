using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avatar

{
    class MiAvatar
    {
        int energia;
        int apetito;
        int diversion;

        public int Energia
        {
            get
            {
                return energia;
            }

            set
            {
                energia = value;
            }
        }

        public int Apetito
        {
            get
            {
                return apetito;
            }

            set
            {
                apetito = value;
            }
        }

        public int Diversion
        {
            get
            {
                return diversion;
            }

            set
            {
                diversion = value;
            }
        }

        public MiAvatar(int e, int a, int d)
        {
            Energia = e;
            apetito = a;
            Diversion = d;

        }
    }
}
