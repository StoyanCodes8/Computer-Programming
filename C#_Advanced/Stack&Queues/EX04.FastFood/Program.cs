namespace EX04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodCapacity = int.Parse(Console.ReadLine());
            Queue<int> ordersCapacityQueue = new();
            Queue<int> numberCheck = new();
            for (int i = 0; i < foodCapacity; i++)
            {
                ordersCapacityQueue.Enqueue(i);
            }
            string[] ordersAmount = Console.ReadLine().Split(" ");
            foreach (string order in ordersAmount)
            {
                int orders = int.Parse(order);
                numberCheck.Enqueue(orders);
            }
            int biggestNumber = numberCheck.Max();
            foreach (string order in ordersAmount)
            {
                int orders = int.Parse(order);
                if (ordersCapacityQueue.Count > 0)
                {
                    for (int i = 0; i < orders; i++)
                    { 
                        if(ordersCapacityQueue.Count > 0)
                        {
                            ordersCapacityQueue.Dequeue();
                        }
                        else if(ordersCapacityQueue.Count == 0)
                        {
                            Console.WriteLine($"{biggestNumber}\nOrders left: {orders}");
                            break;
                        }
                    }
                }
                else if(ordersCapacityQueue.Count == 0)
                {
                    Console.WriteLine($"{biggestNumber}\nOrders left: {orders}");
                    break;
                }
            }
            if(ordersCapacityQueue.Count > 0)
            {
                Console.WriteLine($"{biggestNumber}\nOrders complete");
            }
        }
    }
}
