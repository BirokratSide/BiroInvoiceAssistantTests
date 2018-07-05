using System;
using System.Data;
using System.Text;

using Tests.data.structs;

namespace Tests.data.accessors {
	public class CSlike {

        CDatabase database;

		#region // constructor //
		public CSlike(CDatabase database) {
            this.database = database;
        }
		#endregion
		#region !! ISlike - public !!
		public bool Delete(SSlike data) {
			bool result = false;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandDelete();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
				result = database.sqlConnection.ExecDataTableBln(cmd);
			}
			return result;
		}
		public SListResponse<SSlike> List(SListRequest data) {
			SListResponse<SSlike> result = null;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandList();
				// TODO : query parameters have to be added manually
				DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
				result = GListHelper.ListResponse<SSlike>(dtt, data);
			}
			return result;
		}
		public SSlike Load(int id) {
			SSlike result = null;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = CommandLoad();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", id));
				DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
				if (dtt != null && dtt.Rows.Count == 1) {
					result = new SSlike();
					if (!GDataTypeConverter.ObjectFromDataRow(result, dtt.Rows[0]))
						result = null;
				}
			}
			return result;
		}
		public int Save(SSlike data) {
			int result = 0;
			using (IDbCommand cmd = database.sqlConnection.GenerateCommand()) {
				cmd.CommandType = CommandType.Text;
				if (data.RecNo != 0) {
					cmd.CommandText = CommandUpdate();
					cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.RecNo));
				} else
					cmd.CommandText = CommandInsert();
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Datum", data.Datum));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumVnosa", data.DatumVnosa));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Oznaka", data.Oznaka));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vnasalec", data.Vnasalec));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vrsta", data.Vrsta));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vsebina", data.Vsebina));
				cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Komentar", data.Komentar));
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
			sb.Append("from      [" + database.BiroDb + "].[dbo].[Slike] " + nl);
			sb.Append("where     [YearCode] = '" + database.BiroCd + "' " + nl);
			sb.Append("              and [RecNo] = @RecNo " + nl);
			sb.Append("select    @@rowcount as [Count] ");

			return sb.ToString();
		}
		private string CommandList() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("select " + nl);
			sb.Append("			[Datum], " + nl);
			sb.Append("			[DatumVnosa], " + nl);
			sb.Append("			[Oznaka], " + nl);
			sb.Append("			[RecNo], " + nl);
			sb.Append("			[Vnasalec], " + nl);
			sb.Append("			[Vrsta], " + nl);
			sb.Append("			[Vsebina], " + nl);
			sb.Append("			[Komentar], " + nl);
			sb.Append("			[SyncId], " + nl);
			sb.Append("			[YearCode] " + nl);
			sb.Append("from		[" + database.BiroDb + "].[dbo].[Slike] " + nl);
			sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);
			// TODO : other query conditions have to be added manually

			return sb.ToString();
		}
		private string CommandLoad() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("select " + nl);
			sb.Append("			[Datum], " + nl);
			sb.Append("			[DatumVnosa], " + nl);
			sb.Append("			[Oznaka], " + nl);
			sb.Append("			[RecNo], " + nl);
			sb.Append("			[Vnasalec], " + nl);
			sb.Append("			[Vrsta], " + nl);
			sb.Append("			[Vsebina], " + nl);
			sb.Append("			[Komentar], " + nl);
			sb.Append("			[SyncId], " + nl);
			sb.Append("			[YearCode] " + nl);
			sb.Append("from		[" + database.BiroDb + "].[dbo].[Slike] " + nl);
			sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);
			sb.Append("				and [RecNo] = @RecNo ");

			return sb.ToString();
		}
		private string CommandInsert() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("insert into	[" + database.BiroDb + "].[dbo].[Slike]" + nl);
			sb.Append("				([Datum], [DatumVnosa], [Oznaka], [Vnasalec], [Vrsta], [Vsebina], [Komentar], [YearCode]) " + nl);
			sb.Append("values		(@Datum, @DatumVnosa, @Oznaka, @Vnasalec, @Vrsta, @Vsebina, @Komentar, '" + database.BiroCd + "') " + nl);
			sb.Append("select		ident_current('[" + database.BiroDb + "].[dbo].[Slike]') as [RecNo] ");

			return sb.ToString();
		}
		private string CommandUpdate() {
			StringBuilder sb = new StringBuilder();
			string nl = Environment.NewLine;

			sb.Append("update	[" + database.BiroDb + "].[dbo].[Slike]" + nl);
			sb.Append("set " + nl);
			sb.Append("			[Datum] = @Datum, " + nl);
			sb.Append("			[DatumVnosa] = @DatumVnosa, " + nl);
			sb.Append("			[Oznaka] = @Oznaka, " + nl);
			sb.Append("			[Vnasalec] = @Vnasalec, " + nl);
			sb.Append("			[Vrsta] = @Vrsta, " + nl);
			sb.Append("			[Vsebina] = @Vsebina, " + nl);
			sb.Append("			[Komentar] = @Komentar " + nl);
			sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);
			sb.Append("				and [RecNo] = @RecNo ");
			sb.Append("if (@@rowcount > 0)	select @RecNo as [RecNo] " + nl);
			sb.Append("else					select 0 as [RecNo] ");

			return sb.ToString();
		}
		#endregion
	}
}
