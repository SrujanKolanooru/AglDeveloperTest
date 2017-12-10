using AglDeveloperTest.Common;
using AglDeveloperTest.DataLayer;
using AglDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AglDeveloperTest.BusinessLayer
{
    public class DataService : IDataService
    {
        public async Task<List<CatsByGender>> GetCatsDataByOwnerGender()
        {
            var repo = DependencyResolver.Current.GetService<IDataRepository>();
            var data = await repo.GetData();
            var tempData = data.Select(p => new
            {
                gender = p.gender,
                pets = p.pets == null ? (new List<string>()) : p.pets.Where(q => string.Compare(q.type, "Cat", true) == 0).Select(r=> r.name).ToList()
            });
            return tempData.GroupBy(p => p.gender, q => q.pets, (key, gd) => new CatsByGender() { Gender = key, Cats = gd.SelectMany(t => t).OrderBy(f=> f).ToList()}).OrderByDescending(p=> p.Gender).ToList();
        }
    }
}
