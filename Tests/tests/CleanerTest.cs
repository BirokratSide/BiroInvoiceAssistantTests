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

using Tests.data;
using Tests.host_client;
using Tests.logic;
using Tests.data.structs;
using Tests.entity_framework;
using System.Collections.Generic;

namespace Tests.tests
{
    public class CleanerTest
    {

        IConfiguration Configuration;

        BIAHostClient client;
        BirokratLogic birokrat;
        BirosideLogic biroside;

        string company_id;
        string company_year;
        int user_id;

        public CleanerTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            client = new BIAHostClient();
            birokrat = new BirokratLogic();
            biroside = new BirosideLogic();
            company_id = Configuration.GetValue<string>("Database:company_id");
            company_year = Configuration.GetValue<string>("Database:company_year");
            user_id = 5;
        }

        public void Start()
        {
            birokrat.DeleteAllTestRecords(company_year);
            biroside.DeleteAllTestRecords(company_year);
            string[] oznake = birokrat.AddTestRecordsToDatabase(company_year, "Avansni Racun");

            client.SetProcessAutomaticSwitch(false);
            client.SetUnlockedThreshold(180);

            StartRecordsHost(oznake);

            Thread.Sleep(60 * 1000);

            StartRecordsHost(oznake);

            // now verify that half the records get cleaned and half don't
        }

        #region [private]
        private void StartRecordsHost(string[] oznake)
        {

            List<SSlike> data = birokrat.GetAllSlike(company_year);
            for (int i = 0; i < oznake.Length; i++)
            {
                SSlike slk = data.Where((x) => (x.Oznaka == oznake[i])).ToArray()[0];

                StartingRecord record = new StartingRecord(company_id, company_year, slk.Oznaka, slk.RecNo.ToString(), slk.DatumVnosa);
                HttpResponseMessage msg = client.Start(record);
            }
        }

        private void AssertAllRecordsProcessed(string[] oznake)
        {
            foreach (string oznaka in oznake)
            {
                entity_framework.InvoiceBuffer bufferRecord = biroside.biroside.InvoiceBuffer.Where((x) => (x.Oznaka == oznaka)).ToArray()[0];
                AssertProcessed(bufferRecord);
            }
        }

        private void AssertProcessed(entity_framework.InvoiceBuffer buf)
        {
            Console.WriteLine("RihNet: " + buf.RihNet);
            Console.WriteLine("RihVat: " + buf.RihVat);
            Console.WriteLine("RihGross: " + buf.RihGross);
            Console.WriteLine("RihInvNum: " + buf.RihInvNum);
            Console.WriteLine("RihReference: " + buf.RihReference);
            Console.WriteLine("RihVatIdBuyer: " + buf.RihVatIdBuyer);
            Console.WriteLine("RihVatIdPublisher: " + buf.RihVatIdPublisher);
        }

        private entity_framework.InvoiceBuffer AssertLocked(entity_framework.InvoiceBuffer rec)
        {
            string Oznaka = rec.Oznaka;
            entity_framework.InvoiceBuffer kur = biroside.biroside.InvoiceBuffer.Where((x) => (x.Oznaka == Oznaka)).First();
            if (rec.LockedBy != null && rec.LockedTime != null)
            {
                Console.WriteLine("AssertLocked: Passed");
            }
            else
            {
                throw new Exception("LockedBy or LockedTime were null during AssertLocked!");
            }
            return rec;
        }

        private void FinishRecord(entity_framework.InvoiceBuffer rec)
        {
            // complete the record such that the fields prefixed by Finished are now filled with
            // data
            rec.FinishedBy = user_id; // your UserID
            rec.FinishedGross = rec.RihGross;
            rec.FinishedVat = rec.FinishedVat;

            // finish the record via the host
            client.Finish(rec);
        }

        private void AssertFinished(entity_framework.InvoiceBuffer rec)
        {
            string Oznaka = rec.Oznaka;

            entity_framework.InvoiceBuffer[] array = biroside.biroside.InvoiceBuffer.Where((x) => (x.Oznaka == Oznaka)).ToArray();
            if (array.Length == 0)
            {
                Console.WriteLine("AssertFinished-DeleteInvoiceBufferRecord: PASSED");
            }
            else
            {
                throw new Exception("The invoice buffer was not deleted on finish!!!");
            }

            BufferHistoryLog log = biroside.biroside.BufferHistoryLog.Where((x) => (x.Oznaka == Oznaka)).First();
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
