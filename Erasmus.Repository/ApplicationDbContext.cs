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
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
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

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "4eb6f781-cba6-4873-ac70-7539916f1a17", Name = "User", NormalizedName = "USER" },
                                                    new IdentityRole { Id = "94a5b35b-ef16-434d-b99c-6ecf3c88b40a", Name = "Participant", NormalizedName = "PARTICIPANT" },
                                                    new IdentityRole { Id = "a06137ff-e363-4441-a340-569663a0cc0e", Name = "Organizer", NormalizedName = "ORGANIZER" });

            builder.Entity<Country>().HasData(new Country { Id = Guid.Parse("57242f19-0405-494c-b4bc-bdb52a725442"), Name = "Macedonia" },
                                              new Country { Id = Guid.Parse(" cbec8be4-6325-4b2f-b08e-22d709c27688"), Name = "UK" });

            builder.Entity<City>().HasData(new City { Id = Guid.Parse("415c3843-4bf9-4a21-8696-6781a66204e2"), Name = "Skopje", CountryId = Guid.Parse("57242f19-0405-494c-b4bc-bdb52a725442") },
                                           new City { Id = Guid.Parse("6c3175f9-55e1-423c-a721-ee2ce7af688c"), Name = "London", CountryId = Guid.Parse("cbec8be4-6325-4b2f-b08e-22d709c27688") });
            

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

            builder.Entity<Organizer>()
                   .HasOne<ErasmusUser>(s => s.BaseRecord)
                   .WithOne(z => z.Organizer).HasForeignKey<ErasmusUser>(z => z.OrganizerId);


            //ONE TO ONE
            //Coordinator - Faculty
            builder.Entity<Faculty>()
                .HasOne<Coordinator>(z => z.Coordinator)
                .WithOne(z => z.Faculty)
                .HasForeignKey<Coordinator>(z => z.FacultyId);

            //ONE TO MANY
            //Student - Faculty
            builder.Entity<Student>()
                .HasOne<Faculty>(z => z.Faculty)
                .WithMany(z => z.Students)
                .HasForeignKey(z => z.FacultyId);

            //Coordinator - ErasmusProject
            builder.Entity<Coordinator>()
                .HasOne<ErasmusProject>(z => z.ErasmusProject)
                .WithMany(z => z.Coordinators)
                .HasForeignKey(z => z.ErasmusProjectId);

            //Admin - ErasmusProject
            builder.Entity<Admin>()
                .HasOne<ErasmusProject>(z => z.ErasmusProject)
                .WithMany(z => z.Admins)
                .HasForeignKey(z => z.ErasmusProjectId);

            //University - Faculty
            builder.Entity<Faculty>()
                .HasOne<University>(z => z.University)
                .WithMany(z => z.Faculties)
                .HasForeignKey(z => z.UniversityId);

            builder.Entity<University>()
                .HasOne(z => z.City)
                .WithMany(z => z.Universities)
                .HasForeignKey(z => z.CityId);

            // NonGovProject - City
            builder.Entity<NonGovProject>()
                .HasOne(z => z.City)
                .WithMany(z => z.NonGovProjects)
                .HasForeignKey(z => z.CityId);


            //MANY TO MANY
            //Organizer - NonGovProject
            builder.Entity<NonGovProjectOrganizer>()
                .HasOne(z => z.Organizer)
                .WithMany(z => z.NonGovProjectOrganizers)
                .HasForeignKey(z => z.OrganizerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<NonGovProjectOrganizer>()
                .HasOne(z => z.NonGovProject)
                .WithMany(z => z.NonGovProjectOrganizers)
                .HasForeignKey(z => z.NonGovProjectId)
                .OnDelete(DeleteBehavior.ClientCascade);

            
            //University - ErasmusProject
            builder.Entity<ErasmusProjectUniversity>()
                .HasOne(z => z.University)
                .WithMany(z => z.ErasmusProjectUniversities)
                .HasForeignKey(z => z.UniversityId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ErasmusProjectUniversity>()
                .HasOne(z => z.ErasmusProject)
                .WithMany(z => z.ErasmusProjectUniversities)
                .HasForeignKey(z => z.ErasmusProjectId)
                .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
