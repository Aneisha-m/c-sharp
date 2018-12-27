using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace Entity_08_Northwind_Category_Product_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
        }
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have");
                var categories = db.Categories.Include(c => c.Products);
                foreach (var c in categories)
                {
                    WriteLine($"\n\n{c.CategoryName} has ID {c.CategoryID} and description {c.Description}.  It has {c.Products.Count} products\n");
                    WriteLine($"{"Product",-40}{"ID",-20}{"Cost",-20}{"Stock",-20}");
                    WriteLine($"{"-------",-40}{"--",-20}{"----",-20}{"-----",-20}");
                    foreach (Product p in c.Products)
                    {
                        WriteLine($"{p.ProductName,-40}{p.ProductID,-20}{p.Cost,-20}{p.Stock,-20}");
                    }
                }

                WriteLine("\n\n\nAlso list products\n");
                decimal price = 40.0M;

                var products = db.Products;

                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20}");
                }

                var products2 = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);

                WriteLine("\n\n\nProducts in order greater than a set price\n");
                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products2)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20}");
                }
            }
        }


    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            // use SQLite
            //optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}

