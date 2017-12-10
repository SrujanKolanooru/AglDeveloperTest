using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AglDeveloperTest.Common
{
    public class Configuration
    {
        public static string PeopleDataURL
        {
            get
            {
                return ConfigurationManager.AppSettings["PeopleDataURL"];
            }
        }
    }
}
