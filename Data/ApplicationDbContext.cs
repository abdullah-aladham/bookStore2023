using BookStore2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            
        {

        }
        
            public DbSet<AdminViewModel> BookStoreAdmins { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> BookStoreAuthors { get; set; }
        public DbSet<UserModel> BookStoreUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseMySQL("server=localhost;database=bookstore;username=root;password=HelloWorld-1516!");
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    ModelBuilder.Entity<BookModel>(e => e.Property(o => o.Title).HasColumnType("Varchar(80)"));
        //}
    }
    }


