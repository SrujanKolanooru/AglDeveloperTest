using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AglDeveloperTest.Model
{
    public class Person
    {
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public Pet[] pets { get; set; }
    }
}
