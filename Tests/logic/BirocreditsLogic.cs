using System;
using System.Collections.Generic;
using System.Text;
using Tests.data;
using Tests.data.structs;

namespace Tests.logic
{
    public class BirocreditsLogic : IBirocreditsLogic
    {

        CBirokrat birokrat;

        public BirocreditsLogic() {
            birokrat = new CBirokrat(true);
        }

        public void DeleteAllRecordsFromDatabase(string sifra)
        {
            // could be dangerous to delete partners so we'll just delete CRMStrankeOpcije where Aplication = 'RIH'
            Dictionary<string, string> WhereClauses = new Dictionary<string, string>();
            WhereClauses["Aplikacija"] = "RIH";
            List<SCRMStrankeOpcije> lst = birokrat.CrmStrankeOpcije.List(new data.structs.SListRequest(), WhereClauses).data;
            foreach (SCRMStrankeOpcije opcija in lst) {
                birokrat.CrmStrankeOpcije.Delete(opcija);
            }

            WhereClauses = new Dictionary<string, string>();
            WhereClauses["Sifra"] = sifra;
            List<SPartner> me = birokrat.Partner.List(new data.structs.SListRequest(), WhereClauses).data;
            foreach (SPartner p in me)
                if (!birokrat.Partner.Delete(p)) Console.WriteLine("PARTNER NOT DELETED PROBLEM");
        }

        public void InsertPartner(string sifra, string davcnaStevilka)
        {
            // add only if record does not exist yet

            Dictionary<string, string> WhereClauses = new Dictionary<string, string>();
            WhereClauses["DavcnaStevilka"] = davcnaStevilka;
            WhereClauses["Sifra"] = sifra;
            if (birokrat.Partner.List(new SListRequest(), WhereClauses).data.Count > 0) {
                return;
            }

            SPartner partner = new SPartner();
            partner.Sifra = sifra;
            partner.DavcnaStevilka = davcnaStevilka;
            birokrat.Partner.Save(partner);
        }

        public void InsertOpcija(string sifra, string rih, string rihd, float rihk, float rihz, int rihc, string rihp)
        {
            // insert all of these options for the specified partner
            SCRMStrankeOpcije opcija;
            opcija = GetOpcija(sifra, "RIH", rih);
            birokrat.CrmStrankeOpcije.Save(opcija);
            opcija = GetOpcija(sifra, "RIHD", rihd);
            birokrat.CrmStrankeOpcije.Save(opcija);
            opcija = GetOpcija(sifra, "RIHK", rihk.ToString());
            birokrat.CrmStrankeOpcije.Save(opcija);
            opcija = GetOpcija(sifra, "RIHZ", rihz.ToString());
            birokrat.CrmStrankeOpcije.Save(opcija);
            opcija = GetOpcija(sifra, "RIHC", rihc.ToString());
            birokrat.CrmStrankeOpcije.Save(opcija);
            opcija = GetOpcija(sifra, "RIHP", rihp);
            birokrat.CrmStrankeOpcije.Save(opcija);
        }

        private SCRMStrankeOpcije GetOpcija(string sifra, string opcijaName, string vrednost)
        {
            SCRMStrankeOpcije opcija = new SCRMStrankeOpcije();
            opcija.Aktivno = -1;
            opcija.Sifra = sifra;
            opcija.Aplikacija = "RIH";
            opcija.Opcija = opcijaName;
            opcija.Vrednost = vrednost;
            return opcija;
        }
    }
}
