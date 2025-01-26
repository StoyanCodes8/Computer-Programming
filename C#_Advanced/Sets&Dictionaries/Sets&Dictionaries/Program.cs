namespace Sets_Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            string input;
            for(int i = 0; i < number; i++)
            {
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    set.Add(input);
                } 
            }
            foreach(string item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
