using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LAB5_MSSQL
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<CategorieProdus> CategoriiProduse => Set<CategorieProdus>();
        public DbSet<IstoricVanzari> IstoricVanzari => Set<IstoricVanzari>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            var connectionString = Environment.GetEnvironmentVariable("LAB5_MSSQL_CONNECTION_STRING")
                ?? ConfigurationManager.ConnectionStrings["MagazinDB"]?.ConnectionString
                ?? throw new InvalidOperationException("The MagazinDB SQL Server connection string is missing.");

            optionsBuilder.UseSqlServer(connectionString, sql => sql.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategorieProdus>()
                .Property(c => c.Denumire)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<CategorieProdus>()
                .HasIndex(c => c.Denumire)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.Quantity)
                .IsConcurrencyToken();

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Categorie)
                .WithMany()
                .HasForeignKey(p => p.IdCategorie)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IstoricVanzari>()
                .HasOne(s => s.Produs)
                .WithMany()
                .HasForeignKey(s => s.IdProdus)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

