using System;
using System.Data;
using System.Text;

using Tests.data;
using Tests.data.structs;

namespace Tests.data.accessors {
	public class CPostnaKnjiga {

        CDatabase database;

		#region // constructor //
		public CPostnaKnjiga(CDatabase database) {
            this.database = database;
        }
		#endregion
		#region !! IPostnaKnjiga - public !!
		public bool Delete(SPostnaKnjiga data) {
			bool result = false;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandDelete();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
				result = database.sqlConnection.ExecDataTableBln(cmd);
			}
			return result;
		}
		public SListResponse<SPostnaKnjiga> List(SListRequest data) {
			SListResponse<SPostnaKnjiga> result = null;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandList();
				// TODO : query parameters have to be added manually
				DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
				result = GListHelper.ListResponse<SPostnaKnjiga>(dtt, data);
			}
			return result;
		}
		public SPostnaKnjiga Load(int id) {
			SPostnaKnjiga result = null;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandLoad();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", id));
				DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
				if (dtt != null && dtt.Rows.Count == 1) {
					result = new SPostnaKnjiga();
					if (!GDataTypeConverter.ObjectFromDataRow(result, dtt.Rows[0]))
						result = null;
				}
			}
			return result;
		}
		public int Save(SPostnaKnjiga data) {
			int result = 0;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				if (data.RecNo != 0) {
					cmd.CommandText = CommandUpdate();
					cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
				} else
					cmd.CommandText = CommandInsert();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Datum", data.Datum));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumPotrditve", data.DatumPotrditve));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumVnosa", data.DatumVnosa));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ImePartnerja", data.ImePartnerja));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Komentar", data.Komentar));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Letalsko", data.Letalsko));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Nujno", data.Nujno));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Odkupnina", data.Odkupnina));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Postnina", data.Postnina));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SifraPartnerja", data.SifraPartnerja));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Sporocilo", data.Sporocilo));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Teza", data.Teza));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Tip", data.Tip));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vnasalec", data.Vnasalec));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrednostPoste", data.VrednostPoste));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@VrstaPoste", data.VrstaPoste));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Zadeva", data.Zadeva));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Zaposlen", data.Zaposlen));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZapSt", data.ZapSt));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Datum1", data.Datum1));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Datum2", data.Datum2));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@eSLOGGUID", data.eSLOGGUID));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@InternaStevilka", data.InternaStevilka));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@MPO", data.MPO));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@PE", data.PE));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ScanPrenesen", data.ScanPrenesen));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SlikeOznaka", data.SlikeOznaka));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@SlikeVrsta", data.SlikeVrsta));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@TipPoste", data.TipPoste));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZZI", data.ZZI));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZZI1", data.ZZI1));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@ZZI2", data.ZZI2));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Likvidacija", data.Likvidacija));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_DateTime_Received", data.Rih_DateTime_Received));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_DateTime_Sent", data.Rih_DateTime_Sent));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_DateTime_Updated", data.Rih_DateTime_Updated));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_gross", data.Rih_gross));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_gross_0", data.Rih_gross_0));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_gross_M", data.Rih_gross_M));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_gross_V", data.Rih_gross_V));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_inv_date", data.Rih_inv_date));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_inv_num", data.Rih_inv_num));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_net", data.Rih_net));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_net_0", data.Rih_net_0));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_net_M", data.Rih_net_M));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_net_V", data.Rih_net_V));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_pay_until", data.Rih_pay_until));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_reference", data.Rih_reference));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat", data.Rih_vat));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat_0", data.Rih_vat_0));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat_id_buyer", data.Rih_vat_id_buyer));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat_id_publisher", data.Rih_vat_id_publisher));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat_M", data.Rih_vat_M));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Rih_vat_V", data.Rih_vat_V));
				result = database.sqlConnection.ExecDataTableInt(cmd);
			}
			return result;
		}
		#endregion
		#region // private //
		private string CommandDelete() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("delete " + nl);
			sb.Append("from      [" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga] " + nl);
			sb.Append("where     [YearCode] = '" + database.companyYearCode + "' " + nl);
			sb.Append("              and [RecNo] = @RecNo " + nl);
			sb.Append("select    @@rowcount as [Count] ");

			return sb.ToString();
		}
		private string CommandList() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("select " + nl);
			sb.Append("			[Datum], " + nl);
			sb.Append("			[DatumPotrditve], " + nl);
			sb.Append("			[DatumVnosa], " + nl);
			sb.Append("			[ImePartnerja], " + nl);
			sb.Append("			[Komentar], " + nl);
			sb.Append("			[Letalsko], " + nl);
			sb.Append("			[Nujno], " + nl);
			sb.Append("			[Odkupnina], " + nl);
			sb.Append("			[Postnina], " + nl);
			sb.Append("			[RecNo], " + nl);
			sb.Append("			[SifraPartnerja], " + nl);
			sb.Append("			[Sporocilo], " + nl);
			sb.Append("			[Teza], " + nl);
			sb.Append("			[Tip], " + nl);
			sb.Append("			[Vnasalec], " + nl);
			sb.Append("			[VrednostPoste], " + nl);
			sb.Append("			[VrstaPoste], " + nl);
			sb.Append("			[Zadeva], " + nl);
			sb.Append("			[Zaposlen], " + nl);
			sb.Append("			[ZapSt], " + nl);
			sb.Append("			[Datum1], " + nl);
			sb.Append("			[Datum2], " + nl);
			sb.Append("			[eSLOGGUID], " + nl);
			sb.Append("			[InternaStevilka], " + nl);
			sb.Append("			[MPO], " + nl);
			sb.Append("			[PE], " + nl);
			sb.Append("			[ScanPrenesen], " + nl);
			sb.Append("			[SlikeOznaka], " + nl);
			sb.Append("			[SlikeVrsta], " + nl);
			sb.Append("			[TipPoste], " + nl);
			sb.Append("			[ZZI], " + nl);
			sb.Append("			[ZZI1], " + nl);
			sb.Append("			[ZZI2], " + nl);
			sb.Append("			[SyncId], " + nl);
			sb.Append("			[YearCode], " + nl);
			sb.Append("			[Likvidacija], " + nl);
			sb.Append("			[Rih_DateTime_Received], " + nl);
			sb.Append("			[Rih_DateTime_Sent], " + nl);
			sb.Append("			[Rih_DateTime_Updated], " + nl);
			sb.Append("			[Rih_gross], " + nl);
			sb.Append("			[Rih_gross_0], " + nl);
			sb.Append("			[Rih_gross_M], " + nl);
			sb.Append("			[Rih_gross_V], " + nl);
			sb.Append("			[Rih_inv_date], " + nl);
			sb.Append("			[Rih_inv_num], " + nl);
			sb.Append("			[Rih_net], " + nl);
			sb.Append("			[Rih_net_0], " + nl);
			sb.Append("			[Rih_net_M], " + nl);
			sb.Append("			[Rih_net_V], " + nl);
			sb.Append("			[Rih_pay_until], " + nl);
			sb.Append("			[Rih_reference], " + nl);
			sb.Append("			[Rih_vat], " + nl);
			sb.Append("			[Rih_vat_0], " + nl);
			sb.Append("			[Rih_vat_id_buyer], " + nl);
			sb.Append("			[Rih_vat_id_publisher], " + nl);
			sb.Append("			[Rih_vat_M], " + nl);
			sb.Append("			[Rih_vat_V] " + nl);
			sb.Append("from		[" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga] " + nl);
			sb.Append("where	[YearCode] = '" + database.companyYearCode + "' " + nl);
			// TODO : other query conditions have to be added manually

			return sb.ToString();
		}
		private string CommandLoad() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("select " + nl);
			sb.Append("			[Datum], " + nl);
			sb.Append("			[DatumPotrditve], " + nl);
			sb.Append("			[DatumVnosa], " + nl);
			sb.Append("			[ImePartnerja], " + nl);
			sb.Append("			[Komentar], " + nl);
			sb.Append("			[Letalsko], " + nl);
			sb.Append("			[Nujno], " + nl);
			sb.Append("			[Odkupnina], " + nl);
			sb.Append("			[Postnina], " + nl);
			sb.Append("			[RecNo], " + nl);
			sb.Append("			[SifraPartnerja], " + nl);
			sb.Append("			[Sporocilo], " + nl);
			sb.Append("			[Teza], " + nl);
			sb.Append("			[Tip], " + nl);
			sb.Append("			[Vnasalec], " + nl);
			sb.Append("			[VrednostPoste], " + nl);
			sb.Append("			[VrstaPoste], " + nl);
			sb.Append("			[Zadeva], " + nl);
			sb.Append("			[Zaposlen], " + nl);
			sb.Append("			[ZapSt], " + nl);
			sb.Append("			[Datum1], " + nl);
			sb.Append("			[Datum2], " + nl);
			sb.Append("			[eSLOGGUID], " + nl);
			sb.Append("			[InternaStevilka], " + nl);
			sb.Append("			[MPO], " + nl);
			sb.Append("			[PE], " + nl);
			sb.Append("			[ScanPrenesen], " + nl);
			sb.Append("			[SlikeOznaka], " + nl);
			sb.Append("			[SlikeVrsta], " + nl);
			sb.Append("			[TipPoste], " + nl);
			sb.Append("			[ZZI], " + nl);
			sb.Append("			[ZZI1], " + nl);
			sb.Append("			[ZZI2], " + nl);
			sb.Append("			[SyncId], " + nl);
			sb.Append("			[YearCode], " + nl);
			sb.Append("			[Likvidacija], " + nl);
			sb.Append("			[Rih_DateTime_Received], " + nl);
			sb.Append("			[Rih_DateTime_Sent], " + nl);
			sb.Append("			[Rih_DateTime_Updated], " + nl);
			sb.Append("			[Rih_gross], " + nl);
			sb.Append("			[Rih_gross_0], " + nl);
			sb.Append("			[Rih_gross_M], " + nl);
			sb.Append("			[Rih_gross_V], " + nl);
			sb.Append("			[Rih_inv_date], " + nl);
			sb.Append("			[Rih_inv_num], " + nl);
			sb.Append("			[Rih_net], " + nl);
			sb.Append("			[Rih_net_0], " + nl);
			sb.Append("			[Rih_net_M], " + nl);
			sb.Append("			[Rih_net_V], " + nl);
			sb.Append("			[Rih_pay_until], " + nl);
			sb.Append("			[Rih_reference], " + nl);
			sb.Append("			[Rih_vat], " + nl);
			sb.Append("			[Rih_vat_0], " + nl);
			sb.Append("			[Rih_vat_id_buyer], " + nl);
			sb.Append("			[Rih_vat_id_publisher], " + nl);
			sb.Append("			[Rih_vat_M], " + nl);
			sb.Append("			[Rih_vat_V] " + nl);
			sb.Append("from		[" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga] " + nl);
			sb.Append("where	[YearCode] = '" + database.companyYearCode + "' " + nl);
			sb.Append("				and [RecNo] = @RecNo ");

			return sb.ToString();
		}
		private string CommandInsert() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("insert into	[" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga]" + nl);
			sb.Append("				([Datum], [DatumPotrditve], [DatumVnosa], [ImePartnerja], [Komentar], [Letalsko], [Nujno], [Odkupnina], [Postnina], [SifraPartnerja], [Sporocilo], [Teza], [Tip], [Vnasalec], [VrednostPoste], [VrstaPoste], [Zadeva], [Zaposlen], [ZapSt], [Datum1], [Datum2], [eSLOGGUID], [InternaStevilka], [MPO], [PE], [ScanPrenesen], [SlikeOznaka], [SlikeVrsta], [TipPoste], [ZZI], [ZZI1], [ZZI2], [Likvidacija], [Rih_DateTime_Received], [Rih_DateTime_Sent], [Rih_DateTime_Updated], [Rih_gross], [Rih_gross_0], [Rih_gross_M], [Rih_gross_V], [Rih_inv_date], [Rih_inv_num], [Rih_net], [Rih_net_0], [Rih_net_M], [Rih_net_V], [Rih_pay_until], [Rih_reference], [Rih_vat], [Rih_vat_0], [Rih_vat_id_buyer], [Rih_vat_id_publisher], [Rih_vat_M], [Rih_vat_V], [YearCode]) " + nl);
			sb.Append("values		(@Datum, @DatumPotrditve, @DatumVnosa, @ImePartnerja, @Komentar, @Letalsko, @Nujno, @Odkupnina, @Postnina, @SifraPartnerja, @Sporocilo, @Teza, @Tip, @Vnasalec, @VrednostPoste, @VrstaPoste, @Zadeva, @Zaposlen, @ZapSt, @Datum1, @Datum2, @eSLOGGUID, @InternaStevilka, @MPO, @PE, @ScanPrenesen, @SlikeOznaka, @SlikeVrsta, @TipPoste, @ZZI, @ZZI1, @ZZI2, @Likvidacija, @Rih_DateTime_Received, @Rih_DateTime_Sent, @Rih_DateTime_Updated, @Rih_gross, @Rih_gross_0, @Rih_gross_M, @Rih_gross_V, @Rih_inv_date, @Rih_inv_num, @Rih_net, @Rih_net_0, @Rih_net_M, @Rih_net_V, @Rih_pay_until, @Rih_reference, @Rih_vat, @Rih_vat_0, @Rih_vat_id_buyer, @Rih_vat_id_publisher, @Rih_vat_M, @Rih_vat_V, '" + database.companyYearCode + "') " + nl);
			sb.Append("select		ident_current('[" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga]') as [RecNo] ");

			return sb.ToString();
		}
		private string CommandUpdate() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("update	[" + database.biroDavcnaStevilka + "].[dbo].[PostnaKnjiga]" + nl);
			sb.Append("set " + nl);
			sb.Append("			[Datum] = @Datum, " + nl);
			sb.Append("			[DatumPotrditve] = @DatumPotrditve, " + nl);
			sb.Append("			[DatumVnosa] = @DatumVnosa, " + nl);
			sb.Append("			[ImePartnerja] = @ImePartnerja, " + nl);
			sb.Append("			[Komentar] = @Komentar, " + nl);
			sb.Append("			[Letalsko] = @Letalsko, " + nl);
			sb.Append("			[Nujno] = @Nujno, " + nl);
			sb.Append("			[Odkupnina] = @Odkupnina, " + nl);
			sb.Append("			[Postnina] = @Postnina, " + nl);
			sb.Append("			[SifraPartnerja] = @SifraPartnerja, " + nl);
			sb.Append("			[Sporocilo] = @Sporocilo, " + nl);
			sb.Append("			[Teza] = @Teza, " + nl);
			sb.Append("			[Tip] = @Tip, " + nl);
			sb.Append("			[Vnasalec] = @Vnasalec, " + nl);
			sb.Append("			[VrednostPoste] = @VrednostPoste, " + nl);
			sb.Append("			[VrstaPoste] = @VrstaPoste, " + nl);
			sb.Append("			[Zadeva] = @Zadeva, " + nl);
			sb.Append("			[Zaposlen] = @Zaposlen, " + nl);
			sb.Append("			[ZapSt] = @ZapSt, " + nl);
			sb.Append("			[Datum1] = @Datum1, " + nl);
			sb.Append("			[Datum2] = @Datum2, " + nl);
			sb.Append("			[eSLOGGUID] = @eSLOGGUID, " + nl);
			sb.Append("			[InternaStevilka] = @InternaStevilka, " + nl);
			sb.Append("			[MPO] = @MPO, " + nl);
			sb.Append("			[PE] = @PE, " + nl);
			sb.Append("			[ScanPrenesen] = @ScanPrenesen, " + nl);
			sb.Append("			[SlikeOznaka] = @SlikeOznaka, " + nl);
			sb.Append("			[SlikeVrsta] = @SlikeVrsta, " + nl);
			sb.Append("			[TipPoste] = @TipPoste, " + nl);
			sb.Append("			[ZZI] = @ZZI, " + nl);
			sb.Append("			[ZZI1] = @ZZI1, " + nl);
			sb.Append("			[ZZI2] = @ZZI2, " + nl);
			sb.Append("			[Likvidacija] = @Likvidacija, " + nl);
			sb.Append("			[Rih_DateTime_Received] = @Rih_DateTime_Received, " + nl);
			sb.Append("			[Rih_DateTime_Sent] = @Rih_DateTime_Sent, " + nl);
			sb.Append("			[Rih_DateTime_Updated] = @Rih_DateTime_Updated, " + nl);
			sb.Append("			[Rih_gross] = @Rih_gross, " + nl);
			sb.Append("			[Rih_gross_0] = @Rih_gross_0, " + nl);
			sb.Append("			[Rih_gross_M] = @Rih_gross_M, " + nl);
			sb.Append("			[Rih_gross_V] = @Rih_gross_V, " + nl);
			sb.Append("			[Rih_inv_date] = @Rih_inv_date, " + nl);
			sb.Append("			[Rih_inv_num] = @Rih_inv_num, " + nl);
			sb.Append("			[Rih_net] = @Rih_net, " + nl);
			sb.Append("			[Rih_net_0] = @Rih_net_0, " + nl);
			sb.Append("			[Rih_net_M] = @Rih_net_M, " + nl);
			sb.Append("			[Rih_net_V] = @Rih_net_V, " + nl);
			sb.Append("			[Rih_pay_until] = @Rih_pay_until, " + nl);
			sb.Append("			[Rih_reference] = @Rih_reference, " + nl);
			sb.Append("			[Rih_vat] = @Rih_vat, " + nl);
			sb.Append("			[Rih_vat_0] = @Rih_vat_0, " + nl);
			sb.Append("			[Rih_vat_id_buyer] = @Rih_vat_id_buyer, " + nl);
			sb.Append("			[Rih_vat_id_publisher] = @Rih_vat_id_publisher, " + nl);
			sb.Append("			[Rih_vat_M] = @Rih_vat_M, " + nl);
			sb.Append("			[Rih_vat_V] = @Rih_vat_V " + nl);
			sb.Append("where	[YearCode] = '" + database.companyYearCode + "' " + nl);
			sb.Append("				and [RecNo] = @RecNo ");
			sb.Append("if (@@rowcount > 0)	select @RecNo as [RecNo] " + nl);
			sb.Append("else					select 0 as [RecNo] ");

			return sb.ToString();
		}
		#endregion
	}
}
