using Microsoft.EntityFrameworkCore;
using FormulaOne.Models;
namespace FormulaOne.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

    }
}
