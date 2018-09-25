using System;
using System.Runtime.Serialization;

namespace Tests.data.structs
{
    [Serializable]
    [DataContract]
    public class SPartner
    {
        #region // constructor //
        public SPartner()
        {
            AlternativnaImena = null;
            BarkodaeSLOG = 0;
            BICKoda = null;
            Cena1 = 0;
            Cena2 = 0;
            Cena3 = 0;
            Cena4 = 0;
            ClanaVpisal = null;
            ClanDatumVpisa = null;
            ClanDo = null;
            ClanskaStevilka = null;
            Custom1 = null;
            Custom2 = null;
            Custom3 = null;
            Custom4 = null;
            Custom5 = null;
            DatumKonca = null;
            DatumNastopa = null;
            DatumRojstva = null;
            DatumVnosa = null;
            DavcnaIzpostava = null;
            DavcnaStevilka = null;
            DDV = 0;
            DelovnaDoba = 0;
            DelovnoDovoljenjeST = null;
            DelovnoMesto = null;
            Detacirani = false;
            DirektorijPriloge = null;
            Dodatek1 = 0;
            Dodatek2 = 0;
            Dodatek3 = 0;
            Dodatek4 = 0;
            Dodatno1 = null;
            Dodatno2 = null;
            Dopust = 0;
            DovoljenjeIzdanoDne = null;
            DovoljenjeVeljaDO = null;
            DovoljenjeVeljaOD = null;
            DrugiDelodajalec = 0;
            Drzava = null;
            DrzavaDetasirani = null;
            DrzavaRezidenstva = null;
            Drzavljanstvo = null;
            DvigniCenoZaRabat = 0;
            Email = null;
            EMSO = null;
            eSLOG = 0;
            Fax = null;
            GLNKoda = null;
            H_ST = null;
            HitraOpomba = null;
            Hotelir = 0;
            IDStevilka = null;
            IME = null;
            InternetDa = false;
            Invalid = false;
            InvalidNadKvoto = 0;
            IzkorisceniDopust = 0;
            JeKontakt = 0;
            Komentar1 = null;
            Komentar2 = null;
            KomentarPopusta = null;
            KomentarZnizanjaTakse = null;
            Komercialist = null;
            KonkurencnaKlavzula = 0;
            Konsignatar = 0;
            Kontakt = null;
            Kraj = null;
            KrajRojstva = null;
            KrajZacasnegaBivalisca = null;
            LetnaNarocilnica = null;
            MamicaDo3Leta = 0;
            MaticnaStevilka = null;
            Mesto = null;
            NacinProdaje = 0;
            Naziv = null;
            Nerezident = false;
            NeUporabljaj = 0;
            NeUpostevajZaIOP = 0;
            NoceUPenzijo = 0;
            ObcinaBivanja = null;
            Obrazec = null;
            OdjavljenIzZZZS = null;
            OdprtPri = null;
            OmejitevNeplacano = 0;
            OmejitevZapadlo = 0;
            OmogociPlaciloZDobavnico = 0;
            Opombe = null;
            OpozoriloZaRacun = null;
            OpozoriUporabnik = null;
            OpozoriZapadlo = 0;
            OsebnaIzkaznica = null;
            Otroci = 0;
            OZNAKA = null;
            Partner = null;
            Partner1 = null;
            PE = null;
            PlacilniRok = 0;
            PlacilniRokNaOdpremo = 0;
            Pogodba = null;
            PogodbaOPoslovodenju = 0;
            Poklic = null;
            Popust = 0;
            Posta = null;
            PostaZacasnegaBivalisca = null;
            PotniList = null;
            PotniListDatum = null;
            PotniListDo = null;
            PotniListOd = null;
            PovecanaDobaProcent = 0;
            PovecanaSplosnaOlajsava = false;
            PravniStatus = null;
            PrenesenoIzPOSa = 0;
            PreostaliDopust = 0;
            PRIIMEK = null;
            PrijavljenNaZZZS = null;
            RabatGeneralno = 0;
            RabatnaSkupina = 0;
            RecNo = 0;
            Rojen = null;
            RojenVKraju = null;
            Sifra = null;
            SifraDrzave = null;
            SifraDrzaveNaslova = null;
            SifraPojavnegaStatusa = null;
            SKIS = null;
            Sklic = null;
            Skupina = null;
            Spol = 0;
            Sprememba = false;
            Stalnost = 0;
            StalnostTrenutno = 0;
            StevilkaOsebnegaDokumenta = null;
            StevilkaRacuna = 0;
            Stimulac = 0;
            StopnjaIzobrazbe = null;
            SuperRabat = 0;
            Telefon = null;
            Telefon2 = null;
            TempCena1 = 0;
            TempCena2 = 0;
            TempCena3 = 0;
            TezavnostDela = 0;
            TKDIS = null;
            Ulica = null;
            VarnostPriDelu = null;
            VarnostPriDeluST = null;
            VarnostPriDeluVeljaDO = null;
            VarnostPriDeluVeljaOD = null;
            Viza = null;
            VizaDatum = null;
            VizaDO = null;
            VizaOD = null;
            VIzvrsbi = 0;
            VIzvrsbiOd = null;
            Vnasalec = null;
            VnesenoNaPOSu = 0;
            Vrsta = null;
            VrstaHonorarja = null;
            VrstaIzplacila = 0;
            VrstaNaslova = null;
            VrstaOsebe = 0;
            VrstaOsebnegaDokumenta = null;
            VrstaPoslaZBS = null;
            VrstaUre = null;
            VrstaZaposlitve = null;
            VzdrzevaniOdrasli = 0;
            ZacasnoBivalisce = null;
            Zaposlen = 0;
            ZdravstveniPregled = null;
            ZdravstveniPregledST = null;
            ZdravstveniPregledVeljaDO = null;
            ZdravstveniPregledVeljaOD = null;
            Ziro_Racun = null;
            Ziro_Racun1 = null;
            Ziro_Racun2 = null;
            ZnizanjeTakse = 0;
            AlterTelefon = null;
            MladiDo30 = 0;
            PogodbaOPoslovodenju2014_18Clen = 0;
            SP1LetoOprostitev30 = 0;
            SP1LetoOprostitev50 = 0;
            SP1OdMinimalne2014 = 0;
            SyncId = Guid.Empty;
            YearCode = null;
            PredlogaDobavnica = null;
            PredlogaPredracun = null;
            PredlogaRacun = null;
            Prevoz1NaDan = 0;
            Prevoz1NaMesec = 0;
            Prevoz1Opis = null;
            Prevoz2NaDan = 0;
            Prevoz2NaMesec = 0;
            Prevoz2Opis = null;
            Prevoz3NaDan = 0;
            Prevoz3NaMesec = 0;
            Prevoz3Opis = null;
            VzdrzevaniOtrociSPosebnimiPotrebami = 0;
            cyrillic = 0;
            GDPR1 = false;
            GDPR2 = false;
            GDPR3 = false;
            GDPR4 = false;
            GDPR5 = false;
        }
        #endregion
        #region // properties //
        [DataMember(IsRequired = false)]
        public string AlternativnaImena { get; set; }
        [DataMember(IsRequired = false)]
        public short BarkodaeSLOG { get; set; }
        [DataMember(IsRequired = false)]
        public string BICKoda { get; set; }
        [DataMember(IsRequired = false)]
        public double Cena1 { get; set; }
        [DataMember(IsRequired = false)]
        public double Cena2 { get; set; }
        [DataMember(IsRequired = false)]
        public double Cena3 { get; set; }
        [DataMember(IsRequired = false)]
        public double Cena4 { get; set; }
        [DataMember(IsRequired = false)]
        public string ClanaVpisal { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? ClanDatumVpisa { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? ClanDo { get; set; }
        [DataMember(IsRequired = false)]
        public string ClanskaStevilka { get; set; }
        [DataMember(IsRequired = false)]
        public string Custom1 { get; set; }
        [DataMember(IsRequired = false)]
        public string Custom2 { get; set; }
        [DataMember(IsRequired = false)]
        public string Custom3 { get; set; }
        [DataMember(IsRequired = false)]
        public string Custom4 { get; set; }
        [DataMember(IsRequired = false)]
        public string Custom5 { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DatumKonca { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DatumNastopa { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DatumRojstva { get; set; }
        [DataMember(IsRequired = false)]
        public string DatumVnosa { get; set; }
        [DataMember(IsRequired = false)]
        public string DavcnaIzpostava { get; set; }
        [DataMember(IsRequired = false)]
        public string DavcnaStevilka { get; set; }
        [DataMember(IsRequired = false)]
        public short DDV { get; set; }
        [DataMember(IsRequired = false)]
        public decimal DelovnaDoba { get; set; }
        [DataMember(IsRequired = false)]
        public string DelovnoDovoljenjeST { get; set; }
        [DataMember(IsRequired = false)]
        public string DelovnoMesto { get; set; }
        [DataMember(IsRequired = false)]
        public bool Detacirani { get; set; }
        [DataMember(IsRequired = false)]
        public string DirektorijPriloge { get; set; }
        [DataMember(IsRequired = false)]
        public double Dodatek1 { get; set; }
        [DataMember(IsRequired = false)]
        public double Dodatek2 { get; set; }
        [DataMember(IsRequired = false)]
        public double Dodatek3 { get; set; }
        [DataMember(IsRequired = false)]
        public double Dodatek4 { get; set; }
        [DataMember(IsRequired = false)]
        public string Dodatno1 { get; set; }
        [DataMember(IsRequired = false)]
        public string Dodatno2 { get; set; }
        [DataMember(IsRequired = false)]
        public decimal Dopust { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DovoljenjeIzdanoDne { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DovoljenjeVeljaDO { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? DovoljenjeVeljaOD { get; set; }
        [DataMember(IsRequired = false)]
        public short DrugiDelodajalec { get; set; }
        [DataMember(IsRequired = false)]
        public string Drzava { get; set; }
        [DataMember(IsRequired = false)]
        public string DrzavaDetasirani { get; set; }
        [DataMember(IsRequired = false)]
        public string DrzavaRezidenstva { get; set; }
        [DataMember(IsRequired = false)]
        public string Drzavljanstvo { get; set; }
        [DataMember(IsRequired = false)]
        public short DvigniCenoZaRabat { get; set; }
        [DataMember(IsRequired = false)]
        public string Email { get; set; }
        [DataMember(IsRequired = false)]
        public string EMSO { get; set; }
        [DataMember(IsRequired = false)]
        public short eSLOG { get; set; }
        [DataMember(IsRequired = false)]
        public string Fax { get; set; }
        [DataMember(IsRequired = false)]
        public string GLNKoda { get; set; }
        [DataMember(IsRequired = false)]
        public string H_ST { get; set; }
        [DataMember(IsRequired = false)]
        public string HitraOpomba { get; set; }
        [DataMember(IsRequired = false)]
        public short Hotelir { get; set; }
        [DataMember(IsRequired = false)]
        public string IDStevilka { get; set; }
        [DataMember(IsRequired = false)]
        public string IME { get; set; }
        [DataMember(IsRequired = false)]
        public bool InternetDa { get; set; }
        [DataMember(IsRequired = false)]
        public bool Invalid { get; set; }
        [DataMember(IsRequired = false)]
        public short InvalidNadKvoto { get; set; }
        [DataMember(IsRequired = false)]
        public decimal IzkorisceniDopust { get; set; }
        [DataMember(IsRequired = false)]
        public short JeKontakt { get; set; }
        [DataMember(IsRequired = false)]
        public string Komentar1 { get; set; }
        [DataMember(IsRequired = false)]
        public string Komentar2 { get; set; }
        [DataMember(IsRequired = false)]
        public string KomentarPopusta { get; set; }
        [DataMember(IsRequired = false)]
        public string KomentarZnizanjaTakse { get; set; }
        [DataMember(IsRequired = false)]
        public string Komercialist { get; set; }
        [DataMember(IsRequired = false)]
        public decimal KonkurencnaKlavzula { get; set; }
        [DataMember(IsRequired = false)]
        public short Konsignatar { get; set; }
        [DataMember(IsRequired = false)]
        public string Kontakt { get; set; }
        [DataMember(IsRequired = false)]
        public string Kraj { get; set; }
        [DataMember(IsRequired = false)]
        public string KrajRojstva { get; set; }
        [DataMember(IsRequired = false)]
        public string KrajZacasnegaBivalisca { get; set; }
        [DataMember(IsRequired = false)]
        public string LetnaNarocilnica { get; set; }
        [DataMember(IsRequired = false)]
        public short MamicaDo3Leta { get; set; }
        [DataMember(IsRequired = false)]
        public string MaticnaStevilka { get; set; }
        [DataMember(IsRequired = false)]
        public string Mesto { get; set; }
        [DataMember(IsRequired = false)]
        public short NacinProdaje { get; set; }
        [DataMember(IsRequired = false)]
        public string Naziv { get; set; }
        [DataMember(IsRequired = false)]
        public bool Nerezident { get; set; }
        [DataMember(IsRequired = false)]
        public short NeUporabljaj { get; set; }
        [DataMember(IsRequired = false)]
        public short NeUpostevajZaIOP { get; set; }
        [DataMember(IsRequired = false)]
        public short NoceUPenzijo { get; set; }
        [DataMember(IsRequired = false)]
        public string ObcinaBivanja { get; set; }
        [DataMember(IsRequired = false)]
        public string Obrazec { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? OdjavljenIzZZZS { get; set; }
        [DataMember(IsRequired = false)]
        public string OdprtPri { get; set; }
        [DataMember(IsRequired = false)]
        public double OmejitevNeplacano { get; set; }
        [DataMember(IsRequired = false)]
        public double OmejitevZapadlo { get; set; }
        [DataMember(IsRequired = false)]
        public short OmogociPlaciloZDobavnico { get; set; }
        [DataMember(IsRequired = false)]
        public string Opombe { get; set; }
        [DataMember(IsRequired = false)]
        public string OpozoriloZaRacun { get; set; }
        [DataMember(IsRequired = false)]
        public string OpozoriUporabnik { get; set; }
        [DataMember(IsRequired = false)]
        public short OpozoriZapadlo { get; set; }
        [DataMember(IsRequired = false)]
        public string OsebnaIzkaznica { get; set; }
        [DataMember(IsRequired = false)]
        public double Otroci { get; set; }
        [DataMember(IsRequired = false)]
        public string OZNAKA { get; set; }
        [DataMember(IsRequired = false)]
        public string Partner { get; set; }
        [DataMember(IsRequired = false)]
        public string Partner1 { get; set; }
        [DataMember(IsRequired = false)]
        public string PE { get; set; }
        [DataMember(IsRequired = false)]
        public short PlacilniRok { get; set; }
        [DataMember(IsRequired = false)]
        public short PlacilniRokNaOdpremo { get; set; }
        [DataMember(IsRequired = false)]
        public string Pogodba { get; set; }
        [DataMember(IsRequired = false)]
        public short PogodbaOPoslovodenju { get; set; }
        [DataMember(IsRequired = false)]
        public string Poklic { get; set; }
        [DataMember(IsRequired = false)]
        public short Popust { get; set; }
        [DataMember(IsRequired = false)]
        public string Posta { get; set; }
        [DataMember(IsRequired = false)]
        public string PostaZacasnegaBivalisca { get; set; }
        [DataMember(IsRequired = false)]
        public string PotniList { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? PotniListDatum { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? PotniListDo { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? PotniListOd { get; set; }
        [DataMember(IsRequired = false)]
        public double PovecanaDobaProcent { get; set; }
        [DataMember(IsRequired = false)]
        public bool PovecanaSplosnaOlajsava { get; set; }
        [DataMember(IsRequired = false)]
        public string PravniStatus { get; set; }
        [DataMember(IsRequired = false)]
        public byte PrenesenoIzPOSa { get; set; }
        [DataMember(IsRequired = false)]
        public decimal PreostaliDopust { get; set; }
        [DataMember(IsRequired = false)]
        public string PRIIMEK { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? PrijavljenNaZZZS { get; set; }
        [DataMember(IsRequired = false)]
        public double RabatGeneralno { get; set; }
        [DataMember(IsRequired = false)]
        public int RabatnaSkupina { get; set; }
        [DataMember(IsRequired = false)]
        public int RecNo { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? Rojen { get; set; }
        [DataMember(IsRequired = false)]
        public string RojenVKraju { get; set; }
        [DataMember(IsRequired = false)]
        public string Sifra { get; set; }
        [DataMember(IsRequired = false)]
        public string SifraDrzave { get; set; }
        [DataMember(IsRequired = false)]
        public string SifraDrzaveNaslova { get; set; }
        [DataMember(IsRequired = false)]
        public string SifraPojavnegaStatusa { get; set; }
        [DataMember(IsRequired = false)]
        public string SKIS { get; set; }
        [DataMember(IsRequired = false)]
        public string Sklic { get; set; }
        [DataMember(IsRequired = false)]
        public string Skupina { get; set; }
        [DataMember(IsRequired = false)]
        public short Spol { get; set; }
        [DataMember(IsRequired = false)]
        public bool Sprememba { get; set; }
        [DataMember(IsRequired = false)]
        public decimal Stalnost { get; set; }
        [DataMember(IsRequired = false)]
        public decimal StalnostTrenutno { get; set; }
        [DataMember(IsRequired = false)]
        public string StevilkaOsebnegaDokumenta { get; set; }
        [DataMember(IsRequired = false)]
        public short StevilkaRacuna { get; set; }
        [DataMember(IsRequired = false)]
        public double Stimulac { get; set; }
        [DataMember(IsRequired = false)]
        public string StopnjaIzobrazbe { get; set; }
        [DataMember(IsRequired = false)]
        public decimal SuperRabat { get; set; }
        [DataMember(IsRequired = false)]
        public string Telefon { get; set; }
        [DataMember(IsRequired = false)]
        public string Telefon2 { get; set; }
        [DataMember(IsRequired = false)]
        public double TempCena1 { get; set; }
        [DataMember(IsRequired = false)]
        public double TempCena2 { get; set; }
        [DataMember(IsRequired = false)]
        public double TempCena3 { get; set; }
        [DataMember(IsRequired = false)]
        public short TezavnostDela { get; set; }
        [DataMember(IsRequired = false)]
        public string TKDIS { get; set; }
        [DataMember(IsRequired = false)]
        public string Ulica { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VarnostPriDelu { get; set; }
        [DataMember(IsRequired = false)]
        public string VarnostPriDeluST { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VarnostPriDeluVeljaDO { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VarnostPriDeluVeljaOD { get; set; }
        [DataMember(IsRequired = false)]
        public string Viza { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VizaDatum { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VizaDO { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VizaOD { get; set; }
        [DataMember(IsRequired = false)]
        public short VIzvrsbi { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? VIzvrsbiOd { get; set; }
        [DataMember(IsRequired = false)]
        public string Vnasalec { get; set; }
        [DataMember(IsRequired = false)]
        public byte VnesenoNaPOSu { get; set; }
        [DataMember(IsRequired = false)]
        public string Vrsta { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaHonorarja { get; set; }
        [DataMember(IsRequired = false)]
        public short VrstaIzplacila { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaNaslova { get; set; }
        [DataMember(IsRequired = false)]
        public short VrstaOsebe { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaOsebnegaDokumenta { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaPoslaZBS { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaUre { get; set; }
        [DataMember(IsRequired = false)]
        public string VrstaZaposlitve { get; set; }
        [DataMember(IsRequired = false)]
        public short VzdrzevaniOdrasli { get; set; }
        [DataMember(IsRequired = false)]
        public string ZacasnoBivalisce { get; set; }
        [DataMember(IsRequired = false)]
        public short Zaposlen { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? ZdravstveniPregled { get; set; }
        [DataMember(IsRequired = false)]
        public string ZdravstveniPregledST { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? ZdravstveniPregledVeljaDO { get; set; }
        [DataMember(IsRequired = false)]
        public DateTime? ZdravstveniPregledVeljaOD { get; set; }
        [DataMember(IsRequired = false)]
        public string Ziro_Racun { get; set; }
        [DataMember(IsRequired = false)]
        public string Ziro_Racun1 { get; set; }
        [DataMember(IsRequired = false)]
        public string Ziro_Racun2 { get; set; }
        [DataMember(IsRequired = false)]
        public short ZnizanjeTakse { get; set; }
        [DataMember(IsRequired = false)]
        public string AlterTelefon { get; set; }
        [DataMember(IsRequired = false)]
        public short MladiDo30 { get; set; }
        [DataMember(IsRequired = false)]
        public short PogodbaOPoslovodenju2014_18Clen { get; set; }
        [DataMember(IsRequired = false)]
        public short SP1LetoOprostitev30 { get; set; }
        [DataMember(IsRequired = false)]
        public short SP1LetoOprostitev50 { get; set; }
        [DataMember(IsRequired = false)]
        public short SP1OdMinimalne2014 { get; set; }
        [DataMember(IsRequired = false)]
        public Guid SyncId { get; set; }
        [DataMember(IsRequired = false)]
        public string YearCode { get; set; }
        [DataMember(IsRequired = false)]
        public string PredlogaDobavnica { get; set; }
        [DataMember(IsRequired = false)]
        public string PredlogaPredracun { get; set; }
        [DataMember(IsRequired = false)]
        public string PredlogaRacun { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz1NaDan { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz1NaMesec { get; set; }
        [DataMember(IsRequired = false)]
        public string Prevoz1Opis { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz2NaDan { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz2NaMesec { get; set; }
        [DataMember(IsRequired = false)]
        public string Prevoz2Opis { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz3NaDan { get; set; }
        [DataMember(IsRequired = false)]
        public double Prevoz3NaMesec { get; set; }
        [DataMember(IsRequired = false)]
        public string Prevoz3Opis { get; set; }
        [DataMember(IsRequired = false)]
        public short VzdrzevaniOtrociSPosebnimiPotrebami { get; set; }
        [DataMember(IsRequired = false)]
        public short cyrillic { get; set; }
        [DataMember(IsRequired = false)]
        public bool GDPR1 { get; set; }
        [DataMember(IsRequired = false)]
        public bool GDPR2 { get; set; }
        [DataMember(IsRequired = false)]
        public bool GDPR3 { get; set; }
        [DataMember(IsRequired = false)]
        public bool GDPR4 { get; set; }
        [DataMember(IsRequired = false)]
        public bool GDPR5 { get; set; }
        #endregion
    }
}
