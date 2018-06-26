using System;
using System.Runtime.Serialization;

namespace Tests.data.structs {
	[Serializable]
	[DataContract]
	public class SSlike {
		#region // constructor //
		public SSlike() {
			Datum = null;
			DatumVnosa = null;
			Oznaka = null;
			RecNo = 0;
			Vnasalec = null;
			Vrsta = null;
			Vsebina = null;
			Komentar = null;
			SyncId = Guid.Empty;
			YearCode = null;
		}
		#endregion
		#region // properties //
		[DataMember(IsRequired = false)]
		public DateTime? Datum { get; set; }
		[DataMember(IsRequired = false)]
		public string DatumVnosa { get; set; }
		[DataMember(IsRequired = false)]
		public string Oznaka { get; set; }
		[DataMember(IsRequired = false)]
		public int RecNo { get; set; }
		[DataMember(IsRequired = false)]
		public string Vnasalec { get; set; }
		[DataMember(IsRequired = false)]
		public string Vrsta { get; set; }
		[DataMember(IsRequired = false)]
		public string Vsebina { get; set; }
		[DataMember(IsRequired = false)]
		public string Komentar { get; set; }
		[DataMember(IsRequired = false)]
		public Guid SyncId { get; set; }
		[DataMember(IsRequired = false)]
		public string YearCode { get; set; }
		#endregion
	}
}
