namespace EX05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Boxes stack
            string[] boxes = Console.ReadLine().Split(" ");
            Stack<int> boxValue = new Stack<int>();
            foreach (string boxQuantity in boxes)
            {
                int value = int.Parse(boxQuantity);
                boxValue.Push(value);
            }
            // Boxes stack

            // Идеята е да махаме стойността от shelf-а, когато стойността стане 0, да създаваме нов стак на име shelf
            // Shelf Stack
            int shelfCapacity = int.Parse(Console.ReadLine());
            if(shelfCapacity > 20)
            {
                throw new Exception("Too big shells, try again with smaller one...maybe <= 20 :))");
            }
            Stack<int> shelfs = new();
            for(int i = 0; i < shelfCapacity; i++)
            {
                shelfs.Push(i);
            }
            // Shelfs Stack
            if (boxValue.Count > shelfCapacity)
            {
                throw new Exception("Too many clothes in one box");
            }
            int shelfsCounter = 1;
            int currentShelfCapacity = shelfCapacity; // Remaining capacity of the current rack
            foreach (int number in boxValue)
            {
                if (number <= currentShelfCapacity)
                {
                    // The item fits in the current rack
                    currentShelfCapacity -= number;
                }
                else
                {
                    // The item doesn't fit in the current rack; use a new rack
                    shelfsCounter++;
                    currentShelfCapacity = shelfCapacity - number; // Start a new rack and place the item
                }
            }
            Console.WriteLine(shelfsCounter);
        }
    }
}

// ---------------------------------------- THIS IS SOME FANCY (NOT PROPERLY WORKING BUT REALLY FANCE(FOR ME) STUFF)

//  Dictionary<Stack<int>, int> shelfsDictionary = new(); //брутално
// shelfsDictionary.Add(shelfs, 0);

/* foreach(int number in boxValue)
 {
    if(number < shelfs.Count || number == shelfs.Count)
    {
       for(int j = 0; j < number; j++)
       {
         shelfs.Pop();
       }
    }
    else if(number > shelfs.Count)
    {
      shelfsCounter++;
      for (int i = 0; i < shelfCapacity; i++)
      {
        shelfs.Push(i);
      }
      for (int j = 0; j < number; j++)
      {
        shelfs.Pop();
      }
    }
 }
Console.WriteLine(shelfsCounter);*/

/* if(number < shelfs.Count || number == shelfs.Count)
                 {
                   for(int i = number; i < shelfs.Count; i--)
                   {
                     shelfs.Pop();

                   }
=                 }*/