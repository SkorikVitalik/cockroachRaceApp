namespace cockroachRace
{
    public static class Race
    {
        private static Cockroach[] tarcoons = new Cockroach[0];
        public static bool IsFinished { get; private set; }
        public static int WinnerId { get; private set; }

        public static void SetTarcoons(int quantityOfTarcoonns, int minSpeed, int maxSpeed)
        {
            tarcoons = new Cockroach[quantityOfTarcoonns];
            for (int i = 0; i < quantityOfTarcoonns; i++)
            {
                Random random = new Random();
                tarcoons[i] = new Cockroach(random.Next(minSpeed, maxSpeed), i);
            }
        }
        public static void Start(int sizeField, int StartPositionX)
        {
            Thread[] roads = new Thread[tarcoons.Length];
            for (int i = 0; i < roads.Length; i++)
            {
                int k = i;
                roads[i] = new Thread(() =>
                    {
                        tarcoons[k].Run(sizeField, k, StartPositionX);
                        lock(Cockroach.locker) 
                        {
                            if (tarcoons[k].IsPassed)
                            {
                                for (int j = 0; j < tarcoons.Length; j++)
                                {
                                    tarcoons[j].Stop();
                                }
                                IsFinished = true;
                                WinnerId = tarcoons[k].TarcoonId;
                                Console.SetCursorPosition(StartPositionX, tarcoons.Length + 1);
                                Console.WriteLine($"{WinnerId} победил");
                            }
                        }
                    }
                );
            }
            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].Start();
            }
        }
    }
}
