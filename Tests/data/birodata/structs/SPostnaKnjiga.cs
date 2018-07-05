using System;
using System.Runtime.Serialization;

namespace Tests.data.structs {
	[Serializable]
	[DataContract]
	public class SPostnaKnjiga {
		#region // constructor //
		public SPostnaKnjiga() {
			Datum = null;
			DatumPotrditve = null;
			DatumVnosa = null;
			ImePartnerja = null;
			Komentar = null;
			Letalsko = 0;
			Nujno = 0;
			Odkupnina = 0;
			Postnina = 0;
			RecNo = 0;
			SifraPartnerja = null;
			Sporocilo = null;
			Teza = 0;
			Tip = null;
			Vnasalec = null;
			VrednostPoste = 0;
			VrstaPoste = null;
			Zadeva = null;
			Zaposlen = null;
			ZapSt = 0;
			Datum1 = null;
			Datum2 = null;
			eSLOGGUID = null;
			InternaStevilka = null;
			MPO = null;
			PE = null;
			ScanPrenesen = 0;
			SlikeOznaka = null;
			SlikeVrsta = null;
			TipPoste = null;
			ZZI = null;
			ZZI1 = 0;
			ZZI2 = 0;
			SyncId = Guid.Empty;
			YearCode = null;
			Likvidacija = null;
			Rih_DateTime_Received = null;
			Rih_DateTime_Sent = null;
			Rih_DateTime_Updated = null;
			Rih_gross = null;
			Rih_gross_0 = null;
			Rih_gross_M = null;
			Rih_gross_V = null;
			Rih_inv_date = null;
			Rih_inv_num = null;
			Rih_net = null;
			Rih_net_0 = null;
			Rih_net_M = null;
			Rih_net_V = null;
			Rih_pay_until = null;
			Rih_reference = null;
			Rih_vat = null;
			Rih_vat_0 = null;
			Rih_vat_id_buyer = null;
			Rih_vat_id_publisher = null;
			Rih_vat_M = null;
			Rih_vat_V = null;
		}
		#endregion
		#region // properties //
		[DataMember(IsRequired = false)]
		public DateTime? Datum { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? DatumPotrditve { get; set; }
		[DataMember(IsRequired = false)]
		public string DatumVnosa { get; set; }
		[DataMember(IsRequired = false)]
		public string ImePartnerja { get; set; }
		[DataMember(IsRequired = false)]
		public string Komentar { get; set; }
		[DataMember(IsRequired = false)]
		public short Letalsko { get; set; }
		[DataMember(IsRequired = false)]
		public short Nujno { get; set; }
		[DataMember(IsRequired = false)]
		public double Odkupnina { get; set; }
		[DataMember(IsRequired = false)]
		public double Postnina { get; set; }
		[DataMember(IsRequired = false)]
		public int RecNo { get; set; }
		[DataMember(IsRequired = false)]
		public string SifraPartnerja { get; set; }
		[DataMember(IsRequired = false)]
		public string Sporocilo { get; set; }
		[DataMember(IsRequired = false)]
		public double Teza { get; set; }
		[DataMember(IsRequired = false)]
		public string Tip { get; set; }
		[DataMember(IsRequired = false)]
		public string Vnasalec { get; set; }
		[DataMember(IsRequired = false)]
		public double VrednostPoste { get; set; }
		[DataMember(IsRequired = false)]
		public string VrstaPoste { get; set; }
		[DataMember(IsRequired = false)]
		public string Zadeva { get; set; }
		[DataMember(IsRequired = false)]
		public string Zaposlen { get; set; }
		[DataMember(IsRequired = false)]
		public short ZapSt { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? Datum1 { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? Datum2 { get; set; }
		[DataMember(IsRequired = false)]
		public string eSLOGGUID { get; set; }
		[DataMember(IsRequired = false)]
		public string InternaStevilka { get; set; }
		[DataMember(IsRequired = false)]
		public string MPO { get; set; }
		[DataMember(IsRequired = false)]
		public string PE { get; set; }
		[DataMember(IsRequired = false)]
		public short ScanPrenesen { get; set; }
		[DataMember(IsRequired = false)]
		public string SlikeOznaka { get; set; }
		[DataMember(IsRequired = false)]
		public string SlikeVrsta { get; set; }
		[DataMember(IsRequired = false)]
		public string TipPoste { get; set; }
		[DataMember(IsRequired = false)]
		public string ZZI { get; set; }
		[DataMember(IsRequired = false)]
		public int ZZI1 { get; set; }
		[DataMember(IsRequired = false)]
		public short ZZI2 { get; set; }
		[DataMember(IsRequired = false)]
		public Guid SyncId { get; set; }
		[DataMember(IsRequired = false)]
		public string YearCode { get; set; }
		[DataMember(IsRequired = false)]
		public string Likvidacija { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? Rih_DateTime_Received { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? Rih_DateTime_Sent { get; set; }
		[DataMember(IsRequired = false)]
		public DateTime? Rih_DateTime_Updated { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_gross { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_gross_0 { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_gross_M { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_gross_V { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_inv_date { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_inv_num { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_net { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_net_0 { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_net_M { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_net_V { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_pay_until { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_reference { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat_0 { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat_id_buyer { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat_id_publisher { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat_M { get; set; }
		[DataMember(IsRequired = false)]
		public string Rih_vat_V { get; set; }
		#endregion
	}
}
