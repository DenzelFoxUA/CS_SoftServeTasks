using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CS_SoftServeTasks.Tasks
{
    internal static class Task2
    {
        public enum TestCaseStatus
        {
            Pass = 0,
            Fail,
            Blocked,
            WP,
            Unexecuted
        };

        public struct RGB
        {
            public byte red, 
                green, 
                blue;
        }

        public static void RunTask1()
        {
            int day = 0, 
                month = 0;

            Funcs.GetInputFuncs.GetIntegerInput(ref day, $"Enter day value");
            Funcs.GetInputFuncs.GetIntegerInput(ref month, "Enter month value");

            string canRepresent = (month >= 1 && month <= 12) && (day >= 1 && day <= 31) ? "True" 
                : "False";

            Console.WriteLine($"Values can represent day and month - { canRepresent }.");
            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        public static void RunTask2()
        {
            double num = 0;
            Funcs.GetInputFuncs.GetDoubleInput(ref num, "Enter double number");
            int sum = 0;
            int numbersCountNeeded = 2;

            int[] numbers = new int[numbersCountNeeded];

            int intPart = (int)Math.Truncate(num);
            decimal doublePart = (decimal)num - intPart;

            Console.Write($"You have entered: {num}\n Sum of: ");

            for (int i = 0; i < numbersCountNeeded; i++)
            {
                doublePart *= 10;
                numbers[i] = (int)Math.Truncate(doublePart);
                doublePart = doublePart % 1;
                sum += numbers[i];

                if (i != numbersCountNeeded - 1)
                    Console.Write(numbers[i].ToString() + " + ");
                else
                    Console.Write(numbers[i].ToString());
            }


            Console.WriteLine($" = { sum }");
            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        public static void RunTask3()
        {
            int hh = 0;

            Funcs.GetInputFuncs.GetIntegerInput(ref hh, "Enter hour of a day");

            if (hh >= 22 && hh < 24 || hh >= 0 && hh < 5)
                Console.WriteLine("Good night!");
            else if (hh >= 5 && hh < 12)
                Console.WriteLine("Good morning!");
            else if (hh >= 12 && hh < 17)
                Console.WriteLine("Good afternoon!");
            else if (hh >= 17 && hh < 22)
                Console.WriteLine("Good evening!");
            else
                Console.WriteLine($"You've entered wrong value - {hh}. 0 - 23 correct range");


            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        public static void RunTask4()
        {
            TestCaseStatus status = TestCaseStatus.Pass;

            Console.WriteLine($"Status: {status.ToString()}");
            Console.WriteLine("Press enter");
            Console.ReadLine();

        }

        public static void RunTask5()
        {
            RGB white;
            RGB black;

            white.blue = 255;
            white.green = 255;
            white.red = 255;

            black.red = 0;
            black.green = 0;
            black.blue = 0;
        }


    }
}
