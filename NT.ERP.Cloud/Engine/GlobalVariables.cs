using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTERPCloud.Engine
{
    public static class GlobalVariables
    {
        public static AppConfiguration ConfigSettings { get; set; }

        // readonly variable
        public static string ConnectionString
        {
            get
            {
                return ConfigSettings.ConnectionString;

            }
        }
    }

    // read-write variable
    //public static string Bar
    //{
    //    get
    //    {
    //        return HttpContext.Current.Application["Bar"] as string;
    //    }
    //    set
    //    {
    //        HttpContext.Current.Application["Bar"] = value;
    //    }
    //}
}

