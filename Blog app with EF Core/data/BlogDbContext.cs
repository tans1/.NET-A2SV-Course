using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_app_with_EF_Core.model;
using Microsoft.EntityFrameworkCore;

namespace Blog_app_with_EF_Core.data;

public class BlogDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity => {
                entity.HasOne(e => e.Post)
                    .WithMany(e => e.Comments)
                    .HasForeignKey(e => e.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Post>(entity => {
                entity.HasMany(e => e.Comments)
                    .WithOne(e => e.Post)
                    .HasForeignKey(e => e.PostId);
        });
    }
    


}
