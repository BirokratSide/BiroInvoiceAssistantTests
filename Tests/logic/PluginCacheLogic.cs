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

        public void SaveRecord(PluginCache rec)
        {
            biromaster.PluginCache.Add(rec);
            biromaster.SaveChanges();
        }

        public void DeleteAllRecords()
        {
            biromaster.PluginCache.RemoveRange(biromaster.PluginCache);
        }
    }
}
