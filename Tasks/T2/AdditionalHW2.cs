using System;
using System.Dynamic;

namespace CS_SoftServeTasks.Tasks
{
    public enum FullnessStates
    {
        Starving = 0,
        Hungry = 10,
        Satisfied = 50,
        Full = 99,
        Stuffed = 101

    }

    public enum Food
    { 
        Mouse = 20,
        Fish = 40,
        CatCannedFood = 50,
        RawMeat = 60
    }

    public class Cat
    {
        private uint currFullnessLevel = 0;
        private FullnessStates state = FullnessStates.Starving;

        private void UpdateState()
        {
            if (currFullnessLevel >= 100)
                state = FullnessStates.Stuffed;
            else if (currFullnessLevel >= 99)
                state = FullnessStates.Full;
            else if (currFullnessLevel >= 50)
                state = FullnessStates.Satisfied;
            else if (currFullnessLevel >= 10)
                state = FullnessStates.Hungry;
            else
                state = FullnessStates.Starving;
        }


        public Cat() { }

        public void EatSomeFood(Food food)
        {
            if(currFullnessLevel + (uint)food >= (uint)FullnessStates.Stuffed)
            {
                currFullnessLevel = (uint)FullnessStates.Stuffed;
                UpdateState();
                Console.WriteLine($"Sorry, pal! I can't eat anymore!");
                Console.ReadLine();
            }
            else
            {
                currFullnessLevel += (uint)food;
                UpdateState();
                Console.WriteLine($"Ill take that, ok... +{food.ToString()}");
                Console.ReadLine();
            }
            
        }

        public void ShowLevelOfFullness()
        {
            Console.WriteLine($"Fullness level: {currFullnessLevel.ToString()}\n" +
                $"State: {state.ToString()}");
        }
    
    }

    public struct Student
    {
        private string _lastName = "";
        private string _groupNumber = "";

        public Student() { }

        public Student(string lastName, string gruopNum)
        {
            _lastName = lastName;
            _groupNumber = gruopNum;
        }

        public string LastName { get => _lastName; }
        public string GrpoupNumber { get => _groupNumber; }

        public override string ToString()
        {
            return $"Last Name: {_lastName}, Group: {_groupNumber}";
        }

    }

    internal class AdditionalHW2
    {
        public static void FeedTheCatFunc()
        {
            Cat randomCat = new Cat();

            Console.Clear();

            randomCat.ShowLevelOfFullness();
            randomCat.EatSomeFood(Food.Mouse);
            randomCat.EatSomeFood(Food.Mouse);
            randomCat.ShowLevelOfFullness();
            randomCat.EatSomeFood(Food.Fish);
            randomCat.ShowLevelOfFullness();
            randomCat.EatSomeFood(Food.Fish);
            randomCat.ShowLevelOfFullness();
            randomCat.EatSomeFood(Food.Fish);
            randomCat.ShowLevelOfFullness();

        }

        public static void RunStudentsTask()
        {
            Console.Clear();

            string groupNum1 = "GR01";
            string groupNum2 = "GR02";

            int numOfStudents = 10;

            Student[] studsCollection = new Student[numOfStudents];

            studsCollection[0] = new Student("Johnson", groupNum2);
            studsCollection[2] = new Student("Shevchenko", groupNum2);
            studsCollection[4] = new Student("Rebrov", groupNum2);
            studsCollection[6] = new Student("Rodnyansky", groupNum2);
            studsCollection[8] = new Student("Tarasevic", groupNum2);
            studsCollection[1] = new Student("Klimchenko", groupNum1);
            studsCollection[3] = new Student("Karpin", groupNum1);
            studsCollection[5] = new Student("Samsonov", groupNum1);
            studsCollection[7] = new Student("Manushyan", groupNum1);
            studsCollection[9] = new Student("Liberman", groupNum1);

            char leterLastNameBeginsWith = 'R';
            string searchGroup = groupNum2;
            uint peopleFound = 0;

            for (int i = 0; i < numOfStudents; i++)
            {
                if(studsCollection[i].GrpoupNumber == searchGroup 
                    && studsCollection[i].LastName[0] == leterLastNameBeginsWith)
                {
                    ++peopleFound;
                    Console.WriteLine(studsCollection[i].ToString());
                }
                
            }

            if(peopleFound == 0)
            {
                Console.WriteLine("There are no students found.");
            }

            Console.WriteLine("Press enter");
            Console.ReadLine();
        }
    }
}
