namespace P05.EvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            Queue<int> ints = new Queue<int>();
            for(int i = 0; i < input.Length; i++)
            {
                int number = int.Parse(input[i]);
                if(number %2 == 0)
                {
                    ints.Enqueue(number);
                }
            }
            int counter = 0;
            foreach(var item in ints)
            {
                if(counter == ints.Count-1)
                {
                    Console.Write($"{item}");
                }
                else if(counter < ints.Count)
                {
                    Console.Write($"{item}, ");
                }
                counter++;
            }
        }
    }
}
