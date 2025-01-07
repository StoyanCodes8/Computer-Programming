namespace P07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // имам броя на всички деца
            // имам броя на хвърлянията. Децата се елиминират когато каунтъра стане номера на хвърляния - броят на децата и детето на номера на хвърляния + 1

            string[] participants = Console.ReadLine().Split(" ");
            Queue<string> queue = new();
            string[] participats = queue.ToArray();
            foreach (string participant in participants)
            {
                queue.Enqueue(participant);
            }
            int cycleLength = int.Parse(Console.ReadLine());
            int counter = 0;
            for (int i = 1; i <= cycleLength; i++)
            {
                if (i == queue.Count)
                {
                    i = 0;
                }
                counter++;
                if (counter == cycleLength)
                {

                    queue.Dequeue();
                }
            }

            /*string[] participants = Console.ReadLine().Split(" ");
            int cycleLength = int.Parse(Console.ReadLine());
            int counter = 0;
            for(int i = 0; i <= cycleLength; i++)
            {
                if(i == participants.Length)
                {
                    i = 0;
                }
                Console.WriteLine(participants[i]);
                counter++;
                if(counter  == cycleLength)
                {
                    break;
                }
            }*/
        }
    }
}
