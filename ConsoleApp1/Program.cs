﻿// See https://aka.ms/new-console-template for more information

using System;
using ConsoleApp1.Day1;
using ConsoleApp1.Day2;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, World!");
        Day1 day1 = new Day1();
        day1.part1();
        day1.part2();

        Day2 day2 = new Day2();
        day2.Part1();
        day2.Part2();
    }
}