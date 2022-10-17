using Microsoft.EntityFrameworkCore;
using PlandoDemo.API.Models;
using System.Diagnostics.CodeAnalysis;

namespace PlandoDemo.API.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext([NotNullAttribute] DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
