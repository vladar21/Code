using Microsoft.EntityFrameworkCore;

namespace Packt.CS7
{   
    // управление соединением с базой данных
    public class Northwind : DbContext
    {
        // свойства, сопоставляемые с таблицами в базе данных
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // для Microsoft SQL Server
            optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\mssqllocaldb;" +
            "Initial Catalog=Northwind;" +
            "Integrated Security=true;" +
            "MultipleActiveResultSets=true;");
            // для SQLite
            // string path = System.IO.Path.Combine(
            // System.Environment.CurrentDirectory, "Northwind.db");
            // optionsBuilder.UseSqlite($"Filename={path}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // пример использования Fluent API вместо атрибутов для ограничения
            // имени категории 40 символами
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);

            // глобальный фильтр для удаления снятых с продажи товаров
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
    
}
