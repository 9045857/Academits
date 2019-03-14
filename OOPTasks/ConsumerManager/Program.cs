namespace ConsumerManager
{
    class Program
    {
        static void Main(string[] args)
        {         
            ProducerConsumerManager producerConsumerManager = new ProducerConsumerManager();
            producerConsumerManager.Start();
        }
    }
}
