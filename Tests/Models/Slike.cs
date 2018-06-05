using System;
using System.Collections.Generic;

namespace Tests.Models
{
    public partial class Slike
    {
        public DateTime? Datum { get; set; }
        public string DatumVnosa { get; set; }
        public string Oznaka { get; set; }
        public int RecNo { get; set; }
        public string Vnasalec { get; set; }
        public string Vrsta { get; set; }
        public string Vsebina { get; set; }
        public string Komentar { get; set; }
        public Guid SyncId { get; set; }
        public string YearCode { get; set; }
    }
}
