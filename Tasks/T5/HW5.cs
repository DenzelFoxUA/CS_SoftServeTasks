using System;
using System.Collections.Generic;
using System.Linq;

namespace CS_SoftServeTasks.Tasks
{
    public interface IDeveloper : IComparable<IDeveloper>
    {
        public string Tool { get; set; }

        public virtual void Create() { }
        public virtual void Destroy() { }

        int IComparable<IDeveloper>.CompareTo(IDeveloper? other)
        {
            if (other == null) { return 1; }

            return string.Compare(Tool, other.Tool, StringComparison.Ordinal);
        }

    }

    public class Programmer : IDeveloper
    {
        public string Language { get; set; }
        public string Tool { get; set; }

        public Programmer()
        {
            Tool = string.Empty;
            Language = string.Empty;
        }

        public Programmer(string tool, string language)
        {
            Tool = tool;
            Language = language;
        }

        public void Create()
        {
            Console.WriteLine("Programmer created");
        }

        public void Destroy()
        {
            Console.WriteLine("Programmer destroyed");
        }
    }

    public class Builder : IDeveloper
    {
        private string tool;

        public string Tool
        {
            get { return tool; }
            set { tool = value; }
        }

        public Builder()
        {
            tool = string.Empty;
        }

        public Builder(string _tool)
        {
            tool = _tool;
        }

        public void Create()
        {
            Console.WriteLine("Builder created");
        }

        public void Destroy()
        {
            Console.WriteLine("Builder destroyed");
        }
    }

    public class TeamWork
    {
        public static void SortTeamMembers(IDeveloper[] developers)
        {
            Array.Sort(developers);
        }
    }


    public static class HomeWork5
    {
        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for(int i = 2; i <= number / i; i++)
            {
                if(number % i == 0)
                    return false;
            }

            return true;
        }


        public static void RunTask()
        {
            IDeveloper[] members =
            {
                new Programmer("Visual Studio", "C#"),
                new Builder("Hammer"),
                new Programmer("Rider", "C++")
            };

            TeamWork.SortTeamMembers(members);

            foreach (var member in members)
                Console.WriteLine(member.Tool);
        }

        public static void RunTask2()
        {
            List<int> numbers = new List<int>() { 1, 7, 8, 9, 12, 19, 17, 22, 100, 3 };

            var result = numbers.Where(a => IsPrime(a)).ToList();

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }


        public static void RunTask3()
        {
            Dictionary<uint, string> persons = new Dictionary<uint, string>()
            {
                { 0,"not found" }
            };
            int numOfPersons = 2;

            for(int i = 1; i <= numOfPersons; ++i)
            {
                uint id = 0;
                
                Funcs.MyFuncs.GetUnsignedIntegerInput(ref id, "Enter ID of a person");
                string name = Funcs.MyFuncs.GetStringInput("Enter person's name");

                if (!persons.ContainsKey(id))
                {
                    persons.Add(id, name);

                }   
                else
                {
                    Console.WriteLine("ID already taken");
                    Console.ReadLine();
                }

            }

            uint idSearch = 0;

            Funcs.MyFuncs.GetUnsignedIntegerInput(ref idSearch, "Enter Id to search");

            bool isFound = persons.ContainsKey(idSearch);

            if(isFound)
            {
                Console.WriteLine($"ID: {idSearch}, {persons[idSearch]}");
            }    
            else
            {
                Console.WriteLine("NOT FOUND!");
            }

            Console.ReadLine();

        }
    }
}