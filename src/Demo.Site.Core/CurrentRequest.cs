﻿using System.Collections.Generic;
using Demo.Business.Routing;

namespace Demo.Business
{
    public class CurrentRequest : ICurrentRequest
    {
        public bool IsSecure { get; set; }
        public bool? IsForceSecure { get; set; }
        public string SiteId { get; set; }
        public string DomainId { get; set; }
        public string Port { get; set; }
        public IDictionary<string, string> DomainDatas { get; set; }
    }
}