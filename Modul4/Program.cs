using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Интерфейс \"Фигура\" с методами для вычисления площади и периметра");
            Console.WriteLine("2. Интерфейс \"Товар\" с методами для определения стоимости и остатка товара на складе");
            Console.WriteLine("3. Интерфейс \"Студент\" с методами для определения среднего балла и получения информации о курсе");
            Console.WriteLine("4. Интерфейс \"Книга\" с методами для проверки доступности и выдачи книги");
            Console.WriteLine("5. Интерфейс \"Рисунок\" с методами для рисования линий, кругов и прямоугольников");
            Console.WriteLine("0. Выйти из программы");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали задачу 1.");
                    while (true)
                    {
                        Console.WriteLine("Выберите тип фигуры:");
                        Console.WriteLine("1. Круг");
                        Console.WriteLine("2. Прямоугольник");
                        Console.WriteLine("3. Треугольник");
                        Console.WriteLine("0. Выход");

                        int choice1 = Convert.ToInt32(Console.ReadLine());

                        IFigure figure = null;

                        switch (choice1)
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
                            case 0:
                                Console.WriteLine("Программа завершена.");
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
                        Console.Clear();
                        if (choice1 == 0)
                            break;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали задачу 2.");
                    List<IProduct> products = new List<IProduct>();

                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить продукт");
                        Console.WriteLine("2. Вывести информацию о продуктах");
                        Console.WriteLine("3. Удалить продукт");
                        Console.WriteLine("4. Обновить информацию о продукте");
                        Console.WriteLine("0. Выход");

                        int choice2 = Convert.ToInt32(Console.ReadLine());

                        switch (choice2)
                        {
                            case 1:
                                Console.WriteLine("Выберите тип продукта:");
                                Console.WriteLine("1. Обычный продукт");
                                Console.WriteLine("2. Электроника");

                                int productType = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Введите название продукта: ");
                                string name = Console.ReadLine();

                                Console.Write("Введите цену продукта: ");
                                decimal price = Convert.ToDecimal(Console.ReadLine());

                                Console.Write("Введите количество на складе: ");
                                int stockQuantity = Convert.ToInt32(Console.ReadLine());

                                if (productType == 1)
                                {
                                    products.Add(new Product(name, price, stockQuantity));
                                }
                                else if (productType == 2)
                                {
                                    products.Add(new Electronics(name, price, stockQuantity));
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный выбор типа продукта.");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Информация о продуктах:");
                                foreach (var product in products)
                                {
                                    Console.WriteLine($"Название: {product.GetName()}, Цена: {product.GetPrice():C}, Остаток на складе: {product.GetStockQuantity()} шт.");
                                }
                                break;
                            case 3:
                                Console.Write("Введите название продукта для удаления: ");
                                string productNameToRemove = Console.ReadLine();
                                IProduct productToRemove = products.Find(p => p.GetName().Equals(productNameToRemove, StringComparison.OrdinalIgnoreCase));
                                if (productToRemove != null)
                                {
                                    products.Remove(productToRemove);
                                    Console.WriteLine($"Продукт '{productNameToRemove}' удален.");
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт с названием '{productNameToRemove}' не найден.");
                                }
                                break;
                            case 4:
                                Console.Write("Введите название продукта для обновления: ");
                                string productNameToUpdate = Console.ReadLine();
                                IProduct productToUpdate = products.Find(p => p.GetName().Equals(productNameToUpdate, StringComparison.OrdinalIgnoreCase));
                                if (productToUpdate != null)
                                {
                                    Console.Write("Введите новую цену продукта: ");
                                    decimal newPrice = Convert.ToDecimal(Console.ReadLine());

                                    Console.Write("Введите новое количество на складе: ");
                                    int newStockQuantity = Convert.ToInt32(Console.ReadLine());

                                    // Обновляем информацию о продукте
                                    productToUpdate = new Product(productToUpdate.GetName(), newPrice, newStockQuantity);
                                    Console.WriteLine($"Информация о продукте '{productNameToUpdate}' обновлена.");
                                }
                                else
                                {
                                    Console.WriteLine($"Продукт с названием '{productNameToUpdate}' не найден.");
                                }
                                break;
                            case 0:
                                Console.WriteLine("Программа завершена.");
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }
                        Console.ReadKey();
                        if (choice2 == 0)
                            break;
                    }
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали задачу 3.");
                    List<IStudent> students = new List<IStudent>();

                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить студента");
                        Console.WriteLine("2. Вывести информацию о студентах");
                        Console.WriteLine("0. Выход");

                        int choice3 = Convert.ToInt32(Console.ReadLine());

                        switch (choice3)
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
                            case 0:
                                Console.WriteLine("Программа завершена.");
                                break;
                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }
                        Console.ReadKey();
                        if (choice3 == 0)
                            break;
                    }
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали задачу 4.");
                    List<IBook> library = new List<IBook>();

                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Добавить книгу");
                        Console.WriteLine("2. Проверить доступность книги");
                        Console.WriteLine("3. Выдать книгу");
                        Console.WriteLine("4. Вернуть книгу");
                        Console.WriteLine("0. Выход");

                        int choice4 = Convert.ToInt32(Console.ReadLine());

                        switch (choice4)
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

                            case 0:
                                Console.WriteLine("Программа завершена.");
                                break;

                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }
                        Console.ReadKey();
                        if (choice4 == 0)
                            break;
                    }
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Вы выбрали задачу 5.");
                    Canvas canvas = new Canvas();

                    while (true)
                    {
                        Console.WriteLine("Выберите фигуру для рисования:");
                        Console.WriteLine("1. Линия");
                        Console.WriteLine("2. Круг");
                        Console.WriteLine("3. Прямоугольник");
                        Console.WriteLine("0. Выход");

                        int choice5 = Convert.ToInt32(Console.ReadLine());

                        switch (choice5)
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

                            case 0:
                                Console.WriteLine("Программа завершена.");
                                break;

                            default:
                                Console.WriteLine("Некорректный выбор.");
                                break;
                        }
                        Console.ReadKey();
                        if (choice5 == 0)
                            break;
                    }
                    Console.Clear();
                    break;
                case 0:
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите задачу из списка.");
                    break;
            }
        }
    }
}