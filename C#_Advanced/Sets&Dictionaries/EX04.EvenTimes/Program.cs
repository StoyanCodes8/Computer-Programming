namespace EX04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, int> dictionary = new();
            int iterations = int.Parse(Console.ReadLine());
            int number = 0;
            for(int i = 0; i < iterations; i++)
            {
                number = int.Parse((Console.ReadLine()));
                if (!dictionary.ContainsKey(number))
                {
                    dictionary.Add(number, 1);
                }
                else
                {
                    dictionary[number]++;
                }
            }
            foreach(var item in dictionary)
            {
                if(item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }    
            }
        }
    }
}
// Solution with List
/* List<int> list = new List<int>();
 int number = 0;
 int count = 0;
 int iterations = int.Parse(Console.ReadLine());
 for (int i = 0; i < iterations; i++)
 { 
     number = int.Parse(Console.ReadLine());
     list.Add(number);
     if(list.Contains(number))
     {
         count++;
     }
 }*/