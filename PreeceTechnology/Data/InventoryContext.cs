using Microsoft.EntityFrameworkCore;
using PreeceTechnology.Models;

namespace PreeceTechnology.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        { }
        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
      new Department { DepartmentId = "RR", DepartmentName = "Routers" },
      new Department { DepartmentId = "DM", DepartmentName = "Displays / Monitors" },
      new Department { DepartmentId = "AC", DepartmentName = "Accessories" },
      new Department { DepartmentId = "PT", DepartmentName = "PC Towers" },
      new Department { DepartmentId = "SS", DepartmentName = "Software" },
      new Department { DepartmentId = "OA", DepartmentName = "All-in-one Desktops" }
      );

            modelBuilder.Entity<Inventory>().HasData(
            new Inventory
            {
                Id = 1,
                Name = "Speed Router",
                Description = "Ultra Router",
                InStock = 200,
                NeedStock = 800,
                DepartmentId = "RR"
            },
            new Inventory
            {
                Id = 2,
                Name = "Multi-tool",
                Description = "Multi-tool",
                InStock = 600,
                NeedStock = 400,
                DepartmentId = "AC"
            },
              new Inventory
              {
                  Id = 3,
                  Name = "Wireless Mouse",
                  Description = "Wireless Mouse",
                  InStock = 430,
                  NeedStock = 650,
                  DepartmentId = "AC"
              },
                new Inventory
                {
                    Id = 4,
                    Name = "PC Tower",
                    Description = "PC Tower with LED",
                    InStock = 600,
                    NeedStock = 400,
                    DepartmentId = "PT"
                },
            new Inventory
            {
                Id = 5,
                Name = "24 4K monitor",
                Description = "4K Monitor",
                InStock = 100,
                NeedStock = 1200,
                DepartmentId = "DM"
            }
            );
        }
    }
}
