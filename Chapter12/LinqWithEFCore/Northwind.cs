using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{
    // управление подключением к БД
    public class Northwind : DbContext
    {
        // эти свойства соотносятся с таблицами в базе
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // для использования Microsoft SQL Server раскомментируйте код,
            // данный ниже
            optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\mssqllocaldb;" +
            "Initial Catalog=Northwind;" +
            "Integrated Security=true;" +
            "MultipleActiveResultSets=true;");
            // чтобы использовать SQLite, раскомментируйте этот код
            // string path = System.IO.Path.Combine(
            // System.Environment.CurrentDirectory, "Northwind.db");
            // optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
}
