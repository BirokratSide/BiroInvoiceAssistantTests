using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Tests.data;
using Tests.data.structs;

namespace Tests
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
            string file_path = @"C:\Users\Kristijan\Desktop\receipts\andre-leston.pdf";
            AddTestCaseToDatabase(datum_vnosa, zap_st, year_code, file_path);
        }

        public string AddTestCaseToDatabase(string datum_vnosa, short zap_st, string year_code, string file_path) {
            // want to add a new test case - my rachuns from airbnb

            SPostnaKnjiga pk = new SPostnaKnjiga();
            pk.DatumVnosa = datum_vnosa;
            pk.ZapSt = zap_st;
            pk.YearCode = year_code;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] arr = File.ReadAllBytes(file_path);
            string content = Encoding.GetEncoding(1250).GetString(arr);

            SSlike s = new SSlike();
            s.Vsebina = content;
            s.Oznaka = pk.DatumVnosa + " " + pk.ZapSt;
            s.YearCode = year_code;

            pk.SyncId = Guid.NewGuid();
            s.SyncId = Guid.NewGuid();

            birokrat.PostnaKnjiga.Save(pk);
            birokrat.Slike.Save(s);
            return s.Oznaka;
        }
    }
}
