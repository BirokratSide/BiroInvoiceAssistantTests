using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using Tests.birotest;
using Microsoft.EntityFrameworkCore;

namespace Tests.logic
{
    class BirotestLogic : IBirocreditsLogic
    {

        BiroInvoiceAssistantTestingOnlyContext context;

        public BirotestLogic() {
            context = new BiroInvoiceAssistantTestingOnlyContext();
        }

        public void DeleteAllRecordsFromDatabase() {
            Partner[] arrp = context.Partner.Where((x) => (int.Parse(x.Sifra) > -1)).ToArray();
            context.Partner.RemoveRange(arrp);

            CrmstrankeOpcije[] arro = context.CrmstrankeOpcije.Where((x) => (x.Aplikacija == "RIH")).ToArray();
            context.CrmstrankeOpcije.RemoveRange(arro);

            context.SaveChanges();
        }

        public void InsertPartner(string sifra, string davcnaStevilka) {
            Partner partner = new Partner();
            partner.Sifra = sifra;
            partner.DavcnaStevilka = davcnaStevilka;
            context.Partner.Add(partner);
            context.SaveChanges();
        }

        public void InsertOpcija(string sifra, bool rih, string rihd, float rihk, float rihz, int rihc, string rihp) {
            // insert all of these options for the specified partner
            CrmstrankeOpcije opcija;
            opcija = GetOpcija(sifra, "RIH", rih.ToString());
            context.CrmstrankeOpcije.Add(opcija);
            opcija = GetOpcija(sifra, "RIHD", rihd);
            context.CrmstrankeOpcije.Add(opcija);
            opcija = GetOpcija(sifra, "RIHK", rihk.ToString());
            context.CrmstrankeOpcije.Add(opcija);
            opcija = GetOpcija(sifra, "RIHZ", rihz.ToString());
            context.CrmstrankeOpcije.Add(opcija);
            opcija = GetOpcija(sifra, "RIHC", rihc.ToString());
            context.CrmstrankeOpcije.Add(opcija);
            opcija = GetOpcija(sifra, "RIHP", rihp);
            context.CrmstrankeOpcije.Add(opcija);
            context.SaveChanges();
        }

        private CrmstrankeOpcije GetOpcija(string sifra, string opcijaName, string vrednost) {
            CrmstrankeOpcije opcija = new CrmstrankeOpcije();
            opcija.Sifra = sifra;
            opcija.Aplikacija = "RIH";
            opcija.Opcija = opcijaName;
            opcija.Vrednost = vrednost;
            return opcija;
        }
    }
}
