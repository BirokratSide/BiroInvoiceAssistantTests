using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Tests.Models;

namespace Tests
{
    public class TestCaseAdder
    {
        public TestCaseAdder() {
        }

        public void HardcodedCase() {
            string datum_vnosa = "0406180000";
            short zap_st = 1;
            string year_code = "some";
            string file_path = @"C:\Users\Kristijan\Desktop\receipts\andre-leston.pdf";
            AddTestCaseToDatabase(datum_vnosa, zap_st, year_code, file_path);
        }

        public void AddTestCaseToDatabase(string datum_vnosa, short zap_st, string year_code, string file_path) {
            // want to add a new test case - my rachuns from airbnb
            biro16010264Context ctx = new biro16010264Context();

            PostnaKnjiga pk = new PostnaKnjiga();
            pk.DatumVnosa = datum_vnosa;
            pk.ZapSt = zap_st;
            pk.YearCode = year_code;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] arr = File.ReadAllBytes(file_path);
            string content = Encoding.GetEncoding(1250).GetString(arr);

            Slike s = new Slike();
            s.Vsebina = content;
            s.Oznaka = pk.DatumVnosa + " " + pk.ZapSt;
            s.YearCode = year_code;

            ctx.PostnaKnjiga.Add(pk);
            ctx.Slike.Add(s);
            ctx.SaveChanges();
        }
    }
}
