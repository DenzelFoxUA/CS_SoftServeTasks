
using CS_SoftServeTasks.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;


namespace CS_SoftServeTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new();

            using (var str = new StreamReader("phones.txt"))
            using (var wrt = new StreamWriter("onlyPhones.txt"))
            {
                int numOfLines = 9;

                while (numOfLines > 0 && !str.EndOfStream)
                {
                    string? line = str.ReadLine();

                    if (line is null)
                        break;

                    string[] pair = line.Split(" - ", 2);

                    if (pair.Length != 2)
                        continue;

                    string name = pair[0].Trim();
                    string phone = pair[1].Trim();

                    phoneBook.Add(name, phone);
                    wrt.WriteLine(phone);

                    numOfLines--;
                }
            }

            using (var str = new StreamReader("names.txt"))
            {
                string? name;

                while ((name = str.ReadLine()) != null)
                {
                    name = name.Trim();

                    if (phoneBook.TryGetValue(name, out string? phone))
                    {
                        Console.WriteLine(
                            $"The phone number of {name} is: {phone}");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Name {name} was not found in phone book.");
                    }
                }
            }

            using (var wrt = new StreamWriter("newPhones.txt"))
            {
                foreach (var pair in phoneBook)
                {
                    string phone = pair.Value;

                    if (phone.Length == 11 &&
                        phone.StartsWith("80") &&
                        phone.All(char.IsDigit))
                    {
                        phone = "+3" + phone;
                    }

                    wrt.WriteLine(phone);
                    
                }
            }
        }
    }
}
