using System.Collections.Concurrent;

namespace EX07.TruckTour
{
    public class GasStation
    {
        public int Litres { get; set; }
        public int DistanceToNext { get; set; }

        public GasStation(int litres, int distanceToNext)
        {
            Litres = litres;
            DistanceToNext = distanceToNext;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int gasStationsAmount = int.Parse(Console.ReadLine());
            List<GasStation> gasStations = new List<GasStation>();

            for (int i = 0; i < gasStationsAmount; i++)
            {
                string[] input = Console.ReadLine().Split();
                int litres = int.Parse(input[0]);
                int distance = int.Parse(input[1]);
                gasStations.Add(new GasStation(litres, distance));
            }

            int startIndex = 0; 
            int fuel = 0; 

            for (int i = 0; i < gasStationsAmount; i++)
            {
                GasStation currentStation = gasStations[i];
                fuel += currentStation.Litres;
                fuel -= currentStation.DistanceToNext; 

         
                if (fuel < 0)
                {
                    startIndex = i + 1;
                    fuel = 0; 
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
//******* ОПИТ 1 ********************
// да сложа в опашка горивото, да премахвам дистанцията от него и после да видя ако останлото количество е над 0 да подължа, ако не да спра
/* int gasStationsAmount = int.Parse(Console.ReadLine());
 string[] input;
 int counter = 0;
 Queue<int> fuelQueue = new();
 for(int i = 0; i < gasStationsAmount; i++)
 {
     input = Console.ReadLine().Split(" ");
     int fuel = int.Parse(input[0]);
     fuelQueue.Enqueue(fuel);
     int distance = int.Parse(input[1]);
     if(fuel > distance)
     {
         for (int j = fuel; j > distance; j++)
         {
             fuelQueue.Dequeue();
         }
     }
     counter++;



 }*/
//******* ОПИТ 2 ********************
/* int gasStationsAmount = int.Parse(Console.ReadLine());
 string gasStations = null;
 //Dictionary<int, Dictionary<int, int>> gasDictionary = new();
 Dictionary<int, (int Litres, int Distance)> gasDictionary = new();
 int key = 1;
 for (int i = 0; i < gasStationsAmount; i++)
 {
     gasStations = Console.ReadLine();
     string[] Parameters = gasStations.Split(" ");
     int litres = int.Parse(Parameters[0]);
     int distance = int.Parse(Parameters[1]);
     gasDictionary.Add(key, (litres, distance));
     key++;
 }
 Queue<int> fuel = new();
 foreach (var station in gasDictionary)
 {

     //Console.WriteLine($"Station {station.Key}: {station.Value.Litres} litres, {station.Value.Distance} distance");
 }
}*/


//******* ОПИТ 3 ********************
/*   foreach (var gasStationParameters in gasDictionary)
{
string[] Parameters = gasStationParameters.Split(" ");
int litres = int.Parse(Parameters[0]);
int distance = int.Parse(Parameters[1]);
}*/

/*
 * GasStation gasStation = new GasStation();
            gasStation.Litres = litres;
            gasStation.Distance = distance;  */
/*
public class GasStation
{
    public int Litres { get; set; }
    public int Distance { get; set; }
}
}
}
*/