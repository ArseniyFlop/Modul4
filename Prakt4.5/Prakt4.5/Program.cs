using System;
using System.Collections.Generic;

// Интерфейс для рисования различных фигур
public interface IRenderable
{
    void DrawLine(int x1, int y1, int x2, int y2);
    void DrawCircle(int x, int y, int radius);
    void DrawRectangle(int x, int y, int width, int height);
}

// Класс, представляющий холст для рисования
public class Canvas : IRenderable
{
    public void DrawLine(int x1, int y1, int x2, int y2)
    {
        Console.WriteLine($"Рисуем линию от ({x1}, {y1}) до ({x2}, {y2})");
    }

    public void DrawCircle(int x, int y, int radius)
    {
        Console.WriteLine($"Рисуем круг с центром в точке ({x}, {y}) и радиусом {radius}");
    }

    public void DrawRectangle(int x, int y, int width, int height)
    {
        Console.WriteLine($"Рисуем прямоугольник в точке ({x}, {y}) с шириной {width} и высотой {height}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Canvas canvas = new Canvas();

        while (true)
        {
            Console.WriteLine("Выберите фигуру для рисования:");
            Console.WriteLine("1. Линия");
            Console.WriteLine("2. Круг");
            Console.WriteLine("3. Прямоугольник");
            Console.WriteLine("4. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите координаты начальной и конечной точки (x1 y1 x2 y2): ");
                    string[] lineCoordinates = Console.ReadLine().Split(' ');
                    int x1 = Convert.ToInt32(lineCoordinates[0]);
                    int y1 = Convert.ToInt32(lineCoordinates[1]);
                    int x2 = Convert.ToInt32(lineCoordinates[2]);
                    int y2 = Convert.ToInt32(lineCoordinates[3]);

                    canvas.DrawLine(x1, y1, x2, y2);
                    break;

                case 2:
                    Console.Write("Введите координаты центра круга и радиус (x y radius): ");
                    string[] circleCoordinates = Console.ReadLine().Split(' ');
                    int centerX = Convert.ToInt32(circleCoordinates[0]);
                    int centerY = Convert.ToInt32(circleCoordinates[1]);
                    int radius = Convert.ToInt32(circleCoordinates[2]);

                    canvas.DrawCircle(centerX, centerY, radius);
                    break;

                case 3:
                    Console.Write("Введите координаты верхнего левого угла прямоугольника, ширину и высоту (x y width height): ");
                    string[] rectCoordinates = Console.ReadLine().Split(' ');
                    int rectX = Convert.ToInt32(rectCoordinates[0]);
                    int rectY = Convert.ToInt32(rectCoordinates[1]);
                    int rectWidth = Convert.ToInt32(rectCoordinates[2]);
                    int rectHeight = Convert.ToInt32(rectCoordinates[3]);

                    canvas.DrawRectangle(rectX, rectY, rectWidth, rectHeight);
                    break;

                case 4:
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}
