using System.Data;

namespace EX06.JaggedArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[number][];
            string[] input = null;
            int intInput;

            // Създай масива и му задай дължина спрямо дължината на инпута
            for (int i = 0; i < number; i++)
            {
                input = Console.ReadLine().Split(" ");
                jaggedArray[i] = new int[input.Length];

                // Задаване на стойностите на елементите вътре - jaggedArray[i][j]
                for (int j = 0; j < input.Length; j++)
                {
                    intInput = int.Parse(input[j]);
                    jaggedArray[i][j] = intInput;
                }
            }

            //Анализиране и умножаване на елементи по две или делене на елементи по две
            for (int i = 0; i < number; i++)
            {
                if (i < number-1)
                {
                    if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                    {
                        for (int k = 0; k < jaggedArray[i].Length; k++)
                        {
                            int value = jaggedArray[i + 1][k] *= 2;
                            int value2 = jaggedArray[i][k] *= 2;
                        }
                    }
                    else if (jaggedArray[i].Length != jaggedArray[i + 1].Length)
                    {
                        int maxIndex = jaggedArray[i].Length > jaggedArray[i + 1].Length ? i : i + 1; // •	Ако условието е вярно (т.е. текущият подмасив е по-дълъг), тогава maxIndex ще бъде зададен на i
                        int minIndex = jaggedArray[i].Length < jaggedArray[i + 1].Length ? i : i + 1;

                        for (int k = 0; k < jaggedArray[minIndex].Length; k++)
                        {
                            jaggedArray[minIndex][k] /= 2;
                        }

                        for (int k = 0; k < jaggedArray[maxIndex].Length; k++)
                        {
                            jaggedArray[maxIndex][k] /= 2;
                        }
                    }
                }
            }
            string command;
            string[] textInput;
            while ((command = Console.ReadLine()) != "End")
            {
                textInput = command.Split(" ");
                {
                    string operation = textInput[0];
                    if (operation == "Add")
                    {
                        int row = int.Parse(textInput[1]);
                        int value = int.Parse(textInput[3]);
                        if (row > number)
                        {
                            continue;
                        }
                        int col = int.Parse(textInput[2]);
                        {
                            if (row >= jaggedArray.Length || row < 0 || col >= jaggedArray[row].Length || col < 0)
                            {
                                continue;
                            }
                            else
                            {
                                jaggedArray[row][col] = value;
                            }
                        }
                    }
                    else if (operation == "Subtract")
                    {
                        int row = int.Parse(textInput[1]);
                        int col = int.Parse(textInput[2]);
                        int value = int.Parse(textInput[3]);
                        if (row > number)
                        {
                            continue;
                        }
                        {
                            if (row >= jaggedArray.Length || row < 0 || col >= jaggedArray[row].Length || col < 0)
                            {
                                continue;
                            }
                            else
                            {
                                jaggedArray[row][col] -= value;

                            }
                        }
                    }
                    else
                    {
                        //throw new Exception("Command Not Found"); // or command not available, who cares (I don't) - (I do) - Who are you?! - your shizo friend hehehhe - : ( - : ) - FUCKER
                    }
                }
            }
            int counter = 0; // Because SoftUni made me do it, otherwise the code works
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (i < jaggedArray.Length - 1)
                    {
                        Console.Write(jaggedArray[i][j] + " ");
                    }
                    else if(i == jaggedArray.Length - 1)
                    {
                        Console.Write(jaggedArray[i][j]);
                    }
                    counter++;
                }
                Console.WriteLine();
            }
        }
    }
}

/*   if(textInput.Length == 2)
               {
                   string operation = textInput[0];
                   if(operation == "Add")
                   {

                   }
                   else if(operation == "Subtract")
                   {

                   }
                   int index = int.Parse(textInput[1]);
               }*/

// Създай масива и му задай дължина спрямо дължината на инпута
/*  for(int i = 0; i < number; i++)
  {
      input = Console.ReadLine().Split(" ");
      jaggedArray[i] = new int[input.Length];

      // Задаване на стойностите на елементите вътре - jaggedArray[i][j]
      for(int j = 0; j < input.Length; j++)
      {
          intInput = int.Parse(input[j]);
          jaggedArray[i][j] = intInput;
      }
  }*/
