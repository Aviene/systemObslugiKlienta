using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace systemObslugiKlienta.Models
{
    internal sealed class QueryBuilderResult
    {
        internal string ParametrizedQuery { get; set; }

        internal Dictionary<string, string> ParametersWithValues { get; set; } 
    }
}