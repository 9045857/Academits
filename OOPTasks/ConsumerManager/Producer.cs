using System.Threading;

namespace ConsumerManager
{
    class Producer
    {
        private readonly ProducerConsumerManager manager;

        public Producer(ProducerConsumerManager manager)
        {
            this.manager = manager;
        }

        public void Run()
        {
            int currentNumber = 1;
            while (true)
            {
                Thread.Sleep(2000); // имитация долгой работы
                manager.AddItem("Item " +currentNumber);
                ++currentNumber;
            }
        }
    }
}
