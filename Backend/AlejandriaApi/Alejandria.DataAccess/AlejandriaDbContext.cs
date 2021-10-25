using Alejandria.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.DataAccess
{
    public class AlejandriaDbContext: DbContext
    {
        public AlejandriaDbContext(DbContextOptions<AlejandriaDbContext> options) : base(options)
        {

        }

        public AlejandriaDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server = DESKTOP-I0F6AEQ; Database=AlejandriaDb; Integrated Security = true; ");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
