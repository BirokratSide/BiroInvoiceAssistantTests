using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Common.utils;

namespace Tests.data
{
    class BiroDatabaseAccessor
    {
        CMsSqlConnection sqlConnection;
        string databaseName;

        public BiroDatabaseAccessor(CMsSqlConnection conn)
        {
            sqlConnection = conn;
            this.databaseName = databaseName;
        }

    }
}
