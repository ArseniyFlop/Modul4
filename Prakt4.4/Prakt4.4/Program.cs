using System;
using System.Collections.Generic;

// Интерфейс "Книга"
public interface IBook
{
    bool IsAvailable { get; }
    void BorrowBook();
    void ReturnBook();
}

// Класс, представляющий книгу
public class Book : IBook
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public bool IsAvailable { get; private set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsAvailable = true;
    }

    public void BorrowBook()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"Книга \"{Title}\" автора {Author} успешно выдана.");
        }
        else
        {
            Console.WriteLine($"Книга \"{Title}\" автора {Author} недоступна.");
        }
    }

    public void ReturnBook()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
            Console.WriteLine($"Книга \"{Title}\" автора {Author} успешно возвращена.");
        }
        else
        {
            Console.WriteLine($"Книга \"{Title}\" автора {Author} уже доступна в библиотеке.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IBook> library = new List<IBook>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Проверить доступность книги");
            Console.WriteLine("3. Выдать книгу");
            Console.WriteLine("4. Вернуть книгу");
            Console.WriteLine("5. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите название книги: ");
                    string title = Console.ReadLine();

                    Console.Write("Введите автора книги: ");
                    string author = Console.ReadLine();

                    Book book = new Book(title, author);
                    library.Add(book);
                    break;

                case 2:
                    Console.Write("Введите название книги для проверки доступности: ");
                    string bookToCheck = Console.ReadLine();
                    bool found = false;

                    foreach (var item in library)
                    {
                        if (item is Book && ((Book)item).Title == bookToCheck)
                        {
                            found = true;
                            Console.WriteLine($"Книга \"{bookToCheck}\" доступна: {item.IsAvailable}");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"Книга \"{bookToCheck}\" не найдена.");
                    }
                    break;

                case 3:
                    Console.Write("Введите название книги для выдачи: ");
                    string bookToBorrow = Console.ReadLine();
                    bool borrowed = false;

                    foreach (var item in library)
                    {
                        if (item is Book && item.IsAvailable && ((Book)item).Title == bookToBorrow)
                        {
                            ((Book)item).BorrowBook();
                            borrowed = true;
                            break;
                        }
                    }

                    if (!borrowed)
                    {
                        Console.WriteLine($"Книга \"{bookToBorrow}\" не найдена или недоступна.");
                    }
                    break;

                case 4:
                    Console.Write("Введите название книги для возврата: ");
                    string bookToReturn = Console.ReadLine();
                    bool returned = false;

                    foreach (var item in library)
                    {
                        if (item is Book && !item.IsAvailable && ((Book)item).Title == bookToReturn)
                        {
                            ((Book)item).ReturnBook();
                            returned = true;
                            break;
                        }
                    }

                    if (!returned)
                    {
                        Console.WriteLine($"Книга \"{bookToReturn}\" не найдена или уже доступна в библиотеке.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}
