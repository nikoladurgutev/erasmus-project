﻿// <auto-generated />
using System;
using Erasmus.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Erasmus.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Erasmus.Domain.Domain.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ErasmusProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ErasmusProjectId");

                    b.ToTable("Admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d73d3e8c-ff96-4805-a1bc-18a2467280cc"),
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
                        });
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("415c3843-4bf9-4a21-8696-6781a66204e2"),
                            CountryId = new Guid("57242f19-0405-494c-b4bc-bdb52a725442"),
                            Name = "Skopje"
                        },
                        new
                        {
                            Id = new Guid("6c3175f9-55e1-423c-a721-ee2ce7af688c"),
                            CountryId = new Guid("cbec8be4-6325-4b2f-b08e-22d709c27688"),
                            Name = "London"
                        });
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Coordinator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ErasmusProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ErasmusProjectId");

                    b.HasIndex("FacultyId")
                        .IsUnique()
                        .HasFilter("[FacultyId] IS NOT NULL");

                    b.ToTable("Coordinators");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("57242f19-0405-494c-b4bc-bdb52a725442"),
                            Name = "Macedonia"
                        },
                        new
                        {
                            Id = new Guid("cbec8be4-6325-4b2f-b08e-22d709c27688"),
                            Name = "UK"
                        });
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MailTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sent")
                        .HasColumnType("bit");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmailMessage");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ErasmusProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ErasmusProjects");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ErasmusProjectUniversity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ErasmusProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ErasmusProjectId");

                    b.HasIndex("UniversityId");

                    b.ToTable("ErasmusProjectUniversity");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ErasmusUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CoordinatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("OrganizerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ProfilePhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique()
                        .HasFilter("[AdminId] IS NOT NULL");

                    b.HasIndex("CoordinatorId")
                        .IsUnique()
                        .HasFilter("[CoordinatorId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("OrganizerId")
                        .IsUnique()
                        .HasFilter("[OrganizerId] IS NOT NULL");

                    b.HasIndex("ParticipantId")
                        .IsUnique()
                        .HasFilter("[ParticipantId] IS NOT NULL");

                    b.HasIndex("ProfilePhotoId")
                        .IsUnique()
                        .HasFilter("[ProfilePhotoId] IS NOT NULL");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "def17fc8-fccf-4dc0-a528-3112ecd47a57",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = true,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ8+16kdSyoTzRCJIPhoUMPlu4whltopQLWdrDt+yayR0A2IsfD4qTJ0rItS56/RSQ==",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "82f784e7-69bf-4454-914b-c7d37b95a22a",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Faculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FacultyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.NonGovProject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectPhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("NonGovProject");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.NonGovProjectOrganizer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("NonGovProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OrganizerId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NonGovProjectId");

                    b.HasIndex("OrganizerId");

                    b.ToTable("NonGovProjectOrganizer");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Organizer", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Organizer");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Participant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ParticipantApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NonGovProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ParticipantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ParticipantUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReviewStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NonGovProjectId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ProfilePhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PathOnDisk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProfilePics");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ProjectType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c1e3b0e7-be46-4d1b-a8d4-036ca14d1f7b"),
                            Type = "Language Learning"
                        },
                        new
                        {
                            Id = new Guid("94471ce4-e80b-46e6-95ab-609be06e4d33"),
                            Type = "Computer Science Learning"
                        },
                        new
                        {
                            Id = new Guid("b31ef18a-7bb0-41a6-917a-4a4c0f33a733"),
                            Type = "Business and Marketing"
                        },
                        new
                        {
                            Id = new Guid("80eb5256-1be1-4d87-a7bb-f45575a9346f"),
                            Type = "Politics"
                        });
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FacultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.UploadedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<string>("PathOnDisk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("UserId1");

                    b.ToTable("UploadedFiles");
                });

            modelBuilder.Entity("Erasmus.Domain.DomainModels.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                            ConcurrencyStamp = "9d2aa1b5-8021-42d9-9469-f3bd28362314",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "4eb6f781-cba6-4873-ac70-7539916f1a17",
                            ConcurrencyStamp = "095d5bce-4041-4648-b61d-58c41286e2c5",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                            ConcurrencyStamp = "5ec0a918-0048-4664-9836-e856ce6d1f49",
                            Name = "Participant",
                            NormalizedName = "PARTICIPANT"
                        },
                        new
                        {
                            Id = "a06137ff-e363-4441-a340-569663a0cc0e",
                            ConcurrencyStamp = "e824acfd-eb50-4cbe-b82f-e12c66cd0a13",
                            Name = "Organizer",
                            NormalizedName = "ORGANIZER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "b74ddd14-6340-4840-95c2-db12554843e5",
                            RoleId = "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Admin", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusProject", "ErasmusProject")
                        .WithMany("Admins")
                        .HasForeignKey("ErasmusProjectId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.City", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Coordinator", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusProject", "ErasmusProject")
                        .WithMany("Coordinators")
                        .HasForeignKey("ErasmusProjectId");

                    b.HasOne("Erasmus.Domain.Domain.Faculty", "Faculty")
                        .WithOne("Coordinator")
                        .HasForeignKey("Erasmus.Domain.Domain.Coordinator", "FacultyId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ErasmusProjectUniversity", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusProject", "ErasmusProject")
                        .WithMany("ErasmusProjectUniversities")
                        .HasForeignKey("ErasmusProjectId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Erasmus.Domain.DomainModels.University", "University")
                        .WithMany("ErasmusProjectUniversities")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.ClientCascade);
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ErasmusUser", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.Admin", "Admin")
                        .WithOne("BaseRecord")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "AdminId");

                    b.HasOne("Erasmus.Domain.Domain.Coordinator", "Coordinator")
                        .WithOne("BaseRecord")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "CoordinatorId");

                    b.HasOne("Erasmus.Domain.Domain.Organizer", "Organizer")
                        .WithOne("BaseRecord")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "OrganizerId");

                    b.HasOne("Erasmus.Domain.Domain.Participant", "Participant")
                        .WithOne("BaseRecord")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "ParticipantId");

                    b.HasOne("Erasmus.Domain.Domain.ProfilePhoto", "Photo")
                        .WithOne("User")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "ProfilePhotoId");

                    b.HasOne("Erasmus.Domain.Domain.Student", "Student")
                        .WithOne("BaseRecord")
                        .HasForeignKey("Erasmus.Domain.Domain.ErasmusUser", "StudentId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Faculty", b =>
                {
                    b.HasOne("Erasmus.Domain.DomainModels.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.NonGovProject", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.City", "City")
                        .WithMany("NonGovProjects")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Erasmus.Domain.Domain.ProjectType", "ProjectType")
                        .WithMany("NonGovProjects")
                        .HasForeignKey("ProjectTypeId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.NonGovProjectOrganizer", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.NonGovProject", "NonGovProject")
                        .WithMany("NonGovProjectOrganizers")
                        .HasForeignKey("NonGovProjectId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Erasmus.Domain.Domain.Organizer", "Organizer")
                        .WithMany("NonGovProjectOrganizers")
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.ClientCascade);
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.ParticipantApplication", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.NonGovProject", "NonGovProject")
                        .WithMany("Applications")
                        .HasForeignKey("NonGovProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Erasmus.Domain.Domain.Participant", "Participant")
                        .WithMany("ErasmusApplications")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.Student", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("Erasmus.Domain.Domain.UploadedFile", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ParticipantApplication", "Application")
                        .WithMany("UploadedFiles")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Erasmus.Domain.Domain.Participant", "User")
                        .WithMany("UploadedFiles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Erasmus.Domain.DomainModels.University", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.City", "City")
                        .WithMany("Universities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Erasmus.Domain.Domain.ErasmusUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Erasmus.Domain.Domain.ErasmusUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
