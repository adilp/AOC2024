namespace ConsoleApp1.Day1;

using System;
using System.Collections.Generic;
using System.IO;

public class Day1
{
    public void part1()
    {
        List<string> list = ReadInputFile();
        int sum = calculate(list);

        Console.WriteLine($"Total: {sum}");
    }

    public void part2()
    {
        List<string> list = ReadInputFile();
        List<string> changedNumbers = new();

        for (int i = 0; i < list.Count; i++)
        {
            /*
             * Have to replace this with the word before and after because some overlap occurs
             *"twone" The "o" is shared
             * so this would become two2twoone1one
             */

            list[i] = list[i].Replace("one", "one1one");
            list[i] = list[i].Replace("two", "two2two");
            list[i] = list[i].Replace("three", "three3three");
            list[i] = list[i].Replace("four", "four4four");
            list[i] = list[i].Replace("five", "five5five");
            list[i] = list[i].Replace("six", "six6six");
            list[i] = list[i].Replace("seven", "seven7seven");
            list[i] = list[i].Replace("eight", "eight8eight");
            list[i] = list[i].Replace("nine", "nine9nine");
            changedNumbers.Add(list[i]);
        }

        int sum = calculate(list);

        Console.WriteLine($"Total: {sum}");
    }

    private int calculate(List<string> input)
    {
        int sum = 0;
        // Loop through the list
        foreach (var text in input)
        {
            char number1 = Char.MinValue;
            char number2 = Char.MinValue;

            //Loop throuh each letter in the word
            foreach (var letter in text)
            {
                //Find the first digit and set it
                if (number1 == Char.MinValue && Char.IsDigit(letter))
                {
                    number1 = letter;
                    break;
                }
            }

            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(text[i]))
                {
                    number2 = text[i];
                    break;
                }
            }

            char[] chars = { number1, number2 };
            string s = new string(chars);

            sum += int.Parse(s);
        }

        return sum;
    }


    private List<string> ReadInputFile()
    {
        return File.ReadAllLines("/Users/Adil/Desktop/projects/adventOfCode/AOC/ConsoleApp1/Day1/Input.txt").ToList();
    }
}