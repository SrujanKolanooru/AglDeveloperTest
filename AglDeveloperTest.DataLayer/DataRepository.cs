using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AglDeveloperTest.Model;
using AglDeveloperTest.Common;

namespace AglDeveloperTest.DataLayer
{
    public class DataRepository : IDataRepository
    {
        public async Task<Person[]> GetData()
        {
            var strData = await Utilities.HttpUtility.GetData(Configuration.PeopleDataURL);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Person[]>(strData);
        }
    }
}
