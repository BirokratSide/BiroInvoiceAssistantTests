using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Web;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

using Tests.helpers;
using Tests.structs;
using Tests.Models;
using Tests.Models1;

namespace Tests
{
    public class HappyPathTest
    {

        TestCaseAdder TestCaseAdder;
        IConfiguration Configuration;
        HttpClient host;
        biro16010264Context context;
        birosideContext contextBiroside;

        public HappyPathTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            // test case adder
            TestCaseAdder = new TestCaseAdder();

            // host
            host = new HttpClient();
            host.BaseAddress = new Uri(Configuration.GetValue<string>("BiroInvoiceAssitant:Endpoint"));

            // database
            context = new biro16010264Context();

            // biroside database
            contextBiroside = new birosideContext();
        }

        public void Start()
        {
            string directory = @"/Users/km/Dropbox/docs/archives/mng/mng/docs/airbnb/racuni";
            string[] fileArray = Directory.GetFiles(directory, "*.pdf");

            // add new records into the database
            string[] oznake = new string[fileArray.Length];
            for (int i = 0; i < fileArray.Length; i++)
            {
                string date = DateTime.Now.ToString("ddMMyy") + "0000";
                oznake[i] = TestCaseAdder.AddTestCaseToDatabase(date, (short)i, "some", fileArray[i]);
            }

            // get the actual records from database
            Slike s = context.Slike.Where((x) => (x.Oznaka == oznake[0])).ToArray()[0];
            StartingRecord record = new StartingRecord("16010264", "who", "cares", s.Oznaka, s.RecNo.ToString(), s.DatumVnosa);

            // Start the processing by the host

            string query = QueryStringConstants.MakeStartQueryString(record);
            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            host.GetAsync(query);


            // verify that they have been processed by Rihard after 30 seconds
            Models1.InvoiceBuffer buf = contextBiroside.InvoiceBuffer.Where((x) => (x.Oznaka == oznake[0])).ToArray()[0];
            AssertProcessed(buf);


            // verify that getting the record locks it
            Models1.InvoiceBuffer buf = ExecLockPhase();
            AssertLocked(null);


            // finish the record and verify that it has been correctly finished
            ExecFinishPhase(buf);
            AssertFinished();
        }

        private void AssertProcessed(Models1.InvoiceBuffer buf) {
            Console.WriteLine("RihNet: " + buf.RihNet);
            Console.WriteLine("RihVat: " + buf.RihVat);
            Console.WriteLine("RihGross: " + buf.RihGross);
            Console.WriteLine("RihInvNum: " + buf.RihInvNum);
            Console.WriteLine("RihReference: " + buf.RihReference);
            Console.WriteLine("RihVatIdBuyer: " + buf.RihVatIdBuyer);
            Console.WriteLine("RihVatIdPublisher: " + buf.RihVatIdPublisher);
        }

        private Models1.InvoiceBuffer ExecLockPhase() {
            string query = QueryStringConstants.MakeGetNextQueryString(5);

            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            string content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Models1.InvoiceBuffer ret = JsonConvert.DeserializeObject<Models1.InvoiceBuffer>(content);

            return ret;
        }

        private void AssertLocked(Models1.InvoiceBuffer rec) {
            
        }

        private void ExecFinishPhase(Models1.InvoiceBuffer ret) {
            // complete the record such that the fields prefixed by Finished are now filled with
            // data
            ret.FinishedBy = 5; // your UserID
            ret.FinishedGross = ret.RihGross;
            ret.FinishedVat = ret.FinishedVat;

            // finish the record via the host
            string content = JsonConvert.SerializeObject(ret);
            QueryStringConstants.PostFinish(content, host);
        }

        private void AssertFinished() {
            
        }
    }
}
