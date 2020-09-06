using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using AggriPortal.API.Domain.Enums;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.ToTable("ApplicationUser");

            // Each User can have many UserClaims
            builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.UpdateDate).HasColumnType("datetime");

            // Each User can have many UserLogins
            builder.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }

    public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.ToTable("ApplicationRole");
            // Each Role can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

            builder.HasData(
                new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = ApplicationRoleEnums.Administrator.ToString(), NormalizedName = ApplicationRoleEnums.Administrator.ToString().ToUpper() },
                new ApplicationRole { Id = Guid.NewGuid().ToString(), Name = ApplicationRoleEnums.Client.ToString(), NormalizedName = ApplicationRoleEnums.Client.ToString().ToUpper() }
            );
        }
    }

    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("ApplicationUserRole");
            builder.HasKey(p => new { p.UserId, p.RoleId });
        }
    }

    public class ApplicationUserClaimConfiguration : IEntityTypeConfiguration<ApplicationUserClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserClaim> builder)
        {
            builder.ToTable("ApplicationUserClaim");
            builder.HasOne(p => p.User).WithMany(p => p.Claims).HasForeignKey(p => p.UserId);
        }
    }
    public class ApplicationUserLoginConfiguration : IEntityTypeConfiguration<ApplicationUserLogin>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
        {
            builder.ToTable("ApplicationUserLogin");
            builder.HasKey(p => new { p.LoginProvider, p.ProviderKey });
        }
    }

    public class ApplicationRoleClaimConfiguration : IEntityTypeConfiguration<ApplicationRoleClaim>
    {
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim> builder)
        {
            builder.ToTable("ApplicationRoleClaim");
        }
    }

    public class ApplicationUserTokenConfiguration : IEntityTypeConfiguration<ApplicationUserToken>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
        {
            builder.ToTable("ApplicationUserToken");
            builder.HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
        }
    }

    public class ApplicationUserLoginHistoryConfiguration : IEntityTypeConfiguration<ApplicationUserLoginHistory>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserLoginHistory> builder)
        {
            builder.ToTable("ApplicationUserLoginHistory");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IPAddress).HasMaxLength(50);
            builder.Property(p => p.Browser).HasMaxLength(250);
            builder.Property(p => p.OS).HasMaxLength(50);
            builder.Property(p => p.CountryCode).HasMaxLength(20);
            builder.Property(p => p.CountryName).HasMaxLength(50);
            builder.Property(p => p.RegionCode).HasMaxLength(20);
            builder.Property(p => p.RegionName).HasMaxLength(50);
            builder.Property(p => p.City).HasMaxLength(50);
            builder.Property(p => p.ZipCode).HasMaxLength(20);
            builder.Property(p => p.TimeZone).HasMaxLength(100);
            builder.Property(p => p.Latitude).HasMaxLength(100);
            builder.Property(p => p.Longitude).HasMaxLength(100);
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(450);
            builder.HasOne(p => p.ApplicationUser).WithMany(p => p.ApplicationUserLoginsHistory).HasForeignKey(p => p.ApplicationUserId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
