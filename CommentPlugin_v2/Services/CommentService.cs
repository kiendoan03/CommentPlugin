using CommentPlugin_v2.DAL;
using CommentPlugin_v2.DTOs;
using CommentPlugin_v2.Models;
using CommentPlugin_v2.Services.Interfaces;
using CommentPlugin_v2.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CommentPlugin_v2.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync()
        {
            //return await _context.Comments.ToListAsync();
            return await _unitOfWork.Comments.GetAllAsync();
        }

        public async Task<Comment> GetCommentAsync(int id)
        {
            //return await _context.Comments.FindAsync(id);
            return await _unitOfWork.Comments.GetByIdAsync(id);
        }

        public async Task<Comment> AddCommentAsync(CommentDto commentCreateDto)
        {
            var comment = new Comment
            {
                SenderFullName = commentCreateDto.SenderFullName,
                SenderEmail = commentCreateDto.SenderEmail,
                SenderPhoneNumber = commentCreateDto.SenderPhoneNumber,
                Content = commentCreateDto.Content,
                ObjectTitle = commentCreateDto.ObjectTitle,
                ObjectUrl = commentCreateDto.ObjectUrl,
                ObjectType = commentCreateDto.ObjectType,
                ObjectId = commentCreateDto.ObjectId,
                Status = 0,
                CreatedDate = DateTime.UtcNow
                //CreatedAt = DateTime.UtcNow.AddHours(7)
            };

            //_context.Comments.Add(comment);
            //await _context.SaveChangesAsync();
            //return comment; 
            await _unitOfWork.Comments.AddAsync(comment);
            return comment;
        }

        public async Task<Comment> UpdateCommentAsync(int id, CommentDto commentUpdateDto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return null;

            comment.Content = commentUpdateDto.Content;
            comment.LastModifiedDate = DateTime.UtcNow;

            //await _context.SaveChangesAsync();
            //return comment;
            await _unitOfWork.Comments.UpdateAsync(id, comment);
            return comment;
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                //_context.Comments.Remove(comment);
                //await _context.SaveChangesAsync();
                await _unitOfWork.Comments.DeleteAsync(id);
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectIdAsync(int objectId)
        {
            //return await _context.Comments.Where(c => c.ObjectId == objectId).ToListAsync();
            return await _unitOfWork.Comments.GetCommentsByObjectIdAsync(objectId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectUrlAsync(string objectUrl)
        {
            //return await _context.Comments.Where(c => c.ObjectUrl == objectUrl).ToListAsync();
            return await _unitOfWork.Comments.GetCommentsByObjectUrlAsync(objectUrl);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectIdAndObjectUrlAsync(int objectId, string objectUrl)
        {
            //return await _context.Comments.Where(c => c.ObjectId == objectId && c.ObjectUrl == objectUrl).ToListAsync();
            return await _unitOfWork.Comments.GetCommentsByObjectIdAndObjectUrlAsync(objectId, objectUrl);
        }
    }
}
