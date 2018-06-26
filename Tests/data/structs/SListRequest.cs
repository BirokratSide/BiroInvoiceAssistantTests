using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Tests.data.structs
{
    [Serializable]
    [DataContract]
    public class SListRequest
    {
        #region // constructor //
        public SListRequest()
        {
            full_list = false;
            items_per_page = 0;
            current_page = 0;
            method = string.Empty;
            sort_field = string.Empty;
            sort_descending = false;
            extras = string.Empty;
            parameters = new Dictionary<string, string>();
            show_deleted = false;
        }
        #endregion
        #region // properties //
        [DataMember]
        public bool full_list { get; set; }
        [DataMember]
        public int items_per_page { get; set; }
        [DataMember]
        public int current_page { get; set; }
        [DataMember]
        public string method { get; set; }
        [DataMember]
        public string sort_field { get; set; }
        [DataMember]
        public bool sort_descending { get; set; }
        [DataMember]
        public string extras { get; set; }
        [IgnoreDataMember]
        public Dictionary<string, string> parameters { get; set; }
        [DataMember(Name = "parameters")]
        public string parameters_array
        {
            get
            {
                if (parameters == null)
                    return string.Empty;
                return JsonConvert.SerializeObject(parameters);
            }
            set
            {
                parameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
                if (parameters == null)
                    parameters = new Dictionary<string, string>();
            }
        }
        [DataMember]
        public bool show_deleted { get; set; }
        #endregion
        #region // public //
        public object get_parameter(string key)
        {
            if (parameters == null)
            {
                return DBNull.Value;
            }
            if (parameters.ContainsKey(key))
            {
                return parameters[key] ?? Convert.DBNull;
            }
            else
            {
                return DBNull.Value;
            }
        }
        #endregion
    }
}