using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)

        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < number; i++)
            {
                string[] input = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0].Trim();
                string[] colorClothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < colorClothes.Length; j++)
                {
                    string clothe = colorClothes[j].Trim();

                    if (wardrobe.ContainsKey(color) == false)
                    {
                        wardrobe.Add(color, new Dictionary<string, int>());
                    }

                    if (wardrobe[color].ContainsKey(clothe) == false)
                    {
                        wardrobe[color].Add(clothe, 0);
                    }

                    wardrobe[color][clothe]++;
                }
            }

            string[] search = Console.ReadLine().Split();
            string searchingColor = search[0];
            string searchingClothe = search[1];

            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var clothe in item.Value)
                {
                    if (searchingColor == item.Key && searchingClothe == clothe.Key)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }
    }
}
