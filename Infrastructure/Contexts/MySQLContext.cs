using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions options):base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
    }
}
