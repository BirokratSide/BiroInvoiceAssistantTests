using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Tests.data;
using Tests.data.structs;

namespace Tests.logic
{
    public class TestCaseAdder
    {
        CBirokrat birokrat;

        public TestCaseAdder(CBirokrat birokrat) {
            this.birokrat = birokrat;
        }

        public void HardcodedCase() {
            string datum_vnosa = "0406180000";
            short zap_st = 1;
            string year_code = "some";
            string file_path = @"C:/Users/kiki/Desktop/racuni/andre-leston.pdf";
            AddTestCaseToDatabase(datum_vnosa, zap_st, year_code, file_path, "Avansni Racun");
        }

        public SSlike AddTestCaseToDatabase(string datum_vnosa, short zap_st, string year_code, string file_path, string tipposte) {
            // want to add a new test case - my rachuns from airbnb

            SPostnaKnjiga pk = new SPostnaKnjiga();
            pk.Datum = DateTime.Now;
            pk.DatumVnosa = datum_vnosa;
            pk.ZapSt = zap_st;
            pk.YearCode = year_code;
            pk.TipPoste = tipposte;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] arr = File.ReadAllBytes(file_path);
            string content = Encoding.GetEncoding(1250).GetString(arr);

            SSlike s = new SSlike();
            s.Vsebina = content;
            s.Oznaka = pk.DatumVnosa + " " + pk.ZapSt;
            s.YearCode = year_code;
            s.DatumVnosa = datum_vnosa;

            pk.SyncId = Guid.NewGuid();
            s.SyncId = Guid.NewGuid();

            birokrat.PostnaKnjiga.Save(pk);
            birokrat.Slike.Save(s);
            SListRequest lrq = new SListRequest();
            List<SSlike> slklst = birokrat.Slike.List(lrq).data;
            foreach (var x in slklst) {
                if (x.Oznaka == s.Oznaka)
                    return x;
            }
            return null;
        }
    }
}
