using System;
using System.Linq;
using System.Security.Cryptography;
namespace C__Advanced_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Potions
            Dictionary<int, string> potions = new();
            potions.Add(110, "Brew of Immortality");
            potions.Add(100, "Essence of Resilience");
            potions.Add(90, "Draught of Wisdom");
            potions.Add(80, "Potion of Agility");
            potions.Add(70, "Elixir of Strength");
            UserInput(potions);
        }
        public static void UserInput(Dictionary<int, string> potions)
        {
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> crystals = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            AlchemyProcess(substances, crystals, potions);
        }
        public static void AlchemyProcess(Stack<int> substances, Queue<int> crystals, Dictionary<int, string> potions)
        {
            int requiredPotions = 5;
            int currentPotions = 0;
            HashSet<string> madePotions = new();
            while (currentPotions < requiredPotions && substances.Count != 0) // Условие
            {
                int firstSubstance = substances.Peek();
                int firstCrystal = crystals.Peek();
                int combinedPower = firstSubstance + firstCrystal;
                if (potions.ContainsKey(combinedPower))
                {
                    string value = potions[combinedPower];
                    // •	The alchemist will not make experiments to craft potions, which have been already crafted.
                    if (!madePotions.Contains(value))
                    {
                        madePotions.Add(value);
                        currentPotions++;
                    }
                }
                else if (!potions.ContainsKey(combinedPower))
                {
                    foreach (var key in potions.Keys.Where(key => key < combinedPower))
                    {
                        string value = potions[key];
                        if (!madePotions.Contains(value))
                        {
                            madePotions.Add(value);
                            currentPotions++;
                            break;
                        }
                    }
                }
               /* if (madePotions.Count == requiredPotions)
                {
                    break;
                }*/ // НЕ
                substances.Pop();
               /* if (madePotions.Count == requiredPotions)
                {
                    break;
                } */ // НЕ
                firstCrystal = crystals.Dequeue();
            crystals.Enqueue(0);
                // every morning - we add +5 to every crystal
                int count = crystals.Count;
                //for (int i = 0; i < count; i++)

                for (int i = 0; i < count; i++)
                {
                    int crystal = crystals.Dequeue();
                    crystals.Enqueue(crystal);
                }
            }
            FinalResult(substances, crystals, potions, currentPotions, madePotions);
        }
        public static void FinalResult(Stack<int> substances, Queue<int> crystals, Dictionary<int, string> potions, int currenPotion, HashSet<string> madePotions)
        {
            if (madePotions.Count == 5 && substances.Count > 0)
            {
                Console.WriteLine("Success! The alchemist has forged all potions!");
            }
            else
            {
                Console.WriteLine("The alchemist failed to complete his quest.");
            }
            int counter = 0;
            Console.Write("Crafted potions: ");
            foreach (string potion in madePotions)
            {
                if (counter < 4)
                {
                    Console.Write($"{potion}, ");
                    counter++;
                }
                else
                {
                    Console.Write($"{potion}");
                }
            }
            counter = 0;
            if (substances.Count > 0)
            {
                Console.WriteLine();
                Console.Write("Substances: ");
                foreach (int substance in substances)
                {
                    if (counter < substances.Count - 1)
                    {
                        Console.Write($"{substance}, ");
                        counter++;
                    }
                    else
                    {
                        Console.Write($"{substance}");
                    }
                }
            }
            counter = 0;
            if (crystals.Count > 0)
            {
                Console.WriteLine();
                Console.Write("Crystals: ");
                foreach (int crystal in crystals)
                {
                    if (counter < crystals.Count - 1)
                    {
                        Console.Write($"{crystal}, ");
                        counter++;
                    }
                    else
                    {
                        Console.Write($"{crystal}");
                    }
                }
            }
        }
    }
}
