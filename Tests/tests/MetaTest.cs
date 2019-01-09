using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests.host_client;
using Tests.logic;

namespace Tests.tests
{
    public class MetaTest
    {
        protected IConfiguration Configuration;

        protected BIAHostClient client;
        protected BirokratLogic customerDatabase;
        protected BirosideLogic biroside;
        protected IBirocreditsLogic creditsDatabase;
        protected PluginCacheLogic pluginCacheLogic;

        protected string customer_company_id;
        protected string options_company_year;
        protected string partner_company_year;
        protected string customer_company_year;
        protected string partner_sifra;

        public MetaTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            // 2nd level objects
            client = new BIAHostClient();
            customerDatabase = new BirokratLogic();
            biroside = new BirosideLogic();
            creditsDatabase = new BirocreditsLogic();
            pluginCacheLogic = new PluginCacheLogic();

            // configuration
            customer_company_id = Configuration.GetValue<string>("CustomerDatabase:company_id");
            customer_company_year = Configuration.GetValue<string>("CustomerDatabase:company_year");
            options_company_year = Configuration.GetValue<string>("CreditsDatabase:options_company_year");
            partner_company_year = Configuration.GetValue<string>("CreditsDatabase:partner_company_year");
            partner_sifra = Configuration.GetValue<string>("CreditsDatabase:partner_sifra");
        }

        protected virtual void Start() {
            WipeDatabaseClean();
            creditsDatabase.InsertPartner(partner_sifra, customer_company_id.Substring(4));
        }

        protected void WipeDatabaseClean()
        {
            // delete records from all databases
            customerDatabase.DeleteAllTestRecords(customer_company_year);
            biroside.DeleteAllTestRecords(customer_company_year);
            creditsDatabase.DeleteAllRecordsFromDatabase(partner_sifra);
            pluginCacheLogic.DeleteAllRecords();
        }
    }
}
