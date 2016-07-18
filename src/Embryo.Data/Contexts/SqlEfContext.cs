using Embryo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Embryo.Data.Contexts
{
    public class SqlEfContext : DbContext
    {
        public SqlEfContext(DbContextOptions<SqlEfContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
