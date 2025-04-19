using System;
using System.Threading;
// ---------------------- Part 1: Threads ----------------------
//new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Thread #1");
//}).Start();

//new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Thread #2");
//}).Start();

//new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Thread #3");
//}).Start();

//new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Thread #4");
//}).Start();

// ---------------------- Part 2: Threads Continued ----------------------
//var taskCompletionSource = new TaskCompletionSource<bool>();

//var thread = new Thread(() =>
//{
//    Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} started");
//    Thread.Sleep(1000);
//    taskCompletionSource.TrySetResult(true);
//    Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} ended");
//});
//Console.WriteLine($"Thread Number: {thread.ManagedThreadId}");

//thread.Start();
//var test = taskCompletionSource.Task.Result;
//Console.WriteLine("Task was done: {0}", test);

// ---------------------- Part 3: Thread Pools ----------------------
//new Thread(() =>
//{
//    Thread.Sleep(1000);
//    Console.WriteLine("Background Thread");
//})
//{ IsBackground = true }.Start();


//Enumerable.Range(0, 100).ToList().ForEach(f =>
//{
//    ThreadPool.QueueUserWorkItem((o) =>
//    {
//        Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} started");
//        Thread.Sleep(1000);
//        Console.WriteLine($"Thread Number: {Thread.CurrentThread.ManagedThreadId} ended");
//    });
//});

// ---------------------- Part 4: Join and IsAlive ----------------------
Thread thread1 = new Thread(Thread1Function);
Thread thread2 = new Thread(Thread2Function);

thread1.Start();
thread2.Start();

if (thread1.IsAlive)
{
    Console.WriteLine("Thread 1 is still running");
}

if (thread2.IsAlive)
{
    Console.WriteLine("Thread 1 is still running");
}


thread1.Join();
Console.WriteLine("Thread 1 Function Done");
thread2.Join();
Console.WriteLine("Thread 2 Function Done");

static void Thread1Function()
{
    Console.WriteLine("Thread 1 Function Started");
}

static void Thread2Function()
{
    Console.WriteLine("Thread 2 Function Started");
}

Console.ReadLine();

