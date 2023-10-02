using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Shape
    {
        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    class Triangle : Shape
    {
        public double BaseLength { get; set; }
        public double Height { get; set; }

        public Triangle(double baseLength, double height)
        {
            BaseLength = baseLength;
            Height = height;
        }

        public override double CalculateArea()
        {
            return 0.5 * BaseLength * Height;
        }
    }

    class ShapeChoice
    {
        delegate double CalculateAreaDelegate();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите фигуру для вычисления площади: ");
                Console.WriteLine("1. Круг");
                Console.WriteLine("2. Прямоугольник");
                Console.WriteLine("3. Треугольник");
                Console.WriteLine("4. Выйти из программы");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 4)
                {
                    break;
                }

                Shape shape = null;
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите радиус круга: ");
                        double radius = double.Parse(Console.ReadLine());
                        shape = new Circle(radius);
                        break;
                    case 2:
                        Console.Write("Введите ширину прямоугольника: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту прямоугольника: ");
                        double height = double.Parse(Console.ReadLine());
                        shape = new Rectangle(width, height);
                        break;
                    case 3:
                        Console.Write("Введите длину основания треугольника: ");
                        double baseLength = double.Parse(Console.ReadLine());
                        Console.Write("Введите высоту треугольника: ");
                        double triangleHeight = double.Parse(Console.ReadLine());
                        shape = new Triangle(baseLength, triangleHeight);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        continue;
                }

                CalculateAreaDelegate shapeDelegate = shape.CalculateArea;
                Console.WriteLine($"Площадь выбранной фигуры: {shapeDelegate()}");
                Console.ReadLine();
            }
        }
    }
}