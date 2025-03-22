using Microsoft.EntityFrameworkCore;
using BookStoreDB.Entities;
namespace BookStoreDB
{
    public class BookStore : DbContext
    {
        public BookStore()
        {
            
        }

        public DbSet<Account> accounts { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Author> authors { get; set; }

        public DbSet<Genre> genres { get; set; }

        public DbSet<Discounts>discounts { get; set; }

        public DbSet<Promotion> promotions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer(@"
                                         Data Source = FRASP\SQLEXPRESS;
                                         Initial Catalog = BookStoreDb;
                                         Integrated Security = True;
                                         Connect Timeout = 2;
                                         Encrypt = False;
                                         Trust Server Certificate = False;
                                         Application Intent = ReadWrite;
                                         Multi Subnet Failover = False
                                        ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // one to many
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books);






            // decimal price
            modelBuilder.Entity<Book>()
              .Property(b => b.CostPrice)
              .HasColumnType("decimal(18,2)"); 

            // decimal price
            modelBuilder.Entity<Book>()
                .Property(b => b.SellPrice)
                .HasColumnType("decimal(18,2)");


            // decimal price
            modelBuilder.Entity<Promotion>()
                .Property(p => p.DiscountPercentage)
                .HasColumnType("decimal(2,0)");


            // decimal price
            modelBuilder.Entity<Discounts>()
                .Property(d => d.Discount)
                .HasColumnType("decimal(2,0)");


           






            modelBuilder.seedAccounts();
            modelBuilder.seedBooksAndAuthors();
            modelBuilder.seedGenres();
        }
    }
}
