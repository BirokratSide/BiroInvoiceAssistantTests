using System;
using System.Collections.Generic;

namespace Tests.Models
{
    public partial class PostnaKnjiga
    {
        public DateTime? Datum { get; set; }
        public DateTime? DatumPotrditve { get; set; }
        public string DatumVnosa { get; set; }
        public string ImePartnerja { get; set; }
        public string Komentar { get; set; }
        public short? Letalsko { get; set; }
        public short? Nujno { get; set; }
        public double? Odkupnina { get; set; }
        public double? Postnina { get; set; }
        public int RecNo { get; set; }
        public string SifraPartnerja { get; set; }
        public string Sporocilo { get; set; }
        public double? Teza { get; set; }
        public string Tip { get; set; }
        public string Vnasalec { get; set; }
        public double? VrednostPoste { get; set; }
        public string VrstaPoste { get; set; }
        public string Zadeva { get; set; }
        public string Zaposlen { get; set; }
        public short? ZapSt { get; set; }
        public DateTime? Datum1 { get; set; }
        public DateTime? Datum2 { get; set; }
        public string ESlogguid { get; set; }
        public string InternaStevilka { get; set; }
        public string Mpo { get; set; }
        public string Pe { get; set; }
        public short? ScanPrenesen { get; set; }
        public string SlikeOznaka { get; set; }
        public string SlikeVrsta { get; set; }
        public string TipPoste { get; set; }
        public string Zzi { get; set; }
        public int? Zzi1 { get; set; }
        public short? Zzi2 { get; set; }
        public Guid SyncId { get; set; }
        public string YearCode { get; set; }
        public string Likvidacija { get; set; }
    }
}
