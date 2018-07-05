using System;
using System.Data;

namespace Tests.data
{
    public interface ISqlConnection : IDisposable
    {
        #region // properties //
        ESqlType sqlType { get; }
        string database { get; set; }
        IDbConnection connection { get; }
        bool autoOpenClose { get; set; }
        int connectionTimeout { get; set; }
        int commandTimeout { get; set; }
        #endregion
        #region // public - control //
        void Close();
        void Open();
        #endregion
        #region // public - generate //
        IDbCommand GenerateCommand();
        IDbDataParameter GenerateParameter(string name, object value);
        IDbDataAdapter GenerateDataAdapter();
        IDbDataAdapter GenerateDataAdapter(IDbCommand command);
        IDbDataAdapter GenerateDataAdapter(string query, IDbConnection connection);
        IDbDataAdapter GenerateDataAdapter(IDbCommand command_delete, IDbCommand command_insert, IDbCommand command_update);
        #endregion
        #region // public - execute //
        DataSet ExecDataSet(IDbCommand command);
        DataTable ExecDataTable(IDbCommand command);
        bool ExecDataTableBln(IDbCommand command);
        decimal ExecDataTableDec(IDbCommand command);
        DateTime ExecDataTableDt(IDbCommand command);
        Guid ExecDataTableGid(IDbCommand command);
        int ExecDataTableInt(IDbCommand command);
        long ExecDataTableLng(IDbCommand command);
        string ExecDataTableStr(IDbCommand command);
        T ExecDatatable<T>(IDbCommand command);
        int ExecNonQuery(IDbCommand command);
        bool ExecScalarBln(IDbCommand command);
        decimal ExecScalarDec(IDbCommand command);
        Guid ExecScalarGid(IDbCommand command);
        int ExecScalarInt(IDbCommand command);
        long ExecScalarLng(IDbCommand command);
        string ExecScalarStr(IDbCommand command);
        #endregion
    }
}