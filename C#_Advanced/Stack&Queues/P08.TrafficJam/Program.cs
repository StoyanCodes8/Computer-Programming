using System.Text;

namespace P08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passingCarsAmount = int.Parse(Console.ReadLine());
            string command;
            StringBuilder cars = new StringBuilder();
            Queue<string> carsQueue = new Queue<string>();
            Queue<string> passedCars = new Queue<string>();
            int passedCount = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if(command != "green")
                {
                    //cars.Append(command);
                    carsQueue.Enqueue(command);
                }
                else if(command == "green")
                {
                    for(int i = 0; i < passingCarsAmount; i++)
                    {
                        //string carName = carsQueue.Peek();
                        bool isEmpty = carsQueue.Count == 0;
                        if(!isEmpty)
                        {
                            string car = carsQueue.Dequeue();
                            passedCars.Enqueue(car);
                            passedCount++;
                        }
                    }
                }
            }
            foreach(var car in passedCars)
            {
                Console.WriteLine($"{car} passed!");
            }
            Console.WriteLine($"{passedCount} cars passed the crossroads.");
        }
    }
}
