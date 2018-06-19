using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Tests.Models;

namespace Tests
{
    public class TestCaseAdder
    {
        public TestCaseAdder()
        {
        }

        public void AddHardcodedTestCaseToKnjigaPoste()
        {
            // want to add a new test case - my rachuns from airbnb
            biro16010264Context ctx = new biro16010264Context();

            PostnaKnjiga pk = new PostnaKnjiga();
            pk.DatumVnosa = "0406180000";
            pk.ZapSt = 1;
            pk.YearCode = "some";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] arr = File.ReadAllBytes(@"C:\Users\Kristijan\Desktop\receipts\andre-leston.pdf");
            string content = Encoding.GetEncoding(1250).GetString(arr);

            Slike s = new Slike();
            s.Vsebina = content;
            s.Oznaka = pk.DatumVnosa + " " + pk.ZapSt;
            s.YearCode = "some";

            ctx.PostnaKnjiga.Add(pk);
            ctx.Slike.Add(s);
            ctx.SaveChanges();
        }
    }
}
