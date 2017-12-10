using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AglDeveloperTest.BusinessLayer;
using AglDeveloperTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using AglDeveloperTest.Controllers;
using System.Web.Mvc;

namespace AglDeveloperTest.Tests
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public async Task TestHomeIndex1()
        {
            var dataService = new Mock<IDataService>();
            dataService.Setup(p => p.GetCatsDataByOwnerGender()).Returns(() => { return GetTestObject1(); });

            HomeController controller = new HomeController(dataService.Object);
            var output = await controller.Index();

            var obj = ((List<CatsByGender>)((ViewResult)output).Model);
            Assert.IsTrue(obj.Count == 2 && obj[0].Cats.Count == 4 && obj[1].Cats.Count == 3);
        }

        [TestMethod]
        public async Task TestHomeIndex2()
        {
            var dataService = new Mock<IDataService>();
            dataService.Setup(p => p.GetCatsDataByOwnerGender()).Returns(() => { return GetTestObject2(); });

            HomeController controller = new HomeController(dataService.Object);
            var output = await controller.Index();

            var obj = ((List<CatsByGender>)((ViewResult)output).Model);
            Assert.IsTrue(obj.Count == 2 && obj[0].Cats.Count == 0 && obj[1].Cats.Count == 3);
        }

        Task<List<CatsByGender>> GetTestObject1()
        {
            return Task.Run(() => 
            {
                List<CatsByGender> obj = new List<CatsByGender>();
                List<string> maleOwnerCats = new List<string>();
                List<string> femaleOwnerCats = new List<string>();

                maleOwnerCats.Add("AAAA");
                maleOwnerCats.Add("BBBB");
                maleOwnerCats.Add("CCCC");
                maleOwnerCats.Add("DDDD");

                femaleOwnerCats.Add("PPPP");
                femaleOwnerCats.Add("QQQQ");
                femaleOwnerCats.Add("RRRR");

                obj.Add(new CatsByGender() { Gender = "Male", Cats = maleOwnerCats });
                obj.Add(new CatsByGender() { Gender = "Female", Cats = femaleOwnerCats });
                return obj;
            });
        }
        Task<List<CatsByGender>> GetTestObject2()
        {
            return Task.Run(() =>
            {
                List<CatsByGender> obj = new List<CatsByGender>();
                List<string> femaleOwnerCats = new List<string>();
                femaleOwnerCats.Add("PPPP");
                femaleOwnerCats.Add("QQQQ");
                femaleOwnerCats.Add("RRRR");

                obj.Add(new CatsByGender() { Gender = "Male", Cats = new List<string>() });
                obj.Add(new CatsByGender() { Gender = "Female", Cats = femaleOwnerCats });
                return obj;
            });
        }
    }
}
