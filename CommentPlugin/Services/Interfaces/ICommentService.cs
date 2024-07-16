using CommentPlugin.DTOs;
using CommentPlugin.Models;

namespace CommentPlugin.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(int postId);
        Task<Comment> GetCommentAsync(int id);
        Task<Comment> AddCommentAsync(CommentCreateDto commentCreateDto);
        Task<Comment> UpdateCommentAsync(int id, CommentUpdateDto commentUpdateDto);
        Task DeleteCommentAsync(int id);
    }
}
