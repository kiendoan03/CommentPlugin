using CommentPlugin_v2.DAL;
using CommentPlugin_v2.Models;
using CommentPlugin_v2.Repositoties;
using CommentPlugin_v2.Repositoties.Interfaces;

namespace CommentPlugin_v2.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public ICommentRepository Comments { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Comments = new CommentRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
