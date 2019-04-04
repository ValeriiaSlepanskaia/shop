using Microsoft.EntityFrameworkCore;

namespace Shop
{
   
        class ShopContext : DbContext//передача конфигурации в конструктор базового класса
        {
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Client> Clients { get; set; }
            public DbSet<Provider> Provider { get; set; }
            public DbSet<Supply> Supplies { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Group> Groups { get; set; }


            public ShopContext()
            {
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=shopappdb;Trusted_Connection=True;");//создаем параметры подключения
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Employee>();
                modelBuilder.Entity<Product>();
                modelBuilder.Entity<Client>();
                modelBuilder.Entity<Provider>();
                modelBuilder.Entity<Supply>();
                modelBuilder.Entity<Order>();
                modelBuilder.Entity<Group>();

        }
    }
}

