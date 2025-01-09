using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class RealDatabase : IdentityDbContext<User, IdentityRole, string>
    {
        public RealDatabase() { }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("Server=Simon\\SQLEXPRESS; Database=SimonDemo; Trusted_Connection=true; TrustServerCertificate=true;");

        }


    }
}
