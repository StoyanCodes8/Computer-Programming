namespace P06.SuperMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            Queue<string> customers = new();
            Queue<string> paidCustomersQueue = new();    
            while ((command = Console.ReadLine()) != "End")
            {
                if(command == "Paid")
                {
                    foreach(string paidCustomers in customers)
                    {
                        paidCustomersQueue.Enqueue(paidCustomers);
                    }
                    customers.Clear();
                }
                else if(command != "Paid")
                {
                    customers.Enqueue(command);
                }
            }
            int unpaidCustomer = customers.Count;
            foreach (var customer in paidCustomersQueue)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine($"{unpaidCustomer} people remaining.");
        }
    }
}
