using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Tests.data.structs
{
    [Serializable]
    [DataContract]
    public class SListResponse<T> where T : new()
    {
        #region // constructor //
        public SListResponse()
        {
            item_count = 0;
            items_per_page = 0;
            items_total = 0;
            page_current = 0;
            page_count = 0;
            data = null;
            success = false;
        }
        #endregion
        #region // properties //
        [DataMember]
        public int item_count { get; set; }
        [DataMember]
        public int items_per_page { get; set; }
        [DataMember]
        public int items_total { get; set; }
        [DataMember]
        public int page_current { get; set; }
        [DataMember]
        public int page_count { get; set; }
        [DataMember]
        public List<T> data { get; set; }
        [DataMember]
        public bool success { get; set; }
        #endregion
    }
}