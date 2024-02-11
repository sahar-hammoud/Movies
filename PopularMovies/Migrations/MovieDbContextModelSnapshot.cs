﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieApp.Backend.DataAccess;

#nullable disable

namespace MovieApp.Backend.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorDetails", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthorDetails");
                });

            modelBuilder.Entity("GenreMovieDetails", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovieDetails");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Character")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Adult")
                        .HasColumnType("bit");

                    b.Property<string>("BackdropPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Popularity")
                        .HasColumnType("float");

                    b.Property<string>("PosterPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Video")
                        .HasColumnType("bit");

                    b.Property<double>("VoteAverage")
                        .HasColumnType("float");

                    b.Property<int>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Movie");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.OfflineMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MovideID")
                        .HasColumnType("int");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfflineMovies");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorDetailsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorDetailsId");

                    b.HasIndex("MovieId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Similar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Adult")
                        .HasColumnType("bit");

                    b.Property<string>("BackdropPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("OriginalLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Popularity")
                        .HasColumnType("float");

                    b.Property<string>("PosterPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Video")
                        .HasColumnType("bit");

                    b.Property<double?>("VoteAverage")
                        .HasColumnType("float");

                    b.Property<int?>("VoteCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Similars");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Video", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.MovieDetails", b =>
                {
                    b.HasBaseType("MoviesApp.Backend.Models.Movie");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("Homepage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImdbId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Revenue")
                        .HasColumnType("int");

                    b.Property<int>("Runtime")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tagline")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("MovieId")
                        .IsUnique()
                        .HasFilter("[MovieId] IS NOT NULL");

                    b.HasDiscriminator().HasValue("MovieDetails");
                });

            modelBuilder.Entity("GenreMovieDetails", b =>
                {
                    b.HasOne("MoviesApp.Backend.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoviesApp.Backend.Models.MovieDetails", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Actor", b =>
                {
                    b.HasOne("MoviesApp.Backend.Models.Movie", "Movie")
                        .WithMany("Cast")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Review", b =>
                {
                    b.HasOne("AuthorDetails", "AuthorDetails")
                        .WithMany()
                        .HasForeignKey("AuthorDetailsId");

                    b.HasOne("MoviesApp.Backend.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorDetails");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Similar", b =>
                {
                    b.HasOne("MoviesApp.Backend.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Video", b =>
                {
                    b.HasOne("MoviesApp.Backend.Models.Movie", "Movie")
                        .WithMany("Videos")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.MovieDetails", b =>
                {
                    b.HasOne("MoviesApp.Backend.Models.Movie", "Movie")
                        .WithOne("MovieDetails")
                        .HasForeignKey("MoviesApp.Backend.Models.MovieDetails", "MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MoviesApp.Backend.Models.Movie", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("MovieDetails");

                    b.Navigation("Reviews");

                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
