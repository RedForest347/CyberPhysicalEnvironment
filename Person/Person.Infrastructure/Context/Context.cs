using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Person.Domain;

namespace Person.Infrastructure
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<PersonInfo> PersonInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
