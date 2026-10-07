using System;

namespace CS_SoftServeTasks.Tasks
{
    internal static class HW1
    {
        
        public static void RunTask1()
        {
            Console.Clear();
            int a = 0;

            string messageToShow = "Enter value that represents side of a Square";

            Funcs.GetInputFuncs.GetIntegerInput(ref a, messageToShow);

            Console.Clear();
            Console.WriteLine("Perimeter: " + a * 4);
            Console.WriteLine("Area: " + a * a);
            Console.ReadLine();
        }

        public static void RunTask2()
        {
            Console.Clear();

            string messageToShow = "What is your name?";
            string name = Funcs.GetInputFuncs.GetStringInput(messageToShow);

            int age = 0;
            messageToShow = "How old are you, " + name + "?";
            Funcs.GetInputFuncs.GetIntegerInput(ref age, messageToShow);

            Console.Clear();
            Console.Write($"Name: { name }, Age: { age }\n");
            Console.ReadLine();


        }

        public static void RunTask3()
        {
            Console.Clear();
            string messageToShow = "Enter radius of a CIRCLE";

            double r = 0;
            Funcs.GetInputFuncs.GetDoubleInput(ref r, messageToShow);

            Console.Clear();
            Console.Write($"Length: { 2 * r * Math.PI },\n" +
                $"Area: { Math.PI * Math.Pow(r, 2) },\n" +
                $"Volume: { Math.PI * 4/3 * Math.Pow(r, 3) };");

            Console.ReadLine();
        }
    }
}
