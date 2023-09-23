using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Npgsql;
while (true)
{
    Console.WriteLine("1. Список производителей");
    Console.WriteLine("2. Список всех моделей");
    Console.WriteLine("3. Выполнение вставку новой модели");
    Console.WriteLine("4. Удаление строки в таблице Модели");
    Console.WriteLine("5. Обновление даннх в таблице");
    var choise = Convert.ToInt32(Console.ReadLine());

    if (choise == 1)
    {
        Database db = new();
        foreach (var man in db.Manufacturers)
        {
            Console.WriteLine($"{man.Name}");
        }
        Console.WriteLine();
    }
    if (choise == 2)
    {
        Database db = new();      
        foreach (var model in db.Models)
        {
            Console.WriteLine($"{model.Name}");
        }
        Console.WriteLine();
    }
    if (choise == 3)
    {
        var nme = "";
        var yar = 0;
        var mon = 0;
        Console.WriteLine("Введите новый вид шоколада:");
        nme = Console.ReadLine();
        Console.WriteLine("Введите год выпуска:");
        yar = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите номер производителя:");
        mon = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите ID:");
        var id = Convert.ToInt32(Console.ReadLine());
        Database db = new();
        EF.Model model = new EF.Model { 
            
            Id = id,
            Name = nme,
            Year = yar,
            ManufacturerId = mon
           };
        db.Models.Add(model);
        Console.WriteLine("Успешно.");
        db.SaveChanges();
        Console.WriteLine();
    }
    if (choise == 4)
    {
        Console.WriteLine("Введите id Шоколада, который хотите удалить:");
        var id = Convert.ToInt32(Console.ReadLine());
        Database db = new();
        var entityToDelete = db.Models.Find(id);
        db.Models.Remove(entityToDelete);
        db.SaveChanges();
        Console.WriteLine("Удаление прошло успешно.");
        Console.WriteLine();
    }
    if (choise == 5)
    {
        Console.WriteLine("Введите старое name:");
        var nam_old = Console.ReadLine();
        Console.WriteLine("Введите новое name:");
        var nam_ch7 = Console.ReadLine();
        Database db = new();
        var customer = db.Models
       .Where(c => c.Name == nam_old)
       .FirstOrDefault();
        customer.Name = nam_ch7;
        db.SaveChanges();
        Console.WriteLine("Вставка выполнена.");
        Console.WriteLine();
    }

}

class Database : DbContext
{
    public DbSet<EF.Manufacture> Manufacturers { get; set; }
    public DbSet<EF.Model> Models { get; set; }
    public Database() { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=ep-calm-wave-94412721-pooler.us-east-2.aws.neon.tech;Username=pmm.20;Password=Sz56YosRjGFc;Database=neondb");
    }
}













