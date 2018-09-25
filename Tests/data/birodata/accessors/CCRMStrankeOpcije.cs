using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Tests.data.structs;

namespace Tests.data.accessors
{
    public class CCRMStrankeOpcije
    {

        CDatabase database;

        #region // constructor //
        public CCRMStrankeOpcije(CDatabase database)
        {
            this.database = database;
        }
        #endregion
        #region !! ICRMStrankeOpcije - public !!
        public bool Delete(SCRMStrankeOpcije data)
        {
            bool result = false;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandDelete();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.Recno));
                result = database.sqlConnection.ExecDataTableBln(cmd);
            }
            return result;
        }
        public SListResponse<SCRMStrankeOpcije> List(SListRequest data, Dictionary<string, string> WhereClauses)
        {
            SListResponse<SCRMStrankeOpcije> result = null;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandList(WhereClauses);
                // TODO : query parameters have to be added manually
                DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
                result = GListHelper.ListResponse<SCRMStrankeOpcije>(dtt, data);
            }
            return result;
        }
        public SCRMStrankeOpcije Load(int id)
        {
            SCRMStrankeOpcije result = null;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = CommandLoad();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", id));
                DataTable dtt = database.sqlConnection.ExecDataTable(cmd);
                if (dtt != null && dtt.Rows.Count == 1)
                {
                    result = new SCRMStrankeOpcije();
                    if (!GDataTypeConverter.ObjectFromDataRow(result, dtt.Rows[0]))
                        result = null;
                }
            }
            return result;
        }
        public int Save(SCRMStrankeOpcije data)
        {
            int result = 0;
            using (IDbCommand cmd = database.sqlConnection.GenerateCommand())
            {
                cmd.CommandType = CommandType.Text;
                if (data.Recno != 0)
                {
                    cmd.CommandText = CommandUpdate();
                    cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@RecNo", data.Recno));
                }
                else
                    cmd.CommandText = CommandInsert();
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Aktivno", data.Aktivno));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Aplikacija", data.Aplikacija));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@DatumVnosa", data.DatumVnosa));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Level", data.Level));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Opcija", data.Opcija));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@OpisPolja", data.OpisPolja));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Recno", data.Recno));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Sifra", data.Sifra));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vnasalec", data.Vnasalec));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Vrednost", data.Vrednost));
                cmd.Parameters.Add(database.sqlConnection.GenerateParameter("@Zaporedje", data.Zaporedje));
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
            sb.Append("from      [" + database.BiroDb + "].[dbo].[CRMStrankeOpcije] " + nl);
            sb.Append("where     [YearCode] = '" + database.BiroCd + "' " + nl);
            sb.Append("              and [RecNo] = @RecNo " + nl);
            sb.Append("select    @@rowcount as [Count] ");

            return sb.ToString();
        }
        private string CommandList(Dictionary<string, string> WhereClauses)
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("select " + nl);
            sb.Append("			[Aktivno], " + nl);
            sb.Append("			[Aplikacija], " + nl);
            sb.Append("			[DatumVnosa], " + nl);
            sb.Append("			[Level], " + nl);
            sb.Append("			[Opcija], " + nl);
            sb.Append("			[OpisPolja], " + nl);
            sb.Append("			[Recno], " + nl);
            sb.Append("			[Sifra], " + nl);
            sb.Append("			[Vnasalec], " + nl);
            sb.Append("			[Vrednost], " + nl);
            sb.Append("			[Zaporedje], " + nl);
            sb.Append("			[SyncId], " + nl);
            sb.Append("			[YearCode] " + nl);
            sb.Append("from		[" + database.BiroDb + "].[dbo].[CRMStrankeOpcije] " + nl);
            sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);

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
            sb.Append("			[Aktivno], " + nl);
            sb.Append("			[Aplikacija], " + nl);
            sb.Append("			[DatumVnosa], " + nl);
            sb.Append("			[Level], " + nl);
            sb.Append("			[Opcija], " + nl);
            sb.Append("			[OpisPolja], " + nl);
            sb.Append("			[Recno], " + nl);
            sb.Append("			[Sifra], " + nl);
            sb.Append("			[Vnasalec], " + nl);
            sb.Append("			[Vrednost], " + nl);
            sb.Append("			[Zaporedje], " + nl);
            sb.Append("			[SyncId], " + nl);
            sb.Append("			[YearCode] " + nl);
            sb.Append("from		[" + database.BiroDb + "].[dbo].[CRMStrankeOpcije] " + nl);
            sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);
            sb.Append("				and [RecNo] = @RecNo ");

            return sb.ToString();
        }
        private string CommandInsert()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("insert into	[" + database.BiroDb + "].[dbo].[CRMStrankeOpcije]" + nl);
            sb.Append("				([Aktivno], [Aplikacija], [DatumVnosa], [Level], [Opcija], [OpisPolja], [Sifra], [Vnasalec], [Vrednost], [Zaporedje], [YearCode]) " + nl);
            sb.Append("values		(@Aktivno, @Aplikacija, @DatumVnosa, @Level, @Opcija, @OpisPolja, @Sifra, @Vnasalec, @Vrednost, @Zaporedje, '" + database.BiroCd + "') " + nl);

            return sb.ToString();
        }
        private string CommandUpdate()
        {
            StringBuilder sb = new StringBuilder();
            string nl = Environment.NewLine;

            sb.Append("update	[" + database.BiroDb + "].[dbo].[CRMStrankeOpcije]" + nl);
            sb.Append("set " + nl);
            sb.Append("			[Aktivno] = @Aktivno, " + nl);
            sb.Append("			[Aplikacija] = @Aplikacija, " + nl);
            sb.Append("			[DatumVnosa] = @DatumVnosa, " + nl);
            sb.Append("			[Level] = @Level, " + nl);
            sb.Append("			[Opcija] = @Opcija, " + nl);
            sb.Append("			[OpisPolja] = @OpisPolja, " + nl);
            sb.Append("			[Recno] = @Recno, " + nl);
            sb.Append("			[Sifra] = @Sifra, " + nl);
            sb.Append("			[Vnasalec] = @Vnasalec, " + nl);
            sb.Append("			[Vrednost] = @Vrednost, " + nl);
            sb.Append("			[Zaporedje] = @Zaporedje " + nl);
            sb.Append("where	[YearCode] = '" + database.BiroCd + "' " + nl);
            sb.Append("				and [RecNo] = @RecNo ");
            sb.Append("if (@@rowcount > 0)	select @RecNo as [RecNo] " + nl);
            sb.Append("else					select 0 as [RecNo] ");

            return sb.ToString();
        }
        #endregion
    }
}
