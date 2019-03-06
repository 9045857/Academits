using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {/// <summary>
    /// Done
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Задача
            //•Создать некоторый класс, самим придумать какие поля и методы у него есть
            //•В другом проекте создать класс с Main, прочитать с консоли имя сборки и имя класса из пункта 1
            //•Загрузить сборку, создать экземпляр загруженного класса

            Console.WriteLine("-=Работа с подгружаемой сборкой через Reflection=-");
            Console.Write("Введите имя сборки(exeForReflection): ");
            string fileName = Console.ReadLine();
            //string fileName = "exeForReflection";// сборка для для отладки

            Console.Write("Введите имя класса(Square): ");
            string className = Console.ReadLine();
            //string className = "Square";//класс для отладки

            Assembly myFile = Assembly.Load(fileName);//загружаем сборку

            string typeName = fileName + "." + className;//формируем имя Типа

            Type myType = myFile.GetType(typeName);

            Console.Write("Введите длину стороны: ");
            double inputSideLength = Convert.ToDouble(Console.ReadLine());

            ConstructorInfo myTypeConstructor = myType.GetConstructor(new Type[] { typeof(double) });
            object square = myTypeConstructor.Invoke(new object[] { inputSideLength });

            ////•Попробовать задать значения private полям, повызывать методы класса
            Console.WriteLine();
            Console.WriteLine("Передадим приватному полю sideLength новое значение");
            Console.Write("Введите длину стороны: ");
            inputSideLength = Convert.ToDouble(Console.ReadLine());

            FieldInfo sideLengthField = myType.GetField("sideLength", BindingFlags.Instance | BindingFlags.NonPublic);

            double privateSideLength = (double)sideLengthField.GetValue(square);
            Console.WriteLine();
            Console.WriteLine("sideLength в нашем объекте был: {0}", privateSideLength);

            sideLengthField.SetValue(square, inputSideLength);

            privateSideLength = (double)sideLengthField.GetValue(square);
            Console.WriteLine("sideLength в нашем объекте стал: {0}", privateSideLength);

            MethodInfo getAreaMethod = myType.GetMethod("GetArea");
            Console.WriteLine("Площадь квадрата со стороной {0} = {1}", privateSideLength, getAreaMethod.Invoke(square, new object[] { }));
            Console.WriteLine();

            Console.WriteLine("Зададим длину стороны через публичный сеттер свойства Length");
            Console.Write("Введите новое значение длины: ");
            inputSideLength = Convert.ToDouble(Console.ReadLine());

            PropertyInfo sideLength = myType.GetProperty("SideLength");
            sideLength.SetValue(square, inputSideLength);
            Console.WriteLine("Площадь: {0}", getAreaMethod.Invoke(square, new object[] { }));

            MethodInfo getPerimeterMethod = myType.GetMethod("GetPerimeter");
            Console.WriteLine("Периметр: {0}", getPerimeterMethod.Invoke(square, new object[] { }));
            Console.WriteLine();
        }
    }
}
