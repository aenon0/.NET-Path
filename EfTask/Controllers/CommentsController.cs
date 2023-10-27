using Microsoft.AspNetCore.Mvc;
using EfTask.Data;
using Microsoft.EntityFrameworkCore;
using EfTask.Models;
namespace EfTask.Controllers
{
    [ApiController]
    [Route(template:"api/comments")]
    public class CommentsController : ControllerBase
    {
        static private EfDbContext _efDbContext;
        public CommentsController(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }
       
        [HttpGet("getcomments")]
        public async Task<IActionResult> Get()
        {
            var comments = await _efDbContext.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpGet("getcomments/{commentId}")]
        public async Task<IActionResult> Get(int commentId)
        {
            var comment = await _efDbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (comment == null)
            {
               return BadRequest(error: "Invalid post");
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommentContent commentContent)
        {
            var post = await _efDbContext.Posts.FirstOrDefaultAsync(x=>x.Id == commentContent.PostId);
            if (commentContent == null || post == null)
            {
                return BadRequest(error: "Invalid post/comment");
            }
            var newComment = new Comment() { PostId = commentContent.PostId, Text = commentContent.Text };
            //newComment.Post = post;
            //_efDbContext.Comments.Add(newComment);

            post.Comments.Add(newComment);
            _efDbContext.Posts.Update(post);
            await _efDbContext.SaveChangesAsync();
            return CreatedAtAction("Get", newComment.Id, value: newComment);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int commentId, string newText)
        {
            var editedComment = await _efDbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (newText == null ||  editedComment == null)
            {
                return BadRequest(error: "Invalid post/comment");
            }
            editedComment.Text = newText;
            _efDbContext.Comments.Update(editedComment);
            await _efDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int commentId)
        {
            var editedComment = await _efDbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId);
            if (editedComment == null)
            {
                return BadRequest(error: "Invalid post/comment");
            }

            _efDbContext.Comments.Remove(editedComment);
            await _efDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
