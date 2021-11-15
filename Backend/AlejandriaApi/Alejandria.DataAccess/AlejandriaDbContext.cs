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

                .UseSqlServer(@"Server = sql5097.site4now.net; Database = db_a7c7cc_alejandriadb; user = db_a7c7cc_alejandriadb_admin; pwd = alejandria2021;");

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
