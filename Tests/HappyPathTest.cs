using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Web;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading;

using Tests.helpers;
using Tests.structs;
using Tests.Models1;

namespace Tests
{
    public class HappyPathTest
    {

        TestCaseAdder TestCaseAdder;
        IConfiguration Configuration;
        HttpClient host;
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
            host.BaseAddress = new Uri(Configuration.GetValue<string>("BiroInvoiceAssistant:Endpoint"));

            // database
            //context = new biro16010264Context();

            // biroside database
            contextBiroside = new birosideContext();
        }

        public void Start()
        {
            string[] oznake = InsertNewTestCasesToDatabaseKPAndSlike();

            StartRecordsHost(oznake);

            Thread.Sleep(5000);

            AssertAllRecordsProcessed(oznake);

            for (int i = 0; i < oznake.Length; i++) {
                Models1.InvoiceBuffer buf = GetNextRecord();
                buf = AssertLocked(buf);

                FinishRecord(buf);
                AssertFinished(buf);
            }
        }

        #region [private]
        private string[] InsertNewTestCasesToDatabaseKPAndSlike() {
            string directory = Configuration.GetValue<string>("HappyPathInputDirectory");
            string[] fileArray = Directory.GetFiles(directory, "*.pdf");

            // add new records into the database
            string[] oznake = new string[fileArray.Length];
            for (int i = 0; i < fileArray.Length; i++)
            {
                string date = DateTime.Now.ToString("ddMMyy") + "0000";
                oznake[i] = TestCaseAdder.AddTestCaseToDatabase(date, (short)i, "some", fileArray[i]);
            }
            return oznake;
        }

        private void StartRecordsHost(string[] oznake) {
            for (int i = 0; i < oznake.Length; i++)
            {
                Slike s = context.Slike.Where((x) => (x.Oznaka == oznake[i])).ToArray()[0];
                StartingRecord record = new StartingRecord("16010264", "who", "cares", s.Oznaka, s.RecNo.ToString(), s.DatumVnosa);
                string query = QueryStringConstants.MakeStartQueryString(record);
                HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            }
        }

        private void AssertAllRecordsProcessed(string[] oznake) {
            foreach (string oznaka in oznake)
            {
                Models1.InvoiceBuffer bufferRecord = contextBiroside.InvoiceBuffer.Where((x) => (x.Oznaka == oznaka)).ToArray()[0];
                AssertProcessed(bufferRecord);
            }
        }

        private void AssertProcessed(Models1.InvoiceBuffer buf)
        {
            Console.WriteLine("RihNet: " + buf.RihNet);
            Console.WriteLine("RihVat: " + buf.RihVat);
            Console.WriteLine("RihGross: " + buf.RihGross);
            Console.WriteLine("RihInvNum: " + buf.RihInvNum);
            Console.WriteLine("RihReference: " + buf.RihReference);
            Console.WriteLine("RihVatIdBuyer: " + buf.RihVatIdBuyer);
            Console.WriteLine("RihVatIdPublisher: " + buf.RihVatIdPublisher);
        }

        private Models1.InvoiceBuffer GetNextRecord()
        {
            string query = QueryStringConstants.MakeGetNextQueryString(5);

            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            string content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Models1.InvoiceBuffer ret = JsonConvert.DeserializeObject<Models1.InvoiceBuffer>(content);

            return ret;
        }

        private Models1.InvoiceBuffer AssertLocked(Models1.InvoiceBuffer rec)
        {
            string Oznaka = rec.Oznaka;
            rec = contextBiroside.InvoiceBuffer.Where((x) => (x.Oznaka == Oznaka)).First();
            if (rec.LockedBy != null && rec.LockedTime != null)
            {
                Console.WriteLine("AssertLocked: Passed");
            } else {
                throw new Exception("LockedBy or LockedTime were null during AssertLocked!");
            }
            return rec;
        }

        private void FinishRecord(Models1.InvoiceBuffer rec)
        {
            // complete the record such that the fields prefixed by Finished are now filled with
            // data
            rec.FinishedBy = 5; // your UserID
            rec.FinishedGross = rec.RihGross;
            rec.FinishedVat = rec.FinishedVat;

            // finish the record via the host
            string content = JsonConvert.SerializeObject(rec);
            QueryStringConstants.PostFinish(content, host);
        }

        private void AssertFinished(Models1.InvoiceBuffer rec)
        {
            string Oznaka = rec.Oznaka;

            Models1.InvoiceBuffer[] array = contextBiroside.InvoiceBuffer.Where((x) => (x.Oznaka == Oznaka)).ToArray();
            if (array.Length == 0) {
                Console.WriteLine("AssertFinished-DeleteInvoiceBufferRecord: PASSED");
            } else {
                throw new Exception("The invoice buffer was not deleted on finish!!!");
            }

            BufferHistoryLog log = contextBiroside.BufferHistoryLog.Where((x) => (x.Oznaka == Oznaka)).First();
            if (log.FinishedBy != null && log.FinishedTime != null)
            {
                Console.WriteLine("AssertFinished: Passed");
            }
            else
            {
                throw new Exception("FinishedBy or FinishedTime were null during AssertFinished!");
            }
        }
        #endregion
    }
}
