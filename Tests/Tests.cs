using Common.utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using SystemTests;
using System.Threading;

using Newtonsoft.Json;
using Tests.structs;

namespace Tests
{
    class Tests
    {
        public HttpClient client;

        public Tests() {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:13694/");
        }

        public void StartTestJustOne() {
            string query = "/api/invoice/start?database={0}&company_id={1}&company_year={2}&oznaka={3}&recno={4}";

            SBAzureSettings config = new SBAzureSettings("turizem", "q", "192.168.0.123", "biroside", false, "biroside");
            CMsSqlConnection SqlConn = new CMsSqlConnection(GSqlUtils.GetConnectionString(config.database, config.username, config.password, "", config.integrated_security));
            BiroDatabaseAccessor biro = new BiroDatabaseAccessor(SqlConn);
            SPlacilo placilo = biro.retrieveValidationRecordsKnjigaPoste(5)[4];

            string database = "biro16010264";
            string company_id = "who";
            string company_year = "cares";
            string oznaka = placilo.slika.oznaka;
            string recno = placilo.slika.recno;

            query = string.Format(query, database, company_id, company_year, oznaka, recno);

            HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();
        }

        public void StartTest() {
            string query = "/api/invoice/start?database={0}&company_id={1}&company_year={2}&oznaka={3}&recno={4}&datum_vnosa={5}";

            SBAzureSettings config = new SBAzureSettings("turizem", "q", "192.168.0.123", "biroside", false, "biroside");
            CMsSqlConnection SqlConn = new CMsSqlConnection(GSqlUtils.GetConnectionString(config.database, config.username, config.password, "", config.integrated_security));
            BiroDatabaseAccessor biro = new BiroDatabaseAccessor(SqlConn);
            List<SPlacilo> placila = biro.retrieveValidationRecordsKnjigaPoste(50);
            for (int i = 0; i < 50; i++)
            {
                SPlacilo placilo = placila[i];

                string database = "biro16010264";
                string company_id = "who";
                string company_year = "cares";
                string oznaka = placilo.slika.oznaka;
                string recno = placilo.slika.recno;
                string datum_vnosa = placilo.slika.datum_vnosa;

                query = string.Format(query, database, company_id, company_year, oznaka, recno, datum_vnosa);

                HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();

                Thread.Sleep(5000);
            }
        }

        public void GetNextInvoiceTest() {
            string query = "/api/invoice/get-next?user_id=5";

            HttpResponseMessage msg = client.GetAsync(query).GetAwaiter().GetResult();
            string content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            InvoiceBuffer ret = JsonConvert.DeserializeObject<InvoiceBuffer>(content);

            query = "/api/invoice/finish";
            StringContent contentStr = new StringContent(content, Encoding.UTF8, "application/json");
            msg = client.PostAsync(query, contentStr).GetAwaiter().GetResult();
            content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            Console.WriteLine(content);

        }
    }
}
