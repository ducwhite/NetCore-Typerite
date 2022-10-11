using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Typerite.Models;

namespace Typerite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Authors> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Posts> Posts { get; set; }
    }
}
