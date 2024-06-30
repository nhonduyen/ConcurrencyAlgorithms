using DiningPhilosophersProblem;

int numPhilosophers = 5;
Philosopher[] philosophers = new Philosopher[numPhilosophers];
Chopstick[] chopsticks = new Chopstick[numPhilosophers];

for (int i = 0; i < numPhilosophers; i++)
{
    chopsticks[i] = new Chopstick(i);
}

for (int i = 0; i < numPhilosophers; i++)
{
    var tempIndex = i;
    philosophers[i] = new Philosopher(i);
    Thread thread = new Thread(() => philosophers[tempIndex].Dine(numPhilosophers, chopsticks));
    thread.Start();
}

Console.ReadLine(); // Prevent the main thread from exiting