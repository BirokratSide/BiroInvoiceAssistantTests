using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

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
        public void DeleteAllTestRecords(string company_year) {
            InvoiceBuffer[] invoices = biroside.InvoiceBuffer.Where((x) => (x.CompanyYearId == company_year)).ToArray();
            biroside.InvoiceBuffer.RemoveRange(invoices);

            BufferHistoryLog[] hists = biroside.BufferHistoryLog.Where((x) => (x.CompanyYearId == company_year)).ToArray();
            biroside.BufferHistoryLog.RemoveRange(hists);

            InvoiceBacklog[] backs = biroside.InvoiceBacklog.Where((x) => (x.CompanyYearId == company_year)).ToArray();
            biroside.InvoiceBacklog.RemoveRange(backs);

            biroside.SaveChanges();
        }
    }
}
