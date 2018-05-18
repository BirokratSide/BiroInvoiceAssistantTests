using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Common.utils;

namespace SystemTests
{
    class SPlacilo
    {
       
            public string vat_id_seller;
            public float gross;
            public string inv_num;
            public string inv_date;
            public string pay_until;
            public string referencepart1;
            public string referencepart2;
            public SSlika slika;
            public string rihardReturn = "";

            // members we want to see on the receipt but are not among rihard returns
            public string VDobroRacuna;
            public string NamenNakazila;

            public SPlacilo() { }
            public SPlacilo(DataRow data)
            {

                // for things to be a little shorter
                Func<int, string> f = delegate (int idx) { return GConv.DbToStr(data[idx]); };

                vat_id_seller = f(0);
                gross = GConv.DbToFloat(data[1]);
                inv_num = data[2].ToString();
                inv_date = f(3);
                pay_until = f(4);
                referencepart1 = f(5);
                referencepart2 = f(6);
                slika = new SSlika(f(8), f(9), f(10), f(7));
                VDobroRacuna = f(11);
                NamenNakazila = f(12);
            }

            public static SPlacilo FromOnlySlikaDataRow(DataRow data)
            {
                SPlacilo placilo = new SPlacilo();
                Func<int, string> f = delegate (int idx) { return GConv.DbToStr(data[idx]); };
                placilo.slika = new SSlika(f(0), f(1), f(2), f(3));
                return placilo;
            }
        }

        [Serializable]
        public class SSlika
        {
            public string oznaka;
            public string recno;
            public string vrsta;
            public string vsebina;

            public SSlika(string oznaka, string recno, string vrsta, string vsebina)
            {
                this.oznaka = oznaka;
                this.recno = recno;
                this.vrsta = vrsta;
                this.vsebina = vsebina;
            }
       }
}
