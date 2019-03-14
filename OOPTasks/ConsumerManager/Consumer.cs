using System;
using System.Threading;

namespace ConsumerManager
{
    class Consumer
    {
        private readonly ProducerConsumerManager manager;

        public Consumer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Run()
        {
            while (true)
            {
                string item = manager.GetItem();
                Thread.Sleep(1500);
                Console.WriteLine(item);
            }
        }
    }
}
