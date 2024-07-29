using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourTimeSheet.Core.Entities;
using YourTimeSheet.Core.Entities.IdentityModels;
using YourTimeSheet.Infrastructure.Repositories.Configuration;

namespace YourTimeSheet.Infrastructure.Repositories
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<TestSheet> TestSheets { get; set; }
    }
}
