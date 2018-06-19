using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Web;
using System.Collections;
using System.Linq;

using Tests.helpers;
using Tests.structs;
using Tests.Models;

namespace Tests
{
    public class HappyPathTest
    {

        TestCaseAdder TestCaseAdder;
        IConfiguration Configuration;
        HttpClient host;
        biro16010264Context context;

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
        }

        public void Start() {
            string directory = @"/Users/km/Dropbox/docs/archives/mng/mng/docs/airbnb/racuni";
            string[] fileArray = Directory.GetFiles(directory, "*.pdf");

            // add new records into the database
            string[] oznake = new string[fileArray.Length];
            for (int i = 0; i < fileArray.Length; i++) {
                string date = DateTime.Now.ToString("ddMMyy") + "0000";
                oznake[i] = TestCaseAdder.AddTestCaseToDatabase(date, (short)i, "some", fileArray[i]);
            }

            // get the actual records from database
            Slike s = context.Slike.Where((x) => (x.Oznaka == oznake[0])).ToArray()[0];
            StartingRecord record = new StartingRecord("16010264", "who", "cares", s.Oznaka, s.RecNo.ToString(), s.DatumVnosa);

            // Start the processing by the host
            string query = QueryStringConstants.MakeStartQueryString(record);
            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();


            // verify that they have been processed by Rihard after 30 seconds


            // verify that Student app zakljucs them


            // verify that everything is set up as it should have been


        }
    }
}
