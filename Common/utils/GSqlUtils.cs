using System;
using System.Data.SqlClient;

namespace Common.utils
{
    public class GSqlUtils
    {
        public static string GetConnectionString(string database, string username, string password, string initialcatalog, bool integrated = false)
        {
            if (!integrated)
            {
                // Initial Catalog really set up properly?
                return String.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", database, initialcatalog, username, password);
            }
            else
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = database;
                builder.InitialCatalog = initialcatalog;
                builder.IntegratedSecurity = true;
                return builder.ConnectionString;
            }
        }
    }
}
