using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AglDeveloperTest.BusinessLayer;
using Moq;
using AglDeveloperTest.DataLayer;
using AglDeveloperTest.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity;
using Unity.AspNet.Mvc;
using System.Web.Mvc;

namespace AglDeveloperTest.BusinessLayer.Tests
{
    [TestClass]
    public class DataServiceUnitTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var dataRepo = new Mock<IDataRepository>();
            dataRepo.Setup(p => p.GetData()).Returns(() => { return GetTestObject1(); });

            var container = new UnityContainer();
            container.RegisterInstance<IDataRepository>(dataRepo.Object);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            DataService service = new DataService();
            var obj =  await service.GetCatsDataByOwnerGender();

            Assert.IsTrue(obj.Count == 2 && obj[0].Cats.Count == 1 && obj[1].Cats.Count == 2);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var dataRepo = new Mock<IDataRepository>();
            dataRepo.Setup(p => p.GetData()).Returns(() => { return GetTestObject2(); });

            var container = new UnityContainer();
            container.RegisterInstance<IDataRepository>(dataRepo.Object);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            DataService service = new DataService();
            var obj = await service.GetCatsDataByOwnerGender();

            Assert.IsTrue(obj.Count == 2 && obj[0].Cats.Count == 1 && obj[1].Cats.Count == 1);
        }

        [TestMethod]
        public async Task TestMethod3()
        {
            var dataRepo = new Mock<IDataRepository>();
            dataRepo.Setup(p => p.GetData()).Returns(() => { return GetTestObject3(); });

            var container = new UnityContainer();
            container.RegisterInstance<IDataRepository>(dataRepo.Object);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            DataService service = new DataService();
            var obj = await service.GetCatsDataByOwnerGender();

            Assert.IsTrue(obj.Count == 2 && obj[0].Cats.Count == 1 && obj[1].Cats.Count == 0);
        }

        Task<Person[]> GetTestObject1()
        {
            return Task.Run(() =>
            {
                List<Person> obj = new List<Person>();
                List<Pet> pets1 = new List<Pet>();
                pets1.Add(new Pet() { name = "PA1", type = "Cat" });
                pets1.Add(new Pet() { name = "PA2", type = "Dog" });
                obj.Add(new Person() { gender = "Male", name = "AAAA", age = 20, pets = pets1.ToArray() });

                List<Pet> pets2 = new List<Pet>();
                pets2.Add(new Pet() { name = "PB1", type = "Cat" });
                pets2.Add(new Pet() { name = "PB2", type = "Dog" });
                obj.Add(new Person() { gender = "Female", name = "BBBB", age = 30, pets = pets2.ToArray() });

                List<Pet> pets3 = new List<Pet>();
                pets3.Add(new Pet() { name = "PC1", type = "Cat" });
                pets3.Add(new Pet() { name = "PC2", type = "Dog" });
                pets3.Add(new Pet() { name = "PC3", type = "Fish" });
                obj.Add(new Person() { gender = "Female", name = "CCCC", age = 40, pets = pets3.ToArray() });

                List<Pet> pets4 = new List<Pet>();
                pets4.Add(new Pet() { name = "PD1", type = "Elephant" });
                pets4.Add(new Pet() { name = "PD2", type = "Dog" });
                obj.Add(new Person() { gender = "Male", name = "DDDD", age = 21, pets = pets4.ToArray() });

                return obj.ToArray();
            });
        }

        Task<Person[]> GetTestObject2()
        {
            return Task.Run(() =>
            {
                List<Person> obj = new List<Person>();
                obj.Add(new Person() { gender = "Female", name = "AAAA", age = 20, pets = null });

                List<Pet> pets2 = new List<Pet>();
                pets2.Add(new Pet() { name = "PB1", type = "Cat" });
                pets2.Add(new Pet() { name = "PB2", type = "Dog" });
                obj.Add(new Person() { gender = "Female", name = "BBBB", age = 30, pets = pets2.ToArray() });

                List<Pet> pets3 = new List<Pet>();
                pets3.Add(new Pet() { name = "PC1", type = "Cat" });
                pets3.Add(new Pet() { name = "PC2", type = "Dog" });
                pets3.Add(new Pet() { name = "PC3", type = "Fish" });
                obj.Add(new Person() { gender = "Male", name = "CCCC", age = 40, pets = pets3.ToArray() });

                List<Pet> pets4 = new List<Pet>();
                pets4.Add(new Pet() { name = "PD1", type = "Elephant" });
                obj.Add(new Person() { gender = "Male", name = "DDDD", age = 21, pets = pets4.ToArray() });

                return obj.ToArray();
            });
        }

        Task<Person[]> GetTestObject3()
        {
            return Task.Run(() =>
            {
                List<Person> obj = new List<Person>();
                obj.Add(new Person() { gender = "Female", name = "AAAA", age = 20, pets = null });

                List<Pet> pets2 = new List<Pet>();
                pets2.Add(new Pet() { name = "PB2", type = "Dog" });
                obj.Add(new Person() { gender = "Female", name = "BBBB", age = 30, pets = pets2.ToArray() });

                List<Pet> pets3 = new List<Pet>();
                pets3.Add(new Pet() { name = "PC1", type = "Cat" });
                pets3.Add(new Pet() { name = "PC2", type = "Dog" });
                pets3.Add(new Pet() { name = "PC3", type = "Fish" });
                obj.Add(new Person() { gender = "Male", name = "CCCC", age = 40, pets = pets3.ToArray() });

                List<Pet> pets4 = new List<Pet>();
                pets4.Add(new Pet() { name = "PD1", type = "Elephant" });
                obj.Add(new Person() { gender = "Male", name = "DDDD", age = 21, pets = pets4.ToArray() });

                return obj.ToArray();
            });
        }
    }
}
