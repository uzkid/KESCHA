using System;

public class Car
{
    private string brand;
    private string model;
    private int year;
    private decimal price;
    private decimal speed;

    public Car(string brand, string model, int year, decimal price, decimal speed)
    {
        this.brand = brand;
        this.model = model;
        this.year = year;
        this.price = price;
        this.speed = speed;
    }


    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public decimal Price
    {
        get { return price; }
        set { price = value; }
    }

    public decimal Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public string GetCarInfo()
    {
        return $"Brand: {brand}, Model: {model}, Year: {year}, Price: {price:C}, Speed: {speed} km/h";
    }

    public decimal CalculateDepreciation(int years)
    {
        decimal depreciation = price;
        for (int i = 0; i < years; i++)
        {
            depreciation -= depreciation * 0.10m;
        }
        return depreciation;
    }
}

public class Program
{
    public static void Main()
    {
        Car myCar = new Car("Toyota", "Corolla", 2020, 20000m, 180);

        myCar.Price = 22000m; 

        Console.WriteLine(myCar.GetCarInfo());

        Console.WriteLine("Price after 1 year: " + myCar.CalculateDepreciation(1).ToString("C"));
        Console.WriteLine("Price after 3 years: " + myCar.CalculateDepreciation(3).ToString("C"));
        Console.WriteLine("Price after 5 years: " + myCar.CalculateDepreciation(5).ToString("C"));
    }
}
