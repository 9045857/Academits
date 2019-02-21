using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //•В Main создать список из нескольких людей
            Console.WriteLine("Список людей: Имя - возраст");

            List<Person> people = new List<Person>();

            people.Add(new Person("Анастасия", 21));
            people.Add(new Person("Анастасия", 17));
            people.Add(new Person("Андрей", 19));
            people.Add(new Person("Анна", 24));
            people.Add(new Person("Анна", 14));
            people.Add(new Person("Антон", 10));
            people.Add(new Person("Арина", 43));
            people.Add(new Person("Артем", 37));
            people.Add(new Person("Артем", 26));
            people.Add(new Person("Вероника", 19));
            people.Add(new Person("Владимир", 14));
            people.Add(new Person("Данил", 12));
            people.Add(new Person("Дарья", 21));
            people.Add(new Person("Денис", 25));
            people.Add(new Person("Дмитрий", 13));
            people.Add(new Person("Екатерина", 14));
            people.Add(new Person("Екатерина", 23));

            people.ForEach(p => Console.WriteLine("{0} - {1}", p.Name, p.Age));

            //•При помощи лямбда - функций:
            //•А) получить список уникальных имен
            Console.WriteLine();
            Console.WriteLine("Список уникальных имен:");

            List<string> uniqueNames = people
                .Select(x => x.Name)
                .Distinct()
                .ToList();

            uniqueNames.ForEach(element => Console.WriteLine(element));

            //•Б) вывести список уникальных имен в формате: Имена: Иван, Сергей, Петр.
            Console.WriteLine();
            Console.WriteLine("Список уникальных имен в строку, разделенных запятой:");

            // вариант вывода уникальных имен из специального списка
            //string allNamesString = string.Join(", ", uniqueNames.Select(p => p));

            // вариант вывода уникальных имен из общего списка
            string allUniqueNames = string.Join(", ", people
                .Select(p => p.Name)
                .Distinct());

            Console.WriteLine(allUniqueNames);

            //•В) получить список людей младше 18, посчитать для них средний возраст
            Console.WriteLine();
            Console.WriteLine("список людей младше 18");

            // использование универсального типа var
            //var peopleUnder18 = people
            //    .Where(x => x.Age < 18);

            List<Person> peopleUnder18 = people
               .Where(x => x.Age < 18)
               .ToList();

            foreach (Person person in peopleUnder18)
            {
                Console.WriteLine("{0} - {1}", person.Age, person.Name);
            }

            // расчет среднего возраста для группы людей без создания списка
            //double averageAge = people
            //    .Select(x => x.Age)
            //    .Where(x => x < 18)
            //    .Average();

            //расчет среднего возраста для ранее созданного списка
            double averageAge = peopleUnder18
                .Select(x => x.Age)
                .Average();

            Console.WriteLine("Средний возраст: {0}", averageAge);

            //•Г) при помощи группировки получить Map, в котором ключи – имена, а значения – средний возраст
            Console.WriteLine();
            Console.WriteLine("Map, в котором ключи – имена, а значения – средний возраст");

            var personsByName = people
                .GroupBy(p => p.Name)
                .ToDictionary(p => p.Key, p => p.Select(p1 => p1.Age).Average());

            foreach (KeyValuePair<string, double> keyValue in personsByName)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }

            //•Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста
            Console.WriteLine();
            Console.WriteLine("люди, возраст которых от 20 до 45, их имена в порядке убывания возраста");

            var peopleUp20To45 = people
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();

            peopleUp20To45.ForEach(person => Console.WriteLine("{0} - {1}", person.Age, person.Name));
        }
    }
}
