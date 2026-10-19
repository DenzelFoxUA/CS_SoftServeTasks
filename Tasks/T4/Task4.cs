using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CS_SoftServeTasks.Tasks
{
    public enum Companies
    { 
        Default = 0,
        Mercedess = 1,
        Audi = 2,
        VolksWagen,
        Chevrollet,
        Reno
    }


    internal class Car
    {
        protected Companies CompanyName;
        public string Name { protected set; get; }
        public Color CarColor { protected set; get; }
        public decimal Price { protected set; get; }

        public Car()
        {
            CompanyName = Companies.Default;
            Name = "Default";
            CarColor = Color.Black;
            Price = 0.0m;
        }

        public Car(Companies company, string name, Color color, decimal price)
        {
            CompanyName = company;
            Name = name;
            CarColor = color;
            Price = price;
        }

        public void Input()
        {
            string company = Funcs.MyFuncs.GetStringInput("Enter company name");

            if (Enum.TryParse<Companies>(company, true, out Companies _company)
                && Enum.IsDefined(_company))
            {
                CompanyName = _company;
            }
            else
            {
                CompanyName = Companies.Default;
                Console.WriteLine("No such company! Set to defaults");
                Console.ReadLine();
            }

            string nameInput = Funcs.MyFuncs.GetStringInput("Enter name of a Car");
            Name = nameInput;

            Color col = Color.Transparent;
            Funcs.MyFuncs.GetColorInput(ref col, "Enter color of a Car");
            CarColor = col;

            decimal price = 0.0m;
            Funcs.MyFuncs.GetDecimalInput(ref price, "Enter pirce $");
            Price = price;

        }

        public void Output()
        {
            Console.Clear();
            Console.WriteLine($"Company: {CompanyName}\n" +
                $"Model: {Name}");
            Console.Write($"Color: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(CarColor.Name + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"$Price: {Price}\n");

            Console.WriteLine("- Press enter -");
            Console.ReadLine();
        }
        //якщо + то ціна в гору, якщо - то вниз
        public void ChangePrice(int percents)
        {
            decimal difference = Price / 100 * percents;
            Price += difference;
        }

        public void ChangePaint(Color newValue)
        {
            CarColor = newValue;
        }

        //overriding

        public override string ToString()
        {
            return $"Company: {CompanyName}\n" +
                $"Model: {Name} \n" +
                $"Color: {CarColor.Name} \n" +
                $"Price: {Price}\n";
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is not Car other)
                return false;

            return Name == other.Name &&
                CompanyName == other.CompanyName &&
                CarColor == other.CarColor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, CompanyName,CarColor);
        }

        public static bool operator == (Car one, Car other)
        {
            return one.CompanyName == other.CompanyName &&
                one.Name == other.Name &&
                one.CarColor == other.CarColor;
        }

        public static bool operator != (Car one, Car other)
        {
            return !(one == other);
        }
    }

    internal class Task4
    {
        public static void RunTask1()
        {
            Car car = new();
            car.Input();
            car.Output();

            car.ChangePrice(-10);
            car.ChangePaint(Color.White);
            car.Output();

            Car car2 = new(Companies.Mercedess, "SL200", Color.Red, 45000.0m);
            Car car3 = new(Companies.Mercedess, "SL200", Color.Red, 45000.0m);
            Car car4 = new(Companies.VolksWagen, "T6", Color.Black, 25000.0m);

            if (car4 == car3)
            {
                Console.WriteLine(car4.ToString() + " && \n" + car3.ToString() + " are same.");
            }
            else
            {
                Console.WriteLine("No cars is different");
            }
        }
    }
}
