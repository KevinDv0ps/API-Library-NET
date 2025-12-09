using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class DataContextLibrary: DbContext
    {
        public DataContextLibrary(DbContextOptions<DataContextLibrary> options) : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definición de relaciones

            modelBuilder.Entity<Loan>() // 1 Préstamo -> 1 Libro
                .HasOne(b => b.book)
                .WithOne(l => l.Loan)
                .HasForeignKey<Loan>(f => f.id_book);

            modelBuilder.Entity<Loan>() // N Préstamo -> 1 Usuario
                .HasOne(b => b.user)
                .WithMany(l => l.loans)
                .HasForeignKey(f => f.id_user);

            modelBuilder.Entity<Author>() // N Autor -> N Libro
                .HasMany(l => l.Books)
                .WithMany(f => f.Authors);

            modelBuilder.Entity<Genre>() // N Género -> N Libro
                .HasMany(l => l.Books)
                .WithMany(f => f.Genres);

            base.OnModelCreating(modelBuilder); // Llamada al método base
        }

    }
}
