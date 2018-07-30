using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBotNetCoreSample.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
    }
}
