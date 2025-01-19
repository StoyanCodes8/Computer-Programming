using System.Diagnostics.Metrics;

namespace EX10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightLength = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> charsCars = new Queue<string>();
            HashSet<string> passedCars = new();
            Queue<string> crashedCars = new();
            Queue<char> crashedChar = new();
            string message = null;
            string command = null;
            int crashCounter = 0;
            int remainingGreenLight = 0;
            int remainingWindow = 0;
            while ((command = Console.ReadLine()) != "END")
            {

                if (command != "green")
                {
                    charsCars.Enqueue(command);
                }
                if (command == "green")
                {
                    remainingGreenLight = greenLightLength;
                    while (charsCars.Count > 0)
                    {
                        string car = charsCars.Peek();
                        if (car.Length <= remainingGreenLight)
                        {
                            remainingGreenLight -= car.Length;
                            charsCars.Dequeue();
                            passedCars.Add(car);
                        }
                        else
                        {
                            remainingWindow = freeWindow - (car.Length - remainingGreenLight); //интересна логика, вярна е
                            if (remainingWindow >= 0)
                            {
                                charsCars.Dequeue();
                                passedCars.Add(car);
                            }
                            else
                            {
                                //int crashIndex = remainingGreenLight + freeWindow;
                                crashedCars.Enqueue(car);
                                char crashIndex = car[remainingGreenLight + freeWindow];
                                crashedChar.Enqueue(crashIndex);
                                crashCounter++;
                                break;
                            }
                        }
                    }
                }
            }
            if(crashCounter == 0)
            {
                Console.WriteLine($"Everyone is safe.");
                Console.WriteLine($"{passedCars.Count} total cars passed the crossroads.");
            }
            else if(crashCounter > 0)
            {
                string car = crashedCars.Peek();
                char crashIndex = crashedChar.Peek();
                Console.WriteLine($"A crash happened!\n{car} was hit at {crashIndex}.");
            }
        }
    }
}


        
/*Използване на foreach с Dequeue:
Проблемът е, че модифицираш опашката (charsCars.Dequeue()), докато итерираш с foreach. Това води до неочаквано поведение, защото foreach не е предназначен за промяна на колекцията, докато се обхожда. Вместо това използвай while цикъл с Peek и Dequeue, за да обработваш елементите един по един.

Логиката за коли с дължина под greenLightLength:
В момента инкрементираш counter в цикъл за всяка секунда, но не рестартираш counter за всяка кола. Това води до неточни изчисления. Трябва да следиш колко време остава от зеления сигнал и да намаляваш това време с всяка преминала кола.

Липсва логика за коли, които са твърде дълги:
В else if (car.Length > greenLightLength) блокът ти липсва реална проверка дали колата може да премине с помощта на "свободния прозорец" (freeWindow). Тук трябва да изчислиш оставащото време от зеления сигнал и да добавиш "свободния прозорец", за да провериш дали е достатъчно, за да премине колата.

Проблем с прекъсване при катастрофа:
Не проследяваш момента, в който кола не успява да премине и катастрофира. Трябва да спреш изпълнението, когато това се случи, и да изведеш съобщение.*/


  /* foreach(string car in charsCars)
                    {
                           if(car.Length < greenLightLength)
                            {
                                for (int i = 0; i < greenLightLength; i++)
                                {
                                    counter++;
                                    if(counter == car.Length)
                                    {
                                        charsCars.Dequeue();
                                    }
                                }
                            }
                           else if(car.Length > greenLightLength)
                            {

                            }*/


/*foreach(char c in command)
               {
                   chars.Enqueue(c);
               }*/


// Хамъра тръгва да катастрофира, защото когато има една секунда от светофара, когато ползваме дължината на светофара, колите тръгват, когато обаче премине
// - към свободният прозорец, те катастрофират, трябва да си тръгнат, не могат да останат.







/*  int counter = 0;
                        for (int i = 0; i < greenLightLength; i++)
                        {
                            chars.Dequeue();
                            counter++;
                        }
                        if (counter == greenLightLength)
                        {
                            if (chars.Count < freeWindow) //NO CRASH
                            {
                                for (int j = 0; j < chars.Count; j++)
                                {
                                    chars.Dequeue();
                                }
                            }
                            else if (chars.Count > freeWindow) //CRASH
                            {
                                for (int j = 0; j < chars.Count; j++)
                                {
                                    chars.Dequeue();
                                    if( j == charsCars.Count)
                                    {
                                        Console.WriteLine("Crash happened!");
                                        break;
                                    }
                                }
                            }
                        }*/