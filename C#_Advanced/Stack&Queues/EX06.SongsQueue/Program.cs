using System.Linq;

namespace EX06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> cSharpPlayer = new();
            foreach (string songs in input)
            {
                cSharpPlayer.Enqueue(songs);
            }
            while (cSharpPlayer.Count > 0)
            {
                if (cSharpPlayer.Count > 0)
                {
                    string command = Console.ReadLine();
                    string module = command.Split(' ')[0];
                    string[] remainingParts = command.Split(' ').Skip(1).ToArray();
                    string restOfCommand = string.Join(" ", remainingParts);
                    switch (module)
                    {
                        case "Play":
                            if (cSharpPlayer.Count > 0)
                            {
                                cSharpPlayer.Dequeue();
                            }
                            else
                            {
                                Console.WriteLine("No more songs in the queue!");
                            }
                            break;

                        case "Add":
                            bool exist = cSharpPlayer.Contains(restOfCommand);
                            if (!exist)
                            {
                                cSharpPlayer.Enqueue(restOfCommand);
                            }
                            else if (exist)
                            {
                                Console.WriteLine($"{restOfCommand} is already contained!");
                            }
                            break;

                        case "Show":
                            int counter = 0;
                            foreach (string songs in cSharpPlayer)
                            {
                                if(counter == cSharpPlayer.Count-1)
                                {
                                    Console.Write($"{songs}");

                                }
                                else if(counter < cSharpPlayer.Count)
                                {
                                    Console.Write($"{songs}, ");
                                }
                                counter++;
                            }
                            break;
                    }
                }
            }
            if (cSharpPlayer.Count == 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
