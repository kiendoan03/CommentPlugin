using CommentPlugin_v2.Models;

namespace CommentPlugin_v2.Repositoties.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        //GetCommentsByObjectIdAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectIdAsync(int objectId);
        //GetCommentsByObjectUrlAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectUrlAsync(string objectUrl);
        //GetCommentsByObjectIdAndObjectUrlAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectIdAndObjectUrlAsync(int objectId, string objectUrl);
    }
}
