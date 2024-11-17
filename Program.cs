using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Choose a program:");
        Console.WriteLine("1. Calculate the area and circumference of a circle");
        Console.WriteLine("2. Currency converter (USD to local currency)");
        Console.WriteLine("3. Calculate how many days you've lived");
        Console.Write("Enter the program number: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            Console.Write("Enter the radius: ");
            if (double.TryParse(Console.ReadLine(), out double radius))
            {
                double area = Math.PI * Math.Pow(radius, 2);
                double circumference = 2 * Math.PI * radius;

                Console.WriteLine($"Area: {area}, Circumference: {circumference}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        else if (choice == "2")
        {
            Console.Write("Exchange rate: 1 USD = 12400. How many dollars do you have? ");
            if (decimal.TryParse(Console.ReadLine(), out decimal dollars))
            {
                decimal localMoney = dollars * 12400;
                Console.WriteLine($"You will have {localMoney} in local currency.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        else if (choice == "3")
        {
            Console.Write("Enter your birth year: ");
            if (int.TryParse(Console.ReadLine(), out int birthYear))
            {
                int currentYear = DateTime.Now.Year;
                int yearsLived = currentYear - birthYear;
                int daysLived = yearsLived * 365;

                Console.WriteLine($"You have lived approximately {daysLived} days.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }
        else
        {
            Console.WriteLine("Invalid program choice.");
        }
    }
}
