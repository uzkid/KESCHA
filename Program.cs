using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a task to run (1, 2, or 3):");
        Console.WriteLine("1 - Sum of odd numbers from 1 to 1000");
        Console.WriteLine("2 - Product of the largest and smallest array values");
        Console.WriteLine("3 - Calculate factorial of a number");
        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                SumOfOddNumbers();
                break;
            case "2":
                ArrayMinMaxProduct();
                break;
            case "3":
                FactorialCalculation();
                break;
            default:
                Console.WriteLine("Invalid choice. Please run the program again.");
                break;
        }
    }

    static void SumOfOddNumbers()
    {
        int sum = 0;
        int i = 1;
        while (i <= 1000)
        {
            if (i % 2 != 0)
            {
                sum += i;
            }
            i++;
        }
        Console.WriteLine($"The sum of odd numbers from 1 to 1000 is: {sum}");
    }

    static void ArrayMinMaxProduct()
    {
        Console.Write("Enter numbers separated by commas (e.g., 3, 7, 1, 9): ");
        string input = Console.ReadLine();
        int[] numbers = Array.ConvertAll(input.Split(','), int.Parse);

        int min = numbers[0];
        int max = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
                min = numbers[i];
            if (numbers[i] > max)
                max = numbers[i];
        }

        int product = min * max;
        Console.WriteLine($"The product of the smallest ({min}) and largest ({max}) values is: {product}");
    }

    static void FactorialCalculation()
    {
        Console.Write("Enter an integer (x): ");
        int x = int.Parse(Console.ReadLine());
        long factorial = 1;

        for (int i = 1; i <= x; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"{x}! = {factorial}");
    }
}

