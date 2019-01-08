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


namespace Tests
{
    public class HappyPathTest
    {

        IConfiguration Configuration;

        BIAHostClient client;
        BirokratLogic birokrat;
        BirosideLogic biroside;
        IBirocreditsLogic birotest;

        string company_id;
        string options_company_year;
        string partner_company_year;
        string company_year;
        int user_id;

        public HappyPathTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            client = new BIAHostClient();
            birokrat = new BirokratLogic();
            biroside = new BirosideLogic();
            birotest = new BirocreditsLogic();
            company_id = Configuration.GetValue<string>("Database:company_id");
            company_year = Configuration.GetValue<string>("Database:company_year");
            options_company_year = Configuration.GetValue<string>("CreditsDatabase:options_company_year");
            partner_company_year = Configuration.GetValue<string>("CreditsDatabase:partner_company_year");
            user_id = 5;
        }

        public void Start()
        {
            // delete records from all databases
            birokrat.DeleteAllTestRecords(company_year);
            biroside.DeleteAllTestRecords(company_year);
            //birotest.DeleteAllRecordsFromDatabase();

            // add test records to knjiga poste and slike
            string[] oznake = birokrat.AddTestRecordsToDatabase(company_year, "Avansni Racun");

            // add test records for credits
            birotest.InsertPartner("1", company_id);
            birotest.InsertOpcija("1", true, "2018-06-07 12:00:00", 5.20f, 5.10f, 0, "");


            StartRecordsHost(oznake);

            //birotest.DeleteAllRecordsFromDatabase();
            //birotest.InsertPartner("1", "16010264");
            //birotest.InsertOpcija("1", true, "2018-06-07 12:00:00", 1.00f, 1.00f, 0, "");

            Thread.Sleep(5000);

            
            //AssertAllRecordsProcessed(oznake);

            /*for (int i = 0; i < oznake.Length; i++) {
                entity_framework.InvoiceBuffer buf = client.Next(user_id);
                //buf = AssertLocked(buf);
                
                FinishRecord(buf);
                //AssertFinished(buf);
            }*/
        }

        #region [private]
        private void StartRecordsHost(string[] oznake) {

            List<SSlike> data = birokrat.GetAllSlike(company_year);
            for (int i = 0; i < oznake.Length; i++)
            {
                Thread.Sleep(5000);
                SSlike slk = data.Where((x) => (x.Oznaka == oznake[i])).ToArray()[0];
                
                StartingRecord record = new StartingRecord(company_id.Substring(4), company_year, slk.Oznaka, slk.RecNo.ToString(), slk.DatumVnosa);
                HttpResponseMessage msg = client.Start(record);
            }
        }

        private void AssertAllRecordsProcessed(string[] oznake) {
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
            } else {
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
            if (array.Length == 0) {
                Console.WriteLine("AssertFinished-DeleteInvoiceBufferRecord: PASSED");
            } else {
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