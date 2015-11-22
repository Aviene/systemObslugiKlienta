using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace systemObslugiKlienta.Models
{
    internal sealed class QueryBuilderModel
    {
        internal Dictionary<string, string> Parameters { get; set; }

        internal string Columns { get; set; } 
    }
}