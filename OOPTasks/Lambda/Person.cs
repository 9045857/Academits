﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
