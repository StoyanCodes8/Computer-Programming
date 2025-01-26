namespace EX02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            int set1Length = int.Parse(input[0]);
            int set2Length = int.Parse(input[1]);
            int number = 0;

            // Направи сетове
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            // Сега запълни сетовете, само че за този начин не съм сигурен как дас е провери ако станат еднакви елементите
          /*  for(int i = 0; i < set1Length + set2Length; i++)
            {
                number = int.Parse(Console.ReadLine());
            } */

            for(int i = 0; i < set1Length; i++)
            {
                number = int.Parse(Console.ReadLine());
                set1.Add(number);
            }
            for(int i = 0;i < set2Length; i++)
            {
                number = int.Parse(Console.ReadLine());
                set2.Add(number);
            }
            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ", set1)); // Извежда: 2, 3
        }
    }
}
