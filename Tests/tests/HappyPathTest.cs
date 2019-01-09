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
using Tests.data.plugincache;

namespace Tests.tests
{
    public class HappyPathTest : MetaTest
    {
        public HappyPathTest() : base() {}

        // test parameters
        float RihZ = 0.0f;

        public new void Start()
        {
            base.Start();
            
            // add slike, kp to database
            SSlike[] slike = customerDatabase.AddTestRecordsToDatabase(customer_company_year, "Avansni Racun");

            // add credits, partner to database
            creditsDatabase.InsertOpcija(partner_sifra, "-1", "2018-06-07 12:00:00", 5.20f, 5.10f, 0, "");
            
            // simulate bazure service
            foreach (var s in slike)
                pluginCacheLogic.SaveRecord(PluginCache.TYPE_SLIKE, customer_company_id.Substring(4), 
                                            customer_company_year, s.Oznaka, s.RecNo.ToString());
            
        }
    }
}