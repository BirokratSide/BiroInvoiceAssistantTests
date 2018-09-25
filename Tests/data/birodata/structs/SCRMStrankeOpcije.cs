using System;
using System.Runtime.Serialization;

namespace Tests.data.structs
{
    [Serializable]
    [DataContract]
    public class SCRMStrankeOpcije
    {
        #region // constructor //
        public SCRMStrankeOpcije()
        {
            Aktivno = 0;
            Aplikacija = null;
            DatumVnosa = null;
            Level = 0;
            Opcija = null;
            OpisPolja = null;
            Recno = 0;
            Sifra = null;
            Vnasalec = null;
            Vrednost = null;
            Zaporedje = 0;
            SyncId = Guid.Empty;
            YearCode = null;
        }
        #endregion
        #region // properties //
        [DataMember(IsRequired = false)]
        public short Aktivno { get; set; }
        [DataMember(IsRequired = false)]
        public string Aplikacija { get; set; }
        [DataMember(IsRequired = false)]
        public string DatumVnosa { get; set; }
        [DataMember(IsRequired = false)]
        public short Level { get; set; }
        [DataMember(IsRequired = false)]
        public string Opcija { get; set; }
        [DataMember(IsRequired = false)]
        public string OpisPolja { get; set; }
        [DataMember(IsRequired = false)]
        public int Recno { get; set; }
        [DataMember(IsRequired = false)]
        public string Sifra { get; set; }
        [DataMember(IsRequired = false)]
        public string Vnasalec { get; set; }
        [DataMember(IsRequired = false)]
        public string Vrednost { get; set; }
        [DataMember(IsRequired = false)]
        public short Zaporedje { get; set; }
        [DataMember(IsRequired = false)]
        public Guid SyncId { get; set; }
        [DataMember(IsRequired = false)]
        public string YearCode { get; set; }
        #endregion
    }
}
