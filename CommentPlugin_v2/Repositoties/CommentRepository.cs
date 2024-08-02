using CommentPlugin_v2.DAL;
using CommentPlugin_v2.Models;
using CommentPlugin_v2.Repositoties.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommentPlugin_v2.Repositoties
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectIdAndObjectUrlAsync(int objectId, string objectUrl)
        {
            return await _context.Comments.Where(c => c.ObjectId == objectId && c.ObjectUrl == objectUrl).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectIdAsync(int objectId)
        {
            return await _context.Comments.Where(c => c.ObjectId == objectId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByObjectUrlAsync(string objectUrl)
        {
            return await _context.Comments.Where(c => c.ObjectUrl == objectUrl).ToListAsync();
        }
    }
}
