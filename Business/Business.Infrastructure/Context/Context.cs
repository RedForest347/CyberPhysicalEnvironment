using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Domain;

namespace Business.Infrastructure
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<BusinessInfo> BusinessInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
