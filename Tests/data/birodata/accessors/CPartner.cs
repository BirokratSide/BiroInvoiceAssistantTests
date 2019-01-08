using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Tests.data.structs;

namespace Tests.data.accessors
{
    public class CPartner
    {

        CDatabase database;

        #region // constructor //
        public CPartner(CDatabase database)
        {
            this.database = database;
        }
        #endregion
        #region !! IPartner - public !!
        public bool Delete(SPartner data)
        {
            bool result = false;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandDelete();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
                result = database.sqlConnection.ExecDataTableBln(cmd);
            }
            return result;
        }
        public SListResponse<SPartner> List(SListRequest data, Dictionary<string, string> WhereConditions)
        {
            SListResponse<SPartner> result = null;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandList(WhereConditions);
                // TODO : query parameters have to be added manually
                DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
                result = GListHelper.ListResponse<SPartner>(dtt, data);
            }
            return result;
        }
        public SPartner Load(int id)
        {
            SPartner result = null;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandLoad();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", id));
                DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
                if (dtt != null && dtt.Rows.Count == 1)
                {
                    result = new SPartner();
                    if (!GDataTypeConverter.ObjectFromDataRow(result, dtt.Rows[0]))
                        result = null;
                }
            }
            return result;
        }
        public int Save(SPartner data)
        {
            int result = 0;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                if (data.RecNo != 0)
                {
                    cmd.CommandText = CommandUpdate();
                    cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
                }
                else
                    cmd.CommandText = CommandInsert();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@AlternativnaImena", data.AlternativnaImena));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@BarkodaeSLOG", data.BarkodaeSLOG));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@BICKoda", data.BICKoda));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Cena1", data.Cena1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Cena2", data.Cena2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Cena3", data.Cena3));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Cena4", data.Cena4));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ClanaVpisal", data.ClanaVpisal));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ClanDatumVpisa", data.ClanDatumVpisa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ClanDo", data.ClanDo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ClanskaStevilka", data.ClanskaStevilka));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Custom1", data.Custom1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Custom2", data.Custom2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Custom3", data.Custom3));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Custom4", data.Custom4));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Custom5", data.Custom5));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumKonca", data.DatumKonca));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumNastopa", data.DatumNastopa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumRojstva", data.DatumRojstva));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumVnosa", data.DatumVnosa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DavcnaIzpostava", data.DavcnaIzpostava));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DavcnaStevilka", data.DavcnaStevilka));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DDV", data.DDV));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DelovnaDoba", data.DelovnaDoba));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DelovnoDovoljenjeST", data.DelovnoDovoljenjeST));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DelovnoMesto", data.DelovnoMesto));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Detacirani", data.Detacirani));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DirektorijPriloge", data.DirektorijPriloge));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatek1", data.Dodatek1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatek2", data.Dodatek2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatek3", data.Dodatek3));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatek4", data.Dodatek4));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatno1", data.Dodatno1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dodatno2", data.Dodatno2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Dopust", data.Dopust));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DovoljenjeIzdanoDne", data.DovoljenjeIzdanoDne));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DovoljenjeVeljaDO", data.DovoljenjeVeljaDO));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DovoljenjeVeljaOD", data.DovoljenjeVeljaOD));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DrugiDelodajalec", data.DrugiDelodajalec));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Drzava", data.Drzava));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DrzavaDetasirani", data.DrzavaDetasirani));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DrzavaRezidenstva", data.DrzavaRezidenstva));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Drzavljanstvo", data.Drzavljanstvo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DvigniCenoZaRabat", data.DvigniCenoZaRabat));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Email", data.Email));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@EMSO", data.EMSO));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@eSLOG", data.eSLOG));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Fax", data.Fax));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@GLNKoda", data.GLNKoda));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@H_ST", data.H_ST));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@HitraOpomba", data.HitraOpomba));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Hotelir", data.Hotelir));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@IDStevilka", data.IDStevilka));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@IME", data.IME));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@InternetDa", data.InternetDa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Invalid", data.Invalid));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@InvalidNadKvoto", data.InvalidNadKvoto));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@IzkorisceniDopust", data.IzkorisceniDopust));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@JeKontakt", data.JeKontakt));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Komentar1", data.Komentar1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Komentar2", data.Komentar2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@KomentarPopusta", data.KomentarPopusta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@KomentarZnizanjaTakse", data.KomentarZnizanjaTakse));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Komercialist", data.Komercialist));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@KonkurencnaKlavzula", data.KonkurencnaKlavzula));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Konsignatar", data.Konsignatar));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Kontakt", data.Kontakt));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Kraj", data.Kraj));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@KrajRojstva", data.KrajRojstva));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@KrajZacasnegaBivalisca", data.KrajZacasnegaBivalisca));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@LetnaNarocilnica", data.LetnaNarocilnica));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@MamicaDo3Leta", data.MamicaDo3Leta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@MaticnaStevilka", data.MaticnaStevilka));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Mesto", data.Mesto));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@NacinProdaje", data.NacinProdaje));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Naziv", data.Naziv));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Nerezident", data.Nerezident));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@NeUporabljaj", data.NeUporabljaj));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@NeUpostevajZaIOP", data.NeUpostevajZaIOP));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@NoceUPenzijo", data.NoceUPenzijo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ObcinaBivanja", data.ObcinaBivanja));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Obrazec", data.Obrazec));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OdjavljenIzZZZS", data.OdjavljenIzZZZS));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OdprtPri", data.OdprtPri));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OmejitevNeplacano", data.OmejitevNeplacano));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OmejitevZapadlo", data.OmejitevZapadlo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OmogociPlaciloZDobavnico", data.OmogociPlaciloZDobavnico));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Opombe", data.Opombe));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OpozoriloZaRacun", data.OpozoriloZaRacun));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OpozoriUporabnik", data.OpozoriUporabnik));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OpozoriZapadlo", data.OpozoriZapadlo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OsebnaIzkaznica", data.OsebnaIzkaznica));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Otroci", data.Otroci));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OZNAKA", data.OZNAKA));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Partner", data.Partner));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Partner1", data.Partner1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PE", data.PE));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PlacilniRok", data.PlacilniRok));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PlacilniRokNaOdpremo", data.PlacilniRokNaOdpremo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Pogodba", data.Pogodba));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PogodbaOPoslovodenju", data.PogodbaOPoslovodenju));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Poklic", data.Poklic));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Popust", data.Popust));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Posta", data.Posta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PostaZacasnegaBivalisca", data.PostaZacasnegaBivalisca));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PotniList", data.PotniList));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PotniListDatum", data.PotniListDatum));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PotniListDo", data.PotniListDo));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PotniListOd", data.PotniListOd));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PovecanaDobaProcent", data.PovecanaDobaProcent));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PovecanaSplosnaOlajsava", data.PovecanaSplosnaOlajsava));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PravniStatus", data.PravniStatus));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PrenesenoIzPOSa", data.PrenesenoIzPOSa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PreostaliDopust", data.PreostaliDopust));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PRIIMEK", data.PRIIMEK));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PrijavljenNaZZZS", data.PrijavljenNaZZZS));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RabatGeneralno", data.RabatGeneralno));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RabatnaSkupina", data.RabatnaSkupina));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rojen", data.Rojen));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RojenVKraju", data.RojenVKraju));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Sifra", data.Sifra));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SifraDrzave", data.SifraDrzave));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SifraDrzaveNaslova", data.SifraDrzaveNaslova));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SifraPojavnegaStatusa", data.SifraPojavnegaStatusa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SKIS", data.SKIS));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Sklic", data.Sklic));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Skupina", data.Skupina));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Spol", data.Spol));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Sprememba", data.Sprememba));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Stalnost", data.Stalnost));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@StalnostTrenutno", data.StalnostTrenutno));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@StevilkaOsebnegaDokumenta", data.StevilkaOsebnegaDokumenta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@StevilkaRacuna", data.StevilkaRacuna));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Stimulac", data.Stimulac));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@StopnjaIzobrazbe", data.StopnjaIzobrazbe));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SuperRabat", data.SuperRabat));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Telefon", data.Telefon));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Telefon2", data.Telefon2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TempCena1", data.TempCena1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TempCena2", data.TempCena2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TempCena3", data.TempCena3));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TezavnostDela", data.TezavnostDela));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TKDIS", data.TKDIS));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Ulica", data.Ulica));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VarnostPriDelu", data.VarnostPriDelu));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VarnostPriDeluST", data.VarnostPriDeluST));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VarnostPriDeluVeljaDO", data.VarnostPriDeluVeljaDO));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VarnostPriDeluVeljaOD", data.VarnostPriDeluVeljaOD));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Viza", data.Viza));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VizaDatum", data.VizaDatum));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VizaDO", data.VizaDO));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VizaOD", data.VizaOD));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VIzvrsbi", data.VIzvrsbi));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VIzvrsbiOd", data.VIzvrsbiOd));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vnasalec", data.Vnasalec));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VnesenoNaPOSu", data.VnesenoNaPOSu));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vrsta", data.Vrsta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaHonorarja", data.VrstaHonorarja));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaIzplacila", data.VrstaIzplacila));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaNaslova", data.VrstaNaslova));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaOsebe", data.VrstaOsebe));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaOsebnegaDokumenta", data.VrstaOsebnegaDokumenta));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaPoslaZBS", data.VrstaPoslaZBS));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaUre", data.VrstaUre));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaZaposlitve", data.VrstaZaposlitve));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VzdrzevaniOdrasli", data.VzdrzevaniOdrasli));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZacasnoBivalisce", data.ZacasnoBivalisce));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Zaposlen", data.Zaposlen));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZdravstveniPregled", data.ZdravstveniPregled));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZdravstveniPregledST", data.ZdravstveniPregledST));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZdravstveniPregledVeljaDO", data.ZdravstveniPregledVeljaDO));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZdravstveniPregledVeljaOD", data.ZdravstveniPregledVeljaOD));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Ziro_Racun", data.Ziro_Racun));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Ziro_Racun1", data.Ziro_Racun1));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Ziro_Racun2", data.Ziro_Racun2));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZnizanjeTakse", data.ZnizanjeTakse));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@AlterTelefon", data.AlterTelefon));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@MladiDo30", data.MladiDo30));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PogodbaOPoslovodenju2014_18Clen", data.PogodbaOPoslovodenju2014_18Clen));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SP1LetoOprostitev30", data.SP1LetoOprostitev30));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SP1LetoOprostitev50", data.SP1LetoOprostitev50));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SP1OdMinimalne2014", data.SP1OdMinimalne2014));
                result = database.sqlConnection.ExecDataTableInt(cmd);
            }
            return result;
        }
        #endregion
        #region // private //
        private string CommandDelete()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("delete " + nl);
            sb.Append("from      [" + database.biroDavcnaStevilka + "].[dbo].[Partner] " + nl);
            sb.Append("where     [YearCode] = '" + database.partnerYearCode + "' " + nl);
            sb.Append("              and [RecNo] = @RecNo " + nl);
            sb.Append("select    @@rowcount as [Count] ");

            return sb.ToString();
        }
        private string CommandList(Dictionary<string, string> WhereClauses)
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("select " + nl);
            sb.Append("			[Sifra], " + nl);
            sb.Append("			[YearCode] " + nl);
            sb.Append("from		[" + database.biroDavcnaStevilka + "].[dbo].[Partner] " + nl);
            sb.Append("where	[YearCode] = '" + database.partnerYearCode + "' " + nl);

            foreach (var key in WhereClauses.Keys)
            {
                sb.Append(String.Format("   and {0} = '{1}' ", key, WhereClauses[key]));
            }

            return sb.ToString();
        }
        private string CommandLoad()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("select " + nl);
            sb.Append("			[Sifra], " + nl);
            sb.Append("			[YearCode] " + nl);
            sb.Append("from		[" + database.biroDavcnaStevilka + "].[dbo].[Partner] " + nl);
            sb.Append("where	[YearCode] = '" + database.partnerYearCode + "' " + nl);
            sb.Append("				and [RecNo] = @RecNo ");

            return sb.ToString();
        }
        private string CommandInsert()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("insert into	[" + database.biroDavcnaStevilka + "].[dbo].[Partner]" + nl);
            sb.Append("				([AlternativnaImena], [BarkodaeSLOG], [BICKoda], [Cena1], [Cena2], [Cena3], [Cena4], [ClanaVpisal], [ClanDatumVpisa], [ClanDo], [ClanskaStevilka], [Custom1], [Custom2], [Custom3], [Custom4], [Custom5], [DatumKonca], [DatumNastopa], [DatumRojstva], [DatumVnosa], [DavcnaIzpostava], [DavcnaStevilka], [DDV], [DelovnaDoba], [DelovnoDovoljenjeST], [DelovnoMesto], [Detacirani], [DirektorijPriloge], [Dodatek1], [Dodatek2], [Dodatek3], [Dodatek4], [Dodatno1], [Dodatno2], [Dopust], [DovoljenjeIzdanoDne], [DovoljenjeVeljaDO], [DovoljenjeVeljaOD], [DrugiDelodajalec], [Drzava], [DrzavaDetasirani], [DrzavaRezidenstva], [Drzavljanstvo], [DvigniCenoZaRabat], [Email], [EMSO], [eSLOG], [Fax], [GLNKoda], [H_ST], [HitraOpomba], [Hotelir], [IDStevilka], [IME], [InternetDa], [Invalid], [InvalidNadKvoto], [IzkorisceniDopust], [JeKontakt], [Komentar1], [Komentar2], [KomentarPopusta], [KomentarZnizanjaTakse], [Komercialist], [KonkurencnaKlavzula], [Konsignatar], [Kontakt], [Kraj], [KrajRojstva], [KrajZacasnegaBivalisca], [LetnaNarocilnica], [MamicaDo3Leta], [MaticnaStevilka], [Mesto], [NacinProdaje], [Naziv], [Nerezident], [NeUporabljaj], [NeUpostevajZaIOP], [NoceUPenzijo], [ObcinaBivanja], [Obrazec], [OdjavljenIzZZZS], [OdprtPri], [OmejitevNeplacano], [OmejitevZapadlo], [OmogociPlaciloZDobavnico], [Opombe], [OpozoriloZaRacun], [OpozoriUporabnik], [OpozoriZapadlo], [OsebnaIzkaznica], [Otroci], [OZNAKA], [Partner], [Partner1], [PE], [PlacilniRok], [PlacilniRokNaOdpremo], [Pogodba], [PogodbaOPoslovodenju], [Poklic], [Popust], [Posta], [PostaZacasnegaBivalisca], [PotniList], [PotniListDatum], [PotniListDo], [PotniListOd], [PovecanaDobaProcent], [PovecanaSplosnaOlajsava], [PravniStatus], [PrenesenoIzPOSa], [PreostaliDopust], [PRIIMEK], [PrijavljenNaZZZS], [RabatGeneralno], [RabatnaSkupina], [Rojen], [RojenVKraju], [Sifra], [SifraDrzave], [SifraDrzaveNaslova], [SifraPojavnegaStatusa], [SKIS], [Sklic], [Skupina], [Spol], [Sprememba], [Stalnost], [StalnostTrenutno], [StevilkaOsebnegaDokumenta], [StevilkaRacuna], [Stimulac], [StopnjaIzobrazbe], [SuperRabat], [Telefon], [Telefon2], [TempCena1], [TempCena2], [TempCena3], [TezavnostDela], [TKDIS], [Ulica], [VarnostPriDelu], [VarnostPriDeluST], [VarnostPriDeluVeljaDO], [VarnostPriDeluVeljaOD], [Viza], [VizaDatum], [VizaDO], [VizaOD], [VIzvrsbi], [VIzvrsbiOd], [Vnasalec], [VnesenoNaPOSu], [Vrsta], [VrstaHonorarja], [VrstaIzplacila], [VrstaNaslova], [VrstaOsebe], [VrstaOsebnegaDokumenta], [VrstaPoslaZBS], [VrstaUre], [VrstaZaposlitve], [VzdrzevaniOdrasli], [ZacasnoBivalisce], [Zaposlen], [ZdravstveniPregled], [ZdravstveniPregledST], [ZdravstveniPregledVeljaDO], [ZdravstveniPregledVeljaOD], [Ziro_Racun], [Ziro_Racun1], [Ziro_Racun2], [ZnizanjeTakse], [AlterTelefon], [MladiDo30], [PogodbaOPoslovodenju2014_18Clen], [SP1LetoOprostitev30], [SP1LetoOprostitev50], [SP1OdMinimalne2014], [YearCode]) " + nl);
            sb.Append("values		(@AlternativnaImena, @BarkodaeSLOG, @BICKoda, @Cena1, @Cena2, @Cena3, @Cena4, @ClanaVpisal, @ClanDatumVpisa, @ClanDo, @ClanskaStevilka, @Custom1, @Custom2, @Custom3, @Custom4, @Custom5, @DatumKonca, @DatumNastopa, @DatumRojstva, @DatumVnosa, @DavcnaIzpostava, @DavcnaStevilka, @DDV, @DelovnaDoba, @DelovnoDovoljenjeST, @DelovnoMesto, @Detacirani, @DirektorijPriloge, @Dodatek1, @Dodatek2, @Dodatek3, @Dodatek4, @Dodatno1, @Dodatno2, @Dopust, @DovoljenjeIzdanoDne, @DovoljenjeVeljaDO, @DovoljenjeVeljaOD, @DrugiDelodajalec, @Drzava, @DrzavaDetasirani, @DrzavaRezidenstva, @Drzavljanstvo, @DvigniCenoZaRabat, @Email, @EMSO, @eSLOG, @Fax, @GLNKoda, @H_ST, @HitraOpomba, @Hotelir, @IDStevilka, @IME, @InternetDa, @Invalid, @InvalidNadKvoto, @IzkorisceniDopust, @JeKontakt, @Komentar1, @Komentar2, @KomentarPopusta, @KomentarZnizanjaTakse, @Komercialist, @KonkurencnaKlavzula, @Konsignatar, @Kontakt, @Kraj, @KrajRojstva, @KrajZacasnegaBivalisca, @LetnaNarocilnica, @MamicaDo3Leta, @MaticnaStevilka, @Mesto, @NacinProdaje, @Naziv, @Nerezident, @NeUporabljaj, @NeUpostevajZaIOP, @NoceUPenzijo, @ObcinaBivanja, @Obrazec, @OdjavljenIzZZZS, @OdprtPri, @OmejitevNeplacano, @OmejitevZapadlo, @OmogociPlaciloZDobavnico, @Opombe, @OpozoriloZaRacun, @OpozoriUporabnik, @OpozoriZapadlo, @OsebnaIzkaznica, @Otroci, @OZNAKA, @Partner, @Partner1, @PE, @PlacilniRok, @PlacilniRokNaOdpremo, @Pogodba, @PogodbaOPoslovodenju, @Poklic, @Popust, @Posta, @PostaZacasnegaBivalisca, @PotniList, @PotniListDatum, @PotniListDo, @PotniListOd, @PovecanaDobaProcent, @PovecanaSplosnaOlajsava, @PravniStatus, @PrenesenoIzPOSa, @PreostaliDopust, @PRIIMEK, @PrijavljenNaZZZS, @RabatGeneralno, @RabatnaSkupina, @Rojen, @RojenVKraju, @Sifra, @SifraDrzave, @SifraDrzaveNaslova, @SifraPojavnegaStatusa, @SKIS, @Sklic, @Skupina, @Spol, @Sprememba, @Stalnost, @StalnostTrenutno, @StevilkaOsebnegaDokumenta, @StevilkaRacuna, @Stimulac, @StopnjaIzobrazbe, @SuperRabat, @Telefon, @Telefon2, @TempCena1, @TempCena2, @TempCena3, @TezavnostDela, @TKDIS, @Ulica, @VarnostPriDelu, @VarnostPriDeluST, @VarnostPriDeluVeljaDO, @VarnostPriDeluVeljaOD, @Viza, @VizaDatum, @VizaDO, @VizaOD, @VIzvrsbi, @VIzvrsbiOd, @Vnasalec, @VnesenoNaPOSu, @Vrsta, @VrstaHonorarja, @VrstaIzplacila, @VrstaNaslova, @VrstaOsebe, @VrstaOsebnegaDokumenta, @VrstaPoslaZBS, @VrstaUre, @VrstaZaposlitve, @VzdrzevaniOdrasli, @ZacasnoBivalisce, @Zaposlen, @ZdravstveniPregled, @ZdravstveniPregledST, @ZdravstveniPregledVeljaDO, @ZdravstveniPregledVeljaOD, @Ziro_Racun, @Ziro_Racun1, @Ziro_Racun2, @ZnizanjeTakse, @AlterTelefon, @MladiDo30, @PogodbaOPoslovodenju2014_18Clen, @SP1LetoOprostitev30, @SP1LetoOprostitev50, @SP1OdMinimalne2014, '" + database.partnerYearCode + "') " + nl);
            sb.Append("select		ident_current('[" + database.biroDavcnaStevilka + "].[dbo].[Partner]') as [RecNo] ");

            return sb.ToString();
        }
        private string CommandUpdate()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("update	[" + database.biroDavcnaStevilka + "].[dbo].[Partner]" + nl);
            sb.Append("set " + nl);
            sb.Append("			[AlternativnaImena] = @AlternativnaImena, " + nl);
            sb.Append("			[BarkodaeSLOG] = @BarkodaeSLOG, " + nl);
            sb.Append("			[BICKoda] = @BICKoda, " + nl);
            sb.Append("			[Cena1] = @Cena1, " + nl);
            sb.Append("			[Cena2] = @Cena2, " + nl);
            sb.Append("			[Cena3] = @Cena3, " + nl);
            sb.Append("			[Cena4] = @Cena4, " + nl);
            sb.Append("			[ClanaVpisal] = @ClanaVpisal, " + nl);
            sb.Append("			[ClanDatumVpisa] = @ClanDatumVpisa, " + nl);
            sb.Append("			[ClanDo] = @ClanDo, " + nl);
            sb.Append("			[ClanskaStevilka] = @ClanskaStevilka, " + nl);
            sb.Append("			[Custom1] = @Custom1, " + nl);
            sb.Append("			[Custom2] = @Custom2, " + nl);
            sb.Append("			[Custom3] = @Custom3, " + nl);
            sb.Append("			[Custom4] = @Custom4, " + nl);
            sb.Append("			[Custom5] = @Custom5, " + nl);
            sb.Append("			[DatumKonca] = @DatumKonca, " + nl);
            sb.Append("			[DatumNastopa] = @DatumNastopa, " + nl);
            sb.Append("			[DatumRojstva] = @DatumRojstva, " + nl);
            sb.Append("			[DatumVnosa] = @DatumVnosa, " + nl);
            sb.Append("			[DavcnaIzpostava] = @DavcnaIzpostava, " + nl);
            sb.Append("			[DavcnaStevilka] = @DavcnaStevilka, " + nl);
            sb.Append("			[DDV] = @DDV, " + nl);
            sb.Append("			[DelovnaDoba] = @DelovnaDoba, " + nl);
            sb.Append("			[DelovnoDovoljenjeST] = @DelovnoDovoljenjeST, " + nl);
            sb.Append("			[DelovnoMesto] = @DelovnoMesto, " + nl);
            sb.Append("			[Detacirani] = @Detacirani, " + nl);
            sb.Append("			[DirektorijPriloge] = @DirektorijPriloge, " + nl);
            sb.Append("			[Dodatek1] = @Dodatek1, " + nl);
            sb.Append("			[Dodatek2] = @Dodatek2, " + nl);
            sb.Append("			[Dodatek3] = @Dodatek3, " + nl);
            sb.Append("			[Dodatek4] = @Dodatek4, " + nl);
            sb.Append("			[Dodatno1] = @Dodatno1, " + nl);
            sb.Append("			[Dodatno2] = @Dodatno2, " + nl);
            sb.Append("			[Dopust] = @Dopust, " + nl);
            sb.Append("			[DovoljenjeIzdanoDne] = @DovoljenjeIzdanoDne, " + nl);
            sb.Append("			[DovoljenjeVeljaDO] = @DovoljenjeVeljaDO, " + nl);
            sb.Append("			[DovoljenjeVeljaOD] = @DovoljenjeVeljaOD, " + nl);
            sb.Append("			[DrugiDelodajalec] = @DrugiDelodajalec, " + nl);
            sb.Append("			[Drzava] = @Drzava, " + nl);
            sb.Append("			[DrzavaDetasirani] = @DrzavaDetasirani, " + nl);
            sb.Append("			[DrzavaRezidenstva] = @DrzavaRezidenstva, " + nl);
            sb.Append("			[Drzavljanstvo] = @Drzavljanstvo, " + nl);
            sb.Append("			[DvigniCenoZaRabat] = @DvigniCenoZaRabat, " + nl);
            sb.Append("			[Email] = @Email, " + nl);
            sb.Append("			[EMSO] = @EMSO, " + nl);
            sb.Append("			[eSLOG] = @eSLOG, " + nl);
            sb.Append("			[Fax] = @Fax, " + nl);
            sb.Append("			[GLNKoda] = @GLNKoda, " + nl);
            sb.Append("			[H_ST] = @H_ST, " + nl);
            sb.Append("			[HitraOpomba] = @HitraOpomba, " + nl);
            sb.Append("			[Hotelir] = @Hotelir, " + nl);
            sb.Append("			[IDStevilka] = @IDStevilka, " + nl);
            sb.Append("			[IME] = @IME, " + nl);
            sb.Append("			[InternetDa] = @InternetDa, " + nl);
            sb.Append("			[Invalid] = @Invalid, " + nl);
            sb.Append("			[InvalidNadKvoto] = @InvalidNadKvoto, " + nl);
            sb.Append("			[IzkorisceniDopust] = @IzkorisceniDopust, " + nl);
            sb.Append("			[JeKontakt] = @JeKontakt, " + nl);
            sb.Append("			[Komentar1] = @Komentar1, " + nl);
            sb.Append("			[Komentar2] = @Komentar2, " + nl);
            sb.Append("			[KomentarPopusta] = @KomentarPopusta, " + nl);
            sb.Append("			[KomentarZnizanjaTakse] = @KomentarZnizanjaTakse, " + nl);
            sb.Append("			[Komercialist] = @Komercialist, " + nl);
            sb.Append("			[KonkurencnaKlavzula] = @KonkurencnaKlavzula, " + nl);
            sb.Append("			[Konsignatar] = @Konsignatar, " + nl);
            sb.Append("			[Kontakt] = @Kontakt, " + nl);
            sb.Append("			[Kraj] = @Kraj, " + nl);
            sb.Append("			[KrajRojstva] = @KrajRojstva, " + nl);
            sb.Append("			[KrajZacasnegaBivalisca] = @KrajZacasnegaBivalisca, " + nl);
            sb.Append("			[LetnaNarocilnica] = @LetnaNarocilnica, " + nl);
            sb.Append("			[MamicaDo3Leta] = @MamicaDo3Leta, " + nl);
            sb.Append("			[MaticnaStevilka] = @MaticnaStevilka, " + nl);
            sb.Append("			[Mesto] = @Mesto, " + nl);
            sb.Append("			[NacinProdaje] = @NacinProdaje, " + nl);
            sb.Append("			[Naziv] = @Naziv, " + nl);
            sb.Append("			[Nerezident] = @Nerezident, " + nl);
            sb.Append("			[NeUporabljaj] = @NeUporabljaj, " + nl);
            sb.Append("			[NeUpostevajZaIOP] = @NeUpostevajZaIOP, " + nl);
            sb.Append("			[NoceUPenzijo] = @NoceUPenzijo, " + nl);
            sb.Append("			[ObcinaBivanja] = @ObcinaBivanja, " + nl);
            sb.Append("			[Obrazec] = @Obrazec, " + nl);
            sb.Append("			[OdjavljenIzZZZS] = @OdjavljenIzZZZS, " + nl);
            sb.Append("			[OdprtPri] = @OdprtPri, " + nl);
            sb.Append("			[OmejitevNeplacano] = @OmejitevNeplacano, " + nl);
            sb.Append("			[OmejitevZapadlo] = @OmejitevZapadlo, " + nl);
            sb.Append("			[OmogociPlaciloZDobavnico] = @OmogociPlaciloZDobavnico, " + nl);
            sb.Append("			[Opombe] = @Opombe, " + nl);
            sb.Append("			[OpozoriloZaRacun] = @OpozoriloZaRacun, " + nl);
            sb.Append("			[OpozoriUporabnik] = @OpozoriUporabnik, " + nl);
            sb.Append("			[OpozoriZapadlo] = @OpozoriZapadlo, " + nl);
            sb.Append("			[OsebnaIzkaznica] = @OsebnaIzkaznica, " + nl);
            sb.Append("			[Otroci] = @Otroci, " + nl);
            sb.Append("			[OZNAKA] = @OZNAKA, " + nl);
            sb.Append("			[Partner] = @Partner, " + nl);
            sb.Append("			[Partner1] = @Partner1, " + nl);
            sb.Append("			[PE] = @PE, " + nl);
            sb.Append("			[PlacilniRok] = @PlacilniRok, " + nl);
            sb.Append("			[PlacilniRokNaOdpremo] = @PlacilniRokNaOdpremo, " + nl);
            sb.Append("			[Pogodba] = @Pogodba, " + nl);
            sb.Append("			[PogodbaOPoslovodenju] = @PogodbaOPoslovodenju, " + nl);
            sb.Append("			[Poklic] = @Poklic, " + nl);
            sb.Append("			[Popust] = @Popust, " + nl);
            sb.Append("			[Posta] = @Posta, " + nl);
            sb.Append("			[PostaZacasnegaBivalisca] = @PostaZacasnegaBivalisca, " + nl);
            sb.Append("			[PotniList] = @PotniList, " + nl);
            sb.Append("			[PotniListDatum] = @PotniListDatum, " + nl);
            sb.Append("			[PotniListDo] = @PotniListDo, " + nl);
            sb.Append("			[PotniListOd] = @PotniListOd, " + nl);
            sb.Append("			[PovecanaDobaProcent] = @PovecanaDobaProcent, " + nl);
            sb.Append("			[PovecanaSplosnaOlajsava] = @PovecanaSplosnaOlajsava, " + nl);
            sb.Append("			[PravniStatus] = @PravniStatus, " + nl);
            sb.Append("			[PrenesenoIzPOSa] = @PrenesenoIzPOSa, " + nl);
            sb.Append("			[PreostaliDopust] = @PreostaliDopust, " + nl);
            sb.Append("			[PRIIMEK] = @PRIIMEK, " + nl);
            sb.Append("			[PrijavljenNaZZZS] = @PrijavljenNaZZZS, " + nl);
            sb.Append("			[RabatGeneralno] = @RabatGeneralno, " + nl);
            sb.Append("			[RabatnaSkupina] = @RabatnaSkupina, " + nl);
            sb.Append("			[Rojen] = @Rojen, " + nl);
            sb.Append("			[RojenVKraju] = @RojenVKraju, " + nl);
            sb.Append("			[Sifra] = @Sifra, " + nl);
            sb.Append("			[SifraDrzave] = @SifraDrzave, " + nl);
            sb.Append("			[SifraDrzaveNaslova] = @SifraDrzaveNaslova, " + nl);
            sb.Append("			[SifraPojavnegaStatusa] = @SifraPojavnegaStatusa, " + nl);
            sb.Append("			[SKIS] = @SKIS, " + nl);
            sb.Append("			[Sklic] = @Sklic, " + nl);
            sb.Append("			[Skupina] = @Skupina, " + nl);
            sb.Append("			[Spol] = @Spol, " + nl);
            sb.Append("			[Sprememba] = @Sprememba, " + nl);
            sb.Append("			[Stalnost] = @Stalnost, " + nl);
            sb.Append("			[StalnostTrenutno] = @StalnostTrenutno, " + nl);
            sb.Append("			[StevilkaOsebnegaDokumenta] = @StevilkaOsebnegaDokumenta, " + nl);
            sb.Append("			[StevilkaRacuna] = @StevilkaRacuna, " + nl);
            sb.Append("			[Stimulac] = @Stimulac, " + nl);
            sb.Append("			[StopnjaIzobrazbe] = @StopnjaIzobrazbe, " + nl);
            sb.Append("			[SuperRabat] = @SuperRabat, " + nl);
            sb.Append("			[Telefon] = @Telefon, " + nl);
            sb.Append("			[Telefon2] = @Telefon2, " + nl);
            sb.Append("			[TempCena1] = @TempCena1, " + nl);
            sb.Append("			[TempCena2] = @TempCena2, " + nl);
            sb.Append("			[TempCena3] = @TempCena3, " + nl);
            sb.Append("			[TezavnostDela] = @TezavnostDela, " + nl);
            sb.Append("			[TKDIS] = @TKDIS, " + nl);
            sb.Append("			[Ulica] = @Ulica, " + nl);
            sb.Append("			[VarnostPriDelu] = @VarnostPriDelu, " + nl);
            sb.Append("			[VarnostPriDeluST] = @VarnostPriDeluST, " + nl);
            sb.Append("			[VarnostPriDeluVeljaDO] = @VarnostPriDeluVeljaDO, " + nl);
            sb.Append("			[VarnostPriDeluVeljaOD] = @VarnostPriDeluVeljaOD, " + nl);
            sb.Append("			[Viza] = @Viza, " + nl);
            sb.Append("			[VizaDatum] = @VizaDatum, " + nl);
            sb.Append("			[VizaDO] = @VizaDO, " + nl);
            sb.Append("			[VizaOD] = @VizaOD, " + nl);
            sb.Append("			[VIzvrsbi] = @VIzvrsbi, " + nl);
            sb.Append("			[VIzvrsbiOd] = @VIzvrsbiOd, " + nl);
            sb.Append("			[Vnasalec] = @Vnasalec, " + nl);
            sb.Append("			[VnesenoNaPOSu] = @VnesenoNaPOSu, " + nl);
            sb.Append("			[Vrsta] = @Vrsta, " + nl);
            sb.Append("			[VrstaHonorarja] = @VrstaHonorarja, " + nl);
            sb.Append("			[VrstaIzplacila] = @VrstaIzplacila, " + nl);
            sb.Append("			[VrstaNaslova] = @VrstaNaslova, " + nl);
            sb.Append("			[VrstaOsebe] = @VrstaOsebe, " + nl);
            sb.Append("			[VrstaOsebnegaDokumenta] = @VrstaOsebnegaDokumenta, " + nl);
            sb.Append("			[VrstaPoslaZBS] = @VrstaPoslaZBS, " + nl);
            sb.Append("			[VrstaUre] = @VrstaUre, " + nl);
            sb.Append("			[VrstaZaposlitve] = @VrstaZaposlitve, " + nl);
            sb.Append("			[VzdrzevaniOdrasli] = @VzdrzevaniOdrasli, " + nl);
            sb.Append("			[ZacasnoBivalisce] = @ZacasnoBivalisce, " + nl);
            sb.Append("			[Zaposlen] = @Zaposlen, " + nl);
            sb.Append("			[ZdravstveniPregled] = @ZdravstveniPregled, " + nl);
            sb.Append("			[ZdravstveniPregledST] = @ZdravstveniPregledST, " + nl);
            sb.Append("			[ZdravstveniPregledVeljaDO] = @ZdravstveniPregledVeljaDO, " + nl);
            sb.Append("			[ZdravstveniPregledVeljaOD] = @ZdravstveniPregledVeljaOD, " + nl);
            sb.Append("			[Ziro_Racun] = @Ziro_Racun, " + nl);
            sb.Append("			[Ziro_Racun1] = @Ziro_Racun1, " + nl);
            sb.Append("			[Ziro_Racun2] = @Ziro_Racun2, " + nl);
            sb.Append("			[ZnizanjeTakse] = @ZnizanjeTakse, " + nl);
            sb.Append("			[AlterTelefon] = @AlterTelefon, " + nl);
            sb.Append("			[MladiDo30] = @MladiDo30, " + nl);
            sb.Append("			[PogodbaOPoslovodenju2014_18Clen] = @PogodbaOPoslovodenju2014_18Clen, " + nl);
            sb.Append("			[SP1LetoOprostitev30] = @SP1LetoOprostitev30, " + nl);
            sb.Append("			[SP1LetoOprostitev50] = @SP1LetoOprostitev50, " + nl);
            sb.Append("			[SP1OdMinimalne2014] = @SP1OdMinimalne2014 " + nl);
            sb.Append("where	[YearCode] = '" + database.partnerYearCode + "' " + nl);
            sb.Append("				and [RecNo] = @RecNo ");
            sb.Append("if (@@rowcount > 0)	select @RecNo as [RecNo] " + nl);
            sb.Append("else					select 0 as [RecNo] ");

            return sb.ToString();
        }
        #endregion
    }
}
