using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.data
{
    public class CDatabase
    {

        public ISqlConnection sqlConnection;
        public string biroDavcnaStevilka;
        public string partnerYearCode;
        public string optionsYearCode;
        public string companyYearCode;

        public CDatabase(ISqlConnection conn, string partnerYearCode, string optionsYearCode, string companyYearCode, string biroDavcnaStevilka) {
            sqlConnection = conn;
            this.partnerYearCode = partnerYearCode;
            this.optionsYearCode = optionsYearCode;
            this.biroDavcnaStevilka = biroDavcnaStevilka;
            this.companyYearCode = companyYearCode;
        }
    }
}
