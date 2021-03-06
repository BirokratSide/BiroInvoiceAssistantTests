﻿using System;
using System.Collections.Generic;

namespace Tests.data.plugincache
{
    
    public partial class PluginCache
    {

        #region [constants]
        public const string TYPE_SLIKE = "slike";
        public const string TYPE_CRMSTRANKEOPCIJE = "crmstrankeopcije";
        #endregion

        public int Id { get; set; }
        public string Type { get; set; }
        public string Davcnastevilka { get; set; }
        public string Companyyear { get; set; }
        public string Oznaka { get; set; }
        public string Datumvnosa { get; set; }
        public string Recno { get; set; }
        public bool? Toprocess { get; set; }
        public bool Processed { get; set; }
    }
}
