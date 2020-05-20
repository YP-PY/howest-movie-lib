using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace howest_movie_lib.Library.Models
{
    public partial class db_moviesContext : DbContext
    {
        public db_moviesContext()
        {
        }

        public db_moviesContext(DbContextOptions<db_moviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<GenreMovie> GenreMovie { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<MovieRole> MovieRole { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<ShopCustomer> ShopCustomer { get; set; }
        public virtual DbSet<ShopMoviePrice> ShopMoviePrice { get; set; }
        public virtual DbSet<ShopOrder> ShopOrder { get; set; }
        public virtual DbSet<ShopOrderDetail> ShopOrderDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-J2LMT8CC\\SQLEXPRESS;Initial Catalog=db_movies;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<GenreMovie>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.GenreId })
                    .HasName("PK_genre_movie_raw");

                entity.ToTable("genre_movie");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.ToTable("genres");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImdbName)
                    .HasColumnName("imdb_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MovieRole>(entity =>
            {
                entity.HasKey(e => new { e.MovieId, e.PersonId, e.Role });

                entity.ToTable("movie_role");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.ToTable("movies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CoverUrl)
                    .IsRequired()
                    .HasColumnName("cover_url")
                    .HasMaxLength(500);

                entity.Property(e => e.ImdbId)
                    .IsRequired()
                    .HasColumnName("imdb_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Kind)
                    .IsRequired()
                    .HasColumnName("kind")
                    .HasMaxLength(50);

                entity.Property(e => e.OriginalAirDate)
                    .IsRequired()
                    .HasColumnName("original_air_date")
                    .HasMaxLength(50);

                entity.Property(e => e.Plot)
                    .HasColumnName("plot")
                    .HasColumnType("text");

                entity.Property(e => e.Rating)
                    .HasColumnName("rating")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(100);

                entity.Property(e => e.Top250Rank).HasColumnName("top_250_rank");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.ToTable("persons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Biography)
                    .IsRequired()
                    .HasColumnName("biography");

                entity.Property(e => e.ImdbId)
                    .IsRequired()
                    .HasColumnName("imdb_id")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ShopCustomer>(entity =>
            {
                entity.ToTable("shop_customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(450)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopMoviePrice>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.ToTable("shop_movie_price");

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<ShopOrder>(entity =>
            {
                entity.ToTable("shop_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShopOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.MovieId });

                entity.ToTable("shop_order_detail");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unit_price")
                    .HasColumnType("decimal(8, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
