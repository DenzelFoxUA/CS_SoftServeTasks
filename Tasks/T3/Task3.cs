using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Transactions;

namespace CS_SoftServeTasks.Tasks
{
    public struct Drink
    {
        private string name = ""; 
        private decimal price = 0.0m;

        public Drink() { }
        public Drink(string _name, decimal _price)
        {
            name = _name;
            price = _price;
        }

        public string Name
        {
            get => name;
        }

        public override string ToString()
        {
            return $"{name}| Price: {price}";
        }

    }

    public class Task3
    {
        public static void RunTask1()
        {
            int numA = 0;
            int numB = 0;
            int counter = 0;
            Funcs.GetInputFuncs.GetIntegerInput(ref numA, "Enter frist num: ");
            Funcs.GetInputFuncs.GetIntegerInput(ref numB, "Enter second num: ");

            for (int i = numA; i <= numB; i++)
            {
                if (i % 3 == 0)
                    counter++;
            }

            Console.WriteLine(
                $"Numbers in range [{numA}|{numB}] can be devided by 3: {counter}"
                );
        }

        public static void RunTask2()
        {
            string uInput = Funcs.GetInputFuncs.GetStringInput("Enter a word or sentence: ");
            for (int i = 0; i < uInput.Length; i++)
            {
                if (i % 2 != 0 && uInput[i] != ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(uInput[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(uInput[i]);
                }
            }
            Console.WriteLine();

        }

        public static void RunTask3()
        {

            bool isCorrect = false;

            Drink[] drinks = {
                new("Water", 35.5m),
                new("Tea", 50.0m),
                new("Juice", 120.0m),
                new("Coffe", 110.5m)

            };

            do
            {
                Console.Clear();
                string uInput = Funcs.GetInputFuncs.GetStringInput("Enter name of a drink: ");

                foreach (var drink in drinks)
                {
                    if (drink.Name == uInput)
                    {
                        isCorrect = true;
                        Console.WriteLine(drink.ToString());
                        Console.ReadLine();
                        break;
                    }

                }

                if (!isCorrect)
                {
                    Console.WriteLine("Not found.");
                    Console.ReadLine();
                }

            }
            while (!isCorrect);
        }

        public static void RunTask4()
        {
            int uInput = 0;
            int sum = 0;
            int steps = 0;
            do
            {
                Funcs.GetInputFuncs.GetIntegerInput(ref uInput, "Enter any number");
                if(uInput > 0)
                {
                    sum += uInput;
                    steps++;
                }

            }
            while (uInput > 0);

            Console.WriteLine($"Average: {(double)sum / steps}");
        }

        public static void RunTask5()
        {
            int year = 0;

            Funcs.GetInputFuncs.GetIntegerInput(ref year, "Enter year value");

            Console.WriteLine(Funcs.MyBasicFunctions.IsLeapYear(year) ? "True" : "False");
        }
        
        public static void RunTask6()
        {
            int uInput = 0;

            Funcs.GetInputFuncs.GetIntegerInput(ref uInput, "Enter int number");

            int bufNum = uInput;

            int sum = 0;

            while (bufNum != 0)
            {
                int curr = bufNum % 10;
       
                Console.WriteLine($"{sum} += {curr}");
                sum += curr;
                bufNum /= 10;
            }

            Console.WriteLine($"Sum of all digits = {sum}");
            Console.ReadLine();

        }

        public static void RunTask7()
        {
            int uInput = 0;

            Funcs.GetInputFuncs.GetIntegerInput(ref uInput, "Enter int number");

            int bufNum = uInput;
            bool areOdd = true;

            while (bufNum != 0)
            {
                int curr = bufNum % 10;

                if(curr % 2 == 0)
                {
                    areOdd = false;
                    break;
                }

                bufNum /= 10;
            }

            if (areOdd)
                Console.WriteLine($"Digits are odd!");
            else
                Console.WriteLine($"There are even digits.");


            Console.ReadLine();

        }
    }
}
