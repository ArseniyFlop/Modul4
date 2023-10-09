using System;
using System.Collections.Generic;

// Интерфейс для продуктов, определяющий методы для получения цены и остатка
public interface IProduct
{
    decimal GetPrice();
    int GetStockQuantity();
    string GetName();
}

// Класс, представляющий обычный продукт, реализующий интерфейс IProduct
public class Product : IProduct
{
    private string name;
    private decimal price;
    private int stockQuantity;

    public Product(string name, decimal price, int stockQuantity)
    {
        this.name = name;
        this.price = price;
        this.stockQuantity = stockQuantity;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public int GetStockQuantity()
    {
        return stockQuantity;
    }

    public string GetName()
    {
        return name;
    }
}

// Класс, представляющий продукт в категории "Электроника", также реализующий интерфейс IProduct
public class Electronics : IProduct
{
    private string name;
    private decimal price;
    private int stockQuantity;

    public Electronics(string name, decimal price, int stockQuantity)
    {
        this.name = name;
        this.price = price;
        this.stockQuantity = stockQuantity;
    }

    public decimal GetPrice()
    {
        return price;
    }

    public int GetStockQuantity()
    {
        return stockQuantity;
    }

    public string GetName()
    {
        return name;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IProduct> products = new List<IProduct>();

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить продукт");
            Console.WriteLine("2. Вывести информацию о продуктах");
            Console.WriteLine("3. Удалить продукт");
            Console.WriteLine("4. Обновить информацию о продукте");
            Console.WriteLine("5. Выход");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
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