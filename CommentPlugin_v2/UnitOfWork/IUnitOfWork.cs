using CommentPlugin_v2.Models;
using CommentPlugin_v2.Repositoties.Interfaces;

namespace CommentPlugin_v2.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICommentRepository Comments { get; }
        Task Save();

    }
}
