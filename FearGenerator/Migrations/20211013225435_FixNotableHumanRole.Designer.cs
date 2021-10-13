﻿// <auto-generated />
using System;
using FearGenerator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FearGenerator.Migrations
{
    [DbContext(typeof(FearGeneratorContext))]
    [Migration("20211013225435_FixNotableHumanRole")]
    partial class FixNotableHumanRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FearGenerator.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("FearGenerator.Models.MoviesSubgenres", b =>
                {
                    b.Property<int>("MoviesSubgenresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("SubgenreId")
                        .HasColumnType("int");

                    b.HasKey("MoviesSubgenresId");

                    b.HasIndex("MovieId");

                    b.HasIndex("SubgenreId");

                    b.ToTable("MoviesSubgenres");
                });

            modelBuilder.Entity("FearGenerator.Models.NotableHuman", b =>
                {
                    b.Property<int>("NotableHumanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("HumanName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Role")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("NotableHumanId");

                    b.ToTable("NotableHuman");
                });

            modelBuilder.Entity("FearGenerator.Models.NotableHumansMovies", b =>
                {
                    b.Property<int>("NotableHumansMoviesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("NotableHumanId")
                        .HasColumnType("int");

                    b.Property<int>("NotableHumansId")
                        .HasColumnType("int");

                    b.HasKey("NotableHumansMoviesId");

                    b.HasIndex("MovieId");

                    b.HasIndex("NotableHumanId");

                    b.ToTable("NotableHumansMovies");
                });

            modelBuilder.Entity("FearGenerator.Models.Subgenre", b =>
                {
                    b.Property<int>("SubgenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("SubgenreId");

                    b.ToTable("Subgenres");
                });

            modelBuilder.Entity("FearGenerator.Models.MoviesSubgenres", b =>
                {
                    b.HasOne("FearGenerator.Models.Movie", "Movie")
                        .WithMany("JoinEntities")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FearGenerator.Models.Subgenre", "Subgenre")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SubgenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Subgenre");
                });

            modelBuilder.Entity("FearGenerator.Models.NotableHumansMovies", b =>
                {
                    b.HasOne("FearGenerator.Models.Movie", "Movie")
                        .WithMany("HumansJoinEntities")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FearGenerator.Models.NotableHuman", "NotableHuman")
                        .WithMany("HumansJoinEntities")
                        .HasForeignKey("NotableHumanId");

                    b.Navigation("Movie");

                    b.Navigation("NotableHuman");
                });

            modelBuilder.Entity("FearGenerator.Models.Movie", b =>
                {
                    b.Navigation("HumansJoinEntities");

                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("FearGenerator.Models.NotableHuman", b =>
                {
                    b.Navigation("HumansJoinEntities");
                });

            modelBuilder.Entity("FearGenerator.Models.Subgenre", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}