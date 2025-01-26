using System.ComponentModel.Design;
using System.Net.WebSockets;

namespace EX06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>>wardrobe = new();
            int iterations = int.Parse(Console.ReadLine());
            string[] input = null;
            string uniquekey = null;
            string dress = null;
            string[] uniqueDress = null;
            for (int i = 0; i < iterations;)
            {
                while (i < iterations)
                {
                    input = Console.ReadLine().Split(" -> ");
                    string key = input[0];
                    string[] values = input[1].Split(",");
                    if (!wardrobe.ContainsKey(key))
                    {
                        wardrobe[key] = new Dictionary<string, int>();
                    }
                    foreach (string value in values)
                    {
                        if (!wardrobe[key].ContainsKey(value))
                        {
                            wardrobe[key].Add(value, 1);
                        }
                        else
                        {
                            wardrobe[key][value]++;
                        }
                    }
                    i++;
                }
                uniqueDress = Console.ReadLine().Split(" ");
                uniquekey = uniqueDress[0];
                dress = uniqueDress[1];
            }
            foreach(var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach(var user in item.Value)
                {
                    if(item.Key == uniquekey && user.Key == dress)
                    {
                        Console.WriteLine($"* {user.Key} - {user.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {user.Key} - {user.Value}");
                    }

                }
            }
        }
    }
}
/*
 * Blue -> dress,jeans,hat
Gold -> dress,t-shirt,boxers
White -> briefs,tanktop
Blue -> gloves
Blue dress*/