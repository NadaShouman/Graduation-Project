using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AbilitySystem.DAL;

public class IdentityContext: IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
      : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().ToTable("Users");

       // builder.Entity<User>().ToTable("Users");
    }
}
