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

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student" },
                                                    new IdentityRole { Name = "User" }, new IdentityRole { Name = "Admin" },
                                                    new IdentityRole { Name = "Coordinator" });


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
