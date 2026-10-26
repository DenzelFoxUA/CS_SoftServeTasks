using System;
using System.Collections.Generic;

namespace CS_SoftServeTasks.Tasks
{
    public class WorkWithExceptions
    {
        public static void Div(int a, int b)
        {
            Console.WriteLine("A / B = " + a / b);
        }

        public static void Div(double a, double b)
        {
            throw new ArgumentException("ERR::Devision of two double values");
        }

        public static void StudentMain()
        {
            try
            {
                int a = 0;
                int b = 0;

                Funcs.MyFuncs.GetIntegerInput(ref a, "Enter integer numA");
                Funcs.MyFuncs.GetIntegerInput(ref b, "Enter integer numB");

                Div(a, b);
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, enter an integer value");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, enter an integer value");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by 0");
            }
        }

        public static void DivisionOfDoubles(double a, double b)
        {
            const double EPS = 0.0001d;

            if (b != 0 && 
                Math.Abs(a - Math.Round(a)) <= EPS &&
                Math.Abs(b - Math.Round(b)) <= EPS)
            {
                Console.WriteLine(a / b);
            }    
            else
                throw new ArithmeticException("ERR::Devision of two doubles!");
        }

        public static void ReadNumber(int start, int end)
        {
            do
            {
                int uInput = 0;
                Console.Clear();
                Funcs.MyFuncs.GetIntegerInput(ref uInput, $"Enter num in range [{start}-{end}]");

                if(uInput <= end && uInput >= start)
                {
                    Console.Clear();
                    Console.WriteLine($"You have entered -> {uInput}");
                    Console.ReadLine();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid argument::number out of range");
                }    

            }
            while (true);
        }

    }

    internal class Task7
    {
        public static void RunTask()
        {
            //WorkWithExceptions.StudentMain();

            //try
            //{
            //    double a = 12,
            //        b = 1.01;

            //    Console.Write($"Trying to {a}/{b} = ");
            //    WorkWithExceptions.DivisionOfDoubles(a, b);
            //}
            //catch(DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            try
            {
                WorkWithExceptions.ReadNumber(1, 10);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block executed!");
            }

        }
    }
}
