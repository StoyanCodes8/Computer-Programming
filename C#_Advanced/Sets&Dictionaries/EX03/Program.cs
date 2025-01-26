using System.Collections.Generic;
using System.Reflection.Metadata;

namespace EX03_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            SortedSet<string> strings = new();
            string[] input;
            for(int i = 0; i < iterations; i++)
            {
                input = Console.ReadLine().Split(" ");
                foreach(string word in input)
                {
                    strings.Add(word);
                }
            }
            foreach(string item in strings)
            {
                Console.Write(item + " ");
            }
        }
    }
}
/*  Dictionary<int, string> webinarData = new(); // автобус за двойки ключ-стойност
           // KeyValuePair<int, string> webinar = new(0, "Hello"); // единична двойка ключ-стойнсот
            webinarData.Add(0, "Stoyan");
            webinarData.Add(1, "George");
            webinarData.Add(2, "Ivo");
            webinarData.Add(3, "Jeremy");
            webinarData.Add(4, "Viktor");
            webinarData.Add(5, "Ivan");
            webinarData.Add(6, "Stoyan");
            webinarData.Add(7, "Stoyan");
            webinarData.Add(8, "Stoyan");
            webinarData.Add(9, "Stoyan");



            webinarData = webinarData.OrderBy(s  => s.Key) // ако стойност е равна
                .ThenBy(s => s.Key)
                .ToDictionary();

            List<int>  list = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            list = list.OrderByDescending(x => x).Take(3).ToList();




            foreach (KeyValuePair<int, string> item in webinarData)
            {
                Console.WriteLine(item);
            }*/