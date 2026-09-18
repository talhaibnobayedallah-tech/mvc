using Microsoft.EntityFrameworkCore;
using Task1.Models.DAL.Entities;
namespace Task1.Models.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
		optionsBuilder.UseSqlServer( "Server=localhost,1433;Database=items;User Id=sa;Password=Akev7994@;TrustServerCertificate=True;Encrypt=True;");
        }
        public DbSet<Vegetable> Vegetables { get; set; } = null!;
	public DbSet<Customer> Customers {get; set;} = null!; 
    }
}
