﻿using System.Reflection;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<UserPoints> UserPoints { get; set; }
        public DbSet<Point> Points { get; set; }
        public AppIdentityDbContext( DbContextOptions<AppIdentityDbContext> options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            base.OnModelCreating ( builder );
            
            builder.ApplyConfigurationsFromAssembly ( Assembly.GetExecutingAssembly() );
        }
    }
}