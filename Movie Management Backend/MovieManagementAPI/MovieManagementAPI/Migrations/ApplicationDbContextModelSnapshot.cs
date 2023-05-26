﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManagementAPI.Data;

#nullable disable

namespace MovieManagementAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieManagementAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("MovieLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MediaPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieMedia");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieRating");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieReview");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.UserFavourite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("UserFavourite");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.UserMovieLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("UserMovieLog");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieDetails", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithOne("MovieDetails")
                        .HasForeignKey("MovieManagementAPI.Models.MovieDetails", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieMedia", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithMany("Medias")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieRating", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithMany("MovieRatings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.MovieReview", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithMany("MovieReviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.UserFavourite", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithMany("UserFavourites")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.UserMovieLog", b =>
                {
                    b.HasOne("MovieManagementAPI.Models.Movie", "Movie")
                        .WithMany("UserMovieLogs")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MovieManagementAPI.Models.Movie", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("MovieDetails");

                    b.Navigation("MovieRatings");

                    b.Navigation("MovieReviews");

                    b.Navigation("UserFavourites");

                    b.Navigation("UserMovieLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
