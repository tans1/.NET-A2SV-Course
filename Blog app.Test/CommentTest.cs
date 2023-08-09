using Blog_app_with_EF_Core.data;
using Blog_app_with_EF_Core.model;
using Blog_app_with_EF_Core.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_app.Test
{
    public class CommentTest
    {
        private readonly BlogDbContext _context;

        public CommentTest()
        {
            _context = DataContext.GetDbContext ();
        }


        [Fact]
        public async void GetAllComments()
        {
            // arrange
            var commentRepository = new CommentRepository(_context);
            // act
            var comments = await commentRepository.GetAllComments();
            // assert
            Assert.NotNull(comments);
        }

        [Fact]
        public async void GetCommentsByValidPostId(){
            // arrange
            int postId = 1;
            var commentRepository = new CommentRepository(_context);
            // act
            var comments = await commentRepository.GetCommentsByPostId(postId);
            // assert
            Assert.NotNull(comments);
        }

        [Fact]
        public async void GetCommentsByInvalidPostId(){
            // arrange
            int postId = 100;
            var commentRepository = new CommentRepository(_context);
            // act
            var comments = await commentRepository.GetCommentsByPostId(postId);
            // assert
            Assert.Null(comments);
        }


        [Fact]
        public async void CreateComment()
        {
            // arrange
            var newComment = new Comment()
            {
                Id = 3,
                Text = "Test Comment 3",
                CreatedAt = DateTime.Now,
                PostId = 1
            };

            // act
            var commentRepository = new CommentRepository(_context);
            var result = await commentRepository.CreateComment(newComment);
            // assert
            Assert.NotNull(result);
            // Assert.Equal(newComment, result);
        }


        [Fact]
        public async void UpdateValidComment()
        {
            // arrange
            int id = 1;
            var newComment = new Comment()
            {
                Id = 1,
                Text = "Test UpdateComment 3",
                CreatedAt = DateTime.Now,
                PostId = 1
            };

            // act
            var commentRepository = new CommentRepository(_context);
            var result = await commentRepository.UpdateComment(id, newComment);
            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void UpdateNotExistingComment()
        {
            // arrange
            int id = 100;
            var newComment = new Comment()
            {
                Id = 1,
                Text = "Test UpdateComment 4",
                CreatedAt = DateTime.Now,
                PostId = 1
            };

            // act
            var commentRepository = new CommentRepository(_context);
            var result = await commentRepository.UpdateComment(id, newComment);
            // assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteValidComment()
        {
            // arrange
            int id = 1;
            // act
            var commentRepository = new CommentRepository(_context);
            var result = await commentRepository.DeleteComment(id);
            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void DeleteNotExistingComment()
        {
            // arrange
            int id = 100;
            // act
            var commentRepository = new CommentRepository(_context);
            var result = await commentRepository.DeleteComment(id);
            // assert
            Assert.Null(result);
        }
    }
}
