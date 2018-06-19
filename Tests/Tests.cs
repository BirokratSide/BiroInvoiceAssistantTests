using Common.utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SystemTests;
using System.Threading;
using System.IO;

using Newtonsoft.Json;
using Tests.structs;
using Microsoft.Extensions.Configuration;

using Tests.helpers;

namespace Tests
{
    class Tests
    {
        public HttpClient client;
        public IConfiguration Configuration;
        public BiroDatabaseAccessor biro;


        public Tests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            // Host init
            string host_endpoint = Configuration.GetValue<string>("BiroInvoiceAssistant:Endpoint");
            client = new HttpClient();
            client.BaseAddress = new Uri(host_endpoint);

            // Database init
            SBAzureSettings config = new SBAzureSettings(
                Configuration.GetValue<string>("Database:Username"),
                Configuration.GetValue<string>("Database:Password"),
                Configuration.GetValue<string>("Database:Address"),
                Configuration.GetValue<string>("Database:InitialCatalog"),
                Configuration.GetValue<bool>("Database:IntegratedSecurity"),
                Configuration.GetValue<string>("Database:Database"));
            CMsSqlConnection SqlConn = new CMsSqlConnection(GSqlUtils.GetConnectionString(config.database, config.username, config.password, "", config.integrated_security));
            biro = new BiroDatabaseAccessor(SqlConn);
        }

        #region [public]
        public HttpResponseMessage StartTestOne(StartingRecord rec)
        {
            string query = QueryStringConstants.MakeStartQueryString(rec);
            HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();
            return msg;
        }
        #endregion

        public void StartTestJustOne()
        {

            SPlacilo placilo = biro.retrieveValidationRecordsKnjigaPoste(15)[14];

            StartingRecord startingRecord = new StartingRecord("biro16010264", "who", "cares",
                                                               placilo.slika.oznaka, placilo.slika.recno, placilo.slika.datum_vnosa);
            StartTestOne(startingRecord);
        }

        public void StartTest()
        {

            List<SPlacilo> placila = biro.retrieveValidationRecordsKnjigaPoste(10);
            for (int i = 0; i < placila.Count; i++)
            {
                SPlacilo placilo = placila[i];
                StartingRecord startingRecord = new StartingRecord("biro16010264", "who", "cares",
                                                               placilo.slika.oznaka, placilo.slika.recno, placilo.slika.datum_vnosa);
                StartTestOne(startingRecord);
                Thread.Sleep(5000);
            }
        }

        public void StartTestPlacila()
        {

            List<SPlacilo> placila = biro.retrieveValidationRecordsPlacila(15);
            for (int i = 0; i < placila.Count; i++)
            {
                SPlacilo placilo = placila[i];

                byte[] arr = Encoding.GetEncoding(1250).GetBytes(placilo.slika.vsebina);
                MemoryStream data = new MemoryStream(arr);
                FileStream fs = new FileStream(@"/Users/km/Desktop/pajnic" + i + ".pdf", FileMode.Create, FileAccess.ReadWrite);
                data.CopyTo(fs);
                fs.Close();
                data.Close();

                string database = "biro16010264";
                string company_id = "who";
                string company_year = "cares";
                string oznaka = placilo.slika.oznaka;
                string recno = placilo.slika.recno;
                string datum_vnosa = placilo.slika.datum_vnosa;

                string query = string.Format(QueryStringConstants.START_QUERY, database, company_id, company_year, oznaka, recno, datum_vnosa);

                HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();

                Thread.Sleep(5000);
            }
        }

        public void GetNextInvoiceTest()
        {
            string query = QueryStringConstants.MakeGetNextQueryString(5);

            HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();
            string content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            InvoiceBuffer ret = JsonConvert.DeserializeObject<InvoiceBuffer>(content);

            query = "/api/invoice/finish";
            StringContent contentStr = new StringContent(content, Encoding.UTF8, "application/json");
            msg = client.PostAsync(query, contentStr).GetAwaiter().GetResult();
            content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(content);

        }

        #region [CONSTANT QUERY STRINGS]
        #endregion
    }
}
