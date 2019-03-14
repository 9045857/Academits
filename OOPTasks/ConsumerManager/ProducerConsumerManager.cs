using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsumerManager
{
    class ProducerConsumerManager
    {
        private readonly List<string> list = new List<string>();
        private readonly object obj = new object();

        private const int CAPACITY = 5;
        private const int PRODUCERS_COUNT = 2;
        private const int CONSUMERS_COUNT = 2;

        public void Start()
        {
            // создаем потоки производители и потребители, запускаем их
            // создали потребителей
            for (int i = 0; i < CONSUMERS_COUNT; ++i)
            {
                Thread consumer = new Thread(new Consumer(this).Run);
                consumer.Start();
            }

            // создали производителей
            for (int i = 0; i < PRODUCERS_COUNT; ++i)
            {
                Thread producer = new Thread(new Producer(this).Run);
                producer.Start();
            }
        }

        public string GetItem()
        {
            // получение одного элемента
            lock (obj)
            {
                while (list.Count() <= 0)
                {
                    Monitor.Wait(obj);
                }
                string result = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                Monitor.PulseAll(obj);
                return result;
            }
        }

        public void AddItem(string item)
        {
            // добавление в список
            lock (obj)
            {
                while (list.Count() >= CAPACITY)
                {
                    Monitor.Wait(obj);
                }
                list.Add(item);
                Monitor.PulseAll(obj);
            }
        }
    }
}
