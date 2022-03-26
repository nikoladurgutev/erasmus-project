using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student", NormalizedName = "STUDENT" },
                                                    new IdentityRole { Name = "User", NormalizedName = "USER" }, new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                                                    new IdentityRole { Name = "Coordinator", NormalizedName = "COORDINATOR" },
                                                    new IdentityRole { Name = "Organizer", NormalizedName="ORGANIZER"});
            
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
