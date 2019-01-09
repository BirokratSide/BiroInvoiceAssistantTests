using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests.data.plugincache;

namespace Tests.logic
{
    public class PluginCacheLogic
    {
        IConfiguration Configuration;

        public biromasterContext biromaster;

        public PluginCacheLogic()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            biromaster = new biromasterContext();
        }

        
        public void SaveRecord(string type, string davcnastevilka, string companyyear, string oznaka, string recno)
        {
            PluginCache rec = new PluginCache
            {
                Type = type,
                Davcnastevilka = davcnastevilka, // without biro
                Companyyear = companyyear,
                Oznaka = oznaka,
                Datumvnosa = "",
                Toprocess = true,
                Processed = false,
                Recno = recno
            };

            biromaster.PluginCache.Add(rec);
            biromaster.SaveChanges();
        }

        public void DeleteAllRecords()
        {
            biromaster.PluginCache.RemoveRange(biromaster.PluginCache);
        }
    }
}
