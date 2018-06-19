using System;

using Common.utils;

using Common.utils;
using BiroInvoiceAssistant.structs;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace Tests
{
    public class CKnjigaPosteAccessor
    {

        CMsSqlConnection SqlConnection;
        string TargetDatabase;

        #region [constants]
        private const string KNJIGA_POSTE_TABLE_NAME = "PostnaKnjiga";
        #endregion

        #region [constructor]
        public CKnjigaPosteAccessor(CMsSqlConnection conn, string targetDatabase)
        {
            TargetDatabase = targetDatabase;
        }
        #endregion

        #region [KnjigaPoste]
        public string UpdateKnjigaPosteRecordGetSql(SKnjigaPosteRecord rec)
        {
            return UpdateKnjigaPosteSql(rec);
        }

        public bool UpdateKnjigaPosteRecord(SKnjigaPosteRecord rec, IDbCommand cmd = null, SqlTransaction transaction = null)
        {
            var sqlCommand = new SqlCommand();
            sqlCommand.Connection = (SqlConnection)SqlConnection.connection;
            if (transaction != null)
                sqlCommand.Transaction = transaction;
            string sql = UpdateKnjigaPosteSql(rec);
            sqlCommand.CommandText = sql;
            int id = SqlConnection.ExecScalarInt(sqlCommand);
            return id > -1;
        }

        private static string UpdateKnjigaPosteSql(SKnjigaPosteRecord rec)
        {
            string query = @"
                use [biro16010264]
                UPDATE [{0}]
                SET {1}
                WHERE [DatumVnosa] = '{2}' AND [ZapSt] = '{3}'
            ";

            string updatePart = typeof(SKnjigaPosteRecord).GetFields()
                                .Select(field => string.Format("{0} = {1}", field.Name, "'" + field.GetValue(rec) + "'"))
                                .Aggregate("", (acc, x) => acc + x + ", ");
            updatePart = updatePart.Substring(0, updatePart.Length - 2);

            return string.Format(query, KNJIGA_POSTE_TABLE_NAME, updatePart, rec.DatumVnosa, rec.ZapSt);
        }
        #endregion
    }
}
