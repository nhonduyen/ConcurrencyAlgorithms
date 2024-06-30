using ProducerConsumerProblem;

var producerConsumer = new ProducerConsumer();

Thread producerThread = new Thread(new ThreadStart(() => ProducerConsumer.Producer()));
Thread consumerThread = new Thread(new ThreadStart(() => ProducerConsumer.Consumer()));

producerThread.Start();
consumerThread.Start();

// Main thread waits for worker thread to finish
producerThread.Join();
// This below line will only be executed after the worker thread has finished
consumerThread.Join();
