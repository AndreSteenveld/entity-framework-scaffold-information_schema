﻿// <auto-generated />
using System;
using InformationSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InformationSchema.SqlServer.Migrations
{
    [DbContext(typeof(EntertainmentContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("InformationSchema.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("InformationSchema.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("ProductionId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("InformationSchema.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Release")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Productions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Production");
                });

            modelBuilder.Entity("InformationSchema.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProductionId")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("InformationSchema.Movie", b =>
                {
                    b.HasBaseType("InformationSchema.Production");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<double>("WorldwideBoxOfficeGross")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("InformationSchema.Series", b =>
                {
                    b.HasBaseType("InformationSchema.Production");

                    b.Property<int>("NumberOfEpisodes")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Series");
                });

            modelBuilder.Entity("InformationSchema.Character", b =>
                {
                    b.HasOne("InformationSchema.Actor", "Actor")
                        .WithMany("Characters")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InformationSchema.Production", "Production")
                        .WithMany("Characters")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("InformationSchema.Rating", b =>
                {
                    b.HasOne("InformationSchema.Production", "Production")
                        .WithMany("Ratings")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("InformationSchema.Actor", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("InformationSchema.Production", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
