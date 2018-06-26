using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.data
{
    public class CDatabase
    {

        public ISqlConnection sqlConnection;
        public string BiroDb;
        public string BiroCd;

        public CDatabase(ISqlConnection conn, string birocd, string birodb) {
            sqlConnection = conn;
            BiroCd = birocd;
            BiroDb = birodb;
        }
    }
}
