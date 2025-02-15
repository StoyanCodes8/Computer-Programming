using System;
using System.Collections.Generic;
using System.Linq;

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

            while (currentPotions < requiredPotions && substances.Count > 0)
            {
                int firstSubstance = substances.Peek();
                int firstCrystal = crystals.Peek();
                int combinedPower = firstSubstance + firstCrystal;

                // Try to craft the potion with exact match
                if (potions.ContainsKey(combinedPower))
                {
                    string potion = potions[combinedPower];
                    if (!madePotions.Contains(potion))
                    {
                        madePotions.Add(potion);
                        currentPotions++;
                    }
                }
                else
                {
                    // No exact match found, try to craft a potion with the closest smaller energy
                    foreach (var key in potions.Keys.OrderBy(k => k).Where(k => k < combinedPower))
                    {
                        string potion = potions[key];
                        if (!madePotions.Contains(potion))
                        {
                            madePotions.Add(potion);
                            currentPotions++;
                            break;
                        }
                    }
                }

                if (currentPotions == requiredPotions) break;

                // Remove used substance and crystal
                substances.Pop();
                crystals.Dequeue();

                // Reset the crystal and add +5 energy to all remaining crystals
                crystals.Enqueue(0);

                // Restore energy to all crystals
                int count = crystals.Count;
                for (int i = 0; i < count; i++)
                {
                    int crystal = crystals.Dequeue();
                    crystals.Enqueue(crystal + 5);
                }
            }

            FinalResult(substances, crystals, potions, currentPotions, madePotions);
        }

        public static void FinalResult(Stack<int> substances, Queue<int> crystals, Dictionary<int, string> potions, int currentPotions, HashSet<string> madePotions)
        {
            if (madePotions.Count == 5 && substances.Count > 0)
            {
                Console.WriteLine("Success! The alchemist has forged all potions!");
            }
            else
            {
                Console.WriteLine("The alchemist failed to complete his quest.");
            }

            if (madePotions.Count > 0)
            {
                Console.Write("Crafted potions: ");
                Console.WriteLine(string.Join(", ", madePotions));
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (crystals.Count > 0)
            {
                Console.WriteLine($"Crystals: {string.Join(", ", crystals)}");
            }
        }
    }
}
