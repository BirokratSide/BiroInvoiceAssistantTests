using System;
using System.Collections.Generic;

namespace Tests.entity_framework
{
    public partial class InvoiceBacklog
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime? FinishedTime { get; set; }
        public string CompanyId { get; set; }
        public string CompanyYearId { get; set; }
        public string Oznaka { get; set; }
        public string RecNo { get; set; }
        public string DatumVnosa { get; set; }
    }
}
