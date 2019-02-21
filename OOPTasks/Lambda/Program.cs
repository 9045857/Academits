using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //•В Main создать список из нескольких людей

            List<Person> people = new List<Person>();

            people.Add(new Person("Анастасия", 21));
            people.Add(new Person("Анастасия", 17));
            people.Add(new Person("Андрей", 19));
            people.Add(new Person("Анна", 24));
            people.Add(new Person("Анна", 14));
            people.Add(new Person("Антон", 10));
            people.Add(new Person("Арина", 11));
            people.Add(new Person("Артем", 16));
            people.Add(new Person("Артем", 23));
            people.Add(new Person("Вероника", 19));
            people.Add(new Person("Владимир", 14));
            people.Add(new Person("Данил", 12));
            people.Add(new Person("Дарья", 21));
            people.Add(new Person("Денис", 25));
            people.Add(new Person("Дмитрий", 13));
            people.Add(new Person("Екатерина", 14));
            people.Add(new Person("Екатерина", 23));

            //•При помощи лямбда - функций:
            //•А) получить список уникальных имен
            Console.WriteLine("Список уникальных имен:");

            List<string> uniqueNames = people
                .Select(x => x.Name)
                .Distinct()
                .ToList();

            uniqueNames.ForEach(element => Console.WriteLine(element));
            Console.WriteLine();

            //•Б) вывести список уникальных имен в формате: Имена: Иван, Сергей, Петр.
            Console.WriteLine("Список уникальных имен в строку, разделенных запятой:");

            // вариант вывода уникальных имен из специального списка
            //string allNamesString = string.Join(", ", uniqueNames.Select(p => p));

            // вариант вывода уникальных имен из общего списка
            string allUniqueNames = string.Join(", ", people
                .Select(p => p.Name)
                .Distinct());

            Console.WriteLine(allUniqueNames);

            //•В) получить список людей младше 18, посчитать для них средний возраст
            List<Person> peopleUnder18 = people
                .Where(x => x.Age < 18);
                // .Select(x => x.Name);

                /*.Select(x => x)*///;


            double averageAge = people
                .Select(x => x.Age)
                .Where(x => x < 18)
                .Average();

            Console.WriteLine(averageAge);


            //•Г) при помощи группировки получить Map, в котором ключи – имена, а значения – средний возраст
            //•Д) получить людей, возраст которых от 20 до 45, вывести в консоль их имена в порядке убывания возраста




        }
    }
}
