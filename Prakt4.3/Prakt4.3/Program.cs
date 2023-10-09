using System;
using System.Collections.Generic;

// Интерфейс "Студент"
public interface IStudent
{
    double GetAverageGrade();
    int GetCourse();
    string GetFullName();
}

// Класс, представляющий студента
public class Student : IStudent
{
    private string firstName;
    private string lastName;
    private int course;
    private List<double> grades;

    public Student(string firstName, string lastName, int course)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.course = course;
        this.grades = new List<double>();
    }

    public void AddGrade(double grade)
    {
        grades.Add(grade);
    }

    public double GetAverageGrade()
    {
        if (grades.Count == 0)
        {
            return 0.0;
        }
        double sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return sum / grades.Count;
    }

    public int GetCourse()
    {
        return course;
    }

    public string GetFullName()
    {
        return $"{firstName} {lastName}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IStudent> students = new List<IStudent>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Вывести информацию о студентах");
            Console.WriteLine("3. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите имя студента: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Введите фамилию студента: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Введите курс студента: ");
                    int course = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(firstName, lastName, course);

                    // Добавление оценок студента
                    Console.Write("Введите оценки студента через пробел: ");
                    string[] gradeStr = Console.ReadLine().Split(' ');
                    foreach (var grade in gradeStr)
                    {
                        if (double.TryParse(grade, out double parsedGrade))
                        {
                            student.AddGrade(parsedGrade);
                        }
                    }

                    students.Add(student);
                    break;

                case 2:
                    Console.WriteLine("Информация о студентах:");
                    foreach (var s in students)
                    {
                        Console.WriteLine($"Имя: {s.GetFullName()}, Курс: {s.GetCourse()}, Средний балл: {s.GetAverageGrade():F2}");
                    }
                    break;

                case 3:
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}