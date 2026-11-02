using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_SoftServeTasks
{
    public static class Task9
    {
        struct Point
        {
            public int x, y;
            public override string ToString()
            {
                return $"({x},{y})";
            }

            public Point()
            {
                x = 0;
                y = 0;
            }

            public Point(int _x, int _y)
            {
                x = _x;
                y = _y;
            }

            public double DistanceTo(Point other)
            {
                return Math.Sqrt(Math.Pow((x - other.x), 2) + Math.Pow((y - other.y), 2));
            }

            public double DistanceToOrigin()
            {
                return DistanceTo(new(0, 0));
            }
        }

        class Triangle
        {
            private Point vertex1, vertex2, vertex3;
            private double perimeter;
            private double area;
            private double L1, L2, L3;

            public Point CloseToOrigin { get; private set; }

            public Triangle()
            {
                vertex1 = new();
                vertex2 = new();
                vertex3 = new();

                L1 = vertex1.DistanceTo(vertex2);
                L2 = vertex2.DistanceTo(vertex3);
                L3 = vertex3.DistanceTo(vertex1);

                perimeter = Perimeter();
                area = Area();
                CloseToOrigin = ClosestVertexToOrigin();
            }

            public Triangle(Point one, Point two, Point three)
            {
                vertex1 = one;
                vertex2 = two;
                vertex3 = three;

                L1 = vertex1.DistanceTo(vertex2);
                L2 = vertex2.DistanceTo(vertex3);
                L3 = vertex3.DistanceTo(vertex1);

                perimeter = Perimeter();
                area = Area();
                CloseToOrigin = ClosestVertexToOrigin();
            }

            public double Perimeter()
            {
                return L1 + L2 + L3;
            }

            public double Area()
            {
                double halfP = (double)Perimeter() / 2.0d;
                return Math.Sqrt((halfP * (halfP - L1) * (halfP - L2) * (halfP - L3)));
            }

            public void Print()
            {
                Console.WriteLine($"Triangle verticles: {vertex1.ToString()}, {vertex2.ToString()}, {vertex3.ToString()}");
                Console.WriteLine($"Perimeter: {perimeter}");
                Console.WriteLine($"Area: {area}");
            }

            public Point ClosestVertexToOrigin()
            {
                double a = vertex1.DistanceToOrigin(),
                b = vertex2.DistanceToOrigin(),
                c = vertex3.DistanceToOrigin();

                double min = Math.Min(a, Math.Min(b, c));

                return min == a ? vertex1 : min == b ? vertex2 : vertex3;
            }


        }

        class ShapeProblem
        {
            public static void Main()
            {
                List<Triangle> triangles = new()
                {
                    new Triangle(new Point(0,0), new Point(1,0), new Point(0,1)),
                    new Triangle(new Point(0,0), new Point(2,0), new Point(1,2)),
                    new Triangle(new Point(1,1), new Point(4,1), new Point(1,3))
                };


                foreach (var tri in triangles)
                {
                    tri.Print();

                }


                int min = 0;
                Triangle resTriangle = triangles[min];


                for (int i = 1; i < triangles.Count; i++)
                {
                    if (triangles[i].CloseToOrigin.DistanceToOrigin() < resTriangle.CloseToOrigin.DistanceToOrigin())
                    {
                        min = i;
                        resTriangle = triangles[i];
                    }
                }

                resTriangle.Print();

            }

        }

    }
}
