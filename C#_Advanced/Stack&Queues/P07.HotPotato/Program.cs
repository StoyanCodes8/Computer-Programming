namespace P07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // имам броя на всички деца
            // имам броя на хвърлянията. Децата се елиминират когато каунтъра стане номера на хвърляния - броят на децата и детето на номера на хвърляния + 1
            string[] participants = Console.ReadLine().Split(" ");
            int tossCount = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(participants); //тази структура не съм я виждал

            while (queue.Count > 1)
            {
                for (int i = 1; i < tossCount; i++)
                {
                    string current = queue.Dequeue();
                    queue.Enqueue(current);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}




































           /*  string[] participants = Console.ReadLine().Split(" ");
             Queue<string> queue = new();
             foreach (string participant in participants)
             {
                 queue.Enqueue(participant);
             }
             int cycleLength = int.Parse(Console.ReadLine());
             int counter = 0;
            while (queue.Count > 1)
            {
                counter++;
                for (int i = 0; i <= cycleLength - 1; i++)
                {
                    if (i == participants.Length)
                    {
                        i = 0;
                    }
                    if (counter == cycleLength)
                    {
                        string lostPlayer = participants[i];
                        queue.Dequeue(lostPlayer);
                    }
                }
            }*/

            /*string[] participants = Console.ReadLine().Split(" ");
            int cycleLength = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 0; i <= cycleLength; i++)
            {
                if (i == participants.Length)
                {
                    i = 0;
                }
                Console.WriteLine(participants[i]);
                counter++;
                if (counter == cycleLength)
                {
                    break;
                }
            }*/