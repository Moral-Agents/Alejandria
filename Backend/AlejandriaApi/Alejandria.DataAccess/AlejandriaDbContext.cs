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
<<<<<<< Updated upstream
                .UseSqlServer(@"Server = USER\SQLEXPRESS; Database=AlejandriaDb; Integrated Security = true; ");
=======
                .UseSqlServer(@"Server = moralagents; Database=Alejandria.Api_db; Integrated Security = true; ");
>>>>>>> Stashed changes
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
