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
        #endregion

        public CBirokrat()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();


            // host
            string user = Configuration.GetValue<string>("Database:Username");
            string pass = Configuration.GetValue<string>("Database:Password");
            string address = Configuration.GetValue<string>("Database:Address");
            string database = Configuration.GetValue<string>("Database:Database");
            string intSec = Configuration.GetValue<string>("Database:IntegratedSecurity");
            string initCat =  Configuration.GetValue<string>("Database:InitialCatalog");

            CMsSqlConnectionString sqlstring = new CMsSqlConnectionString();
            sqlstring.username = Configuration.GetValue<string>("Database:Username");
            sqlstring.password = Configuration.GetValue<string>("Database:Password");
            sqlstring.server = Configuration.GetValue<string>("Database:Address");
            sqlstring.database = Configuration.GetValue<string>("Database:Database");
            sqlstring.integratedSecurity = Configuration.GetValue<bool>("Database:IntegratedSecurity");
            CMsSqlConnection conn = new CMsSqlConnection((ISqlConnectionString)sqlstring);

            string biroCd = Configuration.GetValue<string>("Database:BiroCd");
            string biroDb = Configuration.GetValue<string>("Database:BiroDb");
            CDatabase db = new CDatabase(conn, biroCd, biroDb);
        }
    }
}
