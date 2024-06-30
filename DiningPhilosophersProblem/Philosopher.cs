namespace DiningPhilosophersProblem
{
    public class Philosopher
    {
        private int id;
        private Random random;

        public Philosopher(int id)
        {
            this.id = id;
            this.random = new Random(id);
        }

        public void Dine(int numPhilosophers, Chopstick[] chopsticks)
        {
            while (true)
            {
                Think();
                Eat(numPhilosophers, chopsticks);
            }
        }

        private void Think()
        {
            Console.WriteLine($"Philosopher {id} is thinking.");
            Thread.Sleep(random.Next(1000, 3000));
        }

        private void Eat(int numPhilosophers, Chopstick[] chopsticks)
        {
            int leftChopstick = id;
            int rightChopstick = (id + 1) % numPhilosophers;

            // To prevent deadlock, we always lock the lower-numbered chopstick first.
            var firstChopstick = chopsticks[Math.Min(leftChopstick, rightChopstick)];
            var secondChopstick = chopsticks[Math.Max(leftChopstick, rightChopstick)];

            lock (firstChopstick)
            {
                lock (secondChopstick)
                {
                    Console.WriteLine($"Philosopher {id} is eating. Chopsticks using {firstChopstick.Id} - {secondChopstick.Id}");
                    Thread.Sleep(random.Next(1000, 2000));
                }
            }
        }
    }
}
