using System.Collections.Generic;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> hashSet = new();
            string[] array = Console.ReadLine().Split(" ");
            foreach (string s in array)
            {
                int number = int.Parse(s);
                hashSet.Add(number);
            }
           
           
            Dictionary<int, List<string>> locks = new();
            locks.Add(1, new List<string> { "Books", "Rubber", "Backpack" });

            Dictionary<string, Dictionary<string, int>> grades = new();
            grades["Stoyan"] = new Dictionary<string, int>
            {
                {"Math", 5 },
                {"English", 6 }
            };
           

            string[] array1 = Console.ReadLine().Split();
            HashSet<int> set = new();
            foreach(string word in array1)
            {
                 if(int.TryParse(word, out int number));
                {
                    set.Add(number);
                }

            }
            foreach(var item in set)
            {
                Console.WriteLine(item);
            }

        }
    }
}
