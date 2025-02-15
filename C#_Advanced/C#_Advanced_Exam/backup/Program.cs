namespace backup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> potions = new()
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
            Stack<int> substances = new(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> crystals = new(Console.ReadLine().Split(", ").Select(int.Parse));
            AlchemyProcess(substances, crystals, potions);
        }

        public static void AlchemyProcess(Stack<int> substances, Queue<int> crystals, Dictionary<int, string> potions)
        {
            int requiredPotions = 5;
            int currentPotions = 0;
            List<string> madePotions = new();

            while (currentPotions < requiredPotions && substances.Count > 0)
            {
                int substance = substances.Pop();
                int crystal = crystals.Dequeue();
                int combinedPower = substance + crystal;

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
                    var possiblePotions = potions.Keys.Where(key => key < combinedPower).OrderByDescending(k => k);
                    if (possiblePotions.Any())
                    {
                        string potion = potions[possiblePotions.First()];
                        if (!madePotions.Contains(potion))
                        {
                            madePotions.Add(potion);
                            currentPotions++;
                        }
                    }
                    else if (substances.Count > 0)
                    {
                        int nextSubstance = substances.Pop();
                        substances.Push(nextSubstance * 2);
                    }
                }
                crystals.Enqueue(0);
                int count = crystals.Count;
                for (int i = 0; i < count; i++)
                {
                    int increasedCrystal = crystals.Dequeue() + 5;
                    crystals.Enqueue(increasedCrystal);
                }
            }

            FinalResult(substances, crystals, madePotions);
        }

        public static void FinalResult(Stack<int> substances, Queue<int> crystals, List<string> madePotions)
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
                Console.WriteLine($"Crafted potions: {string.Join(", ", madePotions)}");
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
