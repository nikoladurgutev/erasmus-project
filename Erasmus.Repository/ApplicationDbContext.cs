using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Erasmus.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ErasmusUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ErasmusProject> ErasmusProjects { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<NonGovProject> NonGovProject { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Coordinator> Coordinators { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        private void SeedUsers(ModelBuilder builder)
        {
            PasswordHasher<ErasmusUser> passwordHasher = new PasswordHasher<ErasmusUser>();

            ErasmusUser user = new ErasmusUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                PhoneNumberConfirmed = true
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "Test123!");

            builder.Entity<ErasmusUser>().HasData(user);

            builder.Entity<Admin>().HasData(new Admin
            {
                Id = Guid.Parse("d73d3e8c-ff96-4805-a1bc-18a2467280cc"),
                UserId = user.Id
            });
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.Parse("d5057dbb-cb98-476a-8f85-f27d6e6d7ec7").ToString(), Name = "Admin", NormalizedName = "ADMIN" });
        }
        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() 
                { 
                  RoleId = Guid.Parse("d5057dbb-cb98-476a-8f85-f27d6e6d7ec7").ToString(),
                  UserId = Guid.Parse("b74ddd14-6340-4840-95c2-db12554843e5").ToString() }
                );
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b", Name = "Student", NormalizedName = "STUDENT" },
                                                    new IdentityRole { Id = "4eb6f781-cba6-4873-ac70-7539916f1a17", Name = "User", NormalizedName = "USER" },
                                                    new IdentityRole { Id = "12739aa2-fc68-45db-82e8-2d0602e94eb6", Name = "Coordinator", NormalizedName = "COORDINATOR" },
                                                    new IdentityRole { Id = "94a5b35b-ef16-434d-b99c-6ecf3c88b40a", Name = "Participant", NormalizedName = "PARTICIPANT" });

            builder.Entity<Admin>()
                   .HasOne<ErasmusUser>(s => s.BaseRecord)
                   .WithOne(z => z.Admin).HasForeignKey<ErasmusUser>(z => z.AdminId);

            builder.Entity<Coordinator>()
                  .HasOne<ErasmusUser>(s => s.BaseRecord)
                  .WithOne(z => z.Coordinator).HasForeignKey<ErasmusUser>(z => z.CoordinatorId);


            builder.Entity<Participant>()
                   .HasOne<ErasmusUser>(s => s.BaseRecord)
                   .WithOne(z => z.Participant).HasForeignKey<ErasmusUser>(z => z.ParticipantId);


            builder.Entity<Student>()
                   .HasOne<ErasmusUser>(s => s.BaseRecord)
                   .WithOne(z => z.Student).HasForeignKey<ErasmusUser>(z => z.StudentId);

        }
    }
}
