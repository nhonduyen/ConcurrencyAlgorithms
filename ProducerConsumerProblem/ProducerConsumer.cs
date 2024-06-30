using System.Collections.Concurrent;

namespace ProducerConsumerProblem
{
    public class ProducerConsumer
    {
        private static readonly int bufferSize = 10;
        private static BlockingCollection<int> buffer = new BlockingCollection<int>(bufferSize);

        public static void Producer()
        {
            int item = 0;
            while (true)
            {
                Thread.Sleep(new Random().Next(100, 500)); // Simulate producing time
                buffer.Add(item);
                Console.WriteLine($"Produced: {item}");
                item++;
            }
        }

        public static void Consumer()
        {
            while (true)
            {
                int item = buffer.Take();
                Console.WriteLine($"Consumed: {item}");
                Thread.Sleep(new Random().Next(100, 500)); // Simulate consuming time
            }
        }

    }
}
