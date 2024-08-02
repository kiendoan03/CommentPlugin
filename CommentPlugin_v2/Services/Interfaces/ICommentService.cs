using CommentPlugin_v2.DTOs;
using CommentPlugin_v2.Models;

namespace CommentPlugin_v2.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<Comment> GetCommentAsync(int id);
        Task<Comment> AddCommentAsync(CommentDto commentCreateDto);
        Task<Comment> UpdateCommentAsync(int id, CommentDto commentUpdateDto);
        Task DeleteCommentAsync(int id);
        //GetCommentsByObjectIdAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectIdAsync(int objectId);
        //GetCommentsByObjectUrlAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectUrlAsync(string objectUrl);
        //GetCommentsByObjectIdAndObjectUrlAsync
        Task<IEnumerable<Comment>> GetCommentsByObjectIdAndObjectUrlAsync(int objectId, string objectUrl);
    }
}
