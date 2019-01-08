using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;

using Common.utils;
using Tests.data.accessors;

namespace Tests.data
{
    public class CBirokrat
    {

        private IConfiguration Configuration;
        private CDatabase database;
        private CSlike slike = null;
        private CPostnaKnjiga postnaKnjiga = null;
        private CPartner partner = null;
        private CCRMStrankeOpcije crmStrankeOpcije = null;

        #region [properties]
        public CSlike Slike {
            get {
                if (slike == null)
                {
                    slike = new CSlike(database);
                }
                return slike;
            }
        }
        public CPostnaKnjiga PostnaKnjiga
        {
            get
            {
                if (postnaKnjiga == null) {
                    postnaKnjiga = new CPostnaKnjiga(database);
                }
                return postnaKnjiga;
            }
        }

        public CPartner Partner {
            get
            {
                if (partner == null)
                {
                    partner = new CPartner(database);
                }
                return partner;
            }
        }

        public CCRMStrankeOpcije CrmStrankeOpcije
        {
            get
            {
                if (crmStrankeOpcije == null)
                {
                    crmStrankeOpcije = new CCRMStrankeOpcije(database);
                }
                return crmStrankeOpcije;
            }
        }
        #endregion

        public CBirokrat(bool credits = false)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"C:\Users\kiki\Desktop\playground\BiroInvoiceAssistantTests\Tests\appsettings.json");
            Configuration = builder.Build();

            string configname = "Database";
            if (credits) configname = "CreditsDatabase";

            // host
            string user = Configuration.GetValue<string>(String.Format("{0}:Username", configname));
            string pass = Configuration.GetValue<string>(String.Format("{0}:Password", configname));
            string address = Configuration.GetValue<string>(String.Format("{0}:Address", configname));
            string database = Configuration.GetValue<string>("Database:Database");
            string intSec = Configuration.GetValue<string>(String.Format("{0}:IntegratedSecurity", configname));
            string initCat =  Configuration.GetValue<string>("Database:InitialCatalog");

            CMsSqlConnectionString sqlstring = new CMsSqlConnectionString();
            sqlstring.username = Configuration.GetValue<string>(String.Format("{0}:Username", configname));
            sqlstring.password = Configuration.GetValue<string>(String.Format("{0}:Password", configname));
            sqlstring.server = Configuration.GetValue<string>(String.Format("{0}:Address", configname));
            sqlstring.database = Configuration.GetValue<string>("Database:Database");
            sqlstring.integratedSecurity = Configuration.GetValue<bool>("Database:IntegratedSecurity");
            CMsSqlConnection conn = new CMsSqlConnection((ISqlConnectionString)sqlstring);
            conn.autoOpenClose = true;

            string partner_company_year = Configuration.GetValue<string>(String.Format("{0}:partner_company_year", configname));
            string options_company_year = Configuration.GetValue<string>(String.Format("{0}:options_company_year", configname));
            string company_year_code = Configuration.GetValue<string>(String.Format("Database:company_year", configname));
            string biroDb = Configuration.GetValue<string>(String.Format("{0}:company_id", configname));
            this.database = new CDatabase(conn, partner_company_year, options_company_year, company_year_code, biroDb);
            
        }
    }
}
