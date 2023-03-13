﻿// <auto-generated />
using System;
using CMS.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CMS.Migrations
{
    [DbContext(typeof(CMSContext))]
    partial class CMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CMS.DBModels.Case", b =>
                {
                    b.Property<int>("CaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.HasKey("CaseID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TaskID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("CMS.DBModels.CaseNote", b =>
                {
                    b.Property<int>("CaseNoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaseNoteID"));

                    b.Property<int>("CaseID")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CaseNoteID");

                    b.HasIndex("CaseID");

                    b.ToTable("CaseNotes");
                });

            modelBuilder.Entity("CMS.DBModels.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CMS.DBModels.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.HasIndex("ClientID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("CMS.DBModels.Case", b =>
                {
                    b.HasOne("CMS.DBModels.Client", "Client")
                        .WithMany("Cases")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CMS.DBModels.Task", "Task")
                        .WithMany("Case")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("CMS.DBModels.CaseNote", b =>
                {
                    b.HasOne("CMS.DBModels.Case", "Case")
                        .WithMany()
                        .HasForeignKey("CaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Case");
                });

            modelBuilder.Entity("CMS.DBModels.Task", b =>
                {
                    b.HasOne("CMS.DBModels.Client", "Client")
                        .WithMany("Task")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CMS.DBModels.Client", b =>
                {
                    b.Navigation("Cases");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("CMS.DBModels.Task", b =>
                {
                    b.Navigation("Case");
                });
#pragma warning restore 612, 618
        }
    }
}
