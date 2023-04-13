class Cockroach
{
    public static object locker = new object();
    private int CurrentX;
    private int CurrentY;
    public bool IsPassed { get; private set; }
    public bool IsStoped { get; private set; }
    public int TarcoonId { get; private set; }
    public int Speed { get; private set; }
    public Cockroach(int speed, int tarcoonId)
    {
        Speed = speed;
        TarcoonId = tarcoonId;
    }

    public void Run(int Count, int StartPositionY, int StartPositionX)
    {
        CurrentY = StartPositionY;
        CurrentX = StartPositionX;
        for (int i = 0; i < Count; i++)
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
                CurrentX = CurrentX + 1;
            }
        }
        lock (locker)
        {
            if (!IsStoped)
            {
                IsPassed = true;
            }
        }
    }
    public void Stop()
    {
        if (!IsPassed)
        {
            IsStoped = true;
        }
    }
}

