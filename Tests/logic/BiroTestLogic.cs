using System;
using System.Collections.Generic;
using System.Text;

using Tests.birotest;

namespace Tests.logic
{
    class BirotestLogic : IBirotestLogic
    {

        BiroInvoiceAssistantTestingOnlyContext context;

        public BirotestLogic() {
            context = new BiroInvoiceAssistantTestingOnlyContext();
        }

        public void DeleteAllRecordsFromDatabase() {
            // remove all partners
            context.Partner.RemoveRange(context.Partner);
            // remove all options
            context.CrmstrankeOpcije.RemoveRange(context.CrmstrankeOpcije);
        }

        public void InsertPartner(string sifra, string davcnaStevilka) {
            Partner partner = new Partner();
            partner.Sifra = sifra;
            partner.DavcnaStevilka = davcnaStevilka;
            context.Add(partner);
            context.SaveChanges();
        }

        public void InsertOpcija(string sifra, bool rih, string rihd, float rihk, float rihz, int rihc, string rihp) {
            // insert all of these options for the specified partner
            CrmstrankeOpcije opcija = GetOpcija(sifra, "RIH", rih.ToString());
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
