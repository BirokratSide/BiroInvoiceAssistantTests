using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

using Tests.entity_framework;

namespace Tests.host_client
{
    public class BIAHostClient
    {
        IConfiguration Configuration;
        HttpClient host;

        public BIAHostClient() {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(StaticConst.SETTINGS_PATH);
            Configuration = builder.Build();

            // host
            host = new HttpClient
            {
                BaseAddress = new Uri(Configuration.GetValue<string>("BiroInvoiceAssistant:Endpoint"))
            };
        }

        #region [configuration]
        public void SetUnlockedThreshold(int seconds)
        {
            string query = QueryStringConstants.MakeUnlockedThresholdString(seconds);
            host.GetAsync(query);
        }

        public void SetLockedThreshold(int seconds)
        {
            string query = QueryStringConstants.MakeLockedThresholdString(seconds);
            host.GetAsync(query);
        }

        public void SetProcessAutomaticSwitch(bool val) {
            string query = QueryStringConstants.MakeProcessAutomaticSwitchQueryString(val);
            host.GetAsync(query);
        }
        #endregion

        #region [api]
        public HttpResponseMessage Start(StartingRecord record) {
            string query = QueryStringConstants.MakeStartQueryString(record);
            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            return msg;
        }

        public InvoiceBuffer Next(int user_id) {
            string query = QueryStringConstants.MakeGetNextQueryString(user_id);
            HttpResponseMessage msg = host.GetAsync(query).GetAwaiter().GetResult();
            string content = msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            entity_framework.InvoiceBuffer ret = JsonConvert.DeserializeObject<entity_framework.InvoiceBuffer>(content);
            return ret;
        }

        public string Finish(InvoiceBuffer rec) {
            string content = JsonConvert.SerializeObject(rec);
            return QueryStringConstants.PostFinish(content, host);
        }
        #endregion
    }
}
