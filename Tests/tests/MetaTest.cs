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
        protected BirokratLogic birokrat;
        protected BirosideLogic biroside;
        protected IBirocreditsLogic birotest;
        protected PluginCacheLogic pluginCacheLogic;

        protected string company_id;
        protected string options_company_year;
        protected string partner_company_year;
        protected string company_year;
        protected int user_id;

        public MetaTest()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            client = new BIAHostClient();
            birokrat = new BirokratLogic();
            biroside = new BirosideLogic();
            birotest = new BirocreditsLogic();
            pluginCacheLogic = new PluginCacheLogic();
            company_id = Configuration.GetValue<string>("Database:company_id");
            company_year = Configuration.GetValue<string>("Database:company_year");
            options_company_year = Configuration.GetValue<string>("CreditsDatabase:options_company_year");
            partner_company_year = Configuration.GetValue<string>("CreditsDatabase:partner_company_year");
            user_id = 5;
        }

        protected virtual void Start() {
            WipeDatabaseClean();
        }

        protected void WipeDatabaseClean()
        {
            // delete records from all databases
            birokrat.DeleteAllTestRecords(company_year);
            biroside.DeleteAllTestRecords(company_year);
            birotest.DeleteAllRecordsFromDatabase();
            pluginCacheLogic.DeleteAllRecords();
        }
    }
}
