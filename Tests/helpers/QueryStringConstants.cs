using System;
using Tests.structs;

namespace Tests.helpers
{
    public static class QueryStringConstants
    {
        public static string START_QUERY = "/api/invoice/start?database={0}&company_id={1}&company_year={2}&oznaka={3}&recno={4}&datum_vnosa={5}";
        public static string GET_NEXT_QUERY = "/api/invoice/get-next?user_id={0}";

        public static string MakeStartQueryString(StartingRecord rec) {
            return String.Format(START_QUERY, rec.database, rec.company_id, rec.company_year, rec.oznaka, rec.recno, rec.datum_vnosa);
        }

        public static string MakeGetNextQueryString(int user_id) {
            return String.Format(GET_NEXT_QUERY, user_id);
        }
    }
}
