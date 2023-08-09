using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;
using Microsoft.EntityFrameworkCore;

namespace Blog_app.Test
{
    public static class DataContext
    {
        public static BlogDbContext GetDbContext ()
        {
            var options = new DbContextOptionsBuilder<BlogDbContext>()
                            .UseInMemoryDatabase(databaseName: "blog_test_db")
                            .Options;
            var dbContext = new BlogDbContext(options);
            dbContext.Database.EnsureCreated();

            // add post to context
            dbContext.Posts.Add(new Post
            {
                Id = 1,
                Title = "Test Post",
                Content = "Test Content",
                CreatedAt = DateTime.Now
            });

            dbContext.Comments.Add(new Comment
            {
                Id = 1,
                Text = "Test Comment 1",
                CreatedAt = DateTime.Now,
                PostId = 1
            });

            dbContext.Comments.Add(new Comment
            {
                Id = 2,
                Text = "Test Comment 2",
                CreatedAt = DateTime.Now,
                PostId = 1
            });


            dbContext.SaveChanges();

            return dbContext;
        }


        // public static BlogDbContext CommentDatabaseContext()
        // {
        //     var options = new DbContextOptionsBuilder<BlogDbContext>()
        //                     .UseInMemoryDatabase(databaseName: "blog_test_db")
        //                     .Options;
        //     var dbContext = new BlogDbContext(options);
        //     dbContext.Database.EnsureCreated();

        //     // add post to context
        //     dbContext.Comment.Add(new Comment
        //     {
        //         Id = 1,
        //         Text = "Test Comment",
        //         CreatedAt = DateTime.Now,
        //         PostId = 1
        //     });
        //     dbContext.SaveChanges();

        //     return dbContext;
        // }
    }
}