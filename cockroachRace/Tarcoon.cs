
class Tarcoon
{
    public object locker = new object();
    public int CurrentX;
    public int CurrentY;
    public int Count;
    public int Speed;
    public bool Finished;
    public Tarcoon(int speed)
    {
        
    }

    public void Move()
    {
        for (int i = 0; i < Count - 1 && !Finished; i++)
        {
            lock (locker)
            {
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write('@');
            }
            Thread.Sleep(Speed);
            lock (locker)
            {
                Console.SetCursorPosition(CurrentX, CurrentY);
                Console.Write(' ');
            }
            CurrentX = CurrentX + 1;
        }
        if (!Finished)
        {
            Console.Write('@');
            Finished = true;
            Console.WriteLine($"{CurrentY} победил");
        }
    }
}

