using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.utils
{
    public class GUtils
    {

        
        /////////////////////////////////////////////////////////////////
        // SQL HELPERS
        
        /*
        public static string getConnectionStringFromConfig()
        {
            string database = GAppSettings.Get("SQL_SERVER");
            string username = GAppSettings.Get("SQL_USERNAME");
            string password = GAppSettings.Get("SQL_PASSWORD");
            bool integrated = bool.Parse(GAppSettings.Get("SQL_INTEGRATED"));
            if (!integrated)
            {
                return String.Format("Data Source={0};Initial Catalog=biro16010264;Persist Security Info=True;User ID={1};Password={2}", database, username, password);
            }
            else {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = database;
                builder.InitialCatalog = "biro16010264";
                builder.IntegratedSecurity = true;
                return builder.ConnectionString;
            }
        }
        */
        /////////////////////////////////////////////////////////////////////////
        // DISTANCE MEASURES
        public static int LevenshteinDistance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        ////////////////////////////////////////////////////////////////
        /// SERIALIZATION UTILITIES
        public static TData DeserializeFromStringBase64<TData>(string settings)
        {
            byte[] b = Convert.FromBase64String(settings);
            using (var stream = new MemoryStream(b))
            {
                var formatter = new BinaryFormatter();
                stream.Seek(0, SeekOrigin.Begin);
                return (TData)formatter.Deserialize(stream);
            }
        }

        public static TData DeserializeFromFileBase64<TData>(string filepath) {
            string content = File.ReadAllText(filepath);
            TData result = DeserializeFromStringBase64<TData>(content);
            return result;
        }

        public static string SerializeToStringBase64<TData>(TData settings)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, settings);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static void SerializeToFileBase64<TData>(TData settings, string filepath) {
            string result = SerializeToStringBase64<TData>(settings);
            File.WriteAllText(filepath, result);
        }

    }
}
