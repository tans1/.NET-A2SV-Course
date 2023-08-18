using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataContext
{
    public class BlogDataContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity => {
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();

                //entity.HasOne(e => e.Post)
                //      .WithMany(e => e.Comments)
                //      .HasForeignKey(e => e.PostId)
                //      .OnDelete(DeleteBehavior.Cascade)
                //      .HasConstraintName("FK_Comment_Post");
            });

            modelBuilder.Entity<Post>(entity => {
                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();
            });
        }
    }
}
