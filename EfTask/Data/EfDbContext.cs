using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EfTask.Models;

namespace EfTask.Data
{
    public class EfDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
                    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Comment>(entity =>
            {
                entity.HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.PostId)
                .HasConstraintName("FK_Post_Id");
            });

            modelBuilder.Entity<Post>().Property(p => p.CreatedAt)
                .HasDefaultValueSql("now()");
            modelBuilder.Entity<Comment>().Property(p => p.CreatedAt)
                .HasDefaultValueSql("now()");


        }

        

    }
}
