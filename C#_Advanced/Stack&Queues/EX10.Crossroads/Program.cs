namespace EX10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int greenLightLength = int.Parse(Console.ReadLine());
           int freeWindow = int.Parse(Console.ReadLine());
           Queue<char> chars = new Queue<char>();
           Queue<string> charsCars = new Queue<string>();
           Queue<string> passedCars = new Queue<string>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if(command != "green")
                {
                    foreach(char c in command)
                    {
                        chars.Enqueue(c);
                    }
                    charsCars.Enqueue(command);
                }
                if (command == "green")
                {
                    // Първи Случай
                    if (chars.Count < greenLightLength)
                    {
                        int counter = 0;
                        for (int i = 0; i < greenLightLength; i++)
                        {
                            chars.Dequeue();
                            counter++;
                        }
                        if (counter == greenLightLength)
                        {
                            if (chars.Count < freeWindow)
                            {
                                for (int j = 0; j < chars.Count; j++)
                                {
                                    chars.Dequeue();
                                }
                            }
                            else if (chars.Count > freeWindow)
                            {
                                for (int j = 0; j < freeWindow; j++)
                                {
                                    chars.Dequeue();
                                    counter++;
                                }
                                if (j == freeWindow)
                                {

                                }
                            }
                        }
                    }
                    else if(chars.Count > greenLightLength)
                    {
                        int counter = 0;
                        for (int i = greenLightLength; i < chars.Count; i--)
                        {
                            counter++;
                        }
                        if(counter == greenLightLength)
                        {
                            Console.WriteLine("Crash Happened");
                        }
                    }
                }
            }
        }
    }
}
