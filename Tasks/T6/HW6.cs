using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;


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

    public static class ShapeFactory
    {
        private static readonly Dictionary<string, Func<double, Shape>> Factories = new()
        {
            ["circle"] = size => new Circle(size),
            ["square"] = size => new Square(size)
        };

        public static Shape? GetShape(string name, double size)
        {
            var searcName = name.Trim().ToLowerInvariant();

            if (Factories.TryGetValue(searcName, out var shape))
                return shape(size);
            else
                return null;
        }

    }

    internal class HW6
    {

        public static Shape GetShapeInput()
        {
            do
            {
                double dimentionSize = 0;
                string name = Funcs.MyFuncs.GetStringInput("Enter shape name");
                Funcs.MyFuncs.GetDoubleInput(ref dimentionSize, "Enter size of a shape");

                var shape = ShapeFactory.GetShape(name, dimentionSize);

                if (shape is null)
                {
                    Console.WriteLine("No such shape on the list");
                    Console.ReadLine();
                }
                else
                {
                    return shape;
                }
            }
            while (true);
        }


        public static void RunTask()
        {
            List<Shape> shapes = new List<Shape>();

            //manual add
            //shapes.Add(new Circle(12));
            //shapes.Add(new Circle(5));
            //shapes.Add(new Square(12));
            //shapes.Add(new Square(17));

            //user input
            int numberOfShapes = 2;

            for (int i = 1; i <= numberOfShapes; i++)
            {
                var shp = GetShapeInput();

                if (shp is not null)
                {
                    shapes.Add(shp);
                }
            }

            //print all
            Console.WriteLine("--- Shapes: ---");
            foreach(var shape in shapes)
            {
                Console.WriteLine(shape);
            }

            //sort by perimeter
            shapes.Sort((a, b) =>
                a.GetPerimeter().CompareTo(b.GetPerimeter()));

            var maxPerimeterShape = shapes.LastOrDefault();
            Console.WriteLine("--- Max Perimeter shape: ---");
            Console.WriteLine(maxPerimeterShape + 
                $" => Perimeter = { maxPerimeterShape!.GetPerimeter() }");

            //sort by area
            shapes.Sort();
            Console.WriteLine("--- Shapes sorted by Area: ---");
            foreach (var shape in shapes)
            {
                Console.WriteLine(shape + $" => Area = { shape.GetArea() }");
            }
        }
    }
}
