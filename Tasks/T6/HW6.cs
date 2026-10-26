using System;
using System.Collections.Generic;
using System.ComponentModel.Design;


namespace CS_SoftServeTasks.Tasks
{

    public abstract class Shape : IComparable<Shape>
    {
        public string Name { get; protected set; }

        protected Shape(string name) => Name = name;

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public int CompareTo(Shape? other)
        {
            if (other is null) return 1;

            return this.GetArea().CompareTo(other.GetArea());
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Circle : Shape
    {

        public double Radius { get; private set; }

        public Circle(double radius, string name = "Circle"): base(name)
        {
            Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return base.ToString() + $" Radius: {Radius}";
        }
    }

    public class Square : Shape
    {

        public double Side { get; private set; }

        public Square(double side, string name = "Square") : base(name)
        {
            Side = side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return Side * 4;
        }

        public override string ToString()
        {
            return base.ToString() + $" Side: {Side}";
        }
    }

    internal class HW6
    {
        public static readonly List<string> KNOWN_SHAPES = new()
        { 
            "Square", 
            "Circle" 
        };

        public static Shape GetShapeInput()
        {

            double dimentionSize = 0;
            string name = "";
            bool hasShape = false;

            do
            {
                name = Funcs.MyFuncs.GetStringInput("Enter shape name");
                Funcs.MyFuncs.GetDoubleInput(ref dimentionSize, "Enter size of a shape");

                if (KNOWN_SHAPES.Contains(name))
                {
                    hasShape = true;
                }
                else
                {
                    Console.WriteLine("No such shape on the list");
                    Console.ReadLine();
                }
            }
            while (!hasShape);

            if(name == "Circle")
            {
                return new Circle(dimentionSize);
                
            }
            else if(name == "Square")
            {
                return new Square(dimentionSize);
            }
            else
            {
                return null!;
            }   
        }

        public static void RunTask()
        {
            List<Shape> shapes = new List<Shape>();

            int numberOfShapes = 4;

            for(int i = 1; i <= numberOfShapes; i++)
            {
                var shp = GetShapeInput();

                if (shp is not null)
                {
                    shapes.Add(shp);
                }
            }

            //sort by area
            shapes.Sort();

            foreach(var shape in shapes)
            {
                Console.WriteLine(shape + $" => Area = {shape.GetArea()}");
            }
        }
    }
}
