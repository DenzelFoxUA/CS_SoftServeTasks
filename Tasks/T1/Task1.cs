using System;
using System.Text.RegularExpressions;

namespace CS_SoftServeTasks.Tasks
{
    internal static class Task1
    {
        public static void RunTask1()
        {

            Console.Clear();
            int a = 0,
                b = 0;

            string message = "Enter integer number.";

            Funcs.GetInputFuncs.GetIntegerInput(ref a, message);
            Funcs.GetInputFuncs.GetIntegerInput(ref b, message);

            Console.WriteLine($"a+b = { a } + { b } = { a + b }\n" +
                $"a-b = { a } - { b } = { a - b }\n" +
                $"a*b = { a } * { b } = { a * b }");

            if(b != 0)
            {
                Console.WriteLine($"a/b = { a } / { b } = { a / b }");
            }
            else
            {
                Console.WriteLine("Division by 0 is not allowed.");
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }

        public static void RunTask2()
        {
            Console.Clear();
            string message = "How are you?";
            string input = Funcs.GetInputFuncs.GetStringInput(message);
            string answer = "You are " + Regex.Replace(input, @"^(?:(?:I am|I'm|Me\?)\s*)+", "");
            Console.WriteLine(answer + "\nPress enter");
            Console.ReadLine();
        }

        public static void RunTask3()
        {
            Console.Clear();
            int charsCount = 3;
            string message = "Enter 3 characters: ";
            char[] setOfChars = new char [charsCount];

            Console.WriteLine(message);

            for(int i = 0; i < charsCount; ++i)
            {
                Console.Write($"{ i+1 }-char: ");
                var ch = Console.ReadKey();
                setOfChars[i] = ch.KeyChar;
                Console.WriteLine();
            }

            Console.Write($"You have entered: ");

            for (int i = 0; i < charsCount; ++i)
            {
                Console.Write($"'{setOfChars[i]}'");

                if (i != charsCount - 1)
                    Console.Write(", ");

            }

            Console.WriteLine("");
            Console.ReadLine();
        }

        public static void RunTask4()
        {

            Console.Clear();
            int a = 0,
                b = 0;

            string message = "Enter integer number.";

            Funcs.GetInputFuncs.GetIntegerInput(ref a, message);
            Funcs.GetInputFuncs.GetIntegerInput(ref b, message);

            string comparisonResult = a > 0 && b > 0 ? "true" : "false";

            Console.WriteLine($"Are they both positive: { comparisonResult }" 
                + "\nPress enter");
            Console.ReadLine();
        }
    }
}
