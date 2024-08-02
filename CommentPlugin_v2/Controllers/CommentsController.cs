using CommentPlugin_v2.CommonHelper.Captcha;
using CommentPlugin_v2.DTOs;
using CommentPlugin_v2.Services.Interfaces;
using CommonHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommentPlugin_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _commentService.GetCommentsAsync();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetCommentAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpGet("get-comments-by-objectId")]
        public async Task<IActionResult> GetCommentsByObjectId(int objectId)
        {
            var comments = await _commentService.GetCommentsByObjectIdAsync(objectId);
            return Ok(comments);
        }

        [HttpGet("get-comments-by-objectUrl")]
        public async Task<IActionResult> GetCommentsByObjectUrl(string objectUrl)
        {
            var comments = await _commentService.GetCommentsByObjectUrlAsync(objectUrl);
            return Ok(comments);
        }

        [HttpGet("get-comments-by-objectId-and-objectUrl")]
        public async Task<IActionResult> GetCommentsByObjectIdAndObjectUrl(int objectId, string objectUrl)
        {
            var comments = await _commentService.GetCommentsByObjectIdAndObjectUrlAsync(objectId, objectUrl);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentDto commentCreateDto)
        {
            if(commentCreateDto.captcha != null && commentCreateDto.md5Captcha != null)
            {
                if (Crypton.Md5Encrypt(Crypton.Encrypt(commentCreateDto.captcha.ToLower())) != commentCreateDto.md5Captcha)
                {
                    return Ok(Response<object>.CreateErrorResponse(400, "Mã xác nhận không đúng"));
                }
            }
            var comment = await _commentService.AddCommentAsync(commentCreateDto);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("get-captcha")]
        public Response<object> GetCaptcha()
        {

            try
            {
                var tup = Captcha.GetCaptcha();
                return Response<object>.CreateSuccessResponse(new
                {
                    Content = tup.Item1,
                    Captcha = tup.Item2,
                });
            }
            catch (Exception ex)
            {
                return Response<object>.CreateErrorResponse(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentDto commentUpdateDto)
        {
            var comment = await _commentService.UpdateCommentAsync(id, commentUpdateDto);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }

}
