using System;
using Authentication_ApplicationCore.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Authentication_Infrastructure.Data
{
    //public class AuthenticationDbContext : DbContext
    // replace DbContext to IdentitydbContext
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> option) : base(option)
        {
        }

        /* IdentityDbContext has pre-defined entites, we don't need to define the relationships betweeen entities.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<Account>(ConfigureAccount);
            modelBuilder.Entity<AuthorizationRole>(ConfigureAuthorizationRole);
        }

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(e => e.Id);
            builder.HasOne(a => a.Account).WithMany(e => e.UserRoles).HasForeignKey(e => e.UserId);
            builder.HasOne(a => a.AuthorizationRole).WithMany(e => e.UserRoles).HasForeignKey(e => e.RoleId);
        }

        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(e => e.UserId);
        }

        private void ConfigureAuthorizationRole(EntityTypeBuilder<AuthorizationRole> builder)
        {
            builder.ToTable("AuthorizationRole");
            builder.HasKey(e => e.RoleId);
        }
        */
    }
}

