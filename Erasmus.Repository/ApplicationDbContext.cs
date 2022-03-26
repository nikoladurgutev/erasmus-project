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
                                                    new IdentityRole { Name = "Coordinator", NormalizedName = "COORDINATOR" });

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

            //ONE TO ONE
            //Coordinator - Faculty
            builder.Entity<Faculty>()
                .HasOne<Coordinator>(z => z.Coordinator)
                .WithOne(z => z.Faculty)
                .HasForeignKey<Coordinator>(z => z.FacultyId);

            //ONE TO MANY
            //Student - Faculty


        }
    }
}
