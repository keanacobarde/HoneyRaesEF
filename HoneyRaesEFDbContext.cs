using HoneyRaesEF.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HoneyRaesEF
{
    public class HoneyRaesEFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ServiceTicket> ServiceTickets { get; set; }

        public HoneyRaesEFDbContext(DbContextOptions<HoneyRaesEFDbContext> context) : base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer[]{ 
            new Customer() { Id = 1, Name = "Salem", Address = "123 Witch Lane" },
            new Customer() { Id = 2, Name = "Saleoomi", Address = "124 Witch Lane" },
            new Customer() { Id = 3, Name = "Salogna", Address = "125 Witch Lane" }
            });

            modelBuilder.Entity<Employee>().HasData(new Employee[] { 
            new Employee() { Id = 1, Name = "Keana", Specialty = "Dealing with Salems"},
            new Employee() { Id = 2, Name = "Kiki", Specialty = "Dealing with Saleoomis"},
            new Employee() { Id = 3, Name = "Kia", Specialty = "Dealing with Salognas"}
            });

            modelBuilder.Entity<ServiceTicket>().HasData(new ServiceTicket[] { 
            new ServiceTicket() { Id = 1, CustomerId = 1, EmployeeId = 1, Description = "The salem needs a Cauldron", Emergency = false, DateCompleted = new DateTime(2023, 12, 1)},
            new ServiceTicket() { Id = 2, CustomerId = 2, EmployeeId = 2, Description = "The saleoomi needs a Cauldron", Emergency = true, DateCompleted = new DateTime(2021, 12, 1)},
            new ServiceTicket() { Id = 3, CustomerId = 3, EmployeeId = 3, Description = "The salogna needs a Cauldron", Emergency = true, DateCompleted = null},
            });
        }


    }
}
