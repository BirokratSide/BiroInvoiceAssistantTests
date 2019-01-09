using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tests.data.plugincache;
using Tests.data.structs;

namespace Tests.tests
{
    class SadPathTest : MetaTest
    {
        public SadPathTest() : base() { }

        // test parameters
        float RihZ = 0.0f;

        public new void Start()
        {
            base.Start();

            // add slike, kp to database
            SSlike[] slike = customerDatabase.AddTestRecordsToDatabase(customer_company_year, "Avansni Racun");

            // simulate bazure service
            foreach (var s in slike)
                pluginCacheLogic.SaveRecord(PluginCache.TYPE_SLIKE, customer_company_id.Substring(4),
                                            customer_company_year, s.Oznaka, s.RecNo.ToString());

            // wait a bit so that records are processed as out of credits
            Thread.Sleep(10000);

            // add credits
            creditsDatabase.InsertOpcija(partner_sifra, "-1", "2018-06-07 12:00:00", 5.20f, 5.10f, 0, "");

            // simulate bazure service
            pluginCacheLogic.SaveRecord(PluginCache.TYPE_CRMSTRANKEOPCIJE, customer_company_id.Substring(4),
                                        customer_company_year, partner_sifra, "");

            // wait and see if it gets processed
        }
    }
}
