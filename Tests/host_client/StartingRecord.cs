using System;
namespace Tests.host_client
{
    public class StartingRecord
    {

        public string database;
        public string company_id;
        public string company_year;
        public string oznaka;
        public string recno;
        public string datum_vnosa;

        public StartingRecord() {}
        public StartingRecord(string database, string company_id, string company_year, string oznaka, string recno, string datum_vnosa) {
            this.database = database;
            this.company_id = company_id;
            this.company_year = company_year;
            this.oznaka = oznaka;
            this.recno = recno;
            this.datum_vnosa = datum_vnosa;
        }
    }
}
