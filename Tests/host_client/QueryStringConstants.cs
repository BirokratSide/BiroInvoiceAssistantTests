using System;
using Tests.structs;
using System.Web;
using System.Net.Http;
using System.Text;

namespace Tests.host_client
{
    static class QueryStringConstants
    {
        
        private static string START_QUERY = "/api/invoice/start?davcnastevilka={0}&company_year={1}&oznaka={2}&recno={3}&datum_vnosa={4}";
        private static string REMOVE_FROM_QUEUE = "/api/invoice/remove?davcnastevilka={0}&company_year={1}&oznaka={2}&recno={3}&datum_vnosa={4}";
        private static string GET_NEXT_QUERY = "/api/invoice/get-next?user_id={0}";
        private static string SWITCH_QUERY = "/api/invoice/set-switch?val={0}";
        private static string LOCKED_QUERY = "/api/invoice/locked-threshold?seconds={0}";
        private static string UNLOCKED_QUERY = "/api/invoice/unlocked-threshold?seconds={0}";

        #region [configuration]
        public static string MakeLockedThresholdString(int seconds) {
            return String.Format(LOCKED_QUERY, seconds);
        }

        public static string MakeUnlockedThresholdString(int seconds) {
            return String.Format(UNLOCKED_QUERY, seconds);
        }

        public static string MakeProcessAutomaticSwitchQueryString(bool val) {
            return String.Format(SWITCH_QUERY, val);
        }
        #endregion

        #region [api]
        public static string MakeStartQueryString(StartingRecord rec) {
            return String.Format(START_QUERY, rec.davcnastevilka, rec.company_year, rec.oznaka, rec.recno, rec.datum_vnosa);
        }

        public static string MakeRemoveFromQueueQueryString(StartingRecord rec) {
            return String.Format(REMOVE_FROM_QUEUE, rec.davcnastevilka, rec.company_year, rec.oznaka, rec.recno, rec.datum_vnosa);
        }

        public static string MakeGetNextQueryString(int user_id) {
            return String.Format(GET_NEXT_QUERY, user_id);
        }

        public static string PostFinish(string content, HttpClient client) {
            string query = "/api/invoice/finish";
            StringContent contentStr = new StringContent(content, Encoding.UTF8, "application/json");
            var msg = client.PostAsync(query, contentStr).GetAwaiter().GetResult();
            return msg.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        #endregion
    }
}
