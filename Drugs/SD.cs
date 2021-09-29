using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drugs
{
    public class SD
    {
        public static string DrugAPIBase { get; set; }
        public static string SubscriptionAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
