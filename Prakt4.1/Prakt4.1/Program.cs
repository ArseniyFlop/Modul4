using System;

// Интерфейс для фигур
public interface IFigure
{
    double CalculateArea();
    double CalculatePerimeter();
}

// Класс для круга
public class Circle : IFigure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

// Класс для прямоугольника
public class Rectangle : IFigure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}

// Класс для треугольника
public class Triangle : IFigure
{
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Side3 { get; set; }

    public Triangle(double side1, double side2, double side3)
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double CalculateArea()
    {
        // Используем формулу Герона для вычисления площади треугольника
        double s = (Side1 + Side2 + Side3) / 2;
        return Math.Sqrt(s * (s - Side1) * (s - Side2) * (s - Side3));
    }

    public double CalculatePerimeter()
    {
        return Side1 + Side2 + Side3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите тип фигуры:");
        Console.WriteLine("1. Круг");
        Console.WriteLine("2. Прямоугольник");
        Console.WriteLine("3. Треугольник");

        int choice = Convert.ToInt32(Console.ReadLine());

        IFigure figure = null;

        switch (choice)
        {
            case 1:
                Console.Write("Введите радиус круга: ");
                double radius = Convert.ToDouble(Console.ReadLine());
                figure = new Circle(radius);
                break;
            case 2:
                Console.Write("Введите ширину прямоугольника: ");
                double width = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите высоту прямоугольника: ");
                double height = Convert.ToDouble(Console.ReadLine());
                figure = new Rectangle(width, height);
                break;
            case 3:
                Console.Write("Введите длину первой стороны треугольника: ");
                double side1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину второй стороны треугольника: ");
                double side2 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину третьей стороны треугольника: ");
                double side3 = Convert.ToDouble(Console.ReadLine());
                figure = new Triangle(side1, side2, side3);
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }

        if (figure != null)
        {
            Console.WriteLine($"Площадь фигуры: {figure.CalculateArea()}");
            Console.WriteLine($"Периметр фигуры: {figure.CalculatePerimeter()}");
        }

        Console.ReadKey();
    }
}
