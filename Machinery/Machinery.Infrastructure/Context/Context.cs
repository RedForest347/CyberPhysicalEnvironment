using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machinery.Domain;

namespace Machinery.Infrastructure
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<MachineryInfo> MachineryInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
