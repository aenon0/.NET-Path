using EfTask.Data;
using EfTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace EfTask.Controllers
{
    [ApiController]
    [Route(template:"api/posts")]
    public class PostsController : ControllerBase
    {
        static private EfDbContext _efDbContext;
        public PostsController(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }
        [HttpGet("GetPosts")]
        public async Task<IActionResult> Get()
        {
            var posts = await _efDbContext.Posts.ToListAsync();
            return Ok(posts);   
        }
        [HttpGet("GetPosts/{postId}")]
        public async Task<IActionResult> Get(int postId)
        {
            var post = await _efDbContext.Posts.FirstOrDefaultAsync(x=>x.Id == postId);
            if (post == null)
            {
                return BadRequest(error: "Invalid post.");
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostContent postContent)
        {
            if (postContent == null)
            {
                return BadRequest(error: "Invalid Request: empty post");
            }
            var newPost = new Post() { Title = postContent.Title, Content = postContent.Content };
            await _efDbContext.Posts.AddAsync(newPost);
            await _efDbContext.SaveChangesAsync();
            return Ok(CreatedAtAction("Get", newPost.Id, value: newPost));
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(int postId, PostContent postContent)
        {
           var existingPost = await _efDbContext.Posts.FirstOrDefaultAsync(x=>x.Id == postId);   

            if (existingPost == null)
            {
                return BadRequest(error: "Invalid Post");
            }
            existingPost.Title = postContent.Title;
            existingPost.Content = postContent.Content;
            _efDbContext.Posts.Update(existingPost);
            await _efDbContext.SaveChangesAsync();
            return NoContent();          
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _efDbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (post == null)
            {
                return BadRequest(error: "Invalid Id");
            }
            _efDbContext.Posts.Remove(post);
            await _efDbContext.SaveChangesAsync();
            return NoContent();
        }
    }

}
