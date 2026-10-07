using System;

namespace CS_SoftServeTasks.Tasks.Funcs
{
    public static class GetInputFuncs
    {
        public static string GetStringInput(string message = "")
        {
            bool isCorrect = false;
            string result = "";
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                result = Console.ReadLine();

                if (result == "")
                {
                    Console.WriteLine("ERR::Empty string is not allowed");
                    Console.ReadLine();
                }
                else
                {
                    isCorrect = true;
                }

            }
            while (!isCorrect);

            return result;
        }

        public static void GetIntegerInput(ref int source, string message = "")
        {
            bool isInputCorrect = false;

            do
            {
                Console.Clear();
                Console.WriteLine(message);
                Console.Write("Value: ");
                string input = Console.ReadLine();
                isInputCorrect = int.TryParse(input, out source);

                if (!isInputCorrect)
                {
                    Console.WriteLine("Error::Wrong input. Press enter.");
                    Console.ReadLine();
                }

            }
            while (!isInputCorrect);
        }

        public static void GetDoubleInput(ref double source, string message = "")
        {
            bool isInputCorrect = false;

            do
            {
                Console.Clear();
                Console.WriteLine(message);
                Console.Write("Value: ");
                string input = Console.ReadLine();
                isInputCorrect = double.TryParse(input, out source);

                if (!isInputCorrect)
                {
                    Console.WriteLine("Error::Wrong input. Press enter.");
                    Console.ReadLine();
                }

            }
            while (!isInputCorrect);
        }
    }
}
