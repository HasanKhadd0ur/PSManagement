﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSManagement.Infrastructure.Persistence;

namespace PSManagement.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240803190751_AddDomains5")]
    partial class AddDomains5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Arabic_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSManagement.Domain.Customers.Aggregate.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PSManagement.Domain.Employees.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("PSManagement.Domain.Employees.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HIASTId")
                        .HasColumnType("int");

                    b.Property<int?>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PSManagement.Domain.Identity.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("PSManagement.Domain.Identity.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PSManagement.Domain.Identity.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PSManagement.Domain.ProjectTypes.Entities.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkerCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProjectType");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Aggregate.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExecuterId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("ProposerId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamLeaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExecuterId");

                    b.HasIndex("ProjectStatusId");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("ProposerId");

                    b.HasIndex("TeamLeaderId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Entities.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttachmenDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AttachmentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Entities.ProjectStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatus");
                });

            modelBuilder.Entity("PSManagement.Domain.Steps.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StepId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("PSManagement.Domain.Steps.Entities.Step", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StepName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TrackId");

                    b.ToTable("Steps");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Entities.EmployeeWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContributingRatio")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeWorkId")
                        .HasColumnType("int");

                    b.Property<int>("HoursWorked")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StepTrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("StepTrackId");

                    b.ToTable("EmployeeWorks");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Entities.StepTrack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StepId")
                        .HasColumnType("int");

                    b.Property<int>("TrackId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StepId");

                    b.HasIndex("TrackId");

                    b.ToTable("StepTracks");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrackDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackNote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("PermissionsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("PermissionRole");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("PSManagement.Domain.Customers.Aggregate.Customer", b =>
                {
                    b.OwnsMany("PSManagement.Domain.Customers.Entities.ContactInfo", "ContactInfo", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("ContactType")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ContactValue")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CustomerId", "Id");

                            b1.ToTable("ContactInfo");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("PSManagement.Domain.Customers.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("StreetName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("StreetName");

                            b1.Property<int>("StreetNumber")
                                .HasColumnType("int")
                                .HasColumnName("StreetNumber");

                            b1.Property<int>("ZipCode")
                                .HasColumnType("int")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address");

                    b.Navigation("ContactInfo");
                });

            modelBuilder.Entity("PSManagement.Domain.Employees.Entities.Employee", b =>
                {
                    b.HasOne("PSManagement.Domain.Steps.Entities.Step", null)
                        .WithMany("Participants")
                        .HasForeignKey("StepId");

                    b.HasOne("PSManagement.Domain.Identity.Entities.User", "User")
                        .WithOne("Employee")
                        .HasForeignKey("PSManagement.Domain.Employees.Entities.Employee", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("PSManagement.Domain.Employees.Entities.Availability", "Availability", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("CurrentWorkingHours")
                                .HasColumnType("int")
                                .HasColumnName("CurrentWorkingHours");

                            b1.Property<bool>("IsAvailable")
                                .HasColumnType("bit")
                                .HasColumnName("IsAvailable");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.OwnsOne("PSManagement.Domain.Employees.Entities.PersonalInfo", "PersonalInfo", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employees");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Availability");

                    b.Navigation("PersonalInfo");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Aggregate.Project", b =>
                {
                    b.HasOne("PSManagement.Domain.Employees.Entities.Department", "Executer")
                        .WithMany()
                        .HasForeignKey("ExecuterId");

                    b.HasOne("PSManagement.Domain.Projects.Entities.ProjectStatus", "ProjectStatus")
                        .WithMany()
                        .HasForeignKey("ProjectStatusId");

                    b.HasOne("PSManagement.Domain.ProjectTypes.Entities.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId");

                    b.HasOne("PSManagement.Domain.Customers.Aggregate.Customer", "Proposer")
                        .WithMany("Projects")
                        .HasForeignKey("ProposerId");

                    b.HasOne("PSManagement.Domain.Employees.Entities.Employee", "TeamLeader")
                        .WithMany()
                        .HasForeignKey("TeamLeaderId");

                    b.OwnsOne("PSManagement.Domain.Projects.Aggregate.Aggreement", "ProjectAggreement", b1 =>
                        {
                            b1.Property<int>("ProjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("AggreementDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("AggreementDate");

                            b1.Property<int>("AggreementNumber")
                                .HasColumnType("int")
                                .HasColumnName("AggreementNumber");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.OwnsOne("PSManagement.Domain.Projects.Aggregate.ProjectInfo", "ProjectInfo", b1 =>
                        {
                            b1.Property<int>("ProjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Code")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Code");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Description");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.OwnsOne("PSManagement.Domain.Projects.Aggregate.ProposalInfo", "ProposalInfo", b1 =>
                        {
                            b1.Property<int>("ProjectId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("ProposingBookDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("ProposingBookDate");

                            b1.Property<int>("ProposingBookNumber")
                                .HasColumnType("int")
                                .HasColumnName("ProposingBookNumber");

                            b1.HasKey("ProjectId");

                            b1.ToTable("Projects");

                            b1.WithOwner()
                                .HasForeignKey("ProjectId");
                        });

                    b.Navigation("Executer");

                    b.Navigation("ProjectAggreement");

                    b.Navigation("ProjectInfo");

                    b.Navigation("ProjectStatus");

                    b.Navigation("ProjectType");

                    b.Navigation("ProposalInfo");

                    b.Navigation("Proposer");

                    b.Navigation("TeamLeader");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Entities.Attachment", b =>
                {
                    b.HasOne("PSManagement.Domain.Projects.Aggregate.Project", null)
                        .WithMany("Attachments")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("PSManagement.Domain.Steps.Entities.Item", b =>
                {
                    b.HasOne("PSManagement.Domain.Steps.Entities.Step", null)
                        .WithMany("Purchases")
                        .HasForeignKey("StepId");

                    b.OwnsOne("PSManagement.SharedKernel.ValueObjects.Money", "Price", b1 =>
                        {
                            b1.Property<int>("ItemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Ammount")
                                .HasColumnType("int")
                                .HasColumnName("Ammount");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Currency");

                            b1.HasKey("ItemId");

                            b1.ToTable("Items");

                            b1.WithOwner()
                                .HasForeignKey("ItemId");
                        });

                    b.Navigation("Price");
                });

            modelBuilder.Entity("PSManagement.Domain.Steps.Entities.Step", b =>
                {
                    b.HasOne("PSManagement.Domain.Projects.Aggregate.Project", "Project")
                        .WithMany("Steps")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSManagement.Domain.Tracking.Track", null)
                        .WithMany("Steps")
                        .HasForeignKey("TrackId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Entities.EmployeeWork", b =>
                {
                    b.HasOne("PSManagement.Domain.Employees.Entities.Employee", "Employee")
                        .WithMany("EmployeeWorks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PSManagement.Domain.Tracking.Entities.StepTrack", "StepTrack")
                        .WithMany("EmployeeWorks")
                        .HasForeignKey("StepTrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("StepTrack");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Entities.StepTrack", b =>
                {
                    b.HasOne("PSManagement.Domain.Steps.Entities.Step", "Step")
                        .WithMany("StepTracks")
                        .HasForeignKey("StepId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PSManagement.Domain.Tracking.Track", "Track")
                        .WithMany("StepTracks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Step");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Track", b =>
                {
                    b.HasOne("PSManagement.Domain.Projects.Aggregate.Project", "Project")
                        .WithMany("Tracks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PermissionRole", b =>
                {
                    b.HasOne("PSManagement.Domain.Identity.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSManagement.Domain.Identity.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("PSManagement.Domain.Identity.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSManagement.Domain.Identity.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PSManagement.Domain.Customers.Aggregate.Customer", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("PSManagement.Domain.Employees.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeWorks");
                });

            modelBuilder.Entity("PSManagement.Domain.Identity.Entities.User", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PSManagement.Domain.ProjectTypes.Entities.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("PSManagement.Domain.Projects.Aggregate.Project", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Steps");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("PSManagement.Domain.Steps.Entities.Step", b =>
                {
                    b.Navigation("Participants");

                    b.Navigation("Purchases");

                    b.Navigation("StepTracks");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Entities.StepTrack", b =>
                {
                    b.Navigation("EmployeeWorks");
                });

            modelBuilder.Entity("PSManagement.Domain.Tracking.Track", b =>
                {
                    b.Navigation("Steps");

                    b.Navigation("StepTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
