using System;
using System.IO;

namespace L16Streams
{
    class Program
    {
        /// <summary>
        /// Задачи 1 и 2 лекции 16 - Ввод/вывод
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Задача 1
            //•Побайтово скопировать файл
            //•Использовать буферизованные байтовые потоки, использовать цикл при чтении

            try
            {
                string readerFileName = "source.jpg";
                string writerFileName = "destination.jpg";

                Console.WriteLine("Задание 1");
                Console.WriteLine("Копирование файла {0} в {1}", readerFileName, writerFileName);

                using (BinaryReader reader = new BinaryReader(new FileStream(readerFileName, FileMode.Open, FileAccess.Read)))
                {
                    using (BinaryWriter writer = new BinaryWriter(new FileStream(writerFileName, FileMode.OpenOrCreate, FileAccess.Write)))
                    {
                        byte[] res = new byte[100000];

                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            int read = 0;
                            int off = 0;

                            while ((read = reader.Read(res, off, res.Length - off)) >= 0)
                            {
                                off += read;
                            }

                            writer.Write(res, 0, off);
                        }

                    }
                }

                Console.WriteLine("Копирование завершено");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Задача 2
            //•Создать файл и записать в него 100 строк вида «Строка 1», «Строка 2» и т.д.до «Строка 100»
            //•Записать в файл еще несколько произвольных строк
            //•Использовать StreamWriter

            try
            {
                string textFileName = "textDestination.txt";

                Console.WriteLine("Задание 2");
                Console.WriteLine("Запись в файл {0} текстовых строк", textFileName);

                using (StreamWriter textWriter = new StreamWriter(textFileName, true, System.Text.Encoding.Default))
                {
                    textWriter.WriteLine("Запись строк от 1 до 100");
                    textWriter.WriteLine();

                    for (int i = 1; i < 101; i++)
                    {
                        textWriter.WriteLine("Строка {0}", i);
                    }

                    textWriter.WriteLine();
                    textWriter.WriteLine("Запись строк закончена");
                }

                Console.WriteLine("Запись в файл завершена");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
