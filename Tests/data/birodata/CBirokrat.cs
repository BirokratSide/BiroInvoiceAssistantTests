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


            string type = "CustomerDatabase";
            if (credits) type = "CreditsDatabase";

            CMsSqlConnectionString sqlstring = new CMsSqlConnectionString();
            sqlstring.username = Configuration.GetValue<string>("DatabaseConnection:Username");
            sqlstring.password = Configuration.GetValue<string>("DatabaseConnection:Password");
            sqlstring.server = Configuration.GetValue<string>("DatabaseConnection:Address");
            sqlstring.integratedSecurity = Configuration.GetValue<bool>("DatabaseConnection:IntegratedSecurity");
            sqlstring.database = Configuration.GetValue<string>(String.Format("{0}:Database", type));

            CMsSqlConnection conn = new CMsSqlConnection((ISqlConnectionString)sqlstring);
            conn.autoOpenClose = true;

            string partner_company_year = Configuration.GetValue<string>("CreditsDatabase:partner_company_year");
            string options_company_year = Configuration.GetValue<string>("CreditsDatabase:options_company_year");
            string company_year_code = Configuration.GetValue<string>("CustomerDatabase:company_year");
            string biroDb = Configuration.GetValue<string>(String.Format("{0}:company_id", type));
            this.database = new CDatabase(conn, partner_company_year, options_company_year, company_year_code, biroDb);
            
        }
    }
}
