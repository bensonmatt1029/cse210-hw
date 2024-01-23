using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        var cars = new List<Car>();

        var count = 23;
        var car = new Car();
        car.make = "Honda";
        car.model = "Civic";
        car.gallons = 10;
        car.milesPerGallon = 30;
        
        var owner = new Owner();
        owner.name = "Bob";
        owner.phone = "333-3333";

        count = 45;
        car = new Car();
        car.make = "Ford";
        car.model = "F-150";
        car.gallons = 30;
        car.milesPerGallon = 5;

        owner = new Owner();
        owner.name = "Sue";
        owner.phone = "444-4444";
        car.owner = owner;

        cars.Add(car);

        foreach (var c in cars)
        {
            c.Display();
            int range = c.TotalRange();
        }

    }
}

public class Car 
{
    public string make;
    public string model;
    public int gallons;
    public int milesPerGallon;
    public Owner owner;

    public Car(string make, string model, int gallons, int milesPerGallon, Owner owner)
    {
        this.make = make;
        this.model = model;
        this.gallons = gallons;
        this.milesPerGallon = milesPerGallon;
        this.owner = owner;

    }

    public int TotalRange()
    {
        return gallons * milesPerGallon;
    }

    public void Display()
    {
        System.Console.WriteLine($"{make} {model} {owner.name}: Range = {TotalRange()}");
    }
}

public class Owner 
{
    public string name;
    public string phone;

}