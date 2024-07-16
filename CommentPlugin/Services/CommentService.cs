using CommentPlugin.DAL;
using CommentPlugin.DTOs;
using CommentPlugin.Models;
using CommentPlugin.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommentPlugin.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> AddCommentAsync(CommentCreateDto commentCreateDto)
        {
            var comment = new Comment
            {
                PostId = commentCreateDto.PostId,
                AuthorName = commentCreateDto.AuthorName,
                AuthorImage = commentCreateDto.AuthorImage,
                Content = commentCreateDto.Content,
                Status = 0,
                CreatedAt = DateTime.UtcNow
                //CreatedAt = DateTime.UtcNow.AddHours(7)
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            comment.Content = commentUpdateDto.Content;
            comment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
