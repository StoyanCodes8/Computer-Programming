using System;
using System.Collections.Generic;
using System.Linq;

namespace C__Advanced_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> potions = new Dictionary<int, string>
            {
                { 110, "Brew of Immortality" },
                { 100, "Essence of Resilience" },
                { 90, "Draught of Wisdom" },
                { 80, "Potion of Agility" },
                { 70, "Elixir of Strength" }
            };
            UserInput(potions);
        }

        public static void UserInput(Dictionary<int, string> potions)
        {
            Stack<int> substances = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).Reverse());
            Queue<int> crystals = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            AlchemyProcess(substances, crystals, potions);
        }

        public static void AlchemyProcess(Stack<int> substances, Queue<int> crystals, Dictionary<int, string> potions)
        {
            int requiredPotions = 5;
            HashSet<string> madePotions = new HashSet<string>();
            bool catalyzerUsed = false;

            while (substances.Count > 0 && madePotions.Count < requiredPotions)
            {
                int currentSubstance = substances.Pop();
                if (catalyzerUsed)
                {
                    currentSubstance *= 2;
                    catalyzerUsed = false;
                }

                if (crystals.Count == 0) break;
                int currentCrystal = crystals.Dequeue();
                int combinedPower = currentSubstance + currentCrystal;

                bool potionCrafted = false;
                if (potions.ContainsKey(combinedPower))
                {
                    string potion = potions[combinedPower];
                    if (madePotions.Add(potion))
                    {
                        potionCrafted = true;
                    }
                }
                else
                {
                    var validKeys = potions.Keys.Where(key => key < combinedPower).OrderByDescending(k => k);
                    foreach (int key in validKeys)
                    {
                        string potion = potions[key];
                        if (madePotions.Add(potion))
                        {
                            potionCrafted = true;
                            int leftover = combinedPower - key;
                            if (substances.Count > 0)
                            {
                                catalyzerUsed = true;
                            }
                            break;
                        }
                    }
                }

                crystals.Enqueue(currentCrystal + 5);

                if (!potionCrafted)
                {
                    catalyzerUsed = false;
                }

                if (madePotions.Count == requiredPotions)
                {
                    break;
                }
            }

            FinalResult(substances, crystals, madePotions);
        }

        public static void FinalResult(Stack<int> substances, Queue<int> crystals, HashSet<string> madePotions)
        {
            if (madePotions.Count == 5)
            {
                Console.WriteLine("Success! The alchemist has forged all potions!");
            }
            else
            {
                Console.WriteLine("The alchemist failed to complete his quest.");
            }

            if (madePotions.Count > 0)
            {
                Console.WriteLine("Crafted potions: " + string.Join(", ", madePotions));
            }

            if (substances.Count > 0)
            {
                Console.WriteLine("Substances: " + string.Join(", ", substances));
            }

            if (crystals.Count > 0)
            {
                Console.WriteLine("Crystals: " + string.Join(", ", crystals));
            }
        }
    }
}
