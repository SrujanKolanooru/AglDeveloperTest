using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AglDeveloperTest.Common.Utility
{
    public class HttpUtility
    {
        public async Task<string> GetData(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var strData = await client.GetStringAsync(url);
                return strData;
            }
        }
    }
}
