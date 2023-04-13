using System.Threading;

object locker = new Object();
Start(Create(10));

void Move(int x, int y, int count, int speed, ref bool finished)
{
    for (int i = 0; i < count - 1 && !finished; i++)
    {
        lock (locker)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('@');
        }
        Thread.Sleep(speed);
        lock (locker)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');

        }
        x = x + 1;
    }
    if (!finished)
    {
        lock(locker)
        {
            Console.Write('@');
            finished = true;
            Console.WriteLine($"{y} победил");
        }

    }

}
Thread[] Create(int count)
{
    bool IsFinished = false;
    Random random = new Random();
    Thread[] threads2 = new Thread[count];
    for (int i = 0; i < count; i++)
    {
        int x = i;
        threads2[i] = new Thread(() => Move(0, x, 20, random.Next(100, 200), ref IsFinished));
    }
    return threads2;
}
Thread[] Start(Thread[] threads)
{
    for (int i = 0; i < threads.Length; i++)
    {
        threads[i].Start();
    }
    return threads;
}

