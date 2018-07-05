using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;

using Tests.entity_framework;

namespace Tests.logic
{
    public class BirosideLogic
    {
        IConfiguration Configuration;

        public birosideContext biroside;

        public BirosideLogic()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            biroside = new birosideContext();
        }
    }
}
