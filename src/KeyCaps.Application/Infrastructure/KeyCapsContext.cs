using Bogus;
using KeyCaps.Application.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCaps.Application.Infrastructure
{
    public class KeyCapsContext : DbContext
    {
        public KeyCapsContext(DbContextOptions opt) : base(opt) { }
        public DbSet<Customer> Customers => Set<Customer>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public void Seed()
        {
            Randomizer.Seed = new Random(731);
            var customers = new Faker<Customer>("de").CustomInstantiator(f =>
            {
                return new Customer(firstname: f.Name.FirstName(), lastname: f.Name.LastName());
            })
            .Generate(10)
            .ToList();
            Customers.AddRange(customers);
            SaveChanges();
        }
    }
}
