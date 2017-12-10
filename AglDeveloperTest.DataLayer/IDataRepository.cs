using AglDeveloperTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AglDeveloperTest.DataLayer
{
    public interface IDataRepository
    {
        Task<Person[]> GetData(); 
    }
}
