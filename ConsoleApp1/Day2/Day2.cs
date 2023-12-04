using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Day2
{
    public class Day2
    {
        private List<string> ReadInputFile()
        {
            // return File.ReadAllLines("/Users/Adil/Desktop/projects/adventOfCode/AOC/ConsoleApp1/Day2/TestInput.txt").ToList();
            return File.ReadAllLines("/Users/Adil/Desktop/projects/adventOfCode/AOC/ConsoleApp1/Day2/Input.txt")
                .ToList();
        }

        // Initialize the capacity of the bag for each color
        Dictionary<string, int> bagCapacity = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        public void Part1()
        {
            int gameResults = 0;
            List<string> txtInput = ReadInputFile();

            foreach (var input in txtInput)
            {
                var gameData = ParseGameData(input);
                if (IsGamePossible(gameData))
                {
                    gameResults += ExtractGameNumber(gameData.GameName);
                }
            }

            Console.WriteLine($"Result Day1 Part 1: {gameResults}");
        }

        public void Part2()
        {
            List<string> txtInput = ReadInputFile();
            int part2Result = 0;

            foreach (var input in txtInput)
            {
                var gameData = ParseGameData(input);
                int res = 1;
                foreach (var data in gameData.MaximumColors)
                {
                    res = res * data.Value;
                }

                part2Result += res;
            }


            Console.WriteLine($"Result Day2 Part2: {part2Result}");
        }

        private (string GameName, Dictionary<string, int> MaximumColors) ParseGameData(string input)
        {
            string[] parts = input.Split(':');
            string gameName = parts[0];

            string[] colorCounts = Regex.Split(parts[1], ";|,");

            Dictionary<string, int> maximumColors = InitializeColorDictionary();

            foreach (var colorCount in colorCounts)
            {
                UpdateMaximumColors(colorCount.Trim(), maximumColors);
            }

            return (GameName: gameName, MaximumColors: maximumColors);
        }

        private Dictionary<string, int> InitializeColorDictionary()
        {
            return new Dictionary<string, int>
            {
                { "red", 0 },
                { "green", 0 },
                { "blue", 0 }
            };
        }

        private void UpdateMaximumColors(string colorCount, Dictionary<string, int> maximumColors)
        {
            var parts = colorCount.Split(' ');
            // Assuming parts is an array resulting from splitting a color count string like "3 blue"
            if (parts.Length == 2)
            {
                // Try to parse the first part as an integer 
                bool isNumber = int.TryParse(parts[0], out int cubeCount);

                if (isNumber)
                {
                    // The second part of the array should be the color of the cubes
                    string cubeColor = parts[1];

                    // Check if this draw has more cubes of this color than any previous draw
                    int currentMaxForColor = maximumColors[cubeColor];
                    int newMaxForColor = Math.Max(currentMaxForColor, cubeCount);

                    // Update the maximum count for this color
                    maximumColors[cubeColor] = newMaxForColor;
                }
            }
        }

        private bool IsGamePossible((string GameName, Dictionary<string, int> MaximumColors) gameData)
        {
            // Iterate through each color in the game data
            foreach (var colorEntry in gameData.MaximumColors)
            {
                string color = colorEntry.Key;
                int maxColorCountInGame = colorEntry.Value;

                // Retrieve the bag's capacity for this color
                int bagCapacityForColor = bagCapacity[color];

                // Check if the game's maximum color count exceeds the bag's capacity
                if (maxColorCountInGame > bagCapacityForColor)
                {
                    // If any color count exceeds the capacity, the game is not possible
                    return false;
                }
            }

            return true;
        }


        private int ExtractGameNumber(string gameName)
        {
            Match match = Regex.Match(gameName, @"\d+");
            if (match.Success)
            {
                return int.Parse(match.Value);
            }

            return 0;
        }
    }
}