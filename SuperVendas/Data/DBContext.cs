using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperVendas.Models;

namespace SuperVendas.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<SuperVendas.Models.AccessLevel> AccessLevel { get; set; } = default!;
        public DbSet<SuperVendas.Models.Login> Login { get; set; } = default!;
        public DbSet<SuperVendas.Models.Category> Category { get; set; } = default!;
        public DbSet<SuperVendas.Models.Client> Client { get; set; } = default!;
        public DbSet<SuperVendas.Models.Employee> Employee { get; set; } = default!;
        public DbSet<SuperVendas.Models.Product> Product { get; set; } = default!;
        public DbSet<SuperVendas.Models.Order> Order { get; set; } = default!;
    }
}
