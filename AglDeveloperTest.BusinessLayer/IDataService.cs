using AglDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AglDeveloperTest.BusinessLayer
{
    public interface IDataService
    {
        Task<List<CatsByGender>> GetCatsDataByOwnerGender();
    }
}
