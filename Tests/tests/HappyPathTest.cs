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
    public class HappyPathTest : MetaTest
    {
        public HappyPathTest() : base() {}

        public new void Start()
        {
            base.Start();
            
            // add slike, kp to database
            string[] oznake = birokrat.AddTestRecordsToDatabase(customer_company_year, "Avansni Racun");

            // add credits, partner to database
            birotest.InsertPartner("1", customer_company_id);
            birotest.InsertOpcija("1", true, "2018-06-07 12:00:00", 5.20f, 5.10f, 0, "");

            // add to plugin cache
            pluginCacheLogic.SaveRecord(null);


            // add test records to knjiga poste and slike
            
        }
    }
}