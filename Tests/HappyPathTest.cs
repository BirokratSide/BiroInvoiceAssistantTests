using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Web;

using Tests.helpers;

namespace Tests
{
    public class HappyPathTest
    {

        TestCaseAdder TestCaseAdder;
        IConfiguration Configuration;
        HttpClient host;

        public HappyPathTest()
        {
            TestCaseAdder = new TestCaseAdder();

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            host = new HttpClient();
            host.BaseAddress = new Uri(Configuration.GetValue<string>("BiroInvoiceAssitant:Endpoint"));
        }

        public void Start() {
            string directory = @"/Users/km/Dropbox/docs/archives/mng/mng/docs/airbnb/racuni";
            string[] fileArray = Directory.GetFiles(directory, "*.pdf");

            // add new records into the database
            for (int i = 0; i < fileArray.Length; i++) {
                string date = DateTime.Now.ToString("ddMMyy") + "0000";
                TestCaseAdder.AddTestCaseToDatabase(date, (short)i, "some", fileArray[i]);
            }


            // Start the processing by the host
            host.GetAsync("api/invoice/start");


            // verify that they have been processed by Rihard after 30 seconds


            // verify that Student app zakljucs them


            // verify that everything is set up as it should have been


        }
    }
}
