using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CS_SoftServeTasks.Tasks
{
    public interface IFly
    {
        public void Fly();
        public void Print();
    }

    public class Bird : IFly
    { 
        public string Name
        {
            get;
            protected set;
        }

        public bool CanFly
        {
            get;
            protected set;
        }

        public Bird()
        {
            Name = "default ctor";
            CanFly = true;
        }

        public Bird(string name, bool canFly = true)
        {
            Name = name;
            CanFly = canFly;
        }

        public void Fly()
        {
            if (CanFly)
                Console.WriteLine("Bird is flying");
            else
                Console.WriteLine("This bird can't fly");

        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Can Fly: {CanFly}");
        }

    }

    public class Airplane : IFly
    {
        public string Model
        {
            get;
            protected set;
        }

        public uint HighFly
        {
            get;
            protected set;
        }

        public Airplane()
        {
            Model = "default ctor";
            HighFly = 0;
        }

        public Airplane(string model, uint highFly)
        {
            Model = model;
            HighFly = highFly;
        }

        public void Fly()
        {
            Console.WriteLine($"Flying on heght: {HighFly}");
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Model}, Height: {HighFly}");
        }

    }

    internal class Task5
    {
        public static void RunTask1()
        {
            List<IFly> flyables = new List<IFly>()
            {
                new Bird("Eagle", true),
                new Bird("Penguin", false),
                new Airplane("Boeing", 17000),
                new Airplane("F16", 10000)
            };


            foreach(var flyObject in flyables)
            {
                flyObject.Print();
                flyObject.Fly();
            }    
        }

        public static void RunTask2()
        {
            Random rand = new Random();

            List<int> numbers = new List<int>();

            int sizeOfCollection = 10;

            for(int i = 0; i < sizeOfCollection; i++)
            {
                numbers.Add(rand.Next(-15, 30));
            }

            Funcs.MyBasicFunctions.PrintCollection(numbers);

            var indexOfMinusTen = numbers.FindIndex(x => x == -10);

            Console.WriteLine( $"Num -10 index: {indexOfMinusTen}");

            numbers.RemoveAll(num => num > 20);

            KeyValuePair<int, int> pair1 = new KeyValuePair<int, int>(2,-1);
            KeyValuePair<int, int> pair2 = new KeyValuePair<int, int>(5, -4);
            KeyValuePair<int, int> pair3 = new KeyValuePair<int, int>(8, -3);

            numbers.Insert(pair1.Key, pair1.Value);
            numbers.Insert(pair2.Key, pair2.Value);
            numbers.Insert(pair3.Key, pair3.Value);

            Funcs.MyBasicFunctions.PrintCollection(numbers);


        }
    }
}
