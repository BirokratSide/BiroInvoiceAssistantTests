using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.utils
{
    public class SBAzureSettings
    {
        public string username;
        public string password;
        public string database;
        public string initial_catalog;
        public bool integrated_security;
        public string target_database;

        public SBAzureSettings(string username, string password, string database, string initial_catalog, bool integrated_security, string target_database)
        {
            this.username = username;
            this.password = password;
            this.database = database;
            this.initial_catalog = initial_catalog;
            this.integrated_security = integrated_security;
            this.target_database = target_database;
        }
    }
}
