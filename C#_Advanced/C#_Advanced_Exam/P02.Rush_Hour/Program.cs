using System;
using System.Collections.Generic;
namespace P02.Rush_Hour;
public class Program
{
    public static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None);
        int n = int.Parse(dimensions[0]);
        int m = int.Parse(dimensions[1]);

        char[][] grid = new char[n][];
        (int x, int y) initialPos = (-1, -1);
        (int x, int y) deliveryPos = (-1, -1);

        for (int i = 0; i < n; i++)
        {
            grid[i] = Console.ReadLine().ToCharArray();
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 'V')
                {
                    initialPos = (i, j);
                }
                else if (grid[i][j] == 'D')
                {
                    deliveryPos = (i, j);
                }
            }
        }

        (int x, int y) currentPos = initialPos;
        int trafficJams = 0;
        bool deliveryCompleted = false;
        bool commandsFinished = false;
        List<string> commands = new List<string>();

        string line;
        while ((line = Console.ReadLine()) != null)
        {
            if (!string.IsNullOrWhiteSpace(line))
                commands.Add(line.Trim());
        }

        foreach (string cmd in commands)
        {
            int newX = currentPos.x;
            int newY = currentPos.y;

            switch (cmd)
            {
                case "left": newY--; break;
                case "right": newY++; break;
                case "up": newX--; break;
                case "down": newX++; break;
            }

            if (newX >= 0 && newX < n && newY >= 0 && newY < m)
            {
                if (grid[newX][newY] == 'X')
                {
                    trafficJams++;
                    grid[newX][newY] = '*';
                }
                else if (grid[newX][newY] == '*' || grid[newX][newY] == 'D')
                {
                    if (grid[newX][newY] == 'D')
                    {
                        grid[currentPos.x][currentPos.y] = '*';
                        grid[initialPos.x][initialPos.y] = 'V';
                        currentPos = initialPos;
                        deliveryCompleted = true;
                        goto CommandsLoopExit;
                    }
                    else
                    {
                        grid[currentPos.x][currentPos.y] = '*';
                        grid[newX][newY] = 'V';
                        currentPos = (newX, newY);
                    }
                }
            }

            if (trafficJams >= 3)
            {
                if (deliveryPos.x != -1)
                {
                    grid[deliveryPos.x][deliveryPos.y] = '*';
                }
                goto CommandsLoopExit;
            }
        }

    CommandsLoopExit:

        if (deliveryCompleted)
        {
            Console.WriteLine("Delivery completed!");
        }
        else if (trafficJams >= 3)
        {
            Console.WriteLine("Delivery failed, too many traffic jams!");
        }
        else
        {
            Console.WriteLine("Delivery failed! Did not reach the destination.");
        }

        // Print final grid
        foreach (char[] row in grid)
        {
            Console.WriteLine(new string(row));
        }
    }
}